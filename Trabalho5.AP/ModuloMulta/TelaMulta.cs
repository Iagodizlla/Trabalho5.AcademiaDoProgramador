using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.ModuloEmprestimo;

namespace Trabalho5.AP.ModuloMulta
{
    public class TelaMulta
    {
        RepositorioMulta repositorioMulta;
        RepositorioEmprestimo repositorioEmprestimo;
        public TelaMulta(RepositorioMulta repositorioMulta, RepositorioEmprestimo repositorioEmprestimo)
        {
            this.repositorioMulta = repositorioMulta;
            this.repositorioEmprestimo = repositorioEmprestimo;
        }
        public void ListarMultasAbertas()
        {
            Console.Clear();
            Emprestimo[] emprestimo = repositorioEmprestimo.ListarEmprestimos();
            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -20} | {3, -15} | {4, -15} | {5, -10}",
            "ID", "Nome Amigo", "Titulo Revista", "Situacao", "Data Restante", "Multa"
            );
            for (int i = 0; i < emprestimo.Length; i++)
            {
                if (emprestimo[i] == null) continue;
                TimeSpan Data = emprestimo[i].DataFinal - DateTime.Today;
                int data = Convert.ToInt32(Data);
                if (data < 0)
                {
                    emprestimo[i].Multa = data * 2;
                    Console.WriteLine(
                    "{0, -6} | {1, -20} | {2, -20} | {3, -15} | {4, -15} | {5, -10}",
                    emprestimo[i].Id, emprestimo[i].Amigo.Nome, emprestimo[i].Revista.Titulo, emprestimo[i].Situacao, Data.ToString("dd"), $"{emprestimo[i].Multa} reais"
                    );
                }
            }
        }
    }
}