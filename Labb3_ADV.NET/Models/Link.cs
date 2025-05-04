namespace Labb3_ADV.NET.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int PersonId { get; set; }
        public int InterestId { get; set; }

        public PersonInterest PersonInterest { get; set; }
    }
}
