using System;
using System.Threading;

class Program
{
    //Carlos Torres 1-22-7963
    //Franjolin 2-16-7878
    //Elliam Jiménez 1-22-7873
    //Erianly 1-22-7901

    static void Main()
    {
        // Ajusta el tamano de la ventana de la consola
        Console.WindowWidth = 100;
        Console.WindowHeight = 40;
        Console.BufferWidth = 100;
        Console.BufferHeight = 40;

        // Oculta el cursor
        Console.CursorVisible = false;

        // Verificar de que la consola este completamente lista
        Thread.Sleep(100); // Espera breve para permitir que la consola se inicialice correctamente

        // Tamano y posicion de la caja
        int boxWidth = 40;
        int boxHeight = 15;
        int boxLeft = (Console.WindowWidth - boxWidth) / 2;
        int boxRight = boxLeft + boxWidth - 1;
        int boxTop = (Console.WindowHeight - boxHeight) / 2;
        int boxBottom = boxTop + boxHeight - 1;

        // Inicializa la pelota en una posicion aleatoria dentro de la caja
        Random rand = new Random();
        int ballX = rand.Next(boxLeft + 1, boxRight);
        int ballY = rand.Next(boxTop + 1, boxBottom);

        // Velocidades aleatorias para la pelota
        int ballDX = rand.Next(1, 3) * (rand.Next(0, 2) * 2 - 1);
        int ballDY = rand.Next(1, 3) * (rand.Next(0, 2) * 2 - 1);

        // Verificar que la pelota tenga una velocidad en ambas direcciones
        while (ballDX == 0 && ballDY == 0)
        {
            ballDX = rand.Next(1, 3) * (rand.Next(0, 2) * 2 - 1);
            ballDY = rand.Next(1, 3) * (rand.Next(0, 2) * 2 - 1);
        }

        // Dibuja la caja en la consola
        DrawBox(boxLeft, boxRight, boxTop, boxBottom);

        // Muestra el mensaje para empezar
        Console.SetCursorPosition(boxLeft + 1, boxBottom + 2);
        Console.Write("Presiona una tecla para empezar...");
        Console.ReadKey(true);

        // Borra el mensaje para empezar y muestra el mensaje para finalizar
        Console.SetCursorPosition(boxLeft + 1, boxBottom + 2);
        Console.Write(new string(' ', "Presiona una tecla para empezar...".Length));
        Console.SetCursorPosition(boxLeft + 1, boxBottom + 2);
        Console.Write("Pulse cualquier tecla para finalizar.");

        // Bucle principal del juego
        bool gameRunning = true;
        while (gameRunning)
        {
            // Borra la posicion anterior de la pelota
            Console.SetCursorPosition(ballX, ballY);
            Console.Write(" ");

            // Mueve la pelota
            ballX += ballDX;
            ballY += ballDY;

            // Verifica si la pelota choca con los limites de la caja
            if (ballX <= boxLeft || ballX >= boxRight)
            {
                ballDX = -ballDX;
                ballX = Math.Max(boxLeft + 1, Math.Min(ballX, boxRight - 1));
            }

            if (ballY <= boxTop || ballY >= boxBottom)
            {
                ballDY = -ballDY;
                ballY = Math.Max(boxTop + 1, Math.Min(ballY, boxBottom - 1));
            }

            // Dibuja la pelota en su nueva posición
            Console.SetCursorPosition(ballX, ballY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("O");
            Console.ResetColor();

            // Espera antes de la siguiente actualización de la pantalla
            Thread.Sleep(30);

            // Verifica si el usuario presiona una tecla para finalizar el juego
            if (Console.KeyAvailable)
            {
                Console.ReadKey(true); // Lee la tecla para evitar el bloqueo
                gameRunning = false;
            }
        }

        // Restaura la visibilidad del cursor
        Console.CursorVisible = true;

        // Mensaje final al terminar el juego
        Console.SetCursorPosition(boxLeft + 1, boxBottom + 4);
        Console.Write("Juego finalizado. Presiona cualquier tecla para salir.");
        Console.ReadKey(true);
    }

    // Dibuja la caja
    static void DrawBox(int left, int right, int top, int bottom)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        // Dibuja los bordes superior e inferior de la caja
        for (int i = left; i <= right; i++)
        {
            Console.SetCursorPosition(i, top);
            Console.Write("█");
            Console.SetCursorPosition(i, bottom);
            Console.Write("█");
        }

        // Dibuja los bordes izquierdo y derecho de la caja
        for (int i = top; i <= bottom; i++)
        {
            Console.SetCursorPosition(left, i);
            Console.Write("█");
            Console.SetCursorPosition(right, i);
            Console.Write("█");
        }

        Console.ResetColor();
    }
}
