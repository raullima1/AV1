using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CobrinhaApp.Classes
{
    public static class GerenciadorArqIni
    {
        private static ArquivoIni ini = new ArquivoIni("Config.ini");
        
        //cria um arquivo se não existir
        public static void CriarArquivo()
        {
            if(!File.Exists(ini.Path))
            {
                ini.Write("pontuacaoMax", "0", "JogoCobrinha");
                ini.Write("Colidir", "0", "JogoCobrinha");
            }
        }

        public static bool PontosMax(int pontos)
        {
            return (pontos > int.Parse(ini.Read("pontuacaoMax", "JogoCobrinha")));
        }

        public static void SalvarJogo(int pontos, Cenario.ColidirComAsBordas colidir)
        {
            if(PontosMax(pontos))
                ini.Write("pontuacaoMax", pontos.ToString(), "JogoCobrinha");

            ini.Write("Colidir", ((int)colidir).ToString(), "JogoCobrinha");

        }

        public static Cenario.ColidirComAsBordas GetColidir()
        {
            return (Cenario.ColidirComAsBordas)int.Parse(ini.Read("colidir", "JogoCobrinha"));
        }


    }
}
