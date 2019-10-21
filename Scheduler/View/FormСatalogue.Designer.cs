namespace Scheduler.View
{
    partial class FormСatalogue
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonReturnToMain = new System.Windows.Forms.Button();
            this.listBoxCatalogues = new System.Windows.Forms.ListBox();
            this.dataGridViewCurrentCatalogue = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentCatalogue)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonReturnToMain);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxCatalogues);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewCurrentCatalogue);
            this.splitContainer1.Size = new System.Drawing.Size(857, 486);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonReturnToMain
            // 
            this.buttonReturnToMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReturnToMain.Location = new System.Drawing.Point(3, 426);
            this.buttonReturnToMain.Name = "buttonReturnToMain";
            this.buttonReturnToMain.Size = new System.Drawing.Size(207, 50);
            this.buttonReturnToMain.TabIndex = 1;
            this.buttonReturnToMain.Text = "Возврат к главной форме";
            this.buttonReturnToMain.UseVisualStyleBackColor = true;
            // 
            // listBoxCatalogues
            // 
            this.listBoxCatalogues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCatalogues.FormattingEnabled = true;
            this.listBoxCatalogues.ItemHeight = 16;
            this.listBoxCatalogues.Items.AddRange(new object[] {
            "Преподаватели",
            "Учебные группы",
            "Аудитории",
            "Дисциплины"});
            this.listBoxCatalogues.Location = new System.Drawing.Point(0, 0);
            this.listBoxCatalogues.Name = "listBoxCatalogues";
            this.listBoxCatalogues.Size = new System.Drawing.Size(211, 420);
            this.listBoxCatalogues.TabIndex = 0;
            this.listBoxCatalogues.SelectedIndexChanged += new System.EventHandler(this.listBoxCatalogues_SelectedIndexChanged);
            // 
            // dataGridViewCurrentCatalogue
            // 
            this.dataGridViewCurrentCatalogue.AllowUserToDeleteRows = false;
            this.dataGridViewCurrentCatalogue.AllowUserToResizeRows = false;
            this.dataGridViewCurrentCatalogue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCurrentCatalogue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCurrentCatalogue.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCurrentCatalogue.Name = "dataGridViewCurrentCatalogue";
            this.dataGridViewCurrentCatalogue.RowTemplate.Height = 24;
            this.dataGridViewCurrentCatalogue.Size = new System.Drawing.Size(640, 486);
            this.dataGridViewCurrentCatalogue.TabIndex = 1;
            // 
            // FormСatalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 486);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(875, 533);
            this.Name = "FormСatalogue";
            this.Text = "FormСatalogue";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrentCatalogue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBoxCatalogues;
        private System.Windows.Forms.DataGridView dataGridViewCurrentCatalogue;
        private System.Windows.Forms.Button buttonReturnToMain;
    }
}