﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.ArticleCategory
{
    public class ArticleCategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CretionDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

