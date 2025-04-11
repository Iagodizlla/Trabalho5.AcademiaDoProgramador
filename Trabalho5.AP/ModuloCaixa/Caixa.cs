using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP.ModuloCaixa
{
    public class Caixa
    {
        public int Id { get; set; }
        public string Etiqueta { get; set; }
        public string Cor { get; set; }
        public int DiasDeEmprestimo { get; set; }
        public Revista[] Revistas { get; set; }
        public Caixa(string etiqueta, string cor, int diasDeEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasDeEmprestimo = diasDeEmprestimo;
            Revistas = new Revista[100];
        }
        public void AdicionarRevista(Revista revista)
        {
            for (int i = 0; i < Revistas.Length; i++)
            {
                if (Revistas[i] == null)
                {
                    Revistas[i] = revista;
                    break;
                }
            }
        }
        public void RemoverRevista(Revista revista)
        {
            for (int i = 0; i < Revistas.Length; i++)
            {
                if (Revistas[i] == revista)
                {
                    Revistas[i] = null!;
                    break;
                }
            }
        }
        public int ObterQuantidadeRevistas()
        {
            int contador = 0;

            for (int i = 0; i < Revistas.Length; i++)
            {
                if (Revistas[i] != null)
                    contador++;
            }
            return contador;
        }
    }
}