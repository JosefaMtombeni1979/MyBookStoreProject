using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
    }
}
