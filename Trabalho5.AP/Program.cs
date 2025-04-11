using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloCaixa;
using Trabalho5.AP.ModuloEmprestimo;
using Trabalho5.AP.ModuloRevista;
using Trabalho5.AP.Compartilhado;

namespace Trabalho5.AP;

public class Program
{
    static void Main(string[] args)
    {
        #region Configuração do Console
        Menu menu = new Menu();
        RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
        RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        RepositorioRevista repositorioRevista = new RepositorioRevista();
        RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

        TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
        TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
        TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
        TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);
        #endregion
        bool continuar = true;
        while (true)
        {
            continuar = true;
            char opcaoP = menu.MostrarMenuPrincipal();
            if (opcaoP == '1')
            {
                while (continuar)
                {
                    char opcao = menu.MostrarMenuAmigo();
                    switch (opcao)
                    {
                        case '1': telaAmigo.CadastrarAmigo(); break;
                        case '2': telaAmigo.RemoverAmigo(); break;
                        case '3': telaAmigo.ListarAmigos(); break;
                        case '4': telaAmigo.EditarAmigo(); break;
                        case 'S': continuar = false; break;
                        default: Console.WriteLine("Opção inválida."); Console.ReadLine(); break;
                    }
                }
            }
            else if (opcaoP == '2')
            {
                while (continuar)
                {
                    char opcao = menu.MostrarMenuCaixa();
                    switch (opcao)
                    {
                        case '1': telaCaixa.CadastrarCaixa(); break;
                        case '2': telaCaixa.RemoverCaixa(); break;
                        case '3': telaCaixa.ListarCaixas(); break;
                        case '4': telaCaixa.EditarCaixa(); break;
                        case 'S':  continuar = false; break;
                        default: Console.WriteLine("Opção inválida."); Console.ReadLine(); break;
                    }
                }
            }
            else if (opcaoP == '3')
            {
                while (continuar)
                {
                    char opcao = menu.MostrarMenuRevista();
                    switch (opcao)
                    {
                        case '1': telaRevista.CadastrarRevista(); break;
                        case '2': telaRevista.RemoverRevista(); break;
                        case '3': telaRevista.ListarRevistas(); break;
                        case '4': telaRevista.EditarRevista(); break;
                        case 'S': continuar = false; break;
                        default: Console.WriteLine("Opção inválida."); Console.ReadLine(); break;
                    }
                }
            }
            else if (opcaoP == '4')
            {
                while (continuar)
                {
                    char opcao = menu.MostrarMenuEmprestimo();
                    switch (opcao)
                    {
                        case '1': telaEmprestimo.CadastrarEmprestimo(); break;
                        case '2': telaEmprestimo.RemoverEmprestimo(); break;
                        case '3': telaEmprestimo.ListarEmprestimos(); break;
                        case '4': telaEmprestimo.EditarEmprestimo(); break;
                        case '5': telaEmprestimo.RegistrarDevolucao(); break;
                        case '6': telaEmprestimo.ListarEmprestimosAmigo(); break;
                        case 'S': continuar = false; break;
                        default: Console.WriteLine("Opção inválida."); Console.ReadLine(); break;
                    }
                }
            }
            else if (opcaoP == 'S')
            {
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                Console.ReadKey();
            }
        }
    }
}