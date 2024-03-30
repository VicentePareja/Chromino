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

            for (int i = 0; i < BolsaDeFichas.fichas.Count; i++)
            {
                if (BolsaDeFichas.fichas[i].Color2 == "C")
                {
                    comodin = BolsaDeFichas.fichas[i];
                    BolsaDeFichas.fichas.RemoveAt(i); 
                    break;
                }
            }

            if (comodin != null)
            {
  
                tablero.AgregarFichaForzado(comodin, 0, 1);
            }
            else
            {
                
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
