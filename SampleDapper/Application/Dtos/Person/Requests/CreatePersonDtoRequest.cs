using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Person.Requests
{
    public class CreatePersonDtoRequest
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime? DayOfBirth { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
