public class ManejoArchivos
{
    private string rutaCadetes;

    private string rutaCadeteria;

    public ManejoArchivos()
    {
        rutaCadeteria ="cadeteria.csv";
        rutaCadetes="cadetes.csv";
    }

    private List<Cadete> DatosCadetes()
    {
        List<Cadete> LosCadetes=new List<Cadete>();

        if (File.Exists(rutaCadetes) && new FileInfo(rutaCadetes).Length >0 )
        {
            using (var FlujoCadeteStream= new StreamReader(rutaCadetes))
            {
                while (!FlujoCadeteStream.EndOfStream)
                {
                    string linea=FlujoCadeteStream.ReadLine();
                    string[] Datoscadetess= linea.Split(',');
                    int id= int.Parse(Datoscadetess[0]);
                    string nombre= Datoscadetess[1];
                    string direccion= Datoscadetess[2];
                    string tel=Datoscadetess[3];
                    LosCadetes.Add(new Cadete(id, nombre, direccion, tel, new List<Pedidos>()));
                }
                FlujoCadeteStream.Close();
            }
        }

        return LosCadetes;
    }

    public Cadeteria CrearCadeteria()
    {
        Cadeteria  cadeteriax=null;

        if (File.Exists(rutaCadeteria) && new FileInfo(rutaCadeteria).Length >0)
        {
            string[] linea=File.ReadAllLines(rutaCadeteria);
            string primeraLinea=linea[0];
            string[] DatosCadeteriass = primeraLinea.Split(',');
            string nombre= DatosCadeteriass[0];
            string telefono= DatosCadeteriass[1];
            List<Cadete> NuestrosCadetes=DatosCadetes();
            cadeteriax=new Cadeteria(nombre,telefono,NuestrosCadetes);

        }


        return cadeteriax;
    }
}