using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho5.AP.Compartilhado;

public class GeradorId
{
    private static int IdAmigo = 0;
    private static int IdCaixa = 0;
    private static int IdRevista = 0;
    public static int GerarIdAmigo()
    {
        return ++IdAmigo;
    }
    public static int GerarIdCaixa()
    {
        return ++IdCaixa;
    }
    public static int GerarIdRevista()
    {
        return ++IdRevista;
    }
}