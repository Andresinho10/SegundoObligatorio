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
        List<Pago> listaPagos;

        #endregion

        #region Propiedades
        
        public string Categoria
        {
            set { categoria = value; }
            get { return categoria; }
        }
        

        public int LimiteDeCredito
        {
            set
            {
                if (categoria == "Clasica")
                {
                    limiteDeCredito = 18000;
                }
                else if (categoria == "Plata")
                {
                    limiteDeCredito = 30000;
                }
                else if (categoria == "Oro")
                {
                    limiteDeCredito = 70000;
                }
                else if (categoria == "Platinium")
                {
                    limiteDeCredito = 120000;
                }
            }
            get { return limiteDeCredito; }
        }
        #endregion

        #region Constructores
       //Constructor Completo
       public Credito(bool cPersonalizada, string cCategoria)
           : base( cPersonalizada)
        {
           Categoria = cCategoria;
           LimiteDeCredito = limiteDeCredito;
           Tarjeta.numero = numero + 1;

        }

        public Credito(bool cPersonalizada)
            : base(cPersonalizada)
        {
            Categoria = categoria;
            limiteDeCredito = 0;
            Tarjeta.numero = numero + 1;
        }
        // Constructor por defecto
        public Credito()
            : base()
        {
            categoria = "Sin Datos";
            limiteDeCredito = 0;
            Tarjeta.numero=numero + 1;
        }

        //Metodo ToString()
       
        public override string ToString()
        {
            string frase = base.ToString();
            frase += " de credito categoria " + categoria + " y su limite es de "+ limiteDeCredito+"." ;
            return frase;
        }
        
        #endregion

        #region Operaciones
        
        
        
        #endregion
    }
}
