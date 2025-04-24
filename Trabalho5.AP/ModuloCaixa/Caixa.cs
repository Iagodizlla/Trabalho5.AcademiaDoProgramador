using Trabalho5.AP.Compartilhado;
using Trabalho5.AP.ModuloAmigo;
using Trabalho5.AP.ModuloRevista;

namespace Trabalho5.AP.ModuloCaixa
{
    public class Caixa : EntidadeBase
    {
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
        public override void AtualizarRegistro(EntidadeBase registroAtualizado)
        {
            Caixa caixaAtualizado = (Caixa)registroAtualizado;

            Etiqueta = caixaAtualizado.Etiqueta;
            Cor = caixaAtualizado.Cor;
            DiasDeEmprestimo = caixaAtualizado.DiasDeEmprestimo;
        }
        public override string Validar()
        {
            string erros = "";

            if (Cor.Length < 3)
                erros += "O campo 'Cor' precisa conter ao menos 3 caracteres.\n";

            if (Etiqueta.Length > 50)
                erros += "O campo 'Etiqueta' precisa conter ao maximo 50 caracteres.\n";

            if (DiasDeEmprestimo < 0 )
               erros += "O campo 'Dias de Emprestimo' deve ser positivo.";

            return erros;
        }
    }
}