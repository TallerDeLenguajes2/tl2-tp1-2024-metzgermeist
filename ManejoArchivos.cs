using System.Text.Json;

public abstract class ManejoArchivosBase
{
    protected string rutaCadetes;
    protected string rutaCadeteria;

    public ManejoArchivosBase(string rutaCadetes, string rutaCadeteria)
    {
        this.rutaCadetes = rutaCadetes;
        this.rutaCadeteria = rutaCadeteria;
    }

    public abstract List<Cadete> DatosCadetes();
    public abstract Cadeteria CrearCadeteria();
}

public class ManejoArchivosCSV : ManejoArchivosBase
{
    public ManejoArchivosCSV() : base("cadetes.csv", "cadeteria.csv") { }

    public override List<Cadete> DatosCadetes()
    {
        List<Cadete> LosCadetes = new List<Cadete>();

        if (File.Exists(rutaCadetes) && new FileInfo(rutaCadetes).Length > 0)
        {
            using (var FlujoCadeteStream = new StreamReader(rutaCadetes))
            {
                while (!FlujoCadeteStream.EndOfStream)
                {
                    string linea = FlujoCadeteStream.ReadLine();
                    string[] Datoscadetess = linea.Split(',');
                    int id = int.Parse(Datoscadetess[0]);
                    string nombre = Datoscadetess[1];
                    string direccion = Datoscadetess[2];
                    string tel = Datoscadetess[3];
                    LosCadetes.Add(new Cadete(id, nombre, direccion, tel));
                }
            }
        }

        return LosCadetes;
    }

    public override Cadeteria CrearCadeteria()
    {
        Cadeteria cadeteriax = null;

        if (File.Exists(rutaCadeteria) && new FileInfo(rutaCadeteria).Length > 0)
        {
            string[] linea = File.ReadAllLines(rutaCadeteria);
            string primeraLinea = linea[0];
            string[] DatosCadeteriass = primeraLinea.Split(',');
            string nombre = DatosCadeteriass[0];
            string telefono = DatosCadeteriass[1];
            List<Cadete> NuestrosCadetes = DatosCadetes();
            cadeteriax = new Cadeteria(nombre, telefono, NuestrosCadetes);
        }

        return cadeteriax;
    }
}



public class ManejoArchivosJSON : ManejoArchivosBase
{
    public ManejoArchivosJSON() : base("cadetes.json", "cadeteria.json") { }

    public override List<Cadete> DatosCadetes()
    {
        List<Cadete> LosCadetes = new List<Cadete>();

        if (File.Exists(rutaCadetes) && new FileInfo(rutaCadetes).Length > 0)
        {
            string datos = File.ReadAllText(rutaCadetes);
            LosCadetes =JsonSerializer.Deserialize<List<Cadete>>(rutaCadetes);
        }

        return LosCadetes;
    }

    public override Cadeteria CrearCadeteria()
    {
        Cadeteria cadeteriax = null;

        if (File.Exists(rutaCadeteria) && new FileInfo(rutaCadeteria).Length > 0)
        {
            string jsonContent = File.ReadAllText(rutaCadeteria);
            cadeteriax = JsonSerializer.Deserialize<Cadeteria>(jsonContent);
        }

        return cadeteriax;
    }
}


public class ManejoArchivos
{
    private string rutaCadetes;

    private string rutaCadeteria;

    public ManejoArchivos()
    {
        rutaCadeteria = "cadeteria.csv";
        rutaCadetes = "cadetes.csv";
    }

    private List<Cadete> DatosCadetes()
    {
        List<Cadete> LosCadetes = new List<Cadete>();

        if (File.Exists(rutaCadetes) && new FileInfo(rutaCadetes).Length > 0)
        {
            using (var FlujoCadeteStream = new StreamReader(rutaCadetes))
            {
                while (!FlujoCadeteStream.EndOfStream)
                {
                    string linea = FlujoCadeteStream.ReadLine();
                    string[] Datoscadetess = linea.Split(',');
                    int id = int.Parse(Datoscadetess[0]);
                    string nombre = Datoscadetess[1];
                    string direccion = Datoscadetess[2];
                    string tel = Datoscadetess[3];
                    LosCadetes.Add(new Cadete(id, nombre, direccion, tel));
                }
                FlujoCadeteStream.Close();
            }
        }

        return LosCadetes;
    }

    public Cadeteria CrearCadeteria()
    {
        Cadeteria cadeteriax = null;

        if (File.Exists(rutaCadeteria) && new FileInfo(rutaCadeteria).Length > 0)
        {
            string[] linea = File.ReadAllLines(rutaCadeteria);
            string primeraLinea = linea[0];
            string[] DatosCadeteriass = primeraLinea.Split(',');
            string nombre = DatosCadeteriass[0];
            string telefono = DatosCadeteriass[1];
            List<Cadete> NuestrosCadetes = DatosCadetes();
            cadeteriax = new Cadeteria(nombre, telefono, NuestrosCadetes);

        }


        return cadeteriax;
    }
}