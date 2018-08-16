using System;
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
             
                                        Console.Write("\n\tIngrese nuevos datos del cliente: \n");
                                        Console.Write("\n\tIngrese nombre: ");
                                        string Nombre = Console.ReadLine();
                                        Console.Write("\n\tIngrese apellido: ");
                                        string Apellido = Console.ReadLine();
                                        Console.Write("\n\tIngrese teléfono: ");
                                        string Telefono = Console.ReadLine();
                                        string Cedula = cedula;
                                        Cliente customerMod = new Cliente(Nombre,Apellido,Cedula,Telefono);
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
                                     
                                        Console.Write("\n\tIngrese el nombre: ");
                                        string Nombre = Console.ReadLine();
                                        Console.Write("\n\tIngrese el apellido: ");
                                        string Apellido = Console.ReadLine();
                                        Console.Write("\n\tIngrese el número de teléfono: ");
                                        string Telefono = Console.ReadLine();
                                        string Cedula = cedula;
                                        Cliente customer = new Cliente(Nombre,Apellido,Cedula,Telefono);
                                        lista.Add(customer);


                                        Console.Write("\n\tEl cliente ha sido registrado con éxito!!\n");
                                        Console.Write(customer);

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
                                case "1":
                                    Console.WriteLine("\n\n\t*****Tarjeta de Crédito*****\n");

                                    Console.Write("\n\tIngrese el numero de cedula del cliente:");

                                    string documento = Console.ReadLine();
                                    int aux2 = 0;
                                    if (documento.Length == 7 && int.TryParse(documento, out aux2))
                                    {
                                        if (Buscar(lista, documento))
                                        {

                                            foreach (Cliente cliente in lista)
                                            {
                                                if (cliente.Cedula == documento)
                                                {
                                                    Console.WriteLine(cliente);
                                                    Console.Write("\n\tDesea crear una nueva Tarjeta?(S/N): ");
                                                    string opcionCredito = Console.ReadLine();
                                                    string categoria="";

                                                    if (opcionCredito.ToUpper() == "S")
                                                    { 	
                                                        Console.Write("\n\t*****Categoría de la Tarjeta*****\n");
                                                        Console.Write("\n\t1- CLÁSICA");
                                                        Console.Write("\n\t2- PLATA");
                                                        Console.Write("\n\t3- ORO");
                                                        Console.Write("\n\t4- PLATINO");
                                                        Console.Write("\n\tSeleccione una opción: ");
                                                        string opcion2 = Console.ReadLine();
                                                     
                                                        if (String.IsNullOrEmpty(opcion2))
                                                        	throw new Exception("\n\tDebe seleccionar una opción.");
                                                   
                                                        switch (opcion2)
                                                        {
                                                            case "1":
                                                                categoria = "CLÁSICA";      
                                                                break;
                                                            case "2":
                                                                categoria = "PLATA";
                                                                break;
                                                            case "3":
                                                                categoria="ORO";
                                                                break;
                                                            case "4":
                                                                categoria = "PLATINO";
                                                                break;                                                          
                                                        }
                                                                                                                
                                                        Console.Write("\n\tDesea personalizar su tarjeta?(S/N):");
                                                        bool Personalizada;
                                                        string personalizar = Console.ReadLine();
                                                        
                                                        if (personalizar.ToUpper() == "S")
                                                           Personalizada = true;
                                                        else if(personalizar.ToUpper() == "N")
                                                           Personalizada = false;
                                                        else
                                                        	throw new Exception("\n\tOpción incorrecta.");
                                                        
                                                        Console.Write("\n\tSeleccione un limite de credito:");
                                                        int limite=Convert.ToInt32(Console.ReadLine());
                                                       
                                                        Credito card = new Credito(Personalizada,categoria,limite);
                                                        cliente.AgregarTarjeta(card);
                                                        Console.WriteLine(card);
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
                                    	    throw new Exception("\n\tLa cédula debe tener formato numérico y no mas de 7 dígitos");
  
                                    break;

                                case "2":
                                    Console.WriteLine("\n\n\t*****Tarjeta de Débito*****\n");
                                    Console.Write("\n\tIngrese el número de cedula del cliente:");

                                    string documento2 = Console.ReadLine();
                                    int aux3 = 0;
                                    if (documento2.Length == 7 && int.TryParse(documento2, out aux3))
                                    {
                                        if (Buscar(lista, documento2))
                                        {

                                            foreach (Cliente cliente in lista)
                                            {
                                                if (cliente.Cedula == documento2)
                                                {
                                                    Console.WriteLine(cliente);
                                                    Console.Write("\n\tDesea crear una nueva Tarjeta?(S/N): ");
                                                    string opcionDebito = Console.ReadLine();

                                                    if (opcionDebito.ToUpper() == "S")
                                                    {   
                                                        
                                                        Console.Write("\n\tDesea personalizar su tarjeta?(S/N):");
                                                        string personalizar = Console.ReadLine();
                                                        bool Personalizada;
                                                     
                                                        if (personalizar.ToUpper() == "S")
                                                           Personalizada = true;
                                                        else if(personalizar.ToUpper() == "N")
                                                           Personalizada = false;
                                                        else
                                                        	throw new Exception("\n\tOpción incorrecta.");

                                                        Console.Write("\n\tIngrese Cantidad de cuentas para asociar:");
                                                        int cuentas = Convert.ToInt32(Console.ReadLine());
                                                        
                                                        Debito card=new Debito(Personalizada,cuentas);
                                                        cliente.AgregarTarjeta(card);
                                                        Console.WriteLine(card);
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
                                    	    throw new Exception("\n\tLa cédula debe tener formato numérico y no más de 7 dígitos");

                                    break;

                            }

                            break;
                        #endregion

                        #region case 3: Carga de Saldo y Pago de Tarjeta
                        case "3":
                            Console.WriteLine("\n\n\t ***** Carga de Saldo y Pago de Tarjeta *****\n");

                            Console.Write("\n\tIngrese el número de documento: ");
                            string doc = Console.ReadLine();
                            Buscar(lista,doc);

                            if (!Buscar(lista, doc))
                            {
                                Console.WriteLine("\n\tEl cliente con cédula " + doc + " no se encuentra registrado ");
                                Console.WriteLine("\n\tDebe registrar un cliente para acceder a esta opción.");
                            }
                                                        
                            else
                            {
                                foreach (Cliente customer in lista)
                                    if (customer.Cedula==doc)
                                    {
                                          foreach (Tarjeta tar in Cliente.listaTarjetas)
                                    {
                                        if (tar is Credito)
                                        {
                                            Console.WriteLine(((Credito)tar));
                                        }

                                        else
                                        {
                                            Console.WriteLine(((Debito)tar));
                                        }
                                    }

                                    }
                                
                            Console.Write("\n\tSeleccione el número de la tarjeta con la que desea operar:");
                            int opcionOperacion = Convert.ToInt32(Console.ReadLine());
                            Cliente.BuscarTarjeta(opcionOperacion);
   
                            if (Cliente.BuscarTarjeta(opcionOperacion) is Credito)
                            {
                            	Tarjeta a= Cliente.BuscarTarjeta(opcionOperacion);
                                Console.Write("\n\tHa seleccionado una tarjeta de CREDITO.\n");
                                Console.Write("\n\tDigite el importe del pago:");
                                int monto=Convert.ToInt32(Console.ReadLine());
                                
                                if(monto>((Credito)a).LimiteDeCredito)
                                {
                                	Console.Write("\n\tEl pago supera el limite de credito de la tarjeta seleccionada.");
                                    Console.Write("\n\n\tPresione enter para volver al menu principal...");
                                }
                                
                                else
                                {
                                	Console.Write("\n\tIngrese la fecha de compra:");
                                    DateTime fecha=Convert.ToDateTime(Console.ReadLine());
                                    Pago pago = new Pago(fecha,monto);
                                    ((Credito)a).VerificarLimite(pago,((Credito)a));
                                	Console.Write("\n\tPago ingresado correctamente.");
                                }
                             
                            }
                            
                            else if(Cliente.BuscarTarjeta(opcionOperacion) is Debito)
                           	
                            {                            	
                            	Tarjeta b=Cliente.BuscarTarjeta(opcionOperacion);
                            	Console.Write("\n\tHa seleccionado DEBITO.");
                            	Console.Write("\n\n\tDigite el saldo que desea cargar:");
                            	int monto=Convert.ToInt32(Console.ReadLine());
                            	((Debito)b).CargarSaldo(monto);
                                Console.Write("\n\tSaldo cargado con exito por $" + monto + ".");                           	
                            }

                            }
                       
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
                                case "1":
                                    Console.WriteLine("\n\n\t*****Listado de Clientes*****\n");

                                    if (lista.Count == 0)
                                        throw new Exception("No hay personas para listar.");

                                    //Ordena la lista de clientes alfabeticamente         
                                    IEnumerable<Cliente> listaOrdenada = lista.OrderBy(customer => customer.Nombre);
                                    foreach (Cliente customer in listaOrdenada)
                                    {                                       
                                        Console.WriteLine("- " + customer.Nombre + " " + customer.Apellido + " CI:" + customer.Cedula + " TEL:" + customer.Telefono + " Cantidad de tarjetas:" +customer.CantidadTarjetas );
                                    }

                                    break;

                                case "2":
                                    Console.WriteLine("\n\n\t*****Listado de Tarjetas*****\n");
                                    //lista Todas las tarjetas de la lista que esta en la clase Tarjetas
                                    if (lista.Count==0)
                                    	   throw new Exception("No hay clientes que tengan tarjetas registradas en nuestro sistema.");
                                    if (Cliente.listaTarjetas.Count == 0)
                                           throw new Exception("No hay tarjetas para listar.");

                                    foreach (Tarjeta tar in Cliente.listaTarjetas)
                                    {
                                        if (tar is Credito)
                                        {
                                            Console.WriteLine(((Credito)tar));
                                        }

                                        else
                                        {
                                            Console.WriteLine(((Debito)tar));
                                        }
                                    }
                           
                                    break;

                                case "3":
                                    Console.WriteLine("\n\n\t*****Listado de Pagos*****\n");

                                    Console.Write("\n\tIngrese el numero de tarjeta: ");
                                    int numTarjeta = Convert.ToInt32(Console.ReadLine());
                                    Cliente.BuscarTarjeta(numTarjeta);
                                    
                                    if(Cliente.BuscarTarjeta(numTarjeta) is Credito)
                                    {
	                                        if (Credito.listaPagos.Count == 0 ) 
	                                        {
			                                   Console.WriteLine("\n\tNo hay pagos para listar.");	
	                                        }
	                                        	                                    
	                                             else 
	                                        	 {
		                                    	 	 foreach(Pago pago in Credito.listaPagos)
					                                    {
					                                      Console.WriteLine("\n\t" + pago);
					                                    }
		                                    	 }
	                             
	                                }
                                    
                                    else 
                                    	Console.WriteLine("\n\tEl Nro.ingresado pertenece a una tarjeta de Débito.");
                                                                         
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
            Console.WriteLine("\n\n\t\t * * * FINANCIERA * * *\n");
            Console.WriteLine("\t 1- Mantenimiento de Clientes.\n");
            Console.WriteLine("\t 2- Solicitud de Tarjetas.\n");
            Console.WriteLine("\t 3- Carga de Saldo y Pago de Tarjeta.\n");
            Console.WriteLine("\t 4- Listados.\n");
            Console.WriteLine("\t 0- Salir.\n");
            Console.Write("\n\tIngrese la opción deseada: ");
        }

        //Busca un cliente en la lista por su cédula.
        static bool Buscar(List<Cliente> lista, string cedula)
        {
            foreach (Cliente cliente in lista)
            {
                if (cliente.Cedula == cedula)
                    return true;
            }
            
            return false;
        }

        //Elimina un cliente de la lista.
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

        //Modifica los datos de un cliente.
        static void Modificar(List<Cliente> lista, Cliente customerEdit, string cedula)
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

