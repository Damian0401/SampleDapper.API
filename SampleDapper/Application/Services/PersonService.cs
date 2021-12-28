using Application.Dtos.Person.Requests;
using Application.Dtos.Person.Responses;
using Application.Interfaces;
using Application.Services.Utilities;
using Domain.Models;
using Persistance.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonService : Service, IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _personRepository = serviceProvider.GetService<IPersonRepository>();
        }

        public async Task<ServiceResponse<CreatePersonDtoResponse>> CreateAsync(CreatePersonDtoRequest dto)
        {
            try
            {
                var personToAdd = Mapper.Map<Person>(dto);

                var id = await _personRepository.AddAsync(personToAdd);

                var responseDto = Mapper.Map<CreatePersonDtoResponse>(personToAdd);

                responseDto.Id = id;

                return new ServiceResponse<CreatePersonDtoResponse>(HttpStatusCode.OK, responseDto);
            }
            catch (Exception e)
            {
                // DOTO logger implementation
                return new ServiceResponse<CreatePersonDtoResponse>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<ServiceResponse> DeleteByIdAsync(int id)
        {
            try
            {
                var isDeleted = await _personRepository.DeleteAsync(id);

                if (isDeleted)
                    return new ServiceResponse(HttpStatusCode.OK);

                return new ServiceResponse(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                // DOTO logger implementation
                return new ServiceResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<UpdatePersonByIdDtoResponse>> UpdateByIdAsync(int id, UpdatePersonByIdDtoRequest dto)
        {
            try
            {
                var personToUpdate = Mapper.Map<Person>(dto);

                var isUpdated = await _personRepository.UpdateByIdAsync(id, personToUpdate);

                var updatedPerson = Mapper.Map<UpdatePersonByIdDtoResponse>(personToUpdate);
                updatedPerson.Id = id;

                if (isUpdated)
                    return new ServiceResponse<UpdatePersonByIdDtoResponse>(HttpStatusCode.OK, updatedPerson);

                return new ServiceResponse<UpdatePersonByIdDtoResponse>(HttpStatusCode.NotFound);
            }
            catch (Exception e)
            {
                // DOTO logger implementation
                return new ServiceResponse<UpdatePersonByIdDtoResponse>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<ServiceResponse<GetAllPersonsDtoResponse>> GetAllAsync()
        {
            try
            {
                var persons = await _personRepository.GetAllAsync();

                var responseDto = new GetAllPersonsDtoResponse
                {
                    Persons = Mapper.Map<List<PersonForGetAllPersonsDtoResponse>>(persons)
                };

                return new ServiceResponse<GetAllPersonsDtoResponse>(HttpStatusCode.OK, responseDto);
            }
            catch (Exception e)
            {
                // DOTO logger implementation
                return new ServiceResponse<GetAllPersonsDtoResponse>(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        public async Task<ServiceResponse<GetPersonByIdDtoResponse>> GetByIdAsync(int id)
        {
            try
            {
                var person = await _personRepository.GetByIdAsync(id);

                if (person is null)
                    return new ServiceResponse<GetPersonByIdDtoResponse>(HttpStatusCode.NotFound);

                var responseDto = Mapper.Map<GetPersonByIdDtoResponse>(person);

                return new ServiceResponse<GetPersonByIdDtoResponse>(HttpStatusCode.OK, responseDto);
            }
            catch (Exception e)
            {
                // DOTO logger implementation
                return new ServiceResponse<GetPersonByIdDtoResponse>(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
