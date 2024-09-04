public class Cliente
{
    private string nombre;
    private string direccion;
    private string telefono; 
    private string referencia; 

    public Cliente(string nombre,string direccion, string tel,string refe)
    {
        this.nombre=nombre;
        this.direccion=direccion;
        this.telefono=tel;
        this.referencia=refe;
    }

    public string Nombre { get => nombre; }
    public string Direccion { get => direccion;}
    public string Telefono { get => telefono;}
    public string Referencia { get => referencia;}
}