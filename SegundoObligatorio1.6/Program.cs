﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoObligatorioAlpha
{
    class Program
    {
        static void Main(string[] args)
        {
            //No va permitir personas con cédula repetida.
            List<Cliente> lista = new List<Cliente>();
            List<Tarjeta>listaTarjetas=new List<Tarjeta>();

            #region Carga de datos
            lista.Add(new Cliente("Marcos", "Perez", "1365987", "25693265"));
            lista.Add(new Cliente("Ana", "Ramos", "2365741", "23360759"));
            lista.Add(new Cliente("Maria", "Marquez", "4401918", "25052458"));
            lista.Add(new Cliente("Roberto", "Ramirez", "4401884", "23659874"));
            lista.Add(new Cliente("Laura", "Paz", "1111111", "23101478"));
            lista.Add(new Cliente("Andres", "De Angeli", "4951791", "099321757"));

            #endregion
            string opcion = "", sino = "";
            while (opcion != "0")
            {
                Menu(); //Imprime el Menu
                opcion = Console.ReadLine();
                Console.Clear();

                try
                {
                    switch (opcion)
                    {
                        #region case 1: Buscar Cliente
                        case "1":
                            Console.WriteLine("\n\n\t ***** Buscar Cliente *****\n");

                         
                            Console.Write("\n\tIngrese el numero de cédula del cliente:");
                            string cedula = Console.ReadLine();

                            int aux = 0;
                            if (cedula.Length == 7 && int.TryParse(cedula, out aux))
                            {
                                if (Buscar(lista, cedula))
                                {
                                    Console.Write("\n\tEl cliente con cédula " + cedula + " ya existe.\n");
                                    Console.Write("\n\tDesea eliminar al cliente(1) o modificar sus datos(2)?:");
                                    int seleccion = Convert.ToInt32(Console.ReadLine());


                                    if (seleccion == 1)
                                    {
                                        Eliminar(lista, cedula);
                                        Console.Write("\n\tEl cliente con cédula " + cedula + " ha sido eliminado de la lista con éxito.");
                                    }
                                    else if (seleccion == 2)
                                    {

                                        Console.Clear();
                                        Console.WriteLine("\n\n\t ***** Modificar Cliente *****\n");


                                        Cliente customerMod = new Cliente();
                                        Console.Write("\n\tIngrese nuevos datos del cliente: \n");
                                        Console.Write("\n\tIngrese nombre: ");
                                        customerMod.Nombre = Console.ReadLine();
                                        Console.Write("\n\tIngrese apellido: ");
                                        customerMod.Apellido = Console.ReadLine();
                                        Console.Write("\n\tIngrese teléfono: ");
                                        customerMod.Telefono = Console.ReadLine();
                                        customerMod.Cedula = cedula;
                                        Modificar(lista, customerMod, cedula);

                                        Console.Write("\n\tEl cliente con cédula " + cedula + " ha sido editado con éxito.");


                                    }
                                    else
                                    {
                                        Console.Write("\n\tNo ingreso una opcion valida");
                                        Console.Write("\n\tPresione Enter para volver al Menú Principal");
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("\n\tEl cliente con cédula " + cedula + " no se encuentra registrado ");
                                    Console.Write("\n\tDesea agregar un nuevo cliente? (S/N): ");
                                    sino = Console.ReadLine();



                                    if (sino.ToUpper() == "S")
                                    {

                                        Cliente customer = new Cliente();
                                        Console.Write("\n\tIngrese el nombre: ");
                                        customer.Nombre = Console.ReadLine();
                                        Console.Write("\n\tIngrese el apellido: ");
                                        customer.Apellido = Console.ReadLine();
                                        Console.Write("\n\tIngrese la cédula: ");
                                        customer.Cedula = Console.ReadLine();
                                        Console.Write("\n\tIngrese el número de teléfono: ");
                                        customer.Telefono = Console.ReadLine();
                                        lista.Add(customer);


                                        Console.Write("\n\tEl cliente ha sido registrado con éxito!!\n");
                                        Console.Write(customer.ToString());

                                    }

                                    else
                                    {
                                        Console.Write("\n\tPresione Enter para volver al Menú Principal");
                                    }


                                }
                            }

                            else
                            {
                                throw new Exception("\n\tLa cédula debe tener 7 dígitos y tener formato numérico.\n");
                            }

                           
                       
                             break;
                        #endregion

                        #region case 2: Solicitud de Tarjetas
                        case "2":
                            Console.WriteLine("\n\n\t ***** Solicitud de Tarjetas *****\n");
                         
                            Console.WriteLine("\t1- Tarjeta de Crédito\n");
                            Console.WriteLine("\t2- Tarjeta de Débito\n");
                            Console.Write("\n\tIngrese una opción : ");
                            opcion = Console.ReadLine();
                            Console.Clear();

                            switch (opcion)
                            { 
                                case"1":
                                    Console.WriteLine("\n\n\t*****Tarjeta de Crédito*****\n");

                                    Console.Write("\n\tIngrese el numero de cedula del cliente:");
                                    
                                    string documento=Console.ReadLine();
                                    int aux2 = 0;
                                    if (documento.Length == 7 && int.TryParse(documento, out aux2))
                                    {
                                        if (Buscar(lista,documento)) 
                                    
                                        {
                                    	
                                             foreach (Cliente cliente in lista)
									         {
									                 if (cliente.Cedula == documento)
									                 {
									                     Console.WriteLine(cliente.ToString());
									                     Console.Write("\n\tDesea crear Tarjeta?(S/N): ");
									                     string opcionCredito =Console.ReadLine();
									                     string categoria;
									                     

                                                            if (opcionCredito.ToUpper() == "S")
                                                            {
                                                                
                                                                Console.Write("\n\tElija la Categoria de la Tarjeta: ");
                                                                Console.Write("\n\t1- Clasica");
                                                                Console.Write("\n\t2- Plata");
                                                                Console.Write("\n\t3- Oro");
                                                                Console.WriteLine("\n\t4- Platinium");
                                                                string opcion2 = Console.ReadLine();
                                                                switch (opcion2)
                                                                {
                                                                    case "1":
                                                                		categoria = "Clasica";
                                                                Console.WriteLine("\n\tUsted ha elegido {0}", categoria);
                                                                
                                                                Console.Write("\n\tDesea personalizar su tarjeta?(S/N)");
                                                                string personalizar=Console.ReadLine();
                                                                if (personalizar.ToUpper()=="S") 
                                                                {
                                                                	cliente.AgregarCredito(true,categoria);
                                                                }
                                                               
                                                                else
                                                                	cliente.AgregarCredito(false,categoria);
                                                                
                                                                    break;

                                                                    case "2":
                                                                        categoria = "Plata";
                                                                Console.WriteLine("\n\tUsted ha elegido {0}", categoria);
                                                                
                                                                 Console.Write("\n\tDesea personalizar su tarjeta?(S/N)");
                                                                string personalizar2=Console.ReadLine();
                                                                if (personalizar2.ToUpper()=="S") 
                                                                {
                                                                	cliente.AgregarCredito(true,categoria);
                                                                }
                                                               
                                                                else
                                                                	cliente.AgregarCredito(false,categoria);
                                                                
                                                                
                                                                break;

                                                                    case "3":
                                                                               categoria = "Oro";
                                                                Console.WriteLine("\n\tUsted ha elegido {0}", categoria);
                                                                
                                                                 Console.Write("\n\tDesea personalizar su tarjeta?(S/N)");
                                                                string personalizar3=Console.ReadLine();
                                                                if (personalizar3.ToUpper()=="S") 
                                                                {
                                                                	cliente.AgregarCredito(true,categoria);
                                                                }
                                                               
                                                                else
                                                                	cliente.AgregarCredito(false,categoria);
                                                                
                                                                break;
                                                                   case "4":
                                                                                categoria = "Platino";
                                                                Console.WriteLine("\n\tUsted ha elegido {0}", categoria);
                                                                
                                                                 Console.Write("\n\tDesea personalizar su tarjeta?(S/N)");
                                                                string personalizar4=Console.ReadLine();
                                                                if (personalizar4.ToUpper()=="S") 
                                                                {
                                                                	cliente.AgregarCredito(true,categoria);
                                                                }
                                                               
                                                                else
                                                                	cliente.AgregarCredito(false,categoria);
                                                                break;
                                                                
                                                                }
                                                                
 
                                                            }
                                                     }

                                             }
                                        }

                                    }
                                    else
                                    {
                                        throw new Exception("\n\tLa cédula debe tener 7 dígitos y tener formato numérico.\n");
                                    }

                                    break;

                                case "2":
                                    Console.WriteLine("\n\n\t*****Tarjeta de Débito*****\n");

                                    Console.Write("\n\tIngrese el numero de cedula del cliente:");
                                    
                                    string documento2=Console.ReadLine();
                                    int aux3 = 0;
                                    if (documento2.Length == 7 && int.TryParse(documento2, out aux3))
                                    {
                                        if (Buscar(lista, documento2))

                                        {

                                            foreach (Cliente cliente in lista)
                                            {
                                                if (cliente.Cedula == documento2)
                                                {
                                                    Console.WriteLine(cliente.ToString());
                                                    Console.Write("\n\tDesea crear Tarjeta?(S/N): ");
                                                    string opcionDebito = Console.ReadLine();

                                                    if (opcionDebito.ToUpper() == "S")
                                                    {
                                                        Console.Write("\n\tDesea una tarjeta personalizada?(S/N):");
                                                        string personalizar = Console.ReadLine();

                                                        if (personalizar.ToUpper() == "S")
                                                        {
                                                            cliente.AgregarDebito(true);
                                                            
                                                        }

                                                        else
                                                        {
                                                            cliente.AgregarDebito(false);
                                                        }

                                                    }
                                                }
                                            }

                                        }

                                        else
                                        {
                                            Console.WriteLine("\n\tNo se ha encontrado al cliente!\n");
                                            Console.Write("\tPresione Enter para continuar...");
                                        }
                                    }

                                    else
                                    {
                                        throw new Exception("\n\tLa cédula debe tener 7 dígitos y tener formato numérico.\n");
                                    }

                                    break;
                            
                            }
                       
                            break;
                        #endregion

                        #region case 3: Carga de Saldo y Pago de Tarjeta
                        case "3":
                            Console.WriteLine("\n\n\t ***** Carga de Saldo y Pago de Tarjeta *****\n");

                            Console.Write("\n\tIngrese el numero de cedula del cliente: ");

                            
                           
                         
                           
                            break;
                        #endregion

                        #region case 4: Listados
                        case "4":
                            Console.WriteLine("\n\n\t ***** Listados *****\n");

                            Console.WriteLine("\t1- Listado de Clientes\n");
                            Console.WriteLine("\t2- Listado de Tarjetas\n");
                            Console.WriteLine("\t3- Listado de Pagos\n");
                            Console.Write("\n\tIngrese una opción : ");
                            opcion = Console.ReadLine();
                            Console.Clear();

                            switch (opcion)
                            { 
                                case"1":
                                    Console.WriteLine("\n\n\t*****Listado de Clientes*****\n");

                                      if (lista.Count == 0)
                                throw new Exception("No hay personas para listar.");
                                      
                            //Ordena la lista de clientes alfabeticamente         
                            IEnumerable<Cliente> listaOrdenada=lista.OrderBy(customer=>customer.Nombre);
                            foreach (Cliente customer in listaOrdenada)
                            {
                            	
                                Console.WriteLine("- " + customer.Nombre + " " + customer.Apellido + " CI:" + customer.Cedula + " TEL:" + customer.Telefono +"\n");
                            }
                                       
                                break;

                                case "2":
                                    Console.WriteLine("\n\n\t*****Listado de Tarjetas*****\n");
                                    if (listaTarjetas.Count == 0)
                                        throw new Exception("No hay tarjetas para listar.");

                                    foreach (Tarjeta tar in listaTarjetas)
                                    {

                                        Console.WriteLine("-  N°Tarjeta: " + tar.Numero + " " + tar.Personalizada + "\n");
                                    }

                                    break;

                                case "3":
                                    Console.WriteLine("\n\n\t*****Listado de Pagos*****\n");

                                    Console.Write("\n\tIngrese el numero de tarjeta: ");

                                break;
                            
                            }
                           

                                break;
                        #endregion

                    
                        #region case 0 y default
                        case "0":
                            Console.WriteLine("\n\n\t¡ ¡ ¡Gracias por utilizar nuestro programa! ! !");
                            Console.Write("\n\t\t\tEnter para salir...");
                            break;
                        default:
                            Console.WriteLine("\n\n\tLa opción ingresada no es válida.");
                            Console.Write("\tEnter para continuar...");
                            break;

                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n\t" + ex.Message);
                    Console.Write("\n\tEnter para continuar...");
                }
                Console.ReadLine();
            }
        }

        #region Metodos

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t * * * FINANCIERA PRONTO! * * *\n");
            Console.WriteLine("\t 1- Mantenimiento de Clientes.\n");
            Console.WriteLine("\t 2- Solicitud de Tarjetas.\n");
            Console.WriteLine("\t 3- Carga de Saldo y Pago de Tarjeta.\n");
            Console.WriteLine("\t 4- Listados.\n");
            Console.WriteLine("\t 0- Salir.\n");
            Console.Write("\n\tIngrese la opción deseada: ");
        }

        //Busca un cliente en la lista por su cédula
        static bool Buscar(List<Cliente> lista, string cedula)
        {
            foreach (Cliente cliente in lista)
            {
                if (cliente.Cedula == cedula)
                    return true; 
            }
            return false;
        }

        //Elimina un cliente de la lista
        static bool Eliminar(List<Cliente> lista, string cedula)
        {
            int index = -1;

           
            foreach (Cliente customer in lista)
            {
                if (customer.Cedula == cedula)
                {
                    index = lista.IndexOf(customer);
                }
            }

            if (index != -1)
            {
                lista.RemoveAt(index);
                return true;
            }

            return false;
        }

        //Modifica los datos de un cliente
        static void Modificar(List<Cliente>lista,Cliente customerEdit,string cedula)
        {
            foreach (Cliente cliente in lista)
            {
                if (cliente.Cedula == cedula)
                {
                    cliente.Nombre = customerEdit.Nombre;
                    cliente.Apellido = customerEdit.Apellido;
                    cliente.Telefono = customerEdit.Telefono;
                }
                  
            }
        }

        #endregion
    }
}

