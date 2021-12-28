using Application.Dtos.Person.Requests;
using Application.Dtos.Person.Responses;
using Application.Services.Utilities;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        Task<ServiceResponse<GetAllPersonsDtoResponse>> GetAllAsync();
        Task<ServiceResponse<GetPersonByIdDtoResponse>> GetByIdAsync(int id);
        Task<ServiceResponse<CreatePersonDtoResponse>> CreateAsync(CreatePersonDtoRequest dto);
        Task<ServiceResponse<UpdatePersonByIdDtoResponse>> UpdateByIdAsync(int id, UpdatePersonByIdDtoRequest dto);
        Task<ServiceResponse> DeleteByIdAsync(int id);
    }
}
