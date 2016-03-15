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
        [Display(Name = "简介")]
        public virtual string Description { get; set; }
        [Display(Name = "作者")]
        public virtual string Author { get; set; }
        [Display(Name = "出版时间")]
        public virtual DateTime PublishTime { get; set; }
        [Display(Name = "分类")]
        public virtual Category Category { get; set; }
        public virtual string PictureUrl { get; set; }
        [Display(Name = "当前数目")]
        public virtual int CurrentCount { get; set; }
    }
}