using Lab4ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Lab4ED1.DB
{
    public class DefaultConnection
    {
        private static volatile DefaultConnection Instance;
        private static object syncRoot = new Object();

        public List<Calcomania> listaCalcomania = new List<Calcomania>();

        public Dictionary<Calcomania, Lista<Calcomania>> DiccionarioListados = new Dictionary<Calcomania, Lista<Calcomania>>();
       

        public Dictionary<Calcomania, bool> DiccionarioEstaONo = new Dictionary<Calcomania, bool>();
        


        public int IDActual { get; set; }

        private DefaultConnection()
        {
            IDActual = 0;
        }

        public static DefaultConnection getInstance
        {
            get
            {
                if (Instance == null)
                {
                    lock (syncRoot)
                    {
                        if (Instance == null)
                        {
                            Instance = new DefaultConnection();
                        }
                    }
                }
                return Instance;
            }
        }
    }
}