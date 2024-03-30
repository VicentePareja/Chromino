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
        
        public bool SinFichas()
        {
            return fichas.Count == 0;
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

        public void JugarTurno(Tablero tablero, Bolsa bolsa)
        {
            if (EsBot)
            {
                bool jugadaRealizada = false;

                // Intenta colocar cada ficha en el tablero, probando todas las direcciones y posiciones.
                foreach (Ficha ficha in fichas)
                {
                    foreach (Direccion direccion in Enum.GetValues(typeof(Direccion)))
                    {
                        ficha.Direccion = direccion; // Establece la dirección de la ficha.

                        // Define el rango de coordenadas a probar en el tablero.
                        // Este rango debería ajustarse a las dimensiones y límites actuales del tablero.
                        for (int x = -100; x <= 100; x++)
                        {
                            for (int y = -100; y <= 100; y++)
                            {
                                if (tablero.JugadaLegal(ficha, x, y) && tablero.AgregarFicha(ficha, x, y))
                                {
                                    Console.WriteLine(
                                        $"Bot ha colocado una ficha en ({x}, {y}) con dirección {direccion}.");
                                    fichas.Remove(ficha); // Remueve la ficha de la mano del bot.
                                    jugadaRealizada = true;
                                    break;
                                }
                            }

                            if (jugadaRealizada) break;
                        }

                        if (jugadaRealizada) break;
                    }

                    if (jugadaRealizada) break;
                }

                if (!jugadaRealizada)
                {
                    Console.WriteLine("No había jugadas posibles.");
                }
            }
            else
            {
                bool jugadaRealizada = false;
                while (!jugadaRealizada)
                {
                    Console.WriteLine("Es tu turno, introduce algo: ");
                    Console.WriteLine("Tienes las siguientes fichas:");
                    for (int i = 0; i < fichas.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {fichas[i]}");
                    }

                    Console.WriteLine("Selecciona una ficha por número (-1 para pasar): ");
                    int eleccion = int.Parse(Console.ReadLine());

                    if (eleccion == -1)
                    {
                        AgregarFicha((bolsa.SacarFicha()));
                        Console.WriteLine("Has pasado tu turno y tomado una nueva ficha de la bolsa.");
                        jugadaRealizada = true;
                    }
                    else
                    {
                        int indiceFicha = eleccion - 1;

                        Console.WriteLine("Introduce coordenada X: ");
                        int x = int.Parse(Console.ReadLine());

                        Console.WriteLine("Introduce coordenada Y: ");
                        int y = int.Parse(Console.ReadLine());

                        Console.WriteLine("Introduce la dirección (N, E, S, O): ");
                        var direccion = Console.ReadLine().ToUpper();
                        Direccion dirEnum = Direccion.N; // Valor predeterminado.
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

                        if (indiceFicha >= 0 && indiceFicha < fichas.Count)
                        {
                            Ficha fichaSeleccionada = fichas[indiceFicha];
                            fichaSeleccionada
                                .CambiarDireccion(
                                    dirEnum); // Asumiendo que este método ajusta la dirección correctamente.

                            if (tablero.AgregarFicha(fichaSeleccionada, x, y))
                            {
                                Console.WriteLine("Ficha colocada exitosamente.");
                                fichas.RemoveAt(
                                    indiceFicha); // Remueve la ficha de la lista del jugador si se coloca exitosamente.
                                jugadaRealizada = true;
                            }
                            else
                            {
                                Console.WriteLine("Jugada inválida, intenta de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Selección inválida, intenta de nuevo.");
                        }
                    }
                }
            }
        }
    }
}