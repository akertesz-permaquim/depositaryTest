﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Entities
{
    internal class BagContentItem
    {
        public string Moneda { get; set; }
        public string Denominacion { get; set; }
        public long Cantidad { get; set; }
        public decimal Total { get; set; }
   
    }
}