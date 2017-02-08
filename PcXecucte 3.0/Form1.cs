using PcXecucte_3._0.Classes;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PcXecucte_3._0
{
    public partial class Form1 : Form
    {
        //====================================================================
        //Atributos
        //====================================================================
        private BindingList<BM_Comando> comandos;
        private string caminhoArquivo;
        private int indexAtual;
        //====================================================================

        //====================================================================
        // Metodo construtor
        //====================================================================
        public Form1()
        {
            InitializeComponent();
        }
        //====================================================================

        //====================================================================
        // Metodo para iniciar um novo comando
        //====================================================================
        private void bm_novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comandos = new BindingList<BM_Comando>();
            caminhoArquivo = "";
            bindComboBoxComandos();
            alterarEnableComandos(true);
        }
        //====================================================================

        //====================================================================
        // Adicionar novo comando
        //====================================================================
        private void adicionarNovoComando()
        {
            comandos.Add(new BM_Comando());
            bm_comboBox_comandos.SelectedIndex = comandos.Count - 1;
        }
        //====================================================================

        //====================================================================
        // Unbinding de dados
        //====================================================================
        private void unBidingDados()
        {
            bm_comboBox_comandos.DataBindings.Clear();
            bm_comando_reconhecimento.DataBindings.Clear();
            bm_richText_sintese.DataBindings.Clear();
            bm_textBox_caminhoExe.DataBindings.Clear();
            bm_richText_teclas.DataBindings.Clear();
            bm_Quantidades.DataBindings.Clear();
            bm_coordenadaX.DataBindings.Clear();
            bm_coordenadaY.DataBindings.Clear();
            bm_trackBar_velocidade.DataBindings.Clear();
            bm_trackBar_volume.DataBindings.Clear();
            bm_checkBox_sintese.DataBindings.Clear();
            bm_checkBox_teclas.DataBindings.Clear();
            bm_checkBox_executavel.DataBindings.Clear();
            bm_checkBox_mouse.DataBindings.Clear();
            bm_checkBox_mouseEsquerdo.DataBindings.Clear();
            bm_checkBox_mouseCentral.DataBindings.Clear();
            bm_checkBox_mouseDireito.DataBindings.Clear();
            bm_checkBox_proximo.DataBindings.Clear();
        }
        //====================================================================

        //====================================================================
        // Binding de dados
        //====================================================================
        private void bindingDados()
        {
            unBidingDados();
            bm_comboBox_comandos.DataBindings.Add(new Binding("Text", comandos[indexAtual], "Nome"));
            bm_comando_reconhecimento.DataBindings.Add(new Binding("Text", comandos[indexAtual], "ComandoVoz"));
            bm_richText_sintese.DataBindings.Add(new Binding("Text", comandos[indexAtual].Fala, "Texto"));
            bm_textBox_caminhoExe.DataBindings.Add(new Binding("Text", comandos[indexAtual], "Executavel"));
            bm_richText_teclas.DataBindings.Add(new Binding("Text", comandos[indexAtual], "Teclas"));
            bm_Quantidades.DataBindings.Add(new Binding("Value", comandos[indexAtual], "Repeticao"));
            bm_coordenadaX.DataBindings.Add(new Binding("Value", comandos[indexAtual].MouseDados, "CoordenadaX"));
            bm_coordenadaY.DataBindings.Add(new Binding("Value", comandos[indexAtual].MouseDados, "CoordenadaY"));
            bm_trackBar_velocidade.DataBindings.Add(new Binding("Value", comandos[indexAtual].Fala, "Velocidade"));
            bm_trackBar_volume.DataBindings.Add(new Binding("Value", comandos[indexAtual].Fala, "Volume"));
            bm_checkBox_sintese.DataBindings.Add(new Binding("Checked", comandos[indexAtual].Funcao, "Sintese"));
            bm_checkBox_teclas.DataBindings.Add(new Binding("Checked", comandos[indexAtual].Funcao, "Teclas"));
            bm_checkBox_executavel.DataBindings.Add(new Binding("Checked", comandos[indexAtual].Funcao, "Executavel"));
            bm_checkBox_mouse.DataBindings.Add(new Binding("Checked", comandos[indexAtual].Funcao, "Mouse"));
            bm_checkBox_mouseEsquerdo.DataBindings.Add(new Binding("Checked", comandos[indexAtual].MouseDados.Botao, "BotaoEsquerdo"));
            bm_checkBox_mouseCentral.DataBindings.Add(new Binding("Checked", comandos[indexAtual].MouseDados.Botao, "BotaoCentral"));
            bm_checkBox_mouseDireito.DataBindings.Add(new Binding("Checked", comandos[indexAtual].MouseDados.Botao, "BotaoDireito"));
            bm_checkBox_proximo.DataBindings.Add(new Binding("Checked", comandos[indexAtual], "UsarProximoComando"));
        }
        //====================================================================

        //====================================================================
        // Bind ComboBox
        //====================================================================
        private void bindComboBoxComandos()
        {
            bm_comboBox_comandos.DataSource = comandos;
            bm_comboBox_comandos.DisplayMember = "Nome";
            itensComboBoxProximo();
        }
        //====================================================================

        //====================================================================
        // ComboBox Proximo comando
        //====================================================================
        private void itensComboBoxProximo()
        {
            bm_comboBox_proximoComando.Items.Clear();
            foreach (var item in comandos)
            {
                bm_comboBox_proximoComando.Items.Add(item.Nome);
            }
            if(bm_comboBox_proximoComando.Items.Count > 0)
                bm_comboBox_proximoComando.SelectedIndex = comandos[indexAtual].ProximoComando;
        }
        //====================================================================

        //====================================================================
        // Modificar enabled componentes
        //====================================================================
        private void alterarEnableComandos(bool _valor)
        {
            bm_Funcoes.Enabled = _valor;
            bm_bAdd.Enabled = _valor;
            bm_bExcluir.Enabled = _valor;
            bm_bSalvar.Enabled = _valor;
            bm_bIniciar.Enabled = _valor;
            bm_Quantidades.Enabled = _valor;
            bm_comboBox_comandos.Enabled = _valor;
            bm_comando_reconhecimento.Enabled = _valor;
            bm_button_limpar.Enabled = _valor;
        }
        //====================================================================

        //====================================================================
        // Adicionar novo comando
        //====================================================================
        private void bm_bAdd_Click(object sender, EventArgs e)
        {
            adicionarNovoComando();
            bindingDados(); 
        }
        //====================================================================

        //====================================================================
        // Atualizar bindings quando o usuario alterar a seleção
        //====================================================================
        private void bm_comboBox_comandos_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexAtual = bm_comboBox_comandos.SelectedIndex;
            bindingDados();
            itensComboBoxProximo();
        }
        //====================================================================

        //====================================================================
        // Botão Excluir
        //====================================================================
        private void bm_bExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir esse comando ?", "Excluir comando", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(comandos.Count > 0)
                {
                    comandos.RemoveAt(bm_comboBox_comandos.SelectedIndex);
                }
            }
        }
        //====================================================================

        //====================================================================
        // Salvar
        //====================================================================
        private void salvar(string _caminho = "")
        {
            BM_JsonSL<BindingList<BM_Comando>> salvar = new BM_JsonSL<BindingList<BM_Comando>>();
            caminhoArquivo = salvar.salvarJson(_caminho, comandos);
        }
        private void bm_bSalvar_Click(object sender, EventArgs e)
        {
            salvar(caminhoArquivo);
        }
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvar(caminhoArquivo);
        }
        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvar();
        }
        //====================================================================

        //====================================================================
        // Carregar dados
        //====================================================================
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BM_JsonSL<BindingList<BM_Comando>> carregar = new BM_JsonSL<BindingList<BM_Comando>>();
            comandos = carregar.carregarDados(out caminhoArquivo);
            if (comandos != null)
            {
                alterarEnableComandos(true);
                bindComboBoxComandos();
            }
        }
        //====================================================================

        //====================================================================
        // Botão iniciar
        //====================================================================
        private void bm_bIniciar_Click(object sender, EventArgs e)
        {
            if (comandos.Count > 0 )
            {
                Log form2 = new Log(comandos);
                this.Hide();
                form2.ShowDialog();
                this.Show();
            }
        }
        //====================================================================

        //====================================================================
        // Abrir executavel
        //====================================================================
        private void bm_button_adicionarExecutavel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                comandos[indexAtual].Executavel = openFile.FileName;
            }
        }
        //====================================================================

        //====================================================================
        // Botão limpar
        //====================================================================
        private void bm_button_limpar_Click(object sender, EventArgs e)
        {
            comandos[indexAtual] = new BM_Comando();
            bindingDados();
        }
        //====================================================================

        //====================================================================
        // Propriedades
        //====================================================================
        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ajuda ajuda = new Ajuda();
            ajuda.Show();
        }
        //====================================================================

        //====================================================================
        // Ativar/Desativar proximo comando
        //====================================================================
        private void bm_checkBox_proximo_CheckedChanged(object sender, EventArgs e)
        {
            if (bm_comboBox_proximoComando.Enabled)
                bm_comboBox_proximoComando.Enabled = false;
            else
            {
                bm_comboBox_proximoComando.Enabled = true;
                if (bm_comboBox_proximoComando.Items.Count > 0)
                    bm_comboBox_proximoComando.SelectedIndex = comandos[indexAtual].ProximoComando;
            }
        }
        //====================================================================

        //====================================================================
        // Atualizar proximo comando
        //====================================================================
        private void bm_comboBox_proximoComando_SelectedIndexChanged(object sender, EventArgs e)
        {
            comandos[indexAtual].ProximoComando = bm_comboBox_proximoComando.SelectedIndex;
        }
        //====================================================================

    }
}
