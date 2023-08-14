using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UpdateFirstAndLastNameDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
