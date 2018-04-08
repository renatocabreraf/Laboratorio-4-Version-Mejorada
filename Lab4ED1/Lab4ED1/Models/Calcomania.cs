using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4ED1.Models
{
    public class Calcomania
    {
        
        public string nombre { get; set; }
        public int numero { get; set; }
        public bool falta { get; set; }
        public List<Calcomania> faltantes {get; set;}
        public List<Calcomania> coleccionadas { get; set; }
        public List<Calcomania> cambios { get; set; }
    }
}