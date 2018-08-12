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

        public int Cuentas
        {
            set
            {
                if (value <= 0)
                    throw new Exception("La cantidad de cuentas debe ser positiva.");
                else
                    cuentas = value;

            }
            get { return cuentas; }
        }

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
        public Debito(bool cPersonalizada, int dcuentas)
            : base(cPersonalizada)
       {
            Cuentas = dcuentas;
        	Personalizada=cPersonalizada;
            saldo = 0;
       }
        
        #endregion
        
        #region Metodos
        
        //Metodo ToString();  
        public override string ToString()
        {
        	string frase = base.ToString();
        	frase +=" de DÉBITO-SALDO: $"+ saldo + "-CUENTAS ASOCIADAS:" + cuentas;
            return frase;
        }

       
        
        #endregion

        
    }
}
