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
        public static List<Tarjeta> Todas = new List<Tarjeta>();//esta lista almacena todas las tarjetas(debito y credito)((se tiene que ir!!)
        

        #endregion

        #region Propiedades

        public int Numero
        {
        	get { return numero; }
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
           	numero=0;
           else
           numero=Base+1;
           Base++;
           
        }

        //Metodo ToString()
       
        public override string ToString()
        {
            string frase = "\n\tSe ha creado correctamente la tarjeta Nro. "  + numero;
            if (personalizada)
            {
            	frase = " \n\tSe ha creado correctamente la tarjeta Personalizada";
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
