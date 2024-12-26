using Domain.Dtos;
using Domain.Models;
using Domain.Responces;
using Infastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("/api/[controller]")]
public class AuthorsController(IAuthorsService authorsService):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Authors>>> GetAll()
    {
        return await authorsService.GetAll();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Authors>> GetById(int id)
    {
        return await authorsService.GetById(id);
    }

    [HttpPost]
    public async Task<Response<bool>> Add(Authors book)
    {
        return await authorsService.Add(book);
    }

    [HttpPut]
    public async Task<Response<bool>> Update(Authors book)
    {
        return await authorsService.Update(book);
    }

    [HttpDelete]
    async Task<Response<bool>> Delete(int id)
    {
        return await authorsService.Delete(id);
    }

}