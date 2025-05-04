namespace Labb3_ADV.NET.Models.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<InterestDto> Interests { get; set; }
    }
}
