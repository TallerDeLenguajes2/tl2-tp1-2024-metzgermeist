public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> losCadetes;
    private List<Pedidos> listaDePedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> LosCadetes { get => losCadetes; set => losCadetes = value; }
    public List<Pedidos> ListaDePedidos { get => listaDePedidos; set => listaDePedidos = value; }

    public Cadeteria(string nom, string tel, List<Cadete> listaCadetes)
    {
        nombre = nom;
        telefono = tel;
        losCadetes = listaCadetes;
        listaDePedidos = new List<Pedidos>();
    }

    public Cadeteria()
    {
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

    public bool AsignarCadeteAlPedido(int idCadete, int idPedido)
    {
        Pedidos pedido = buscarPedidoPorID(idPedido);
        Cadete cadeteAsignar = buscarCadetePorID(idCadete);



        if (pedido != null && cadeteAsignar != null)
        {
            if (pedido.CadeteAsginado == null)
            {
                pedido.RecibirCadete(cadeteAsignar);
                return true;

            }
            else
            {
                return false;

            }
        }
        else
        {
            return false;
        }


    }

    public bool CambiarEstadoPedido(Estado Nuevoestado, int id)
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
            return true;

        }
        else
        {
           return false;
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


    public bool ReasignarPedido(int idCadeteNuevo, int idpedido)
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
            return true;

        }
        else
        {
            return false;
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

    



}