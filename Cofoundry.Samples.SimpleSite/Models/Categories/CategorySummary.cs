﻿using Cofoundry.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cofoundry.Samples.SimpleSite
{
    public class CategorySummary
    {
        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }
    }
}