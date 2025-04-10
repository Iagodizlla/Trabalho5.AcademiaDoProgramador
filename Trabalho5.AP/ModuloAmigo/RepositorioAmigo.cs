using Trabalho5.AP.Compartilhado;

namespace Trabalho5.AP.ModuloAmigo;

public class RepositorioAmigo
{
    public Amigo[] amigos = new Amigo[100];
    public int contadorAmigos = 0;
    public void AdicionarAmigo(Amigo amigo)
    {
        amigo.Id = GeradorId.GerarIdAmigo();
        amigos[contadorAmigos++] = amigo;
    }
    
    public void RemoverAmigo(Amigo amigo)
    {
        for (int i = 0; i < contadorAmigos; i++)
        {
            if (amigos[i] == amigo)
            {
                amigos[i] = null!;
                break;
            }
        }
    }
    public Amigo[] ListarAmigos()
    {
        Amigo[] amigosAtuais = new Amigo[contadorAmigos];
        for (int i = 0; i < contadorAmigos; i++)
        {
            amigosAtuais[i] = amigos[i];
        }
        return amigosAtuais;
    }
    public Amigo BuscarAmigo(int id)
    {
        for (int i = 0; i < contadorAmigos; i++)
        {
            if (amigos[i].Id == id)
            {
                return amigos[i];
            }
        }
        return null!;
    }
    public void EditarAmigo(Amigo amigo, string novoNome, string novoTelefone, string novoResponsavel)
    {
        for (int i = 0; i < contadorAmigos; i++)
        {
            if (amigos[i] == amigo)
            {
                amigos[i].Nome = novoNome;
                amigos[i].Telefone = novoTelefone;
                amigos[i].Responsavel = novoResponsavel;
                break;
            }
        }
    }
}