public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> losCadetes;
    public List<Cadete> LosCadetes { get => losCadetes;}

    public Cadeteria(string nom, string tel, List<Cadete> listaCadetes)
    {
        nombre = nom;
        telefono = tel;
        losCadetes = listaCadetes;
    }

    public void AsignarPedidoaCadete(Pedidos pedidoaAsignar, int id)
    {
        foreach (var cadete in losCadetes)
        {
            if (cadete.Id == id)
            {
                cadete.RecibirPedido(pedidoaAsignar);
            }
        }
    }
    public void CambiarEstadoPedido(Estado Nuevoestado, int id)
    {
        foreach (var cadete in losCadetes)
        {
            foreach (var pedido in cadete.ListaDepedidos)
            {
                if (pedido.Id == id)
                {
                    pedido.actualizarEstado(Nuevoestado);
                }
            }
        }
    }

    private Pedidos BuscarPedidoId(int idPedido)
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
    }

    public void ReasignarPedido(int idCadeteNuevo, int idpedido)
    {
        Pedidos pedidoAReasignar = BuscarPedidoId(idpedido);

        if (pedidoAReasignar != null)
        {
            foreach (var cadete in losCadetes)
            {
                if (cadete.Id == idCadeteNuevo)
                {
                    cadete.RecibirPedido(pedidoAReasignar);
                }
            }
            borrarpedido(pedidoAReasignar);
        }

    }



}