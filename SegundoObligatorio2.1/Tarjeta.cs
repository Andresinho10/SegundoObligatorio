using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoObligatorioAlpha
{
    class Tarjeta
    {
        #region Atributos
       
       
        private static int Base = Rango();
        private int numero;
        private bool personalizada;
     
        

        #endregion

        #region Propiedades

        public int Numero
        {
        	get { return numero;}
        }

        public bool Personalizada
        {
            set { personalizada = value; }
            get { return personalizada; }
        }

        #endregion

        #region Metodos
        
        //Constructor COMPLETO
        public Tarjeta(bool cPersonalizada)
        {
           Personalizada = cPersonalizada;
           if (Personalizada)
           {
               numero = 0;
               Base = Base - 1;
           }
           else
               numero = Base + 1;
               Base++;
           
        }

        //Metodo ToString()
       
        public override string ToString()
        {
            string frase = "\n\tTarjeta Nro."  + numero;
            if (personalizada)
            {
            	frase = " \n\tTarjeta PERSONALIZADA (S/N)";
            }
           
            return frase;
        }
        
        //Genera un nro. aleatorio para inicializar el atributo estatico "número"
        public static int Rango()
        {
            Random rango = new Random();
            int nroTarjeta = rango.Next(45001000,46001000);
        	return nroTarjeta;
        }
       
        #endregion

     
    }
}
