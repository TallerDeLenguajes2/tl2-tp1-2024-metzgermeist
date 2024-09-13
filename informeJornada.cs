
/*Mostrar un informe de pedidos al finalizar la jornada que incluya el monto ganado
y la cantidad de envíos de cada cadete y el total. Muestre también la cantidad de
envíos promedio por cadete.
*/

public class InformeIndividualCadete
{
     int id;

    string nombre;

    float jornal;

    int CantidadDePedidosRecibidos;

    int cantidadPedidosEntregados;

    float promedio;


    public InformeIndividualCadete(int id, string nombre, float jornal,int CantidadDePedidosRecibidos,int cantidadPedidosEntregados,float promedio)
    {
        this.id = id;
        this.nombre=nombre;
        this.jornal=jornal;
        this.CantidadDePedidosRecibidos=CantidadDePedidosRecibidos;
        this.cantidadPedidosEntregados=cantidadPedidosEntregados;
        this.promedio=promedio;

    }

    public int Id { get => id;  }
    public string Nombre { get => nombre;  }
    public float Jornal { get => jornal;  }
    public int CantidadDePedidosRecibidos1 { get => CantidadDePedidosRecibidos;  }
    public int CantidadPedidosEntregados { get => cantidadPedidosEntregados; }
    public float Promedio { get => promedio; }
}

public class InformeCadetes
{

    private readonly Cadeteria cadeteria;

    public InformeCadetes(Cadeteria cadeteria)
    {
        this.cadeteria = cadeteria;
    }

    public List<InformeIndividualCadete> InformeCadetesJornada()
    {
        List<InformeIndividualCadete> datosCadetesJornal = new List<InformeIndividualCadete>();

        foreach (var cadeteX in cadeteria.LosCadetes)
        {
            float jornal = cadeteria.JornalACobrarDelCadete(cadeteX.Id);
            int CantidadDePedidosRecibidos = cadeteria.contadorPedidosParaCadetes(cadeteX.Id, Estado.ingresado);
            int CantidadDePedidosentregados = cadeteria.contadorPedidosParaCadetes(cadeteX.Id, Estado.entregado);
            float promedio;
            if (CantidadDePedidosentregados!=0)
            {
                promedio = (CantidadDePedidosentregados/CantidadDePedidosRecibidos)*100;
                
            }
            else
            {
                promedio=0;
            }

            var Informecadete = new InformeIndividualCadete(cadeteX.Id,cadeteX.Nombre,jornal,CantidadDePedidosRecibidos,CantidadDePedidosentregados,promedio);

            datosCadetesJornal.Add(Informecadete);

        }
        return datosCadetesJornal;
    }
     
    

}
/*--------------------------------------------------------------------------------------------------------------*/
public class InformeCadeteria
{
    private Cadeteria cadeterias;
    private int cantidadPedidosEntregados;

    private int CantidadDePedidosRecibidos;

    private int cantidadPedidosCancelados;

    private float costoDiario;

    public int CantidadPedidosEntregados { get => cantidadPedidosEntregados; }
    public int CantidadDePedidosRecibidos1 { get => CantidadDePedidosRecibidos; }
    public int CantidadPedidosCancelados { get => cantidadPedidosCancelados; }
    public float CostoDiario { get => costoDiario;  }

    public InformeCadeteria(Cadeteria cadeterias)
    {
        this.cadeterias = cadeterias;
        this.cantidadPedidosEntregados = contadorPedidos(Estado.entregado);
        this.cantidadPedidosCancelados = contadorPedidos(Estado.cancelado);
        this.CantidadDePedidosRecibidos = contadorPedidos(Estado.ingresado);
        this.costoDiario = costototal();
    }

    private float costototal()
    {
        float costo = 0;

        foreach (var cadete in cadeterias.LosCadetes)
        {
            costo += cadeterias.JornalACobrarDelCadete(cadete.Id);
        }

        return costo;
    }

    public int contadorPedidos(Estado buscado)
    {
        int cantidadPedidos = 0;

        foreach (var pedido in cadeterias.ListaDePedidos)
        {
            if (pedido.Estado == buscado)
            {
                cantidadPedidos++;
            }
        }

        return cantidadPedidos;
    }

}

