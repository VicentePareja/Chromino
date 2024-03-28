// Program.cs
using System;
using System.Collections.Generic;

namespace Chromino
{
    class Program
    {
        static void Main(string[] args)
        {
            var juego = new Juego();
            var bolsaDeFichas = Juego.GenerarBolsaDeFichas();

            // Inicializar jugadores (Ejemplo con un humano y un bot)
            var jugadorHumano = new Jugador(false); // false indica que no es bot
            var jugadorBot = new Jugador(true); // true indica que es bot

            juego.AgregarJugador(jugadorHumano);
            juego.AgregarJugador(jugadorBot);

            // Distribuir fichas iniciales a los jugadores (simplificado)
            for (int i = 0; i < 5; i++) // asumiendo 5 fichas iniciales por jugador
            {
                jugadorHumano.AgregarFicha(bolsaDeFichas[i]);
                jugadorBot.AgregarFicha(bolsaDeFichas[i + 5]);
            }

            bolsaDeFichas.RemoveRange(0, 10); // Remover las fichas ya distribuidas

            // Simulación del loop del juego
            bool partidaTerminada = false;
            while (!partidaTerminada)
            {
                foreach (var jugador in juego.Jugadores)
                {
                    jugador.JugarTurno();
                    // Verificar condiciones de fin de juego aquí
                    // partidaTerminada = ...
                }
            }
        }
    }
}