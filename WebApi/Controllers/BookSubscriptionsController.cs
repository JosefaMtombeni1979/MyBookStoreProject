using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Authentication;
using WebApi.Models;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookSubscriptionsController : ControllerBase
    {
        private readonly IBookSubscriptionService _booksSubscription;

        public BookSubscriptionsController(IBookSubscriptionService booksSubscription)
        {
            _booksSubscription = booksSubscription;
        }


        // GET: api/BookSubscriptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookSubscription>>> GetBookSubscription()
        {
            return await _booksSubscription.GetAllBookSubscriptions();
        }

        // GET: api/BookSubscriptions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookSubscription>> GetBookSubscription(int id)
        {
            var bookSubscription = await _booksSubscription.GetBookSubscriptionById(id);

            if (bookSubscription == null)
            {
                return NotFound();
            }

            return bookSubscription;
        }


        // POST: api/BookSubscriptions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookSubscription>> PostBookSubscription(BookSubscription bookSubscription)
        {
            await _booksSubscription.CreateBookSubscription(bookSubscription);
            return CreatedAtAction("GetBookSubscription", new { id = bookSubscription.Id }, bookSubscription);
        }

        // DELETE: api/BookSubscriptions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookSubscription>> DeleteBookSubscription(int id)
        {
            var bookSubscription = await _booksSubscription.GetBookSubscriptionById(id);
            if (bookSubscription == null)
            {
                return NotFound();
            }

            await _booksSubscription.DeleteBookSubscription(bookSubscription);

            return bookSubscription;
        }

    }
}
