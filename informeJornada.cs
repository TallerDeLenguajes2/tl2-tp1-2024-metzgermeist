
/*Mostrar un informe de pedidos al finalizar la jornada que incluya el monto ganado
y la cantidad de envíos de cada cadete y el total. Muestre también la cantidad de
envíos promedio por cadete.
*/

public class informeJornadaIndivual
{
    int id;

    string nombre;

    float jornalIndividual;

    int CantidadDePedidosRecibidos;

    int cantidadPedidosEntregados;

    float promedio;


    public informeJornadaIndivual(Cadete cadeteIndivudal)
    {
        this.id = cadeteIndivudal.Id;
        this.nombre = cadeteIndivudal.Nombre;
        this.jornalIndividual = cadeteIndivudal.JornalACobrar();
        this.CantidadDePedidosRecibidos = cadeteIndivudal.contadorPedidos(Estado.ingresado);
        this.cantidadPedidosEntregados = cadeteIndivudal.contadorPedidos(Estado.entregado);
        if (CantidadDePedidosRecibidos != 0)
        {
            this.promedio = (cantidadPedidosEntregados / CantidadDePedidosRecibidos) * 100;

        }
        else
        {
            promedio = 0;
        }
    }

    public float gastoIndividual()
    {
        return jornalIndividual;
    }



    public void MostrarInformeIndivual()
    {
        Console.WriteLine("El id: " + id);
    }

}

public class Informe
{
    private List<Cadete> cadetesInforme;


    public Informe(List<Cadete> cadetes)
    {
        cadetesInforme = cadetes;
    }

    private List<informeJornadaIndivual> InformeJornada()
    {
        List<informeJornadaIndivual> datosCadetesJornal = new List<informeJornadaIndivual>();

        foreach (var cadete in cadetesInforme)
        {
            datosCadetesJornal.Add(new informeJornadaIndivual(cadete));

        }
        return datosCadetesJornal;
    }

    private float GastoTotal()
    {
        var datosCadetesJornal = InformeJornada();
        float gasto = 0;

        foreach (var cadete in datosCadetesJornal)
        {
            gasto += cadete.gastoIndividual();
        }
        return gasto;
    }
    public void MostrarInforme()
    {
        var datosCadetesJornal = InformeJornada();

        foreach (var datos in datosCadetesJornal)
        {
            datos.MostrarInformeIndivual();
        }
        Console.WriteLine("el gasto total es= "+ GastoTotal());
    }

}

