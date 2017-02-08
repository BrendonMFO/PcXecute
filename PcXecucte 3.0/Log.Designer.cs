namespace PcXecucte_3._0
{
    partial class Log
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
            this.bm_buttonIniciar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bm_buttonIniciar
            // 
            this.bm_buttonIniciar.Location = new System.Drawing.Point(12, 12);
            this.bm_buttonIniciar.Name = "bm_buttonIniciar";
            this.bm_buttonIniciar.Size = new System.Drawing.Size(400, 52);
            this.bm_buttonIniciar.TabIndex = 1;
            this.bm_buttonIniciar.Text = "Iniciar reconhecimento de voz";
            this.bm_buttonIniciar.UseVisualStyleBackColor = true;
            this.bm_buttonIniciar.Click += new System.EventHandler(this.bm_buttonIniciar_Click);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 73);
            this.Controls.Add(this.bm_buttonIniciar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Log";
            this.Text = "Log";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Log_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bm_buttonIniciar;
    }
}