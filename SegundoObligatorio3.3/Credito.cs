using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoObligatorio
{
    class Credito : Tarjeta
    {
        #region Atributos

        public string categoria;
        private int limiteDeCredito ;
        public List<Pago> listaPagos;

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

        #region Constructores
        
       //Constructor COMPLETO
       public Credito(bool cPersonalizada, string cCategoria,int cLimite)
           : base( cPersonalizada)
         {
       	   Categoria = cCategoria;
           LimiteDeCredito = cLimite;
           listaPagos=new List<Pago>();
         }

        #endregion

        #region Operaciones

        //Metodo ToString()
        public override string ToString()
        {
            string frase = base.ToString();
            frase += " de CRÉDITO - CATEGORÍA " + categoria + " - LÍMITE DE CRÉDITO: $"+ limiteDeCredito+"." ;
            return frase;
        }
      
        //Verifica si un pago no supera el límite de credito de una tarjeta.
        public void VerificarLimite(Pago pago, Credito tarjeta)
        {
        	listaPagos.Add(pago);
            int suma=0;
        	foreach(Pago pay in listaPagos)
        	{
        		suma +=pay.Monto;
        		if (suma>tarjeta.LimiteDeCredito) 
        		{
        			listaPagos.Remove(pago);
        			throw new Exception("\n\tLímite de crédito superado.No se ha podido ingresar el pago.");
        		}
        		
            }
        	
        }
               
        #endregion
  
    }
}
