using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4ED1.Models
{
    public class Lista<T>
    {
        List<T> faltantes = new List<T>();
        List<T> coleccionadas = new List<T>();
        List<T> cambios = new List<T>();
    }
}