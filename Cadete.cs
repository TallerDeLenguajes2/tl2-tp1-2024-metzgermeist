public class Cadete
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;


    public Cadete(int ID, string nombre, string direccion, string telefono)
    {
        id = ID;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
       
    }

    public int Id { get => id; }
    public string Nombre { get => nombre; }
    public string Direccion { get => direccion; }
    public string Telefono { get => telefono; }


    



    


}
