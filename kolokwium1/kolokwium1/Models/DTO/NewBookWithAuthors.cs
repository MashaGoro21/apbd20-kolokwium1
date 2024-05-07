namespace kolokwium1.Models.DTO;

public class NewBookWithAuthors
{
    public string Title { get; set; } = string.Empty;
    public IEnumerable<Author> Authors { get; set; } = new List<Author>();
}
