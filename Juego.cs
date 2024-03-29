// Juego.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chromino
{
    public class Juego
    {
        public Tablero tablero;
        private List<Jugador> jugadores;
        public Bolsa BolsaDeFichas { get; private set; }

        public List<Jugador> Jugadores => jugadores;

        public Juego()
        {
            tablero = new Tablero();
            jugadores = new List<Jugador>();
            BolsaDeFichas = new Bolsa(GenerarBolsaDeFichas());
            BolsaDeFichas.Mezclar(); // Asegura que las fichas estén mezcladas
        }

        public void AgregarJugador(Jugador jugador)
        {
            jugadores.Add(jugador);
        }
        
        public void IniciarTablero()
        {
            Ficha comodin = null;
            // Busca en la bolsa hasta encontrar un comodín.
            for (int i = 0; i < BolsaDeFichas.fichas.Count; i++)
            {
                if (BolsaDeFichas.fichas[i].Color2 == "C")
                {
                    comodin = BolsaDeFichas.fichas[i];
                    BolsaDeFichas.fichas.RemoveAt(i); // Elimina el comodín encontrado de la bolsa.
                    break; // Sale del ciclo una vez que se encuentra el comodín.
                }
            }

            if (comodin != null)
            {
                // Coloca el comodín en la casilla (0, 1) con dirección norte.
                tablero.AgregarFichaForzado(comodin, 0, 1);
            }
            else
            {
                // Opcional: Manejo de caso donde no se encuentra un comodín.
                Console.WriteLine("No se encontró un comodín en la bolsa.");
            }
        }


        public static IEnumerable<Ficha> GenerarBolsaDeFichas()
        {
            var colores = new List<string> { "G", "R", "Y", "P", "B" };
            var bolsa = new List<Ficha>();
            var fichasUnicas = new HashSet<string>();

            // Generar fichas normales
            foreach (var c1 in colores)
            {
                foreach (var c2 in colores)
                {
                    foreach (var c3 in colores)
                    {
                        var ficha = $"{c1}{c2}{c3}";
                        var fichaInversa = $"{c3}{c2}{c1}";

                        if (!fichasUnicas.Contains(ficha) && !fichasUnicas.Contains(fichaInversa))
                        {
                            fichasUnicas.Add(ficha);
                            bolsa.Add(new Ficha(c1, c2, c3, Direccion.N));
                        }
                    }
                }
            }

            // Agregar comodines específicos
            var comodinesEspecificos = new List<(string, string, string)>
            {
                ("G", "C", "R"),
                ("G", "C", "Y"),
                ("R", "C", "P"),
                ("Y", "C", "B"),
                ("P", "C", "B")
            };

            foreach (var (c1, c2, c3) in comodinesEspecificos)
            {
                bolsa.Add(new Ficha(c1, c2, c3, Direccion.N));
            }

            return bolsa;
        }
    }
}
