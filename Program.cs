internal class Program
{

    private static void Main(string[] args)
    {
        Console.WriteLine("Seleccione el formato de archivo:");
        Console.WriteLine("1. CSV");
        Console.WriteLine("2. JSON");
        string seleccion = Console.ReadLine();

        ManejoArchivosBase losArchivos;

        switch (seleccion)
        {
            case "1":
                losArchivos = new ManejoArchivosCSV();
                break;
            case "2":
                losArchivos = new ManejoArchivosJSON();
                break;
            default:
                Console.WriteLine("Opción no válida.");
                return;
        }
    
        //--crear la cadeteria--//
        Cadeteria  NuestraCadeteria= losArchivos.CrearCadeteria();
  
        

        int opcion = 1;

        while (opcion != 5)

        {
            Console.WriteLine("¿que accion desea realizar? ");
            Console.WriteLine("1)-- Dar de alta pedido --");
            Console.WriteLine("2)-- Asignar pedido a un cadete --");
            Console.WriteLine("3)-- Cambiar estado del pedido --");
            Console.WriteLine("4)-- reasignar pedido a otro cadete --");
            Console.WriteLine("5)-- Apagar --");


            bool resultado;
            bool opcionCorrecta = true;

            do
            {
                string input = Console.ReadLine();
                resultado = int.TryParse(input, out opcion);
                if (!resultado || opcion < 0 || opcion > 5)
                {
                    opcionCorrecta = false;
                    Console.WriteLine("Ingrese una opción válida");
                }

            } while (!opcionCorrecta);


            switch (opcion)
            {
                case 1:

                    //--varaibles para poder crear los clientes--//
                    string nombre, direccion, telefono, referencia;


                    Console.WriteLine("***  usted esta por dar de alta un pedido nuevo, por favor introduza los siguientes datos  ***");
                    Console.WriteLine("\n");
                    Console.WriteLine("***  primero daremos de alta el cliente  ***");

                    nombre = ControlDatosEntrada("introduzca el nombre del cliente: ");

                    direccion = ControlDatosEntrada("introduzca la direccion del cliente: ");

                    telefono = ControlDatosEntrada("introduzca el telefono del cliente: ");

                    referencia = ControlDatosEntrada("introduzca la direccion referencia del cliente: ");

                    Console.WriteLine("\n");
                    Console.WriteLine("Cliente agregado con éxito!");

                    Console.WriteLine("*** ahora alta del pedido  ***");

                    Console.WriteLine("introduzca el codigo identificacion(id) del pedido: ");
                    int id = int.Parse(Console.ReadLine());

                    string observacion = ControlDatosEntrada("introduzca alguna observacion del pedido: ");

                    Pedidos pedidoNuevo = new Pedidos(id, observacion, Estado.ingresado, nombre, direccion, telefono, referencia);
                    NuestraCadeteria.RecibirPedido(pedidoNuevo);

                    break;


                case 2:

                    //--varaibles para asignar un pedido--//
                    
                    Console.WriteLine("***  usted esta por asignar el pedido a un cadete  ***");

                    Console.WriteLine("introduzca el id del cadete al cual quiere asignarle el pedido: ");
                    int idAsignarCadete = int.Parse(Console.ReadLine()); //revisar y hacerlo mas seguro//

                    Console.WriteLine("introduzca el id del pedido que quiere asignar : ");
                    int idAsignarPedido = int.Parse(Console.ReadLine()); //revisar y hacerlo mas seguro//

                    NuestraCadeteria.AsignarCadeteAlPedido(idAsignarCadete,idAsignarPedido);

                    break;

                case 3:
                    Console.WriteLine(" --  ingrese el id del pedido que desea cambiar su estado: -- ");
                    int idPedidoACambiarEstado = int.Parse(Console.ReadLine());

                    //--varaibles para cambiar el estado del pedido--//
                    Console.WriteLine("¿cual es el nuevo estado del pedido? ");
                    Console.WriteLine("1) --  Despachado -- ");
                    Console.WriteLine("2) --  Entregado -- ");
                    Console.WriteLine("3) --  Cancelado --");

                    Estado nuevoEstado;
            
                    string eleccion;
                    do
                    {
                        // Leer la opción ingresada por el usuario
                        eleccion = Console.ReadLine();

                        /*
                        bool resultadoEstado = int.TryParse(eleccion, out nroEstado);
                        nuevoEstado = (Estado)nroEstado;
                        */

                        // Intentar convertir la opción en un valor del enum Estado
                
                        if (Enum.TryParse(eleccion, out nuevoEstado) && Enum.IsDefined(typeof(Estado), nuevoEstado))
                        {
                            Console.WriteLine("El nuevo estado del pedido es: "+ nuevoEstado);
                        }
                        else
                        {
                            Console.WriteLine("Opción inválida. Por favor, ingresa un número válido.");
                        }
                    } while (!Enum.TryParse(eleccion, out nuevoEstado));

                    NuestraCadeteria.CambiarEstadoPedido(nuevoEstado, idPedidoACambiarEstado);




                    break;
                case 4:
                    Console.WriteLine(" -- para reasignar el pedido a otro cadete ingrese los siguientes datos: --");

                    Console.WriteLine("  ingrese el id del pedido que desea cambiar de cadete: ");
                    int idReasignarPedido = int.Parse(Console.ReadLine());

                    Console.WriteLine("  ingrese el id del nuevo cadete: ");
                    int idCadeteNuevo = int.Parse(Console.ReadLine());

                   NuestraCadeteria.ReasignarPedido(idReasignarPedido, idCadeteNuevo);

                    break;
                case 5:
                    Console.WriteLine("  adios perril ");
                    break;
                
            }

        }
        //--crear informe--//
        InformeCadeteria Informetotal =new InformeCadeteria(NuestraCadeteria);
        Informetotal.MostrarInforme();
        InformeCadetes Informeindividual =new InformeCadetes(NuestraCadeteria);
        Informeindividual.MostrarInforme();
        
        

    }

    private static string ControlDatosEntrada(string mensaje)
    {
        string input;
        do
        {
            Console.WriteLine(mensaje);
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input) && string.IsNullOrWhiteSpace(input));
        return input;
    }


}