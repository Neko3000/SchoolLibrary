using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Models
{
    public class Book
    {
        public virtual int Id { get; set; }
        [Display(Name ="标题")]
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Author { get; set; }
        public virtual DateTime PublishTime { get; set; }
        public virtual Category Category { get; set; }
        public virtual string PictureUrl { get; set; }
        public virtual int CurrentCount { get; set; }
    }
}