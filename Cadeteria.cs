public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> losCadetes;
    public List<Cadete> LosCadetes { get => losCadetes; }
    public List<Pedidos> ListaDePedidos { get => listaDePedidos; }

    private List<Pedidos> listaDePedidos;

    public Cadeteria(string nom, string tel, List<Cadete> listaCadetes)
    {
        nombre = nom;
        telefono = tel;
        losCadetes = listaCadetes;
        listaDePedidos = new List<Pedidos>();
    }

    public void RecibirPedido(Pedidos pedido)
    {
        listaDePedidos.Add(pedido);
    }

    public Cadete buscarCadetePorID(int idCadete)
    {

        foreach (var cadete in losCadetes)
        {

            if (cadete.Id == idCadete)
            {
                return cadete;
            }

        }

        return null;
    }

    public Pedidos buscarPedidoPorID(int idPedido)
    {
        return listaDePedidos.Find(pedido => pedido.Id == idPedido);
    }

    public void AsignarCadeteAlPedido(int idCadete, int idPedido)
    {
        Pedidos pedido = buscarPedidoPorID(idPedido);
        Cadete cadeteAsignar = buscarCadetePorID(idCadete);



        if (pedido != null && cadeteAsignar != null)
        {
            if (pedido.CadeteAsginado == null)
            {
                pedido.RecibirCadete(cadeteAsignar);

            }
            else
            {
                Console.WriteLine("\n");
                Console.WriteLine("El pedido ya tiene un cadete asignado.");
                Console.WriteLine("\n");

            }
        }
        else
        {
            Console.WriteLine("\n");
            Console.WriteLine("PONE BIEN EL ID GORDO CARNERO");
            Console.WriteLine("\n");
        }


    }

    public void CambiarEstadoPedido(Estado Nuevoestado, int id)
    {
        bool bandera = false;
        foreach (var pedido in listaDePedidos)
        {
            if (pedido.Id == id)
            {
                pedido.actualizarEstado(Nuevoestado);
                bandera = true;

            }
        }
        if (bandera)
        {
            Console.WriteLine("Cambiado con exito!");

        }
        else
        {
            Console.WriteLine("si seras pelotudo, pone bien los datos");
        }

    }


    public float JornalACobrarDelCadete(int idCadete)
    {
        int contadorPedidos = 0;
        foreach (var pedido in listaDePedidos)
        {
            if (pedido.CadeteAsginado.Id == idCadete)
            {
                contadorPedidos++;
            }
        }
        return contadorPedidos * 500;
    }


    public void ReasignarPedido(int idCadeteNuevo, int idpedido)
    {
        Cadete cadeteAsignar = buscarCadetePorID(idCadeteNuevo);

        if (cadeteAsignar != null)
        {
            foreach (var pedido in listaDePedidos)
            {
                if (pedido.Id == idpedido)
                {
                    pedido.RecibirCadete(cadeteAsignar);
                }
            }

        }
        else
        {
            Console.WriteLine(" pone bien los datos");
        }

    }

    public int contadorPedidos(Estado buscado)
    {
        int cantidadPedidos = 0;

        foreach (var pedido in listaDePedidos)
        {
            if (pedido.Estado == buscado)
            {
                cantidadPedidos++;
            }
        }

        return cantidadPedidos;
    }

    public int contadorPedidosParaCadetes(int id, Estado buscado)
    {
        int cantidadPedidos = 0;

        foreach (var pedido in listaDePedidos)
        {
            if (pedido.CadeteAsginado.Id == id && pedido.Estado == buscado)
            {

                cantidadPedidos++;

            }
        }

        return cantidadPedidos;
    }

    /* private Pedidos BuscarPedidoId(int idPedido)
     {
         Pedidos pedidoDevuelto = null;

         foreach (var cadete in losCadetes)
         {
             foreach (var pedido in cadete.ListaDepedidos)
             {
                 if (pedido.Id == idPedido)
                 {
                     pedidoDevuelto = pedido;

                 }
             }
         }
         return pedidoDevuelto;

     }

     public void borrarpedido(Pedidos pedido)
     {
         foreach (var cadete in losCadetes)
         {
             for (int i = cadete.ListaDepedidos.Count; i >= 0; i--)
             {
                 if (cadete.ListaDepedidos[i] == pedido)
                 {
                     cadete.ListaDepedidos.RemoveAt(i);
                 }
             }
         }
     }*/




}