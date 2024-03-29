// Ficha.cs
namespace Chromino
{
    public enum Direccion { N, E, S, O } // O representa Oeste (W en inglés)

    public class Ficha
    {
        public string Color1 { get; private set; }
        public string Color2 { get; private set; }
        public string Color3 { get; private set; }
        public Direccion Direccion { get; set; } // Dirección de la ficha

        public Ficha(string color1, string color2, string color3, Direccion direccion)
        {
            Color1 = color1;
            Color2 = color2;
            Color3 = color3;
            Direccion = direccion;
        }

        public bool EsCompatibleCon(string color)
        {
            if (Color1 == "C" || Color2 == "C" || Color3 == "C")
            {
                return true;
            }
            return Color1 == color || Color2 == color || Color3 == color;
        }

        // Método para cambiar la dirección de la ficha
        public void CambiarDireccion(Direccion nuevaDireccion)
        {
            Direccion = nuevaDireccion;
        }

        public override string ToString()
        {
            return $"[{Color1},{Color2},{Color3}], Dirección: {Direccion}";
        }
    }
}