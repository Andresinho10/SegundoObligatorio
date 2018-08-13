using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoObligatorioAlpha
{
    class Credito : Tarjeta
    {
        #region Atributos

        public string categoria;
        private int limiteDeCredito ;
        public static List<Pago> listaPagos;

        #endregion

        #region Propiedades
        
        public string Categoria
        {
            set { categoria = value; }
            get { return categoria; }
        }
        

        public int LimiteDeCredito
        {
        	set {limiteDeCredito=value;}
         
            get { return limiteDeCredito; }
        }
        
        
        #endregion

        #region Metodos
        
       //Constructor COMPLETO
       public Credito(bool cPersonalizada, string cCategoria,int cLimite)
           : base( cPersonalizada)
         {
       	   Categoria = cCategoria;
           LimiteDeCredito = cLimite;
           listaPagos=new List<Pago>();
         }


        //Metodo ToString()
       
        public override string ToString()
        {
            string frase = base.ToString();
            frase += " de CRÉDITO - CATEGORÍA " + categoria + " - LÍMITE DE CRÉDITO: $"+ limiteDeCredito+"." ;
            return frase;
        }
        
        
        public void AgregarPago(Pago pago)
        {
        	listaPagos.Add(pago);
        }
        
       
         
        #endregion

    
    }
}
