using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Authentication;
using WebApi.Models;

namespace WebApi.Service
{
    public class BookSubscriptionService : IBookSubscriptionService
    {
        private readonly ApplicationDbContext _context;
        public BookSubscriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookSubscription>> GetAllBookSubscriptions()
        {
            return await _context.BookSubscription.ToListAsync();
        }

        public async Task<List<BookSubscriptions>> GetAllBookSubscriptionsByUserId(string userId)
        {

            return await _context.Book
                .Join(
                    _context.BookSubscription,
                    book => book.Id,
                    booksubscription => booksubscription.Id,
                    (book, booksubscription) => new BookSubscriptions
                    {
                        Id = booksubscription.Id,
                        UserId = Convert.ToString(booksubscription.UserId),
                        Name = book.Name,
                        Price = book.Price
                    }
                ).Where(b => b.UserId == userId).ToListAsync();
        }

        public async Task<BookSubscription> GetBookSubscriptionById(int id)
        {
            return await _context.BookSubscription.FindAsync(id);
        }

        public async Task<BookSubscription> CreateBookSubscription(BookSubscription bookSubscription)
        {
            _context.BookSubscription.Add(bookSubscription);
            await _context.SaveChangesAsync();
            return bookSubscription;
        }

        public async Task<BookSubscription> DeleteBookSubscription(BookSubscription bookSubscription)
        {
            _context.BookSubscription.Remove(bookSubscription);
            await _context.SaveChangesAsync();

            return bookSubscription;
        }
    }

  
}
