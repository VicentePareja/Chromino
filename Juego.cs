//Juego.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chromino
{
    public class Juego
    {
        private Tablero tablero;
        private List<Jugador> jugadores;

        public List<Jugador> Jugadores => jugadores;

        public Juego()
        {
            tablero = new Tablero();
            jugadores = new List<Jugador>();
        }

        public void AgregarJugador(Jugador jugador)
        {
            jugadores.Add(jugador);
        }

        // Método estático para generar la bolsa de fichas, incluidas las fichas comodín.
        public static List<Ficha> GenerarBolsaDeFichas()
        {
            var colores = new List<string> { "G", "R", "Y", "P", "B" };
            var bolsa = new List<Ficha>();

            // Generar las fichas normales
            foreach (var c1 in colores)
            {
                foreach (var c2 in colores)
                {
                    foreach (var c3 in colores)
                    {
                        // Asegurar que cada combinación de ficha es única
                        if (!bolsa.Any(f => f.Color1 == c1 && f.Color2 == c2 && f.Color3 == c3))
                        {
                            bolsa.Add(new Ficha(c1, c2, c3));
                        }
                    }
                }
            }

            // Agregar las fichas comodín
            foreach (var c1 in colores)
            {
                foreach (var c2 in colores)
                {
                    // Asegurar que los colores en los extremos sean diferentes
                    if (c1 != c2)
                    {
                        var fichaComodin1 = new Ficha(c1, "C", c2);
                        var fichaComodin2 = new Ficha(c2, "C", c1);

                        // Añadir fichas comodín si no existen en la bolsa
                        if (!bolsa.Any(f => f.Color1 == fichaComodin1.Color1 && f.Color2 == fichaComodin1.Color2 && f.Color3 == fichaComodin1.Color3))
                        {
                            bolsa.Add(fichaComodin1);
                        }
                        if (!bolsa.Any(f => f.Color1 == fichaComodin2.Color1 && f.Color2 == fichaComodin2.Color2 && f.Color3 == fichaComodin2.Color3))
                        {
                            bolsa.Add(fichaComodin2);
                        }
                    }
                }
            }

            return bolsa;
        }
    }
}
