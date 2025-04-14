﻿﻿﻿﻿﻿﻿﻿﻿namespace PartnersDB
{
    partial class FormPartners
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutButtons = new FlowLayoutPanel();
            buttonAddPartner = new Button();
            buttonUpdatePartner = new Button();
            ButtonCheckHistory = new Button();
            buttonTypesOfPartner = new Button();
            buttonTypesOfProduct = new Button();
            flowLayoutPartners = new FlowLayoutPanel();
            flowLayoutButtons.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutButtons
            // 
            flowLayoutButtons.BackColor = Color.FromArgb(240, 240, 250);
            flowLayoutButtons.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutButtons.Controls.Add(buttonAddPartner);
            flowLayoutButtons.Controls.Add(buttonUpdatePartner);
            flowLayoutButtons.Controls.Add(ButtonCheckHistory);
            flowLayoutButtons.Controls.Add(buttonTypesOfPartner);
            flowLayoutButtons.Controls.Add(buttonTypesOfProduct);
            flowLayoutButtons.Dock = DockStyle.Top;
            flowLayoutButtons.Location = new Point(10, 10);
            flowLayoutButtons.Margin = new Padding(5);
            flowLayoutButtons.Name = "flowLayoutButtons";
            flowLayoutButtons.Size = new Size(864, 70);
            flowLayoutButtons.TabIndex = 0;
            flowLayoutButtons.WrapContents = false;
            // 
            // buttonAddPartner
            // 
            buttonAddPartner.BackColor = Color.FromArgb(70, 130, 180);
            buttonAddPartner.FlatAppearance.BorderSize = 0;
            buttonAddPartner.FlatStyle = FlatStyle.Flat;
            buttonAddPartner.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonAddPartner.ForeColor = Color.White;
            buttonAddPartner.Location = new Point(5, 5);
            buttonAddPartner.Margin = new Padding(5);
            buttonAddPartner.Name = "buttonAddPartner";
            buttonAddPartner.Size = new Size(160, 52);
            buttonAddPartner.TabIndex = 2;
            buttonAddPartner.Text = "Добавить партнера";
            buttonAddPartner.UseVisualStyleBackColor = false;
            buttonAddPartner.Click += ButtonAddPartner_Click;
            // 
            // buttonUpdatePartner
            // 
            buttonUpdatePartner.BackColor = Color.FromArgb(70, 130, 180);
            buttonUpdatePartner.FlatAppearance.BorderSize = 0;
            buttonUpdatePartner.FlatStyle = FlatStyle.Flat;
            buttonUpdatePartner.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonUpdatePartner.ForeColor = Color.White;
            buttonUpdatePartner.Location = new Point(175, 5);
            buttonUpdatePartner.Margin = new Padding(5);
            buttonUpdatePartner.Name = "buttonUpdatePartner";
            buttonUpdatePartner.Size = new Size(160, 52);
            buttonUpdatePartner.TabIndex = 3;
            buttonUpdatePartner.Text = "Редактировать партнера";
            buttonUpdatePartner.UseVisualStyleBackColor = false;
            buttonUpdatePartner.Click += ButtonUpdatePartner_Click;
            // 
            // ButtonCheckHistory
            // 
            ButtonCheckHistory.BackColor = Color.FromArgb(70, 130, 180);
            ButtonCheckHistory.FlatAppearance.BorderSize = 0;
            ButtonCheckHistory.FlatStyle = FlatStyle.Flat;
            ButtonCheckHistory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonCheckHistory.ForeColor = Color.White;
            ButtonCheckHistory.Location = new Point(345, 5);
            ButtonCheckHistory.Margin = new Padding(5);
            ButtonCheckHistory.Name = "ButtonCheckHistory";
            ButtonCheckHistory.Size = new Size(160, 52);
            ButtonCheckHistory.TabIndex = 4;
            ButtonCheckHistory.Text = "История";
            ButtonCheckHistory.UseVisualStyleBackColor = false;
            ButtonCheckHistory.Click += ButtonCheckHistory_Click;
            // 
            // buttonTypesOfPartner
            // 
            buttonTypesOfPartner.BackColor = Color.FromArgb(70, 130, 180);
            buttonTypesOfPartner.FlatAppearance.BorderSize = 0;
            buttonTypesOfPartner.FlatStyle = FlatStyle.Flat;
            buttonTypesOfPartner.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonTypesOfPartner.ForeColor = Color.White;
            buttonTypesOfPartner.Location = new Point(515, 5);
            buttonTypesOfPartner.Margin = new Padding(5);
            buttonTypesOfPartner.Name = "buttonTypesOfPartner";
            buttonTypesOfPartner.Size = new Size(160, 52);
            buttonTypesOfPartner.TabIndex = 5;
            buttonTypesOfPartner.Text = "Типы партнеров";
            buttonTypesOfPartner.UseVisualStyleBackColor = false;
            buttonTypesOfPartner.Click += ButtonTypesOfPartner_Click;
            // 
            // buttonTypesOfProduct
            // 
            buttonTypesOfProduct.BackColor = Color.FromArgb(70, 130, 180);
            buttonTypesOfProduct.FlatAppearance.BorderSize = 0;
            buttonTypesOfProduct.FlatStyle = FlatStyle.Flat;
            buttonTypesOfProduct.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonTypesOfProduct.ForeColor = Color.White;
            buttonTypesOfProduct.Location = new Point(685, 5);
            buttonTypesOfProduct.Margin = new Padding(5);
            buttonTypesOfProduct.Name = "buttonTypesOfProduct";
            buttonTypesOfProduct.Size = new Size(160, 52);
            buttonTypesOfProduct.TabIndex = 6;
            buttonTypesOfProduct.Text = "Типы продукции";
            buttonTypesOfProduct.UseVisualStyleBackColor = false;
            buttonTypesOfProduct.Click += ButtonTypesOfProduct_Click;
            // 
            // flowLayoutPartners
            // 
            flowLayoutPartners.AutoScroll = true;
            flowLayoutPartners.BackColor = Color.FromArgb(250, 250, 255);
            flowLayoutPartners.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPartners.Dock = DockStyle.Fill;
            flowLayoutPartners.Location = new Point(10, 80);
            flowLayoutPartners.Margin = new Padding(3, 10, 3, 3);
            flowLayoutPartners.Name = "flowLayoutPartners";
            flowLayoutPartners.Size = new Size(864, 571);
            flowLayoutPartners.TabIndex = 1;
            // 
            // FormPartners
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 255);
            ClientSize = new Size(884, 661);
            Controls.Add(flowLayoutPartners);
            Controls.Add(flowLayoutButtons);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            MinimumSize = new Size(880, 700);
            Name = "FormPartners";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Партнеры";
            flowLayoutButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutButtons;
        private Button buttonAddPartner;
        private Button buttonUpdatePartner;
        private Button ButtonCheckHistory;
        private Button buttonTypesOfPartner;
        private Button buttonTypesOfProduct;
        private FlowLayoutPanel flowLayoutPartners;
    }
}
