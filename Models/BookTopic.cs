using System;

namespace Asp.netCore_MVC_.Models
{
    public partial class BookTopic
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Book Book { get; set; }
    }
}
