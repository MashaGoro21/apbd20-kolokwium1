using kolokwium1.Models.DTO;

namespace kolokwium1.Repositories;

public interface IBookRepository
{ 
    Task<bool> DoesBookExist(int id);
    Task<BookWithAuthor> GetBook(int id);
    Task AddNewBookWithAuthors(NewBookWithAuthors newBookWithAuthors);
}