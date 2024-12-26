using Domain.Dtos;
using Domain.Models;
using Domain.Responces;
using Infastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("/api/[controller]")]
public class BooksController(IBookService bookService):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Books>>> GetAll()
    {
        return await bookService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Books>> GetById(int id)
    {
        return await bookService.GetById(id);
    }

    [HttpPost]
    public async Task<Response<bool>> Add(Books book)
    {
        return await bookService.Add(book);
    }

    [HttpPut]
    public async Task<Response<bool>> Update(Books book)
    {
        return await bookService.Update(book);
    }

    [HttpDelete]
    async Task<Response<bool>> Delete(int id)
    {
        return await bookService.Delete(id);
    }

    [HttpGet("/BooksWithAuthors")]
    public async Task<Response<List<GetBooksWithAuthorDto>>> GetBooksWithAuthors()
    {
        return await bookService.GetBooksWithAuthors();
    }
    
}