﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoObligatorio
{
    class Pago
    {
        #region Atributos

        private DateTime fecha;
        private int monto;      

        #endregion

        #region Propiedades
        public DateTime Fecha
        {
            set
            {
                if (DateTime.Compare(value, DateTime.Today) > 0)
                    throw new Exception("La fecha de pago no puede ser futura.");
                else
                    fecha = value;
            }
            get { return fecha; }
        }

        public int Monto
        {
            set
            {
                if (value > 0)
                {
                    monto = value;
                }
                else
                {
                    throw new Exception("El monto del pago debe ser positivo.");
                }
            }
            get { return monto; }
        }
                   
        #endregion

        #region Constructores

        //Constructor Completo
        public Pago(DateTime cFecha, int cMonto)
        {
            Fecha = cFecha;
            Monto = cMonto;            
        }

        #endregion

        #region

        //Metodo ToString(); 
       
        public override string ToString()
        {
        	string frase = "-PAGO del día " + fecha.ToShortDateString() + " por $" + monto;
           
            return frase;
        }
        
        #endregion
     
    }
}
