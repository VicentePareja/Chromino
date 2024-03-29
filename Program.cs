using System;

namespace Chromino
{
    class Program
    {
        static void Main(string[] args)
        {
            var juego = new Juego();

            // Initialize one human player and three bots
            var jugadorHumano = new Jugador(false); // false indicates not a bot
            var jugadorBot1 = new Jugador(true);    // true indicates a bot
            var jugadorBot2 = new Jugador(true);    // another bot
            var jugadorBot3 = new Jugador(true);    // and another bot

            juego.AgregarJugador(jugadorHumano);
            //juego.AgregarJugador(jugadorBot1);
            //juego.AgregarJugador(jugadorBot2);
            //juego.AgregarJugador(jugadorBot3);
            juego.IniciarTablero();
            // Distribute initial fichas to players randomly
            int fichasPorJugador = 8; // Assuming 8 initial fichas per player
            for (int i = 0; i < fichasPorJugador; i++)
            {
                jugadorHumano.AgregarFicha(juego.BolsaDeFichas.SacarFicha());
                //jugadorBot1.AgregarFicha(juego.BolsaDeFichas.SacarFicha());
                //jugadorBot2.AgregarFicha(juego.BolsaDeFichas.SacarFicha());
                //jugadorBot3.AgregarFicha(juego.BolsaDeFichas.SacarFicha());
            }

            // Simulate the game loop
            bool partidaTerminada = false;
            int contador = 0;
            while (!partidaTerminada)
            {
                foreach (var jugador in juego.Jugadores)
                {
                    contador += 1;
                    jugador.JugarTurno(juego.tablero);
                    if (contador > 10)
                    {
                        partidaTerminada = true;
                    }
                }
            }
        }
    }
}