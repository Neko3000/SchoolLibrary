using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Models
{
    public class PopularBook
    {
        [Display(Name ="热门书籍ID")]
        public virtual int Id { get; set; }
        [Display(Name = "书籍")]
        public virtual Book BookId { get; set; }
        [Display(Name = "记录时间")]
        public virtual DateTime RecordedTime { get; set; }
        [Display(Name = "描述")]
        public virtual string Discription { get; set; }
    }
}