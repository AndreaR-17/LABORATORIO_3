class Program
{
    // Listas estáticas para almacenar estudiantes y sus calificaciones
    static List<string> estudiantes = new List<string>();
    static List<double> calificaciones = new List<double>();

    static void Main()
    {
        Console.WriteLine("Bienvenido al sistema de gestión de estudiantes.");

        while (true) // Bucle infinito hasta que el usuario seleccione salir
        {
            MostrarMenu(); // Muestra el menú de opciones
            int opcion = LeerEntero("Seleccione una opción: ", 1, 5); // Solicita una opción válida

            switch (opcion) // Evalúa la opción ingresada
            {
                case 1:
                    AgregarEstudiante();
                    break;
                case 2:
                    MostrarEstudiantes();
                    break;
                case 3:
                    CalcularPromedio();
                    break;
                case 4:
                    MostrarEstudianteConMayorCalificacion();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del sistema...");
                    return; // Termina la ejecución del programa
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    // Método para mostrar el menú de opciones en pantalla
    static void MostrarMenu()
    {
        Console.WriteLine("\n1. Agregar estudiante");
        Console.WriteLine("2. Mostrar lista de estudiantes");
        Console.WriteLine("3. Calcular promedio de calificaciones");
        Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
        Console.WriteLine("5. Salir");
    }

    // Método para agregar un estudiante y su calificación a las listas
    static void AgregarEstudiante()
    {
        string nombre;
        do
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            nombre = Console.ReadLine().Trim(); // Elimina espacios en blanco al inicio y final
            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío. Intente nuevamente.");
            }
        } while (string.IsNullOrEmpty(nombre)); // Se repite hasta que el nombre sea válido

        double calificacion = LeerDouble("Ingrese la calificación del estudiante (0 - 100): ", 0, 100);

        estudiantes.Add(nombre); // Agrega el nombre a la lista de estudiantes
        calificaciones.Add(calificacion); // Agrega la calificación a la lista de calificaciones
        Console.WriteLine("Estudiante agregado correctamente.");
    }

    // Método para mostrar todos los estudiantes registrados y sus calificaciones
    static void MostrarEstudiantes()
    {
        if (estudiantes.Count == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        Console.WriteLine("\nLista de estudiantes:");
        for (int i = 0; i < estudiantes.Count; i++)
        {
            Console.WriteLine($"{estudiantes[i]} - Calificación: {calificaciones[i]}");
        }
    }

    // Método para calcular y mostrar el promedio de las calificaciones
    static void CalcularPromedio()
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
            return;
        }

        double promedio = CalcularPromedioCalificaciones();
        Console.WriteLine($"El promedio de calificaciones es: {promedio:F2}");
    }

    // Método que calcula el promedio de las calificaciones almacenadas
    static double CalcularPromedioCalificaciones()
    {
        double suma = 0;
        foreach (double calificacion in calificaciones) // Suma todas las calificaciones
        {
            suma += calificacion;
        }
        return suma / calificaciones.Count; // Retorna el promedio
    }

    // Método para mostrar el estudiante con la calificación más alta
    static void MostrarEstudianteConMayorCalificacion()
    {
        if (calificaciones.Count == 0)
        {
            Console.WriteLine("No hay calificaciones registradas.");
            return;
        }

        (string estudianteMax, double maxCalificacion) = ObtenerEstudianteConMayorCalificacion();
        Console.WriteLine($"El estudiante con la calificación más alta es: {estudianteMax} con {maxCalificacion}");
    }

    // Método que obtiene el estudiante con la calificación más alta
    static (string, double) ObtenerEstudianteConMayorCalificacion()
    {
        double maxCalificacion = calificaciones[0]; // Inicializa con la primera calificación
        string estudianteMax = estudiantes[0]; // Inicializa con el primer estudiante

        for (int i = 1; i < calificaciones.Count; i++)
        {
            if (calificaciones[i] > maxCalificacion)
            {
                maxCalificacion = calificaciones[i]; // Actualiza la mayor calificación
                estudianteMax = estudiantes[i]; // Actualiza el estudiante con mejor calificación
            }
        }
        return (estudianteMax, maxCalificacion); // Retorna el estudiante con mejor nota
    }

    // Método para leer un número entero validado dentro de un rango específico
    static int LeerEntero(string mensaje, int min, int max)
    {
        int numero;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out numero) && numero >= min && numero <= max)
            {
                return numero; // Retorna el número si es válido
            }
            Console.WriteLine($"Entrada inválida. Ingrese un número entre {min} y {max}.");
        }
    }

    // Método para leer un número decimal validado dentro de un rango específico
    static double LeerDouble(string mensaje, double min, double max)
    {
        double numero;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out numero) && numero >= min && numero <= max)
            {
                return numero; // Retorna el número si es válido
            }
            Console.WriteLine($"Entrada inválida. Ingrese un número entre {min} y {max}.");
        }
    }
}
