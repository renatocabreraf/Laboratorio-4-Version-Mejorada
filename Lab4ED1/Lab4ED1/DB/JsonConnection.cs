using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab4ED1.Models;
using System.IO;

namespace Lab4ED1.DB
{
    public class JsonConnection
    {
        private static volatile JsonConnection Instance;
        private static object syncRoot = new Object();
        public Dictionary<string, Lista<int>> DiccionarioListados = new Dictionary<string, Lista<int>>();
        
        public List<Calcomania> listaCalcomaniaColeccionada = new List<Calcomania>();
        public List<Calcomania> listaCalcomaniaCambios = new List<Calcomania>();
        public List<Calcomania> listaCalcomaniaFaltantes = new List<Calcomania>();

        public Dictionary<Calcomania, bool> DiccionarioFaltantes = new Dictionary<Calcomania, bool>();
        public List<Calcomania> listaCalcomaniasCargadas = new List<Calcomania>();


        public int IDActual { get; set; }

        private JsonConnection()
        {
            
            IDActual = 0;
        }

        public static JsonConnection getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new JsonConnection();
                        }
                    }
                }
                return Instance;
            }
        }
    }
}