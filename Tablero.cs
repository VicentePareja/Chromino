// Tablero.cs
using System;
using System.Collections.Generic;

namespace Chromino
{
    public class Tablero
    {
        private Dictionary<(int, int), Ficha> fichas;

        public Tablero()
        {
            fichas = new Dictionary<(int, int), Ficha>();
        }

        public bool AgregarFicha(Ficha ficha, int x, int y)
        {
            if (fichas.ContainsKey((x, y)))
            {
                return false; // No se puede agregar la ficha porque la posición ya está ocupada.
            }

            fichas.Add((x, y), ficha);
            return true;
        }

        private bool PuedeAgregarFicha(Ficha ficha, int x, int y)
        {
            return true; // Simplificado, implementar lógica real.
        }
    }
}
