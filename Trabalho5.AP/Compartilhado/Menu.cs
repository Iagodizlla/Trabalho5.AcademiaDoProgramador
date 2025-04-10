using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho5.AP.Compartilhado
{
    public class Menu
    {
        public char MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1. Geranciar Amigos");
            Console.WriteLine("2. Gerenciar Caixas");
            Console.WriteLine("3. Gerenciar Revistas");
            Console.WriteLine("4. Em desenvolvimento...");
            Console.WriteLine("S. Sair");
            Console.Write("Escolha uma opção: ");

            char opcao = Console.ReadLine()!.ToUpper()[0];
            return opcao;
        }

        public char MostrarMenuAmigo()
        {
            Console.Clear();
            Console.WriteLine("Menu de Amigos");
            Console.WriteLine("1. Adicionar Amigo");
            Console.WriteLine("2. Remover Amigo");
            Console.WriteLine("3. Listar Amigos");
            Console.WriteLine("4. Editar Amigo");
            Console.WriteLine("S. Voltar");
            Console.Write("Escolha uma opção: ");

            char opcao = Console.ReadLine()!.ToUpper()[0];
            return opcao;
        }

        public char MostrarMenuCaixa()
        {
            Console.Clear();
            Console.WriteLine("Menu de Caixas");
            Console.WriteLine("1. Adicionar Caixa");
            Console.WriteLine("2. Remover Caixa");
            Console.WriteLine("3. Listar Caixa");
            Console.WriteLine("4. Editar Caixa");
            Console.WriteLine("S. Voltar");
            Console.Write("Escolha uma opção: ");

            char opcao = Console.ReadLine()!.ToUpper()[0];
            return opcao;
        }
        public char MostrarMenuRevista()
        {
            Console.Clear();
            Console.WriteLine("Menu de Revistas");
            Console.WriteLine("1. Adicionar Revista");
            Console.WriteLine("2. Remover Revista");
            Console.WriteLine("3. Listar Revista");
            Console.WriteLine("4. Editar Revista");
            Console.WriteLine("S. Voltar");
            Console.Write("Escolha uma opção: ");

            char opcao = Console.ReadLine()!.ToUpper()[0];
            return opcao;
        }
    }
}