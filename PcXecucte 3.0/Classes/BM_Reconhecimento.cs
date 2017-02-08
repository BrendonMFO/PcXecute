using System.Collections.Generic;
using Microsoft.Speech.Recognition;
using System.ComponentModel;

namespace PcXecucte_3._0.Classes
{
    class BM_Reconhecimento
    {
        //====================================================================
        //Atributos
        //====================================================================
        private SpeechRecognitionEngine speechEngine;
        private BindingList<BM_Comando> comandos;
        private BM_Executar executar;
        //====================================================================

        //====================================================================
        //Metodo construtor
        //====================================================================
        public BM_Reconhecimento(BindingList<BM_Comando> _comandos)
        {
            speechEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("pt-BR"));
            comandos = _comandos;
        }
        //====================================================================

        //====================================================================
        // Iniciar speechEngine
        //====================================================================
        public void IniciarEngine()
        {
            List<string> tempList = new List<string>();
            Choices choices = new Choices();
            string[] listaComandos = montarComandos();
            if (listaComandos.Length > 0)
            {
                choices.Add(listaComandos);
                speechEngine.LoadGrammar(new Grammar(new GrammarBuilder(choices)));
                speechEngine.SetInputToDefaultAudioDevice();
                speechEngine.RecognizeAsync(RecognizeMode.Multiple);
                speechEngine.SpeechRecognized += SpeechEngine_SpeechRecognized;
                executar = new BM_Executar();
            }
        }
        //====================================================================

        //====================================================================
        // Parar speechEngine
        //====================================================================
        public void PararEngine()
        {
            speechEngine.RecognizeAsyncCancel();
        }
        //====================================================================

        //====================================================================
        // Iniciar reconhecimento
        //====================================================================
        private void SpeechEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (var item in comandos)
            {
                if(e.Result.Text == item.ComandoVoz)
                {
                    if (item.Repeticao != 0)
                    {
                        chamarExecucao(item);
                    }
                }
            }
        }
        //====================================================================

        //====================================================================
        // Chamar metodo de execução
        //====================================================================
        private void chamarExecucao(BM_Comando _comando)
        {
            executar.executarFuncoesAtuais(_comando);
            if (_comando.UsarProximoComando)
            {
                chamarExecucao(comandos[_comando.ProximoComando]);
            }
        }
        //====================================================================

        //====================================================================
        // Montar Listas de Comandos
        //====================================================================
        private string[] montarComandos()
        {
            List<string> retorno = new List<string>();
            foreach (var item in comandos)
            {
                if(item.Repeticao != 0 && !string.IsNullOrEmpty(item.ComandoVoz))
                    retorno.Add(item.ComandoVoz);
            }
            return retorno.ToArray();
        }
        //====================================================================
    }
}
