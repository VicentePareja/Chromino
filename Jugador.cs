// Jugador.cs
using System;
using System.Collections.Generic;

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

        public bool ColocarFichaEnTablero(Ficha ficha, int x, int y, Tablero tablero)
        {
            return false; // Simulación, implementar lógica real.
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

        // Nuevo método para manejar el turno del jugador.
        public void JugarTurno()
        {
            if (EsBot)
            {
                Console.WriteLine("Soy un bot.");
                // Aquí iría la lógica del bot para jugar su turno.
            }
            else
            {
                Console.WriteLine("Es tu turno, introduce algo: ");
                string input = Console.ReadLine();
                Console.WriteLine($"Hola: {input}");
                // Aquí iría la lógica para procesar la entrada del jugador y jugar su turno.
            }
        }
    }
}