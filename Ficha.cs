// Ficha.cs

namespace Chromino
{
    public class Ficha
    {
        // Propiedades que representan los colores de cada segmento de la ficha.
        public string Color1 { get; private set; }
        public string Color2 { get; private set; }
        public string Color3 { get; private set; }

        // Constructor de la ficha que toma los tres colores como argumentos.
        public Ficha(string color1, string color2, string color3)
        {
            Color1 = color1;
            Color2 = color2;
            Color3 = color3;
        }

        // Método para verificar si la ficha es compatible con otro color.
        // Este método es útil cuando se necesita determinar si una ficha puede ser colocada junto a otra.
        public bool EsCompatibleCon(string color)
        {
            // Un comodín (C) es compatible con cualquier color.
            if (Color1 == "C" || Color2 == "C" || Color3 == "C")
            {
                return true;
            }

            // La ficha es compatible si alguno de sus colores coincide con el color proporcionado.
            return Color1 == color || Color2 == color || Color3 == color;
        }

        // Considera agregar más funcionalidades aquí según sea necesario, por ejemplo,
        // una representación en string de la ficha para propósitos de depuración o UI.
        public override string ToString()
        {
            return $"[{Color1},{Color2},{Color3}]";
        }
    }
}