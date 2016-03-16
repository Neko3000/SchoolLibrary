using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolLibrary.Models
{
    public class Category
    {
        [Display(Name = "分类ID")]
        public virtual int Id { get; set; }
        [Display(Name = "分类名称")]
        public virtual string Name { get; set; }
        [Display(Name = "描述")]
        public virtual string Description { get; set; }
    }
}