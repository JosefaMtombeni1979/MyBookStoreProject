using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Service
{
    public interface ISubscriptionService
    {
        Task<Subscription> CreateSubscription(Subscription subscription);
        Task<Subscription> GetSubscriptionById(int id);
        Task<List<BookSubscription>> GetSubscriptions();


    }
}