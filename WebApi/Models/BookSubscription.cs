using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class BookSubscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }



    }
}
