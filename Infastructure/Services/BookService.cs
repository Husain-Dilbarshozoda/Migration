using System.Net;
using Dapper;
using Domain.Dtos;
using Domain.Models;
using Domain.Responces;
using Infastructure.Data;
using Infastructure.Interfaces;

namespace Infastructure.Services;

public class BookService(IDataContaxt contaxt):IBookService
{
    public async Task<Response<List<Books>>> GetAll()
    {
        var sql = "select * from books";
        var res = (await contaxt.Connection().QueryAsync<Books>(sql)).ToList();
        return new Response<List<Books>>(res);
    }

    public async Task<Response<Books>> GetById(int id)
    {
        var sql = "select * from books where id=@ID";
        var res = await contaxt.Connection().QueryFirstOrDefaultAsync<Books>(sql, new { ID = id });
        return new Response<Books>(res);
    }

    public async Task<Response<bool>> Add(Books book)
    {
        var sql = "insert into books(Title,PublishedYear,Genre,IsAvailable,AuthorId) values(@Title,@PublishedYear,@Genre,@IsAvailable,@AuthorId)";
        var res =await contaxt.Connection().ExecuteAsync(sql, book);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, "Server error!!!");
        }

        return new Response<bool>(true);
    }

    public async Task<Response<bool>> Update(Books book)
    {
        var sql = "update books set Title=@Title,PublishedYear=@PublishedYear,Genre=@Genre,IsAvailable=@IsAvailable,AuthorId=@AuthorId where Id=@Id;";
        var res = await contaxt.Connection().ExecuteAsync(sql, book);
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, "Server error!!!");
        }

        return new Response<bool>(true);
    }

    public async Task<Response<bool>> Delete(int id)
    {
        var sql = "delete from books where Id=@ID";
        var res = await contaxt.Connection().ExecuteAsync(sql, new { ID = id });
        if (res == 0)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, "Server error!!!");
        }

        return new Response<bool>(true);
    }

    public async Task<Response<List<GetBooksWithAuthorDto>>> GetBooksWithAuthors()
    {
        var sql = @"select bk.id,bk.title,at.name,bk.publishedYear,bk.genre,bk.isAvailable from books as bk
                    join authors as at on at.id=bk.AuthorId";
        var res = (await contaxt.Connection().QueryAsync<GetBooksWithAuthorDto>(sql)).ToList();
        return new Response<List<GetBooksWithAuthorDto>>(res);
    }
}