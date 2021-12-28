using System;

namespace Application.Dtos.Person.Responses
{
    public class GetPersonByIdDtoResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string Email { get; set; }
    }
}
