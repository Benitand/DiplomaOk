﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Servicios.Digito_Verificador
{
    public class DVV : EntityBase
    {
        public override int Id { get; set; }
        public string dvv { get; set; }
        public string tabla { get; set; }
        public bool estado { get; set; }
    }
}
