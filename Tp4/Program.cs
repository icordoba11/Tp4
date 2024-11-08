using System.Xml.Serialization;
using Tp4;

public class Program
{
    private static List<Vuelo> vuelos = new List<Vuelo>();
    private static string filePath = "vuelos.xml";

    public static void Main()
    {
        CargarDatos();

        int opcion;
        do
        {
            Console.WriteLine("1. Agregar Vuelo");
            Console.WriteLine("2. Registrar Pasajeros en Vuelo");
            Console.WriteLine("3. Calcular Ocupación Media de la Flota");
            Console.WriteLine("4. Vuelo con Mayor Ocupación");
            Console.WriteLine("5. Buscar Vuelo por Código");
            Console.WriteLine("6. Listar Vuelos Ordenados por Ocupación");
            Console.WriteLine("7. Guardar y Salir");
            Console.WriteLine("0. Salir sin guardar");
            Console.Write("Seleccione una opción: ");
            try
            {
                opcion = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                opcion = 100;
            }

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("-----------Carga de Nuevo Vuelo-----------\n");
                    AgregarVuelo();
                    Console.WriteLine("-----------Presione cualquier tecla para continuar-----------");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("-----------Registro de Pasajeros-----------\n");
                    RegistrarPasajeros();
                    Console.WriteLine("-----------Presione cualquier tecla para continuar-----------");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("-----------Calcular ocupacion del vuelo-----------\n");
                    CalcularOcupacionMedia();
                    Console.WriteLine("-----------Presione cualquier tecla para continuar-----------");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("-----------Mostrar vuelo de mayor ocupacion-----------\n");
                    MostrarVueloMayorOcupacion();
                    Console.WriteLine("-----------Presione cualquier tecla para continuar-----------");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("-----------Busqueda de Vuelo-----------\n");
                    BuscarVuelo();
                    Console.WriteLine("-----------Presione cualquier tecla para continuar-----------");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("-----------Listado de vuelos por ocupacion-----------\n");
                    ListarVuelosPorOcupacion();
                    Console.WriteLine("-----------Presione cualquier tecla para continuar-----------");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("-----------Guardado de datos-----------\n");
                    GuardarDatos();
                    Console.WriteLine("-----------Presione cualquier tecla para continuar-----------");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("Hasta luego!!");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opción no válida.");
                    Console.WriteLine("-----------Presione cualquier tecla para continuar-----------");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        } while (opcion != 0);
    }

    private static void AgregarVuelo()
    {
        string codigo;
        DateTime fechaSalida, fechaLlegada;
        TimeSpan horaSalida, horaLlegada;
        string piloto, copiloto;
        int capacidad;

        do
        {
            Console.Write("Código de vuelo: ");
            codigo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(codigo))
            {
                Console.WriteLine("El código de vuelo no puede estar vacío. Intente nuevamente.");
                Thread.Sleep(700);
                Console.Clear();
            }
        } while (string.IsNullOrWhiteSpace(codigo));


        do
        {
            try
            {
                Console.Write("Fecha de salida (dd/MM/yyyy): ");
                fechaSalida = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de fecha inválido. Intente nuevamente.");
                Thread.Sleep(1000);
                Console.Clear();
            }
        } while (true);


        do
        {
            try
            {
                Console.Write("Fecha de llegada (dd/MM/yyyy): ");
                fechaLlegada = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                if (fechaLlegada < fechaSalida)
                {
                    Console.WriteLine("La fecha de llegada debe ser igual o posterior a la fecha de salida.");
                    Thread.Sleep(700);
                    Console.Clear();
                    continue;
                }
                break;
            }
            catch (FormatException)
            {

                Console.WriteLine("Formato de fecha inválido. Intente nuevamente.");
                Thread.Sleep(700);
                Console.Clear();
            }
        } while (true);


        do
        {
            try
            {
                Console.Write("Hora de salida (HH:mm): ");
                horaSalida = TimeSpan.ParseExact(Console.ReadLine(), "hh\\:mm", null);

                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de hora inválido. Intente nuevamente.");
                Thread.Sleep(700);
                Console.Clear();
            }
        } while (true);

        do
        {
            try
            {
                Console.Write("Hora de llegada (HH:mm): ");
                horaLlegada = TimeSpan.ParseExact(Console.ReadLine(), "hh\\:mm", null);



                if (fechaLlegada == fechaSalida && horaLlegada <= horaSalida)
                {
                    Console.WriteLine("La hora de llegada debe ser posterior a la hora de salida en la misma fecha.");
                    Thread.Sleep(700);
                    Console.Clear();
                    continue;
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de hora inválido. Intente nuevamente.");
                Thread.Sleep(700);
                Console.Clear();
            }
        } while (true);


        do
        {
            Console.Write("Nombre del piloto: ");
            piloto = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(piloto))
            {
                Console.WriteLine("El nombre del piloto no puede estar vacío. Intente nuevamente.");
                Thread.Sleep(700);
                Console.Clear();
            }
        } while (string.IsNullOrWhiteSpace(piloto));


        do
        {
            Console.Write("Nombre del copiloto: ");
            copiloto = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(copiloto))
            {
                Console.WriteLine("El nombre del copiloto no puede estar vacío. Intente nuevamente.");
                Thread.Sleep(700);
                Console.Clear();
            }
        } while (string.IsNullOrWhiteSpace(copiloto));


        do
        {
            try
            {
                Console.Write("Capacidad máxima: ");
                capacidad = int.Parse(Console.ReadLine());

                if (capacidad <= 0)
                {
                    Console.WriteLine("La capacidad máxima debe ser un número positivo. Intente nuevamente.");
                    Thread.Sleep(700);
                    Console.Clear();
                    continue;
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Valor inválido. Ingrese un número entero positivo.");
                Thread.Sleep(700);
                Console.Clear();
            }
        } while (true);


        vuelos.Add(new Vuelo(codigo, fechaSalida, fechaLlegada, piloto, copiloto, capacidad));
        Console.WriteLine("Vuelo agregado exitosamente.");
    }


    private static void RegistrarPasajeros()
    {
        Console.Write("Código de vuelo: ");
        string codigo = Console.ReadLine();
        Vuelo vuelo = vuelos.FirstOrDefault(v => v.Codigo == codigo);

        if (vuelo != null)
        {
            Console.Write("Número de pasajeros que subieron: ");
            int pasajeros = int.Parse(Console.ReadLine());

            if (vuelo.PasajerosRegistrados + pasajeros <= vuelo.CapacidadMaxima)
            {
                vuelo.PasajerosRegistrados += pasajeros;
                Console.WriteLine("Pasajeros registrados exitosamente.");
            }
            else
            {
                Console.WriteLine("Capacidad excedida. Registro fallido.");
            }
        }
        else
        {
            Console.WriteLine("Vuelo no encontrado.");
        }
    }

    private static void CalcularOcupacionMedia()
    {
        if (vuelos.Count > 0)
        {
            double ocupacionMedia = vuelos.Average(v => v.ObtenerOcupacion());
            Console.WriteLine($"Ocupación media de la flota: {ocupacionMedia:F2}%");
        }
        else
        {
            Console.WriteLine("No hay vuelos registrados.");
        }
    }

    private static void MostrarVueloMayorOcupacion()
    {
        if (vuelos.Count > 0)
        {
            Vuelo vueloMayorOcupacion = vuelos.OrderByDescending(v => v.ObtenerOcupacion()).First();
            Console.WriteLine($"Vuelo con mayor ocupación: {vueloMayorOcupacion.Codigo} - {vueloMayorOcupacion.ObtenerOcupacion():F2}%");
        }
        else
        {
            Console.WriteLine("No hay vuelos registrados.");
        }
    }

    private static void BuscarVuelo()
    {
        Console.Write("Código de vuelo: ");
        string codigo = Console.ReadLine();
        Vuelo vuelo = vuelos.FirstOrDefault(v => v.Codigo == codigo);

        if (vuelo != null)
        {
            Console.WriteLine($"Código: {vuelo.Codigo}, Salida: {vuelo.FechaHoraSalida}, Llegada: {vuelo.FechaHoraLlegada}");
            Console.WriteLine($"Piloto: {vuelo.Piloto}, Copiloto: {vuelo.Copiloto}, Capacidad: {vuelo.CapacidadMaxima}");
            Console.WriteLine($"Pasajeros registrados: {vuelo.PasajerosRegistrados}, Ocupación: {vuelo.ObtenerOcupacion():F2}%");
        }
        else
        {
            Console.WriteLine("Vuelo no encontrado.");
        }
    }

    private static void ListarVuelosPorOcupacion()
    {
        var vuelosOrdenados = vuelos.OrderByDescending(v => v.ObtenerOcupacion()).ToList();
        foreach (var vuelo in vuelosOrdenados)
        {
            Console.WriteLine($"Código: {vuelo.Codigo}, Ocupación: {vuelo.ObtenerOcupacion():F2}%");
        }
    }

    private static void GuardarDatos()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Vuelo>));
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(stream, vuelos);
        }
        Console.WriteLine("Datos guardados exitosamente.");
    }

    private static void CargarDatos()
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Vuelo>));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                vuelos = (List<Vuelo>)serializer.Deserialize(stream);
            }
            Console.WriteLine("Datos cargados exitosamente.");
        }
    }
}
