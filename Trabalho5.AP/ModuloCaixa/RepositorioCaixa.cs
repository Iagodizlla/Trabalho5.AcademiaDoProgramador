using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloAmigo;

namespace Trabalho5.AP.ModuloCaixa
{
    public class RepositorioCaixa
    {
        public Caixa[] caixas = new Caixa[100];
        public int contadorCaixas = 0;
        public void AdicionarCaixa(Caixa caixa)
        {
            caixa.Id = GeradorId.GerarIdCaixa();
            caixas[contadorCaixas++] = caixa;
        }
        public Caixa[] ListarCaixas()
        {
            Caixa[] caixasAtuais = new Caixa[contadorCaixas];
            for (int i = 0; i < contadorCaixas; i++)
            {
                caixasAtuais[i] = caixas[i];
            }
            return caixasAtuais;
        }
        public void RemoverCaixa(Caixa caixa)
        {
            for (int i = 0; i < contadorCaixas; i++)
            {
                if (caixas[i] == caixa)
                {
                    caixas[i] = null!;
                    break;
                }
            }
        }
        public Caixa BuscarCaixa(int id)
        {
            for (int i = 0; i < contadorCaixas; i++)
            {
                if (caixas[i].Id == id)
                {
                    return caixas[i];
                }
            }
            return null!;
        }
        public void EditarCaixa(Caixa caixa, string novoEtiqueta, string novoCor, int novoDiasDeEmprestimo)
        {
            for (int i = 0; i < contadorCaixas; i++)
            {
                if (caixas[i] == caixa)
                {
                    caixas[i].Etiqueta = novoEtiqueta;
                    //caixas[i].Cor = novoCor;
                    caixas[i].DiasDeEmprestimo = novoDiasDeEmprestimo;
                    break;
                }
            }
        }
    }
}