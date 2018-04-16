﻿using Factory.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class JpgImage : Image
    {
        public JpgImage(string name) : base(name)
        {
            this.Type = "jpeg";
        }
    }
}