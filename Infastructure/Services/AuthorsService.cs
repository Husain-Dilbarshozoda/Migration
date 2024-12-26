using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responces;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Services;

public class AuthorsService(IDataContaxt contaxt):IAuthorsService
{
    public async Task<Response<List<Authors>>> GetAll()
    {
        using var connection = contaxt.Connection();
        var sql = "select * from Authors";
        var res = (await connection.QueryAsync<Authors>(sql)).ToList();
        return new Response<List<Authors>>(res);
    }

    public async Task<Response<Authors>> GetById(int id)
    {
        using var connection = contaxt.Connection();
        var sql = "select * from Authors where Id = @ID";
        var res = await connection.QueryFirstOrDefaultAsync<Authors>(sql,new{ID=id});
        return new Response<Authors>(res);
    }

    public async Task<Response<bool>> Add(Authors author)
    {
        using var connection = contaxt.Connection();
        var sql = "insert into Authors(Name,Country) values(@Name,@Country)";
        var res = await connection.ExecuteAsync(sql, author);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, "Server error!!!");
        }

        return new Response<bool>(true);
    }

    public async Task<Response<bool>> Update(Authors author)
    {
        using var connection = contaxt.Connection();
        var sql = "update Authors set Name=@Name,Country=@Country where Id=@Id";
        var res = await connection.ExecuteAsync(sql, author);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, "Server error!!!");
        }

        return new Response<bool>(true);
    }

    public async Task<Response<bool>> Delete(int id)
    {
        using var connection = contaxt.Connection();
        var sql = "delete from Authors where Id=@ID";
        var res = await connection.ExecuteAsync(sql, new { ID = id });
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, "Server error!!!");
        }

        return new Response<bool>(true);
    }
}