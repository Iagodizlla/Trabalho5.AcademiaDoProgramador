using Trabalho5.AP.ModuloCaixa;

namespace Trabalho5.AP.ModuloRevista;

public class RepositorioRevista
{
    public Revista[] revistas = new Revista[100];
    public int contadorRevistas = 0;
    public void AdicionarRevista(Revista revista)
    {
        revista.Id = GeradorId.GerarIdRevista();
        revistas[contadorRevistas++] = revista;
    }
    public void RemoverRevista(Revista revista)
    {
        for (int i = 0; i < contadorRevistas; i++)
        {
            if (revistas[i] == revista)
            {
                revistas[i] = null!;
                break;
            }
        }
    }
    public Revista BuscarRevista(int id, string situacao)
    {
        for (int i = 0; i < contadorRevistas; i++)
        {
            if (revistas[i].Id == id)
            {
                revistas[i].StatusEmprestimo = situacao;
                return revistas[i];
            }
        }
        return null!;
    }
    public Revista[] ListarRevistas()
    {
        Revista[] revistasAtuais = new Revista[contadorRevistas];
        for (int i = 0; i < contadorRevistas; i++)
        {
            revistasAtuais[i] = revistas[i];
        }
        return revistasAtuais;
    }
    public void EditarRevista(Revista revista, string novoTitulo, string novoStatusEmprestimo, Caixa novoCaixa, int novoNumeroEdicao, DateTime novoAnoPublicacao)
    {
        for (int i = 0; i < contadorRevistas; i++)
        {
            if (revistas[i] == revista)
            {
                revistas[i].Titulo = novoTitulo;
                revistas[i].StatusEmprestimo = novoStatusEmprestimo;
                revistas[i].NumeroEdicao = novoNumeroEdicao;
                revistas[i].AnoPublicacao = novoAnoPublicacao;
                revistas[i].Caixa = novoCaixa;
                break;
            }
        }
    }
    public string EditarSituacao()
    {
        string novosituacao;
        while (true)
        {
            Console.Clear();
            Console.Write("\n1. Disponível\n2. Emprestada\n3. Reservada\nSituacao: ");
            novosituacao = Console.ReadLine()!;
            if (novosituacao == "1")
            {
                novosituacao = "Disponível"; break;
            }
            else if (novosituacao == "2")
            {
                novosituacao = "Emprestada"; break;
            }
            else if (novosituacao == "3")
            {
                novosituacao = "Reservada"; break;
            }
            else
                Console.WriteLine("Invalido, tente novamente!");
            Console.ReadLine();
        }
        return novosituacao;
    }
    public string ValidarRevista(string titulo, int edicao)
    {
        for (int i = 0; i < contadorRevistas; i++)
        {
            if (revistas[i].Titulo == titulo)
            {
                return "Titulo de Revista já cadastrado.\n";
            }
            if (revistas[i].NumeroEdicao == edicao)
            {
                return "Numero de Edicao de Revista já cadastrado.\n";
            }
        }
        return "";
    }
}