
namespace Library.Domain.Entities
{
    public class Image
    {
        public Guid? Id { get; set; }
        public string? Url { get; set; }


        // Navigation Property
        public ICollection<Member> Members { get; set; } = new List<Member>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
