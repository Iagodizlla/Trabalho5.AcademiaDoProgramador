using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.ModuloEmprestimo;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP.ModuloAmigo;

public class Amigo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Responsavel { get; set; }
    public Emprestimo[] Emprestimos { get; set; }

    public Amigo(string nome, string telefone, string responsavel)
    {
        Nome = nome;
        Telefone = telefone;
        Responsavel = responsavel;
        Emprestimos = new Emprestimo[100];
    }
    public void AdicionarEmprestimo(Emprestimo emprestimo)
    {
        for (int i = 0; i < Emprestimos.Length; i++)
        {
            if (Emprestimos[i] == null)
            {
                Emprestimos[i] = emprestimo;
                break;
            }
        }
    }
    public void RemoverEmprestimo(Emprestimo emprestimo)
    {
        for (int i = 0; i < Emprestimos.Length; i++)
        {
            if (Emprestimos[i] == emprestimo)
            {
                Emprestimos[i] = null!;
                break;
            }
        }
    }
    public string Validar()
    {
        string erros = "";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (Nome.Length > 100)
            erros += "O campo 'Nome' precisa conter ao maximo 100 caracteres.\n";

        if (Responsavel.Length < 3)
            erros += "O campo 'Responsavel' precisa conter ao menos 3 caracteres.\n";

        if (Responsavel.Length > 100)
            erros += "O campo 'Responsavel' precisa conter ao maximo 100 caracteres.\n";

        if (Telefone.Length < 12)
            erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.";

        return erros;
    }
}