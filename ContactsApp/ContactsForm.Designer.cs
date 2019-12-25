namespace ContactsApp
{
    partial class ContactsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Colaborador = new System.Windows.Forms.Label();
            this.EmployeeDropdown = new System.Windows.Forms.ComboBox();
            this.CompanyDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EmployeesList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Colaborador);
            this.panel1.Controls.Add(this.EmployeeDropdown);
            this.panel1.Controls.Add(this.CompanyDropdown);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 181);
            this.panel1.TabIndex = 0;
            // 
            // Colaborador
            // 
            this.Colaborador.AutoSize = true;
            this.Colaborador.Location = new System.Drawing.Point(18, 53);
            this.Colaborador.Name = "Colaborador";
            this.Colaborador.Size = new System.Drawing.Size(64, 13);
            this.Colaborador.TabIndex = 3;
            this.Colaborador.Text = "Colaborador";
            // 
            // EmployeeDropdown
            // 
            this.EmployeeDropdown.FormattingEnabled = true;
            this.EmployeeDropdown.Location = new System.Drawing.Point(88, 53);
            this.EmployeeDropdown.Name = "EmployeeDropdown";
            this.EmployeeDropdown.Size = new System.Drawing.Size(121, 21);
            this.EmployeeDropdown.TabIndex = 2;
            this.EmployeeDropdown.SelectedIndexChanged += new System.EventHandler(this.EmployeeDropdown_SelectedIndexChanged);
            // 
            // CompanyDropdown
            // 
            this.CompanyDropdown.FormattingEnabled = true;
            this.CompanyDropdown.Location = new System.Drawing.Point(88, 16);
            this.CompanyDropdown.Name = "CompanyDropdown";
            this.CompanyDropdown.Size = new System.Drawing.Size(121, 21);
            this.CompanyDropdown.TabIndex = 1;
            this.CompanyDropdown.SelectedIndexChanged += new System.EventHandler(this.CompanyDropdown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // EmployeesList
            // 
            this.EmployeesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeesList.Location = new System.Drawing.Point(255, 38);
            this.EmployeesList.Name = "EmployeesList";
            this.EmployeesList.Size = new System.Drawing.Size(533, 227);
            this.EmployeesList.TabIndex = 1;
            // 
            // ContactsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EmployeesList);
            this.Controls.Add(this.panel1);
            this.Name = "ContactsForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Colaborador;
        private System.Windows.Forms.ComboBox EmployeeDropdown;
        private System.Windows.Forms.ComboBox CompanyDropdown;
        private System.Windows.Forms.DataGridView EmployeesList;
    }
}

