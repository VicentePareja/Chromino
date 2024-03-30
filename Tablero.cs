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
  
        private Dictionary<(int, int), bool> disponibilidadCasillas = new Dictionary<(int, int), bool>();
        private Dictionary<(int, int), string> casillasConColor = new Dictionary<(int, int), string>();

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

        IEnumerable<(int, int)> CasillasAdyacentesC1(int x, int y, Direccion direccion)
        {
            switch (direccion)
            {
                case Direccion.N:
                    return new[] { (x - 1, y), (x + 1, y), (x, y + 1) };
                case Direccion.E:
                    return new[] { (x - 1, y), (x, y - 1), (x, y + 1) };
                case Direccion.S:
                    return new[] { (x - 1, y), (x + 1, y), (x, y - 1) };
                case Direccion.O:
                    return new[] { (x + 1, y), (x, y - 1), (x, y + 1) };
                default:
                    return Enumerable.Empty<(int, int)>();
            }
        }
        
        IEnumerable<(int, int)> CasillasAdyacentesC2(int x, int y, Direccion direccion)
        {
            switch (direccion)
            {
                case Direccion.N:
                case Direccion.S:
                    return new[] { (x - 1, y), (x + 1, y) };
                case Direccion.E:
                case Direccion.O:
                    return new[] { (x, y - 1), (x, y + 1) };
                default:
                    return Enumerable.Empty<(int, int)>();
            }
        }
        
        IEnumerable<(int, int)> CasillasAdyacentesC3(int x, int y, Direccion direccion)
        {
            switch (direccion)
            {
                case Direccion.N:
                    return new[] { (x, y - 2), (x - 1, y - 1), (x + 1, y - 1) };
                case Direccion.E:
                    return new[] { (x - 2, y), (x - 1, y - 1), (x - 1, y + 1) };
                case Direccion.S:
                    return new[] { (x, y + 2), (x - 1, y + 1), (x + 1, y + 1) };
                case Direccion.O:
                    return new[] { (x + 2, y), (x + 1, y - 1), (x + 1, y + 1) };
                default:
                    return Enumerable.Empty<(int, int)>();
            }
        }

        public bool JugadaLegal(Ficha ficha, int x, int y)
{
    var posicionesFicha = CalcularPosiciones(ficha, x, y);

    int coincidencias = 0;


    foreach (var pos in CasillasAdyacentesC1(x, y, ficha.Direccion))
    {
        if (casillasConColor.TryGetValue(pos, out string color))
        {
            if (color != ficha.Color1 && color != "C")
            {
      
                return false;
            }
            if (color == ficha.Color1 || color == "C")
            {
                coincidencias++;
            }
        }
    }

    var posC2 = posicionesFicha[1];
    var posC3 = posicionesFicha[2];

    // Verificar adyacencias y coincidencias de color para C2.
    foreach (var pos in CasillasAdyacentesC2(posC2.Item1, posC2.Item2, ficha.Direccion))
    {
        if (casillasConColor.TryGetValue(pos, out string color))
        {
            if (color != ficha.Color2 && color != "C")
            {
                // Retorna falso si se encuentra un color diferente que no es un comodín.
                return false;
            }
            if (color == ficha.Color2 || color == "C")
            {
                coincidencias++;
            }
        }
    }


    foreach (var pos in CasillasAdyacentesC3(posC3.Item1, posC3.Item2, ficha.Direccion))
    {
        if (casillasConColor.TryGetValue(pos, out string color))
        {
            if (color != ficha.Color3 && color != "C")
            {
 
                return false;
            }
            if (color == ficha.Color3 || color == "C")
            {
                coincidencias++;
            }
        }
    }


    return coincidencias >= 2;
}
        

        public bool AgregarFicha(Ficha ficha, int x, int y)
        {

            var posiciones = CalcularPosiciones(ficha, x, y);

            if (posiciones.All(pos => disponibilidadCasillas.ContainsKey(pos) && disponibilidadCasillas[pos]) && JugadaLegal(ficha, x, y))
            {
    
                foreach (var posicion in posiciones)
                {
                    disponibilidadCasillas[posicion] = false;
               
                    if(posicion == posiciones[0]) // Posición para C1
                        casillasConColor[posicion] = ficha.Color1;
                    else if(posicion == posiciones[1]) // Posición para C2
                        casillasConColor[posicion] = ficha.Color2;
                    else if(posicion == posiciones[2]) // Posición para C3
                        casillasConColor[posicion] = ficha.Color3;
                }


                fichas.Add((x, y), ficha);
  
                ImprimirTablero();

                return true;
            }
            else
            {      
                ImprimirTablero();
                return false;
            }
        }


        private List<(int, int)> CalcularPosiciones(Ficha ficha, int x, int y)
        {
            var posiciones = new List<(int, int)> { (x, y) }; // Incluye siempre la posición inicial

       
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
        
        

        private List<(int, int)> ObtenerCasillasAdyacentes((int x, int y) posicion)
        {
            return new List<(int, int)>
            {
                (posicion.x + 1, posicion.y),
                (posicion.x - 1, posicion.y),
                (posicion.x, posicion.y + 1),
                (posicion.x, posicion.y - 1)
            };
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

            foreach (var fichaEntry in fichas)
            {
                var (x, y) = fichaEntry.Key;
                var ficha = fichaEntry.Value;

                casillasConColor[(x, y)] = ficha.Color1;

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
        
        public void AgregarFichaForzado(Ficha ficha, int x, int y)
        {
           
            var posiciones = CalcularPosiciones(ficha, x, y);

            
            foreach (var posicion in posiciones)
            {
                disponibilidadCasillas[posicion] = false; 
                if(posicion == posiciones[0]) // Posición para C1
                    casillasConColor[posicion] = ficha.Color1;
                else if(posicion == posiciones[1]) // Posición para C2
                    casillasConColor[posicion] = ficha.Color2;
                else if(posicion == posiciones[2]) // Posición para C3
                    casillasConColor[posicion] = ficha.Color3;
            }

            // Añade la ficha al tablero.
            fichas.Add((x, y), ficha);
    
            // Imprime el estado actual del tablero.
            ImprimirTablero();
        }

        
        private bool PuedeAgregarFicha(Ficha ficha, int x, int y)
        {
            // Implementar la lógica para determinar si se puede agregar la ficha en la posición (x, y)
            return true;
        }
    }
}
