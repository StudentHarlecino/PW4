namespace PartnersDB
{
    partial class FormAdd
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonSave = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            name = new TextBox();
            nameOfDirector = new TextBox();
            inn = new TextBox();
            legalAdress = new TextBox();
            phone = new TextBox();
            email = new TextBox();
            rating = new TextBox();
            typeOfPartner = new ComboBox();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonSave);
            flowLayoutPanel1.Controls.Add(buttonCancel);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 290);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(539, 52);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonSave
            // 
            buttonSave.BackColor = Color.White;
            buttonSave.DialogResult = DialogResult.OK;
            buttonSave.Location = new Point(402, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(134, 45);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            buttonCancel.BackColor = Color.White;
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(262, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(134, 45);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Отменить";
            buttonCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Location = new Point(27, 13);
            label1.Name = "label1";
            label1.Size = new Size(160, 29);
            label1.TabIndex = 1;
            label1.Text = "Тип:";
            // 
            // label2
            // 
            label2.Location = new Point(27, 81);
            label2.Name = "label2";
            label2.Size = new Size(160, 30);
            label2.TabIndex = 2;
            label2.Text = "Адрес:";
            // 
            // label3
            // 
            label3.Location = new Point(27, 48);
            label3.Name = "label3";
            label3.Size = new Size(160, 30);
            label3.TabIndex = 3;
            label3.Text = "Название:";
            // 
            // label4
            // 
            label4.Location = new Point(27, 114);
            label4.Name = "label4";
            label4.Size = new Size(160, 30);
            label4.TabIndex = 4;
            label4.Text = "ИНН:";
            // 
            // label5
            // 
            label5.Location = new Point(27, 147);
            label5.Name = "label5";
            label5.Size = new Size(160, 30);
            label5.TabIndex = 5;
            label5.Text = "Имя директора:";
            // 
            // label6
            // 
            label6.Location = new Point(27, 180);
            label6.Name = "label6";
            label6.Size = new Size(160, 30);
            label6.TabIndex = 6;
            label6.Text = "Телефон:";
            // 
            // label7
            // 
            label7.Location = new Point(27, 213);
            label7.Name = "label7";
            label7.Size = new Size(160, 30);
            label7.TabIndex = 7;
            label7.Text = "Email:";
            // 
            // label8
            // 
            label8.Location = new Point(27, 246);
            label8.Name = "label8";
            label8.Size = new Size(160, 30);
            label8.TabIndex = 8;
            label8.Text = "Рейтинг:";
            // 
            // name
            // 
            name.Font = new Font("Segoe UI", 12F);
            name.Location = new Point(193, 51);
            name.Multiline = true;
            name.Name = "name";
            name.Size = new Size(260, 27);
            name.TabIndex = 9;
            name.TextChanged += TextBox_TextChanged;
            // 
            // nameOfDirector
            // 
            nameOfDirector.Font = new Font("Segoe UI", 12F);
            nameOfDirector.Location = new Point(193, 150);
            nameOfDirector.Multiline = true;
            nameOfDirector.Name = "nameOfDirector";
            nameOfDirector.Size = new Size(260, 27);
            nameOfDirector.TabIndex = 10;
            nameOfDirector.TextChanged += TextBox_TextChanged;
            // 
            // inn
            // 
            inn.Font = new Font("Segoe UI", 12F);
            inn.Location = new Point(193, 117);
            inn.Multiline = true;
            inn.Name = "inn";
            inn.Size = new Size(260, 27);
            inn.TabIndex = 11;
            inn.TextChanged += TextBox_TextChanged;
            // 
            // legalAdress
            // 
            legalAdress.Font = new Font("Segoe UI", 12F);
            legalAdress.Location = new Point(193, 84);
            legalAdress.Multiline = true;
            legalAdress.Name = "legalAdress";
            legalAdress.Size = new Size(260, 27);
            legalAdress.TabIndex = 12;
            legalAdress.TextChanged += TextBox_TextChanged;
            // 
            // phone
            // 
            phone.Font = new Font("Segoe UI", 12F);
            phone.Location = new Point(193, 183);
            phone.Multiline = true;
            phone.Name = "phone";
            phone.Size = new Size(260, 27);
            phone.TabIndex = 13;
            phone.TextChanged += TextBox_TextChanged;
            // 
            // email
            // 
            email.Font = new Font("Segoe UI", 12F);
            email.Location = new Point(193, 216);
            email.Multiline = true;
            email.Name = "email";
            email.Size = new Size(260, 27);
            email.TabIndex = 14;
            email.TextChanged += TextBox_TextChanged;
            // 
            // rating
            // 
            rating.Font = new Font("Segoe UI", 12F);
            rating.Location = new Point(193, 249);
            rating.Multiline = true;
            rating.Name = "rating";
            rating.Size = new Size(260, 27);
            rating.TabIndex = 15;
            rating.TextChanged += TextBox_TextChanged;
            // 
            // typeOfPartner
            // 
            typeOfPartner.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            typeOfPartner.FormattingEnabled = true;
            typeOfPartner.Location = new Point(193, 13);
            typeOfPartner.Name = "typeOfPartner";
            typeOfPartner.Size = new Size(260, 29);
            typeOfPartner.TabIndex = 17;
            // 
            // FormAdd
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(539, 342);
            Controls.Add(typeOfPartner);
            Controls.Add(rating);
            Controls.Add(email);
            Controls.Add(phone);
            Controls.Add(legalAdress);
            Controls.Add(inn);
            Controls.Add(nameOfDirector);
            Controls.Add(name);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(flowLayoutPanel1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "FormAdd";
            Text = "Добавление партнера";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonSave;
        private Button buttonCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        public TextBox name;
        public TextBox nameOfDirector;
        public TextBox inn;
        public TextBox legalAdress;
        public TextBox phone;
        public TextBox email;
        public TextBox rating;
        public ComboBox typeOfPartner;
    }
}