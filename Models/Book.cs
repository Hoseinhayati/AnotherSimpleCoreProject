using System;
using System.Collections;
using System.Collections.Generic;

namespace Asp.netCore_MVC_.Models
{
    public partial class Book
    {
        public Book()
        {
            BookTopics = new HashSet<BookTopic>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UserId { get; set; }
        public ICollection<BookTopic> BookTopics { get; set; }
    }
}
