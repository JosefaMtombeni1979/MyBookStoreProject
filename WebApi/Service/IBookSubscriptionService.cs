using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Service
{
    public interface IBookSubscriptionService
    {
        Task<BookSubscription> CreateBookSubscription(BookSubscription bookSubscription);
        Task<BookSubscription> DeleteBookSubscription(BookSubscription bookSubscription);
        Task<List<BookSubscription>> GetAllBookSubscriptions();
        Task<BookSubscription> GetBookSubscriptionById(int id);
        Task<List<BookSubscriptions>> GetAllBookSubscriptionsByUserId(string userId);
    }
}