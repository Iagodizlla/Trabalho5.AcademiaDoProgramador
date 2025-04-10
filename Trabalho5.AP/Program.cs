using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloCaixa;
using Trabalho5.AP.ModuloEmprestimo;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP;

class Program
{
    static void Main(string[] args)
    {
        RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
        RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        RepositorioRevista repositorioRevista = new RepositorioRevista();
        RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

        TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
        //TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
        //TelaRevista telaRevista = new TelaRevista(repositorioRevista);
        //TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

        while (true)
        {
            #region Amigo
            char opcao = telaAmigo.MostrarMenu();
            switch (opcao)
            {
                case '1': telaAmigo.Inserir(); break;
                case '2': telaAmigo.RemoverAmigo(); break;
                case '3': telaAmigo.ListarAmigos(); break;
                case '4': telaAmigo.EditarAmigo(); break;
                case 'S': return;
                default: Console.WriteLine("Opção inválida.");Console.ReadLine(); break;
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            #endregion
        }
    }
}