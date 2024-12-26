using Domain.Dtos;
using Domain.Models;
using Domain.Responces;

namespace Infastructure.Interfaces;

public interface IBookService
{
    Task<Response<List<Books>>> GetAll();
    Task<Response<Books>> GetById(int id);
    Task<Response<bool>> Add(Books book);
    Task<Response<bool>> Update(Books book);
    Task<Response<bool>> Delete(int id);
    Task<Response<List<GetBooksWithAuthorDto>>> GetBooksWithAuthors();
}