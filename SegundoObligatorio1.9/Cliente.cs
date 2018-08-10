using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoObligatorioAlpha
{
    class Cliente
    {
        #region Atributos


        string nombre;
        string apellido;
        string cedula;
        string telefono;
        List<Tarjeta>listaTarjetas;

        

        #endregion
        

        #region Propiedades

        public string Nombre
        {
            set
            {
                int aux = 0;
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("\n\tEl nombre no puede estar vacío.\n");
                }
                   

                else if (int.TryParse(value, out aux))
                {
                    throw new Exception("\n\tEl nombre no puede contener números!!\n");
                }

                else
                {
                    nombre = value.ToUpper();
                }
                    
            }
            get { return nombre; }
        }

        public string Apellido
        {
            set
            {
                int aux = 0;
                if (String.IsNullOrEmpty(value))
                {
                    throw new Exception("\n\tEl apellido no puede estar vacío!!\n");
                }


                else if (int.TryParse(value, out aux))
                {
                    throw new Exception("\n\tEl apellido no puede contener números!!\n");
                }

                else
                {
                    apellido = value.ToUpper();
                }
                    
            }
            get { return apellido; }
        
        }

        public string Cedula
        {
            set 
            {
                int aux = 0;
                if (value.Length == 7 && int.TryParse(value, out aux))
                {
                     cedula = value;
                }

                else
                {
                    throw new Exception("\n\tLa cédula debe tener 7 dígitos y tener formato numérico.\n");
                }
                    

            }

            get { return cedula; }
        }

        public string Telefono
        {
            set 
            {
                int aux;
                if (int.TryParse(value, out aux) && value.Length>7 && value.Length<10) 
                {
                    telefono = value;
                }

                else 
	            {
		          throw new Exception("\n\tEl número de teléfono debe tener entre 8 y 9 dígitos y tener formato numérico!!\n");
	            }
            } 

            get { return telefono; }
        }
        
        //es una propiedad que lo que hace es devolver la lista de tarjetas del cliente
        public List<Tarjeta> ListaTarjetas
        {
            get { return listaTarjetas; }
            set
            {
                listaTarjetas = value;
            }
        }

      

        #endregion

        #region Constructores

        //Constructor COMPLETO
        public Cliente(string cNombre, string cApellido, string cCedula, string cTelefono)
        {
            Nombre   = cNombre;
            Apellido = cApellido;
            Cedula   = cCedula ;
            Telefono = cTelefono;
            listaTarjetas = new List<Tarjeta>();
        }

       //Constructor por DEFECTO
        public Cliente()
        {
            nombre = "Sin dato";
            apellido = "Sin dato";
            cedula = "Sin dato";
            telefono = "Sin dato";
            listaTarjetas = new List<Tarjeta>();
        }
        

         #endregion


         #region Metodos 

        //Metodo ToString();
          public override string ToString()
          {
            string frase = "";
            frase = "\n\tEl nombre del cliente es " + nombre + " " + apellido + ", su cédula de identidad es " + cedula;
            frase +=" \n\ty su número de teléfono es " + telefono + ".";
            return frase;
            
          }
          
          //Crea una nueva tarjeta de Crédito
          public void AgregarCredito(Credito card)
          {
          	//el metodo recibe la tarjeta ya creada en la clase Tarjeta y ahora lo unico que hace
          	//es agregar la tarjeta a la lista "general" de tarjetas y ademas a la lista particular del
          	//cliente creado 
            Tarjeta.Todas.Add(card);
            listaTarjetas.Add(card);
                        
          }
          //Crea una nueva tarjeta de Débito   
          public void AgregarDebito(Debito card)
          {
          	  //hace lo mismo que AgregarDebito();
              Tarjeta.Todas.Add(card);
              listaTarjetas.Add(card);            
          }
            
            
      
        #endregion
    }
}
