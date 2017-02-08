using Microsoft.Speech.Synthesis;

namespace PcXecucte_3._0.Classes
{
    class BM_Sintese
    {
        //====================================================================
        //Atributos estaticos
        //====================================================================
        private static BM_Sintese instancia;
        private static object objLock = new object();
        //====================================================================

        //====================================================================
        // GetInstance
        //====================================================================
        public static BM_Sintese getInstance()
        {
            lock (objLock)
            {
                if (instancia == null) instancia = new BM_Sintese();
                return instancia;
            }
        }
        //====================================================================

        //====================================================================
        //Atributos
        //====================================================================
        private SpeechSynthesizer speechEngine;
        //====================================================================

        //====================================================================
        //Metodo construtor
        //====================================================================
        private BM_Sintese()
        {
            speechEngine = new SpeechSynthesizer();
        }
        //====================================================================

        //====================================================================
        // Executar sintese
        //====================================================================
        public void Executar(BM_Comando.Sintese _dados)
        {
            speechEngine.Rate = _dados.Velocidade;
            speechEngine.Volume = _dados.Volume;
            if (!string.IsNullOrWhiteSpace(_dados.Texto))
            {
                switch (speechEngine.State)
                {
                    case SynthesizerState.Ready:
                        speechEngine.SetOutputToDefaultAudioDevice();
                        speechEngine.SpeakAsync(_dados.Texto);
                        break;
                }
            }
        }
        //====================================================================

    }
}
