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
        Cadeteria NuestraCadeteria = losArchivos.CrearCadeteria();



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

                    var control = NuestraCadeteria.AsignarCadeteAlPedido(idAsignarCadete, idAsignarPedido);
                    if (control)
                    {
                        Console.WriteLine("pedido asignado con exito!! ");
                    }
                    else
                    {
                        Console.WriteLine("error al asignar el pedido, controle que haya ingresado bien los id correspondientes! ");

                    }

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


                        if (Enum.TryParse(eleccion, out nuevoEstado) && Enum.IsDefined(typeof(Estado), nuevoEstado))
                        {
                            Console.WriteLine("El nuevo estado del pedido es: " + nuevoEstado);
                        }
                        else
                        {
                            Console.WriteLine("Opción inválida. Por favor, ingresa un número válido.");
                        }
                    } while (!Enum.TryParse(eleccion, out nuevoEstado));

                    var control1 = NuestraCadeteria.CambiarEstadoPedido(nuevoEstado, idPedidoACambiarEstado);

                    if (control1)
                    {
                        Console.WriteLine("pedido cambio de estado con exito!  ");
                    }
                    else
                    {
                        Console.WriteLine("error al cambiar el pedido! ");

                    }

                    break;
                case 4:
                    Console.WriteLine(" -- para reasignar el pedido a otro cadete ingrese los siguientes datos: --");

                    Console.WriteLine("  ingrese el id del pedido que desea cambiar de cadete: ");
                    int idReasignarPedido = int.Parse(Console.ReadLine());

                    Console.WriteLine("  ingrese el id del nuevo cadete: ");
                    int idCadeteNuevo = int.Parse(Console.ReadLine());

                    var control2 = NuestraCadeteria.ReasignarPedido(idReasignarPedido, idCadeteNuevo);

                    if (control2)
                    {
                        Console.WriteLine("pedido se reasigno con exito!! ");
                    }
                    else
                    {
                        Console.WriteLine("error al reasignar el pedido! ");

                    }

                    break;
                case 5:
                    Console.WriteLine("  adios perril ");
                    break;

            }

        }
        //--crear informe y mostrarlo--//
        mostrarInformeGlobal(NuestraCadeteria);

        //--crear informes individuales y mostrarlo--//
        InformeCadetes Informeindividual = new InformeCadetes(NuestraCadeteria);
        
        var ListaDeInformes = Informeindividual.InformeCadetesJornada();
        
        foreach (var informe in ListaDeInformes)
        {
            Console.WriteLine("El id del cadete es: " + informe.Id);
            Console.WriteLine("El nombre del cadete es: " + informe.Nombre);
            Console.WriteLine("La cantidad de pedidos recibidos es: " + informe.CantidadDePedidosRecibidos1);
            Console.WriteLine("La cantidad de pedidos entregados es: " + informe.CantidadPedidosEntregados);
            Console.WriteLine("El Jornal Ganado es: " + informe.Jornal);
            Console.WriteLine("El promedio de pedidos entregados sobre recibidos: " + informe.Promedio);




        }




    }

    private static void mostrarInformeGlobal(Cadeteria NuestraCadeteria)
    {
        InformeCadeteria Informetotal = new InformeCadeteria(NuestraCadeteria);
        Console.WriteLine("La cantidad de pedidos recibidos es: " + Informetotal.CantidadDePedidosRecibidos1);
        Console.WriteLine("La cantidad de pedidos entregados es: " + Informetotal.CantidadPedidosEntregados);
        Console.WriteLine("La cantidad de pedidos cancelados  es: " + Informetotal.CantidadPedidosCancelados);
        Console.WriteLine("El costo total : " + Informetotal.CantidadDePedidosRecibidos1);
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