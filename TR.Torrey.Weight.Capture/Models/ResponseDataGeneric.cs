﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Torrey.Weight.Capture.Models
{
    public class ResponseDataGeneric<T>
    {
        public int code {  get; set; }
        public string message { get; set; }
        public T data {get; set; }
    }
}
