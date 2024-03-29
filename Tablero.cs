// Tablero.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chromino
{
    public class Tablero
    {
        private Dictionary<(int, int), Ficha> fichas = new Dictionary<(int, int), Ficha>();
        // Matriz para marcar la disponibilidad de las casillas. Por simplicidad, vamos a asumir un tamaño fijo grande.
        // En una implementación real, podrías necesitar una estructura de datos más dinámica o compleja.
        private Dictionary<(int, int), bool> disponibilidadCasillas = new Dictionary<(int, int), bool>();

        public Tablero()
        {
            InicializarDisponibilidadCasillas();
        }

        private void InicializarDisponibilidadCasillas()
        {
            // Inicializa todas las casillas como disponibles. Ajusta los rangos según sea necesario.
            for (int i = -100; i <= 100; i++)
            {
                for (int j = -100; j <= 100; j++)
                {
                    disponibilidadCasillas[(i, j)] = true; // Marca inicialmente todas las casillas como disponibles
                }
            }
        }

        public bool AgregarFicha(Ficha ficha, int x, int y)
        {
            var posiciones = CalcularPosiciones(ficha, x, y);
            // Primero verifica si la jugada es válida
            if (posiciones.All(pos => disponibilidadCasillas.ContainsKey(pos) && disponibilidadCasillas[pos]))
            {
                // Marca las casillas como no disponibles
                foreach (var posicion in posiciones)
                {
                    disponibilidadCasillas[posicion] = false;
                }
            
                // Añade la ficha al tablero
                fichas.Add((x, y), ficha);
                ImprimirTablero();
                return true;
            }
            return false;
        }

        private List<(int, int)> CalcularPosiciones(Ficha ficha, int x, int y)
        {
            var posiciones = new List<(int, int)> { (x, y) }; // Incluye siempre la posición inicial

            // Añade las posiciones adicionales basadas en la dirección de la ficha
            switch (ficha.Direccion)
            {
                case Direccion.N:
                    posiciones.Add((x, y - 1));
                    posiciones.Add((x, y - 2));
                    break;
                case Direccion.E:
                    posiciones.Add((x - 1, y));
                    posiciones.Add((x - 2, y));
                    break;
                case Direccion.S:
                    posiciones.Add((x, y + 1));
                    posiciones.Add((x, y + 2));
                    break;
                case Direccion.O:
                    posiciones.Add((x + 1, y));
                    posiciones.Add((x + 2, y));
                    break;
            }

            return posiciones;
        }

        public void ImprimirTablero()
        {
            if (fichas.Count == 0)
            {
                Console.WriteLine("El tablero está vacío.");
                return;
            }

            int minX = fichas.Keys.Min(pos => pos.Item1) - 2;
            int maxX = fichas.Keys.Max(pos => pos.Item1) + 2;
            int minY = fichas.Keys.Min(pos => pos.Item2) - 2;
            int maxY = fichas.Keys.Max(pos => pos.Item2) + 2;

            var casillasConColor = new Dictionary<(int, int), string>();

            foreach (var fichaEntry in fichas)
            {
                var (x, y) = fichaEntry.Key;
                var ficha = fichaEntry.Value;
                // Coloca el primer color de la ficha en la posición original
                casillasConColor[(x, y)] = ficha.Color1;

                // Dependiendo de la dirección, ajusta la posición de los colores 2 y 3
                switch (ficha.Direccion)
                {
                    case Direccion.N:
                        casillasConColor[(x, y - 1)] = ficha.Color2;
                        casillasConColor[(x, y - 2)] = ficha.Color3;
                        break;
                    case Direccion.E:
                        casillasConColor[(x - 1, y)] = ficha.Color2;
                        casillasConColor[(x - 2, y)] = ficha.Color3;
                        break;
                    case Direccion.S:
                        casillasConColor[(x, y + 1)] = ficha.Color2;
                        casillasConColor[(x, y + 2)] = ficha.Color3;
                        break;
                    case Direccion.O:
                        casillasConColor[(x + 1, y)] = ficha.Color2;
                        casillasConColor[(x + 2, y)] = ficha.Color3;
                        break;
                }
            }

            for (int y = maxY; y >= minY; y--)
            {
                StringBuilder linea = new StringBuilder();
                for (int x = minX; x <= maxX; x++)
                {
                    if (casillasConColor.TryGetValue((x, y), out string color))
                    {
                        linea.Append(color + " ");
                    }
                    else
                    {
                        linea.Append("X ");
                    }
                }
                Console.WriteLine(linea.ToString());
            }
        }
        
        private bool PuedeAgregarFicha(Ficha ficha, int x, int y)
        {
            // Implementar la lógica para determinar si se puede agregar la ficha en la posición (x, y)
            return true;
        }
    }
}
