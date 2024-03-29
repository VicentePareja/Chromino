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

        public Tablero()
        {
        }

        public bool AgregarFicha(Ficha ficha, int x, int y)
        {
            if (!fichas.ContainsKey((x, y)))
            {
                fichas.Add((x, y), ficha);
                ImprimirTablero();
                return true;
            }
            return false;
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
