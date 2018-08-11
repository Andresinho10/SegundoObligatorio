using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoObligatorioAlpha
{
    class Debito : Tarjeta
    {
        #region Atributos

        private int saldo;
        private int cuentas;
        

       #endregion

        #region Propiedades

        public int Saldo
        {
            set
            {
                if (value <= 0)
                    throw new Exception("El saldo debe ser positivo");
                else
                    saldo = value;
            }
            get { return saldo; }
        }
        #endregion

        #region Constructores
        
        //Constructor COMPLETO
        public Debito(bool cPersonalizada)
            : base(cPersonalizada)
       {
        	Personalizada=cPersonalizada;
            saldo = 0;
       }
        
        #endregion
        
        #region Metodos
        
        //Metodo ToString();  
        public override string ToString()
        {
        	string frase = base.ToString();
        	frase +=" de debito con saldo: $"+ saldo;
            return frase;
        }
        
        #endregion

        
    }
}
