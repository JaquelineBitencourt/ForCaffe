﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForCaffe.Models
{
    public class Comida
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Tamanho { get; set; }
        public float Preco { get; set; }
    }
}