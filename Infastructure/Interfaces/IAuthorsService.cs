using Domain.Models;
using Domain.Responces;

namespace Infastructure.Interfaces;

public interface IAuthorsService
{
    Task<Response<List<Authors>>> GetAll();
    Task<Response<Authors>> GetById(int id);
    Task<Response<bool>> Add(Authors author);
    Task<Response<bool>> Update(Authors author);
    Task<Response<bool>> Delete(int id);
}