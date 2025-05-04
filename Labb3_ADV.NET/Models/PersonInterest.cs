namespace Labb3_ADV.NET.Models
{
    public class PersonInterest
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }

        public ICollection<Link> Links { get; set; } = new List<Link>();
    }
}
