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
        public Dictionary<Calcomania, Lista<Calcomania>> CargaAlbum = new Dictionary<Calcomania, Lista<Calcomania>>();
        
        public List<Calcomania> listaCalcomaniasCargadas = new List<Calcomania>();

        public Dictionary<Calcomania, bool> CargaCalcomanias = new Dictionary<Calcomania, bool>();
        public List<Calcomania> listaCalcomaniasEstadoCargadas = new List<Calcomania>();


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