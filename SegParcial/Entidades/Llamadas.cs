using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SegParcial.Entidades
{

    public class Llamadas
    {
        [Key]
        public int  Llamadaid { get; set; }
        public string Descripcion { get; set; }


        [ForeignKey("Llamadaid")]
        public virtual List<LlamadasDetalles> Telefono { get; set; }
        

        public Llamadas( )
       
        {
            Llamadaid = 0;
            Descripcion = string.Empty;

            Telefono = new List<LlamadasDetalles>();
        }
    }
}
