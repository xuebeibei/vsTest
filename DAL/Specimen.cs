﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // 化验标本
    public class Specimen
    {
        public Specimen()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string AbbrPY { get; set; }
        public string AbbrWB { get; set; }

    }
}
