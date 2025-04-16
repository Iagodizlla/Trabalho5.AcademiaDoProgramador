namespace Trabalho5.AP.ModuloCaixa;

public class TelaCaixa
{
    RepositorioCaixa repositorioCaixa;
    public TelaCaixa(RepositorioCaixa repositorioCaixa)
    {
        this.repositorioCaixa = repositorioCaixa;
    }
    public void CadastrarCaixa()
    {
        Console.Clear();
        Console.WriteLine("Adicionar Caixa");
        Console.Write("Etiqueta: ");
        string etiqueta = Console.ReadLine()!;
        Console.Write("Cor: ");
        string cor = Console.ReadLine()!;
        Console.Write("Dias de emprestimo: ");
        int diasDeEmprestimo = Convert.ToInt16(Console.ReadLine()!);

        Caixa caixa = new Caixa(etiqueta, cor, diasDeEmprestimo);
        string erros = caixa.Validar();
        if (erros.Length > 1)
        {
            Console.WriteLine(erros);
            Console.ReadLine();
            CadastrarCaixa();

            return;
        }
        repositorioCaixa.AdicionarCaixa(caixa);
    }
    public void ListarCaixas()
    {
        Console.Clear();
        Console.WriteLine("Lista de Caixas");
        Console.WriteLine("-----------------");
        Caixa[] caixas = repositorioCaixa.ListarCaixas();
        Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -20} | {4, -15}",
            "ID", "Etiqueta", "Dias de Emprestimo", "Cor", "Quantidade de Revistas"
            );
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null) continue;
            Console.WriteLine(
                "{0, -6} | {1, -20} | {2, -20} | {3, -20} | {4, -15}",
                caixas[i].Id, caixas[i].Etiqueta, caixas[i].DiasDeEmprestimo, caixas[i].Cor, caixas[i].ObterQuantidadeRevistas()
            );
        }
        Console.ReadLine();
    }
    public void RemoverCaixa()
    {
        Console.Clear();
        Console.WriteLine("Remover Caixa");
        ListarCaixas();
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Caixa caixa = repositorioCaixa.BuscarCaixa(id);
        if(caixa.Revistas.Length > 0)
        {
            Console.WriteLine("Caixa não pode ser removido, pois possui revistas.");
            Console.ReadLine();
            return;
        }
        if (caixa != null)
        {
            repositorioCaixa.RemoverCaixa(caixa);
            Console.WriteLine("Caixa removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Caixa não encontrado.");
        }
        Console.ReadLine();
    }
    public void EditarCaixa()
    {
        Console.Clear();
        Console.WriteLine("Editar Caixa");
        ListarCaixas();
        Console.Write("ID: ");
        int id = Convert.ToInt16(Console.ReadLine()!);
        Caixa caixa = repositorioCaixa.BuscarCaixa(id);
        if (caixa != null)
        {
            Console.Write("Etiqueta: ");
            string novoEtiqueta = Console.ReadLine()!;
            Console.Write("Cor: ");
            string novoCor = Console.ReadLine()!;
            Console.Write("Dias de emprestimo: ");
            int novoDiasDeEmprestimo = Convert.ToInt16(Console.ReadLine()!);

            repositorioCaixa.EditarCaixa(caixa, novoEtiqueta, novoCor, novoDiasDeEmprestimo);
            Console.WriteLine("Caixa editado com sucesso!");
        }
        else
        {
            Console.WriteLine("Caixa não encontrado.");
        }
        Console.ReadLine();
    }
}