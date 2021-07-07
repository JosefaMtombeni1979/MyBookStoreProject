using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Service
{
    public interface IBookService
    {
        Task<Book> GetBookbyId(int id);
        Task<List<Book>> GetBooks();
    }
}