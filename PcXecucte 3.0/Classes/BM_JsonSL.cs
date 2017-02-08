using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace PcXecucte_3._0.Classes
{
    //========================================================================
    // Classe responsavel por salvar e carregar os dados
    //========================================================================
    class BM_JsonSL<T>
    {
        //====================================================================
        // Salvar dados
        //====================================================================
        public string salvarJson(string _caminho, T _objeto)
        {
            string json = JsonConvert.SerializeObject(_objeto);
            if (string.IsNullOrEmpty(_caminho))
            {
                SaveFileDialog bm_save = new SaveFileDialog();
                bm_save.Title = "Salvar Configurações";
                bm_save.Filter = "PcX|*.pcx|All files|*.*";
                bm_save.FilterIndex = 1;
                if (bm_save.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(bm_save.FileName, json);
                    MessageBox.Show("Arquivo Salvo");
                    return bm_save.FileName;
                }
                return _caminho;
            }
            File.WriteAllText(_caminho, json);
            return _caminho;
        }
        //====================================================================

        //====================================================================
        // Carregar Dados
        //====================================================================
        public T carregarDados(out string _caminho)
        {
            OpenFileDialog bm_fileOpen = new OpenFileDialog();
            bm_fileOpen.Filter = "PcX|*.pcx*";
            if (bm_fileOpen.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(bm_fileOpen.FileName);
                _caminho = bm_fileOpen.FileName;
                try {
                    T retorno = JsonConvert.DeserializeObject<T>(json);
                    return retorno;
                }
                catch (JsonReaderException e)
                {
                    MessageBox.Show("Não foi possivel carregar o arquivo");
                }
            }
            _caminho = "";
            return default(T);
        }
        //====================================================================

    }
}
