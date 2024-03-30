// Bolsa.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chromino
{
    public class Bolsa
    {
        public List<Ficha> fichas = new List<Ficha>();
        private Random random = new Random();


        public Bolsa(IEnumerable<Ficha> fichasIniciales = null)
        {
            if (fichasIniciales != null)
            {
                fichas.AddRange(fichasIniciales);
            }
        }


        public void Mezclar()
        {
            fichas = fichas.OrderBy(x => random.Next()).ToList();
        }


        public void AgregarFicha(Ficha ficha)
        {
            fichas.Add(ficha);
        }

     
        public Ficha SacarFicha()
        {
            if (fichas.Count == 0)
            {
                return null; 
            }

            int index = random.Next(fichas.Count);
            Ficha fichaSeleccionada = fichas[index];
            fichas.RemoveAt(index);
            return fichaSeleccionada;
        }


        public int FichasRestantes => fichas.Count;
    }
}