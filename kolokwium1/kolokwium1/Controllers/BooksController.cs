using kolokwium1.Models.DTO;
using kolokwium1.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace kolokwium1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    public BooksController(IBookRepository bookRepository)
    { 
        _bookRepository = bookRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        if (!await _bookRepository.DoesBookExist(id))
            return NotFound($"Book with given ID - {id} doesn't exist");

        var book = await _bookRepository.GetBook(id);

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(NewBookWithAuthors newBookWithAuthors)
    {
        await _bookRepository.AddNewBookWithAuthors(newBookWithAuthors);

        return Created(Request.Path.Value ?? "api/books", newBookWithAuthors);
    }
}
