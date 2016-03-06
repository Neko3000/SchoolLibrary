﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolLibrary.Models
{
    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}