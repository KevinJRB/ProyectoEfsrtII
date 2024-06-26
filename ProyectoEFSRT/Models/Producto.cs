using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoEFSRT.Models
{
    public class Producto
    {
        public string CodProd { get; set; }
        public string NomProd { get; set; }
        public string DescProd { get; set; }
        public decimal PreProd { get; set; }
        public int StkProd { get; set; }
    }
}