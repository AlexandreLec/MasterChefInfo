namespace SimulationRestaurant
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_stop_sim = new System.Windows.Forms.Button();
            this.LogDisplay = new System.Windows.Forms.TextBox();
            this.btn_start_sim = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_conf_save = new System.Windows.Forms.Button();
            this.txt_conf_nb_server = new System.Windows.Forms.TextBox();
            this.label_nb_server = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(708, 311);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_stop_sim);
            this.tabPage1.Controls.Add(this.LogDisplay);
            this.tabPage1.Controls.Add(this.btn_start_sim);
            this.tabPage1.Location = new System.Drawing.Point(4, 10);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(700, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simulation";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_stop_sim
            // 
            this.btn_stop_sim.Location = new System.Drawing.Point(163, 246);
            this.btn_stop_sim.Margin = new System.Windows.Forms.Padding(4);
            this.btn_stop_sim.Name = "btn_stop_sim";
            this.btn_stop_sim.Size = new System.Drawing.Size(151, 28);
            this.btn_stop_sim.TabIndex = 2;
            this.btn_stop_sim.Text = "Stop Simulation";
            this.btn_stop_sim.UseVisualStyleBackColor = true;
            // 
            // LogDisplay
            // 
            this.LogDisplay.Location = new System.Drawing.Point(4, 7);
            this.LogDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.LogDisplay.Multiline = true;
            this.LogDisplay.Name = "LogDisplay";
            this.LogDisplay.ReadOnly = true;
            this.LogDisplay.Size = new System.Drawing.Size(688, 230);
            this.LogDisplay.TabIndex = 1;
            // 
            // btn_start_sim
            // 
            this.btn_start_sim.Location = new System.Drawing.Point(4, 246);
            this.btn_start_sim.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start_sim.Name = "btn_start_sim";
            this.btn_start_sim.Size = new System.Drawing.Size(151, 28);
            this.btn_start_sim.TabIndex = 0;
            this.btn_start_sim.Text = "Start Simulation";
            this.btn_start_sim.UseVisualStyleBackColor = true;
            this.btn_start_sim.Click += new System.EventHandler(this.btn_start_sim_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_conf_save);
            this.tabPage2.Controls.Add(this.txt_conf_nb_server);
            this.tabPage2.Controls.Add(this.label_nb_server);
            this.tabPage2.Location = new System.Drawing.Point(4, 10);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(700, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_conf_save
            // 
            this.btn_conf_save.Location = new System.Drawing.Point(11, 244);
            this.btn_conf_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_conf_save.Name = "btn_conf_save";
            this.btn_conf_save.Size = new System.Drawing.Size(120, 28);
            this.btn_conf_save.TabIndex = 2;
            this.btn_conf_save.Text = "Save";
            this.btn_conf_save.UseVisualStyleBackColor = true;
            // 
            // txt_conf_nb_server
            // 
            this.txt_conf_nb_server.Location = new System.Drawing.Point(165, 17);
            this.txt_conf_nb_server.Margin = new System.Windows.Forms.Padding(4);
            this.txt_conf_nb_server.Name = "txt_conf_nb_server";
            this.txt_conf_nb_server.Size = new System.Drawing.Size(44, 24);
            this.txt_conf_nb_server.TabIndex = 1;
            // 
            // label_nb_server
            // 
            this.label_nb_server.AutoSize = true;
            this.label_nb_server.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_nb_server.Location = new System.Drawing.Point(8, 21);
            this.label_nb_server.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_nb_server.Name = "label_nb_server";
            this.label_nb_server.Size = new System.Drawing.Size(0, 20);
            this.label_nb_server.TabIndex = 0;
            this.label_nb_server.Text = "Nombre de Serveur(s)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(0F, 0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 311);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "SimulationRestaurant";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_stop_sim;
        private System.Windows.Forms.TextBox LogDisplay;
        private System.Windows.Forms.Button btn_start_sim;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_conf_save;
        private System.Windows.Forms.TextBox txt_conf_nb_server;
        private System.Windows.Forms.Label label_nb_server;
    }
}

