using System.Collections.Generic;

namespace Application.Dtos.Person.Responses
{
    public class GetAllPersonsDtoResponse
    {   
        public List<PersonForGetAllPersonsDtoResponse> Persons { get; set; }
    }

    public class PersonForGetAllPersonsDtoResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
