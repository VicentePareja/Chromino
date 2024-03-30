# Chromino Game

Chromino es una versión simplificada del popular juego de mesa, implementada en C# para ejecutarse en la consola. Este proyecto ofrece una base para desarrollar el juego, incluyendo la gestión de fichas, jugadores, y la lógica del tablero.

## Características

- Gestión de fichas incluyendo colores y comodines.
- Soporte para jugadores humanos y bots.
- Tablero expansivo que se ajusta a medida que se añaden fichas.

## Requisitos

- .NET 8.0 SDK o superior.

## Estructura del Proyecto

El proyecto consta de varios archivos principales:

- `Program.cs`: Punto de entrada del juego que inicializa los jugadores, el tablero, y maneja el loop principal del juego.
- `Juego.cs`: Define la lógica central del juego, incluyendo la generación de la bolsa de fichas.
- `Jugador.cs`: Representa un jugador en el juego, ya sea humano o bot, y maneja sus acciones.
- `Tablero.cs`: Gestiona la lógica del tablero, incluyendo la colocación de fichas.
- `Ficha.cs`: Define la estructura y comportamiento de las fichas del juego.

## Cómo Jugar

1. Clonar el repositorio o descargar los archivos del proyecto.
2. Abrir una terminal o línea de comandos.
3. Navegar al directorio del proyecto.
4. Ejecutar `dotnet run` para iniciar el juego.
5. Seguir las instrucciones en consola para jugar.

## Desarrollo Futuro

Este proyecto es una base sobre la cual se pueden añadir más características, como:

- Arreglar la verificación de una jugada legal (Está mal hecho).

## Contribuciones

Las contribuciones son bienvenidas. Si deseas contribuir al proyecto, por favor haz un fork del repositorio y envía un pull request con tus cambios.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT - ver el archivo `LICENSE` para más detalles.
