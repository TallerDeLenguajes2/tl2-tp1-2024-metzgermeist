public enum Estado
{
    ingresado,
    despachado,
    entregado,
    cancelado
}

public class Pedidos
{
    private int id;
    private string observacion;
    private Cliente cliente;
    private Estado estadoDelPedido;

    public int Id { get => id; }
    public string Observacion { get => observacion; }
    public Cliente Cliente { get => cliente; }
    public Estado Estado { get => estadoDelPedido; }

    public Pedidos(int num, string obs, Estado estadoPedido, string nombre, string direccion, string tel, string refe)
    {
        cliente = new Cliente(nombre, direccion, tel, refe);
        id = num;
        observacion = obs;
        estadoDelPedido = estadoPedido;
    }
    public void VerDireccionCliente()
    {

        Console.WriteLine(cliente.Direccion);

    }
    public void VerDatosClient()
    {

        Console.WriteLine(cliente.Direccion);

    }

    public void actualizarEstado(Estado nuevoEstado)
    {
        estadoDelPedido = nuevoEstado;
    }

   

}

