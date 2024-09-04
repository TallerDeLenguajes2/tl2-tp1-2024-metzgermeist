public class pedidosTemp
{
    //-- campos --//
    private List<Pedidos> todosLosPedidos;

    public pedidosTemp()
    {
        todosLosPedidos= new List<Pedidos>();
    }

    //-- metodos --//
    public void AgregarPedidoaLista(Pedidos pedido)
    {
        todosLosPedidos.Add(pedido);
    }
    public Pedidos buscarPedidoDeLista(int id)
    {   
        Pedidos pedidoR=null;
        
        foreach (var pedido in todosLosPedidos)
        {
            if (pedido.Id==id)
            {
                pedidoR=pedido;
            }
        }
        
        return pedidoR;
    }
   
}
