﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SegParcial.Entidades
{
    public class LlamadasDetalles
    {
        [Key]
        public int IdDetalle { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadasDetalles()
        {
            IdDetalle = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }

        public LlamadasDetalles( int idDetalle, string problema, string solucion)
        {
            IdDetalle = idDetalle;
            Problema = problema;
            Solucion = solucion;
        }
    }
}
