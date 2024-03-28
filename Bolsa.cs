// Bolsa.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chromino
{
    public class Bolsa
    {
        private List<Ficha> fichas = new List<Ficha>();
        private Random random = new Random();

        // Constructor que inicializa la bolsa con una lista opcional de fichas
        public Bolsa(IEnumerable<Ficha> fichasIniciales = null)
        {
            if (fichasIniciales != null)
            {
                fichas.AddRange(fichasIniciales);
            }
        }

        // Mezcla las fichas de la bolsa de manera aleatoria
        public void Mezclar()
        {
            fichas = fichas.OrderBy(x => random.Next()).ToList();
        }

        // Agrega una ficha a la bolsa
        public void AgregarFicha(Ficha ficha)
        {
            fichas.Add(ficha);
        }

        // Saca una ficha de la bolsa aleatoriamente y la retorna
        // Retorna null si la bolsa está vacía
        public Ficha SacarFicha()
        {
            if (fichas.Count == 0)
            {
                return null; // O manejar de otra manera si se prefiere
            }

            int index = random.Next(fichas.Count);
            Ficha fichaSeleccionada = fichas[index];
            fichas.RemoveAt(index);
            return fichaSeleccionada;
        }

        // Retorna el número de fichas restantes en la bolsa
        public int FichasRestantes => fichas.Count;
    }
}