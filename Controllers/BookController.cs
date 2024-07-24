using LibraryAPI.Communication.Requests;
using LibraryAPI.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;
[ApiController]
public class BookController : LibraryAPIBaseController
{
    [HttpPost]
    [Route("CreateBook")]
    [ProducesResponseType(typeof(ResponseCreateBookJson), StatusCodes.Status201Created)]
    public IActionResult CreateBook([FromBody] RequestRegisterBookJson request)
    {
        var response = new ResponseCreateBookJson()
        {
            Id = request.Id,
            Title = request.Title,
        };
        return Created(string.Empty, response);
    }

    [HttpGet]
    [Route("GetAllBooks")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
    public IActionResult GetAllBooks()
    {
        List<Book> response = new List<Book>
        {
            new Book{ Id= 1, Author = "1", Genre = "1", Price = 1, Stock = 5, Title = "teste123"},
            new Book{ Id= 2, Author = "1", Genre = "2", Price = 6, Stock = 25, Title = "1234"},
            new Book{ Id= 3, Author = "1", Genre = "3", Price = 7.8f, Stock = 30, Title = "5678"}
        };

        if (response.Count == 0)
        {
            return NoContent();
        }
        return Ok(response);
    }

    [HttpPut]
    [Route("ChangeBook/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ChangeBook([FromRoute] int id, [FromBody] RequestUpdateBookJson request)
    {
        return NoContent();
    }

    [HttpDelete]
    [Route("DeleteBook/{id}")]
    public IActionResult DeleteBook([FromRoute] int id)
    {
        return Ok();
    }

}
