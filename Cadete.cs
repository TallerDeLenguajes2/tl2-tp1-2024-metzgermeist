public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedidos> listaDepedidos;

    public Cadete(int ID, string nombre, string direccion, string telefono, List<Pedidos> listaDepedidos)
    {
        id = ID;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.listaDepedidos = listaDepedidos;
    }

    public int Id { get => id; }
    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }
    public List<Pedidos> ListaDepedidos { get => listaDepedidos; }

    public void RecibirPedido(Pedidos pedido)
    {
        listaDepedidos.Add(pedido);
    }

    public int contadorPedidos(Estado buscado)
    {
        int cantidadPedidos = 0;
        
        foreach (var pedido in listaDepedidos)
        {
            if (pedido.Estado == buscado)
            {
                cantidadPedidos++;
            }
        }

        return cantidadPedidos;
    }

    public float JornalACobrar()
    {
       int cantidadPedidosEntregados = contadorPedidos(Estado.entregado);

        return 500 * cantidadPedidosEntregados;
    }


}

