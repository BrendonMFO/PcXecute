using System.Diagnostics;
using System.Windows.Forms;

namespace PcXecucte_3._0.Classes
{
    class BM_Executar
    {
        //====================================================================
        // Executar funções
        //====================================================================
        public void executarFuncoesAtuais(BM_Comando _comando)
        {
            if (_comando.Funcao.Teclas)
                sendKey(_comando.Teclas);
            if (_comando.Funcao.Executavel)
                abrirExecutavel(_comando.Executavel);
            if (_comando.Funcao.Sintese)
                executarSintese(_comando.Fala);
            if (_comando.Funcao.Mouse)
                executarEventosMouse(_comando.MouseDados);
            if (_comando.Repeticao > 0)
                _comando.Repeticao--;
        }
        //====================================================================

        //====================================================================
        // SendKey
        //====================================================================
        private void sendKey(string _keys)
        {
            SendKeys.SendWait(_keys);
        }
        //====================================================================

        //====================================================================
        // Abrir executavel
        //====================================================================
        private void abrirExecutavel(string _caminho)
        {
            Process.Start(@_caminho);
        }
        //====================================================================

        //====================================================================
        // Executar sintese
        //====================================================================
        private void executarSintese(BM_Comando.Sintese _sintese)
        {
            BM_Sintese.getInstance().Executar(_sintese);
        }
        //====================================================================

        //====================================================================
        // Executar eventos mouse
        //====================================================================
        private void executarEventosMouse(BM_Comando.Mouse _mouse)
        {
            BM_Mouse.getInstance().EventCommandMouse(_mouse);
        }
        //====================================================================
    }
}
