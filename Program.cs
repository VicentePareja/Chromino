using System;

namespace Chromino
{
    class Program
    {
        static void Main(string[] args)
        {
            var juego = new Juego();

            
            var jugadorHumano = new Jugador(false); 
            var jugadorBot1 = new Jugador(true);    
            var jugadorBot2 = new Jugador(true);    
            var jugadorBot3 = new Jugador(true);    

            juego.AgregarJugador(jugadorHumano);
            juego.AgregarJugador(jugadorBot1);
            juego.AgregarJugador(jugadorBot2);
            juego.AgregarJugador(jugadorBot3);
            juego.IniciarTablero();
            
            int fichasPorJugador = 8; 
            for (int i = 0; i < fichasPorJugador; i++)
            {
                jugadorHumano.AgregarFicha(juego.BolsaDeFichas.SacarFicha());
                jugadorBot1.AgregarFicha(juego.BolsaDeFichas.SacarFicha());
                jugadorBot2.AgregarFicha(juego.BolsaDeFichas.SacarFicha());
                jugadorBot3.AgregarFicha(juego.BolsaDeFichas.SacarFicha());
            }

            // Simulate the game loop
            bool partidaTerminada = false;
            int contador = 0;
            while (!partidaTerminada)
            {
                foreach (var jugador in juego.Jugadores)
                {
                    contador += 1;
                    jugador.JugarTurno(juego.tablero, juego.BolsaDeFichas);
                    if (jugador.SinFichas())
                    {
                        partidaTerminada = true;
                    }
                }
            }
        }
    }
}