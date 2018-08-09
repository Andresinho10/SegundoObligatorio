using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoObligatorioAlpha
{
    class Tarjeta
    {
        #region Atributos
       
        Random rango = new Random();
        public static int numero = Rango();
        private bool personalizada;
       
        

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

        #region Constructores
        //Constructor COMPLETO
        public Tarjeta(bool cPersonalizada)
        {
           Personalizada = cPersonalizada;
        }
        //Constructor por defecto
        public Tarjeta()
        {
           personalizada = true; 
        }

        //Metodo ToString()
       
        public override string ToString()
        {
            string frase = "\nSe ha creado correctamente la tarjeta Nro. "  +  Tarjeta.numero;
            if (personalizada)
            {
            	frase = " \nSe ha creado correctamente la tarjeta Personalizada ";
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

        #region Operaciones
        #endregion
    }
}
