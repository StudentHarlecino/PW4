namespace PartnersDB
{
    partial class FormPartnersProducts
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
            historyOfProducts = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)historyOfProducts).BeginInit();
            SuspendLayout();
            // 
            // historyOfProducts
            // 
            historyOfProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            historyOfProducts.BackgroundColor = Color.White;
            historyOfProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historyOfProducts.Dock = DockStyle.Fill;
            historyOfProducts.Location = new Point(16, 17);
            historyOfProducts.Margin = new Padding(5);
            historyOfProducts.MultiSelect = false;
            historyOfProducts.Name = "historyOfProducts";
            historyOfProducts.ReadOnly = true;
            historyOfProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            historyOfProducts.Size = new Size(952, 508);
            historyOfProducts.TabIndex = 0;
            // 
            // FormPartnersProducts
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 542);
            Controls.Add(historyOfProducts);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "FormPartnersProducts";
            Padding = new Padding(16, 17, 16, 17);
            Text = "Продукции партнера";
            ((System.ComponentModel.ISupportInitialize)historyOfProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView historyOfProducts;
    }
}