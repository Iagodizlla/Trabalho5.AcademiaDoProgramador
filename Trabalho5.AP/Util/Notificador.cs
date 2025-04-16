namespace Trabalho5.AP.Util;

public class Notificador
{
    public static void ExibirMensagem(string mensagem, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;

        Console.WriteLine();

        Console.WriteLine(mensagem);

        Console.ResetColor();

        Console.ReadLine();
    }
}
