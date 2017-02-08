using PcXecucte_3._0.Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PcXecucte_3._0
{
    public partial class Log : Form
    {
        //====================================================================
        //Atributos
        //====================================================================
        private BindingList<BM_Comando> comandos;
        private BM_Reconhecimento reconhecimento;
        //====================================================================

        //====================================================================
        // Metodo construtor
        //====================================================================
        public Log(BindingList<BM_Comando> _comandos)
        {
            InitializeComponent();
            comandos = _comandos;
            reconhecimento = new BM_Reconhecimento(comandos);
        }
        //====================================================================

        //====================================================================
        // Botão - Iniciar / Parar reconhecimento de voz
        //====================================================================
        private void bm_buttonIniciar_Click(object sender, EventArgs e)
        {
            switch (bm_buttonIniciar.Text)
            {
                case "Iniciar reconhecimento de voz":
                    reconhecimento.IniciarEngine();
                    bm_buttonIniciar.Text = "Parar reconhecimento de voz";
                    break;
                case "Parar reconhecimento de voz":
                    reconhecimento.PararEngine();
                    bm_buttonIniciar.Text = "Iniciar reconhecimento de voz";
                    break;
            }
        }
        //====================================================================

        //====================================================================
        // Parar reconhecimento
        //====================================================================
        private void Log_FormClosed(object sender, FormClosedEventArgs e)
        {
            reconhecimento.PararEngine();
        }
        //====================================================================

    }
}
