using Application.Dtos.Person.Requests;
using Application.Dtos.Person.Responses;
using AutoMapper;
using Domain.Models;

namespace Application.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            MapsForPerson();
        }

        private void MapsForPerson()
        {
            CreateMap<Person, PersonForGetAllPersonsDtoResponse>();
            CreateMap<Person, GetPersonByIdDtoResponse>();
            CreateMap<CreatePersonDtoRequest, Person>();
            CreateMap<Person, CreatePersonDtoResponse>();
            CreateMap<UpdatePersonByIdDtoRequest, Person>();
            CreateMap<Person, UpdatePersonByIdDtoResponse>();
        }
    }
}
