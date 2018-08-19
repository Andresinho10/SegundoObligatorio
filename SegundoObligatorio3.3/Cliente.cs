using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoObligatorio
{
    class Cliente
    {
        #region Atributos

        string nombre;
        string apellido;
        string cedula;
        string telefono;
        public List<Tarjeta>listaTarjetas;
       
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

        #endregion

        #region Operaciones 

        //Metodo ToString();
          public override string ToString()
          {
            string frase = "";
            frase = "\n\t -" + nombre + " " + apellido + " - Cédula de Identidad " + cedula;
            frase +=" - Teléfono " + telefono + " - Titular de " + listaTarjetas.Count() + " tarjetas";
            return frase;            
          }
          
          //Agrega una tarjeta de Débito o Crédito a la lista de Tarjetas.
          public void AgregarTarjeta(Tarjeta card)
          {
            listaTarjetas.Add(card);
          }

          //Busca una tarjeta por su nro. y devuelve el tipo de tarjeta al que corresponde(CRÉDITO o DÉBITO).
          public Tarjeta BuscarTarjeta(int numeroTarjeta)
          {
              foreach(Tarjeta tar in listaTarjetas)
              {
                  if (tar.Numero==numeroTarjeta && tar is Credito)
                  {
              		return ((Credito)tar);
                  }
                  
                  if (tar.Numero==numeroTarjeta && tar is Debito)
                    return ((Debito)tar);
                     
              }
              
              throw new Exception("\n\tLa tarjeta no se encuentra registrada en nuestro sistema.");
          }
            
        #endregion
    }
}
