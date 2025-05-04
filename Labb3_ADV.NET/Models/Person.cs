namespace Labb3_ADV.NET.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();
    }
}
