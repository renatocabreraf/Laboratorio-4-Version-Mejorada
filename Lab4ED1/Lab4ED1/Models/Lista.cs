using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4ED1.Models
{
    public class Lista<T>
    {
        public string nombre { get; set; }
        public List<T> faltantes = new List<T>();
        public List<T> coleccionadas = new List<T>();
        public List<T> cambios = new List<T>();
        
    }
}