﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibroWebService.Models
{
    public class Response
    {
        public int status { get; set; }

        public string mensaje { get; set; }

        public object data { get; set; }
    }
}
