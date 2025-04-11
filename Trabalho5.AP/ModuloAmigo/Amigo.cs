using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho5.AP.ModuloAmigo;

public class Amigo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Responsavel { get; set; }

    public Amigo(string nome, string telefone, string responsavel)
    {
        Nome = nome;
        Telefone = telefone;
        Responsavel = responsavel;
    }
    public string Validar()
    {
        string erros = "";

        if (Nome.Length < 3)
            erros += "O campo 'Nome' precisa conter ao menos 3 caracteres.\n";

        if (Responsavel.Length < 3)
            erros += "O campo 'Responsavel' precisa conter ao menos 3 caracteres.\n";

        if (Telefone.Length < 12)
            erros += "O campo 'Telefone' deve seguir o formato 00 0000-0000.";

        return erros;
    }
}