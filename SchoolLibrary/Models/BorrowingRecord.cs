using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolLibrary.Models
{
    public class BorrowingRecord
    {
        public virtual int Id { get; set; }
        public virtual Book Book { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual DateTime BorrowingTime { get; set; }
        public virtual string Description { get; set; }
    }
}