using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolLibrary.Models
{
    public class PopularBook
    {
        public virtual int Id { get; set; }
        public virtual Book BookId { get; set; }
        public virtual DateTime RecordedTime { get; set; }
        public virtual string Discription { get; set; }
    }
}