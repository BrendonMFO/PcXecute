using System.ComponentModel;

namespace PcXecucte_3._0.Classes
{

    public class BM_Comando : INotifyPropertyChanged
    {
        //====================================================================
        // Eventos para binding
        //====================================================================
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        //====================================================================

        //====================================================================
        //Atributos
        //====================================================================
        private string nome = "Novo Comando";
        private string comandoVoz = "";
        private string executavel = "";
        private string teclas = "";
        private bool usarProximoComando = false;
        private int proximoComando = -1;
        private int repeticao = -1;
        //====================================================================

        //====================================================================
        //Propriedades
        //====================================================================
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Nome)));
            }
        }
        public string ComandoVoz
        {
            get { return comandoVoz; }
            set
            {
                comandoVoz = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(ComandoVoz)));
            }
        }
        public string Teclas
        {
            get { return teclas; }
            set
            {
                teclas = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Teclas)));
            }
        }
        public string Executavel
        {
            get { return executavel; }
            set
            {
                executavel = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Executavel)));
            }
        }
        public bool UsarProximoComando
        {
            get { return usarProximoComando; }
            set
            {
                usarProximoComando = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(UsarProximoComando)));
            }
        }
        public int ProximoComando
        {
            get { return proximoComando; }
            set
            {
                proximoComando = value;
            }
        }
        public int Repeticao
        {
            get { return repeticao; }
            set
            {
                repeticao = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Repeticao)));
            }
        }
        public Funcoes Funcao { get; set; } = new Funcoes();
        public Sintese Fala { get; set; } = new Sintese();
        public Mouse MouseDados { get; set; } = new Mouse();
        //====================================================================

        //====================================================================
        // Classe responsavel pela sintese de voz
        //====================================================================
        public class Sintese : INotifyPropertyChanged
        {
            //================================================================
            // Eventos para binding
            //================================================================
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, e);
                }
            }
            //================================================================

            //================================================================
            // Atributos
            //================================================================
            private string texto = "";
            private int volume = 50;
            private int velocidade = 0;
            //================================================================

            //================================================================
            // Propriedades
            //================================================================
            public int Velocidade
            {
                get { return velocidade; }
                set
                {
                    velocidade = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Velocidade)));
                }
            }
            public int Volume
            {
                get { return volume; }
                set
                {
                    volume = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Volume)));
                }
            }
            public string Texto
            {
                get { return texto; }
                set
                {
                    texto = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Texto)));
                }
            }
            //================================================================
        }
        //====================================================================

        //====================================================================
        // Classe responsavel por determinar os dados de movimentação do mouse
        //====================================================================
        public class Mouse : INotifyPropertyChanged
        {
            //================================================================
            // Eventos para binding
            //================================================================
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, e);
                }
            }
            //================================================================

            //================================================================
            // Atributos
            //================================================================
            private int coordenadaX = 0;
            private int coordenadaY = 0;
            public Click Botao { get; set; } = new Click();
            //================================================================

            //================================================================
            // Propriedades
            //================================================================
            public int CoordenadaY
            {
                get { return coordenadaY; }
                set
                {
                    coordenadaY = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(CoordenadaY)));
                }
            }
            public int CoordenadaX
            {
                get { return coordenadaX; }
                set
                {
                    coordenadaX = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(CoordenadaX)));
                }
            }
            //================================================================

            //================================================================
            // Classe de eventos de click dos botões
            //================================================================
            public class Click : INotifyPropertyChanged
            {
                //============================================================
                // Eventos para binding
                //============================================================
                public event PropertyChangedEventHandler PropertyChanged;
                public void OnPropertyChanged(PropertyChangedEventArgs e)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, e);
                    }
                }
                //============================================================

                //============================================================
                // Atributos
                //============================================================
                private bool botaoEsquerdo = false;
                private bool botaoCentral = false;
                private bool botaoDireito = false;
                //============================================================

                //============================================================
                // Propriedades
                //============================================================
                public bool BotaoDireito
                {
                    get { return botaoDireito; }
                    set
                    {
                        botaoDireito = value;
                        OnPropertyChanged(new PropertyChangedEventArgs(nameof(BotaoDireito)));
                    }
                }
                public bool BotaoCentral
                {
                    get { return botaoCentral; }
                    set
                    {
                        botaoCentral = value;
                        OnPropertyChanged(new PropertyChangedEventArgs(nameof(BotaoCentral)));
                    }
                }
                public bool BotaoEsquerdo
                {
                    get { return botaoEsquerdo; }
                    set
                    {
                        botaoEsquerdo = value;
                        OnPropertyChanged(new PropertyChangedEventArgs(nameof(BotaoEsquerdo)));
                    }
                }
                //============================================================
            }
            //================================================================
        }
        //====================================================================

        //====================================================================
        // Classe responsavel por definir as operações que serão executadas
        //====================================================================
        public class Funcoes : INotifyPropertyChanged
        {
            //================================================================
            // Eventos para binding
            //================================================================
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, e);
                }
            }
            //================================================================

            //================================================================
            // Atributos
            //================================================================
            private bool sintese = false;
            private bool teclas = false;
            private bool executavel;
            private bool mouse;
            //================================================================

            //================================================================
            // Propriedades
            //================================================================
            public bool Sintese
            {
                get { return sintese; }
                set
                {
                    sintese = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Sintese)));
                }
            }
            public bool Teclas
            {
                get { return teclas; }
                set
                {
                    teclas = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Teclas)));
                }
            }
            public bool Executavel
            {
                get { return executavel; }
                set
                {
                    executavel = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Executavel)));
                }
            }
            public bool Mouse
            {
                get { return mouse; }
                set
                {
                    mouse = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Mouse)));
                }
            }
            //================================================================
        }
        //====================================================================

    }
}
