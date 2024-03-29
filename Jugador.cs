using System;
using System.Collections.Generic;
using System.Linq; // Para usar .Select()

namespace Chromino
{
    public class Jugador
    {
        public bool EsBot { get; set; }
        private List<Ficha> fichas;

        public Jugador(bool esBot)
        {
            EsBot = esBot;
            fichas = new List<Ficha>();
        }

        public void AgregarFicha(Ficha ficha)
        {
            fichas.Add(ficha);
        }

        public void SacarFichaDeLaBolsa(List<Ficha> bolsa)
        {
            if (bolsa.Count > 0)
            {
                Ficha ficha = bolsa[0];
                bolsa.RemoveAt(0);
                AgregarFicha(ficha);
            }
        }

        public void JugarTurno(Tablero tablero)
        {
            if (EsBot)
            {
                Console.WriteLine("Soy un bot jugando mi turno.");
                // Aquí iría la lógica del bot para jugar su turno.
            }
            else
            {
                Console.WriteLine("Es tu turno, introduce algo: ");
                Console.WriteLine("Tienes las siguientes fichas:");
                for (int i = 0; i < fichas.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {fichas[i]}");
                }

                Console.WriteLine("Selecciona una ficha por número: ");
                int indiceFicha = int.Parse(Console.ReadLine()) - 1;
                
                Console.WriteLine("Introduce coordenada X: ");
                int x = int.Parse(Console.ReadLine());

                Console.WriteLine("Introduce coordenada Y: ");
                int y = int.Parse(Console.ReadLine());

                Console.WriteLine("Introduce la dirección (N, E, S, O): ");
                var direccion = Console.ReadLine().ToUpper();
                Direccion dirEnum = Direccion.N; // Default value
                switch (direccion)
                {
                    case "N":
                        dirEnum = Direccion.N;
                        break;
                    case "E":
                        dirEnum = Direccion.E;
                        break;
                    case "S":
                        dirEnum = Direccion.S;
                        break;
                    case "O":
                        dirEnum = Direccion.O;
                        break;
                }
                Ficha fichaSeleccionada = fichas[indiceFicha];
                fichaSeleccionada.Direccion = dirEnum; // Asumiendo que la ficha tiene una propiedad de Dirección que puedes establecer.
                
                if (!tablero.AgregarFicha(fichaSeleccionada, x, y))
                {
                    Console.WriteLine("No se pudo colocar la ficha.");
                }
                else
                {
                    fichas.RemoveAt(indiceFicha); // Remueve la ficha de la lista del jugador si se coloca exitosamente.
                    Console.WriteLine("Ficha colocada exitosamente.");
                }
            }
        }
    }
}
