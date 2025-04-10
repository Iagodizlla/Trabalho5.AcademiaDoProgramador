using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho5.AP.Compartilhado;

public class GeradorId
{
    private static int IdAmigo = 0;

    public static int GerarIdAmigo()
    {
        return ++IdAmigo;
    }
}