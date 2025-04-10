using System;
using System.Collections.Generic;
using System.Linq;
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
}