﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelObjects
{
    public class Comment : UserOpinion
    {
        public string content { get; set; }
        public Chapter chapter { get; set; }
    }
}
