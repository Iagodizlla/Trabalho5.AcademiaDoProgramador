namespace Trabalho5.AP.Compartilhado;

public class EntidadeBase
{
    public int Id { get; set; }

    public abstract void AtualizarRegistro(EntidadeBase registroEditado);
    public abstract string Validar();
}