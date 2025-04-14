using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using PartnersDB.Models;

namespace PartnersDB
{
    public partial class FormPartners : Form
    {
        private PartnersDbContext db;
        private short id;
        private Panel? selectedPanel;
        public FormPartners()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            db = new PartnersDbContext();
            db.Partners.Load();
            db.Products.Load();
            db.PartnersProducts.Load();
            db.TypesOfPartners.Load();
            db.TypesOfProducts.Load();

            var partners = db.Partners.Local.OrderBy(p => p.Id).ToList();
            foreach (var partner in partners)
            {

                CreatePanel(
                    partner.Id,
                    db.TypesOfPartners.FirstOrDefault(t => t.Id == partner.IdTypeOfPartner).TypeOfPartner,
                    partner.Name,
                    partner.NameOfDirector,
                    partner.Phone,
                    partner.Rating
                );

            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            db?.Dispose();
            db = null;
        }

        private void ButtonAddPartner_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd(db.TypesOfPartners);
            DialogResult result = formAdd.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Partner partner = new();
            
            // Получаем максимальный Id из существующих партнеров и увеличиваем на 1
            short maxId = 0;
            if (db.Partners.Any())
            {
                maxId = db.Partners.Max(p => p.Id);
            }
            partner.Id = (short)(maxId + 1);

            partner.IdTypeOfPartner = db.TypesOfPartners
            .FirstOrDefault(t => t.TypeOfPartner == formAdd.typeOfPartner.SelectedValue.ToString()).Id;
            partner.IdTypeOfPartner = (short)formAdd.typeOfPartner.SelectedValue;
            partner.Name = formAdd.name.Text;
            partner.LegalAddress = formAdd.legalAdress.Text;
            partner.Inn = formAdd.inn.Text;
            partner.NameOfDirector = formAdd.nameOfDirector.Text;
            partner.Phone = formAdd.phone.Text;
            partner.Email = formAdd.email.Text;

            if (short.TryParse(formAdd.rating.Text, out short rate))
            {
                if (rate > 10)
                {
                    partner.Rating = 10;
                }
                else if (rate < 0)
                {
                    partner.Rating = 1;
                }
                else
                {
                    partner.Rating = rate;
                }
            }
            else if (formAdd.rating.Text == "")
            {
                partner.Rating = 1;
            }
            else
            {
                MessageBox.Show(
                    "Не удалось преобразовать рейтинг в число",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            db.Partners.Add(partner);
            db.SaveChanges();

            CreatePanel(
                partner.Id,
                db.TypesOfPartners.FirstOrDefault(t => t.Id == partner.IdTypeOfPartner).TypeOfPartner,
                partner.Name,
                partner.NameOfDirector,
                partner.Phone,
                partner.Rating
            );

            MessageBox.Show("Партнер успешно добавлен", "Добавление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonUpdatePartner_Click(object sender, EventArgs e)
        {
            if (selectedPanel == null)
                return;

            var partner = db.Partners.Find(id);

            FormAdd formAdd = new FormAdd(db.TypesOfPartners);
            formAdd.Text = "Редактирование";

            formAdd.typeOfPartner.SelectedValue = partner.IdTypeOfPartner;
            formAdd.name.Text = partner.Name;
            formAdd.legalAdress.Text = partner.LegalAddress;
            formAdd.inn.Text = partner.Inn;
            formAdd.nameOfDirector.Text = partner.NameOfDirector;
            formAdd.phone.Text = partner.Phone;
            formAdd.email.Text = partner.Email;
            formAdd.rating.Text = partner.Rating.ToString();

            DialogResult result = formAdd.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            partner.IdTypeOfPartner = (short)formAdd.typeOfPartner.SelectedValue;
            partner.Name = formAdd.name.Text;
            partner.LegalAddress = formAdd.legalAdress.Text;
            partner.Inn = formAdd.inn.Text;
            partner.NameOfDirector = formAdd.nameOfDirector.Text;
            partner.Phone = formAdd.phone.Text;
            partner.Email = formAdd.email.Text;

            if (short.TryParse(formAdd.rating.Text, out short rate))
            {
                if (rate > 10)
                {
                    partner.Rating = 10;
                }
                else if (rate < 0)
                {
                    partner.Rating = 1;
                }
                else
                {
                    partner.Rating = rate;
                }
            }
            else if (formAdd.rating.Text == "")
            {
                partner.Rating = 1;
            }
            else
            {
                MessageBox.Show(
                    "Не удалось преобразовать рейтинг в число",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }


            db.SaveChanges();

            DeletePanel(selectedPanel);

            CreatePanel(
                partner.Id,
                db.TypesOfPartners.FirstOrDefault(t => t.Id == partner.IdTypeOfPartner).TypeOfPartner,
                partner.Name,
                partner.NameOfDirector,
                partner.Phone,
                partner.Rating

            );

            MessageBox.Show("Партнер был успешно обновлён", "Редактирование",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Panel_MouseDown(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            id = short.Parse(panel.Name.Split("_")[1]);
            panel.BackColor = Color.FromArgb(230, 240, 255);

            if (panel != selectedPanel && selectedPanel != null)
            {
                selectedPanel.BackColor = Color.FromArgb(250, 250, 255);
            }
            selectedPanel = panel;
        }

        private void Panel_MouseUp(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            panel.BackColor = Color.FromArgb(250, 250, 255);
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            var panel = sender as Panel;
            id = short.Parse(panel.Name.Split("_")[1]);
            
            if (panel != selectedPanel && selectedPanel != null)
            {
                selectedPanel.BackColor = Color.FromArgb(250, 250, 255);
            }
            
            panel.BackColor = Color.FromArgb(230, 240, 255);
            selectedPanel = panel;
        }

        private void CreatePanel(short id, string type, string name, string director, string number, short? rate)
        {
            var panel = new Panel();
            Label nameOfPartner = new();
            Label nameOfDirector = new();
            Label phone = new();
            Label rating = new();
            Label percent = new();

            // Устанавливаем размер и стиль панели
            panel.Size = new Size(flowLayoutPartners.Width - 30, 131);
            panel.BackColor = Color.FromArgb(250, 250, 255);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Name = $"panel_{id}";
            panel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            panel.TabIndex = 1;
            panel.Margin = new Padding(5, 10, 5, 10);
            panel.Padding = new Padding(10);
            
            // 
            // percent
            // 
            percent.Location = new Point(700, 15);
            percent.Name = "percent";
            percent.Size = new Size(80, 28);
            percent.TabIndex = 4;
            percent.ForeColor = Color.FromArgb(70, 130, 180);
            percent.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            percent.TextAlign = ContentAlignment.MiddleRight;
            
            // Получаем сумму продуктов для партнера с указанным id
            int sum = 0;
            try
            {
                sum = db.PartnersProducts
                    .Include(i => i.IdProductNavigation)
                    .Select(i => new { i.Count, i.IdPartner })
                    .Where(i => i.IdPartner == id)
                    .Sum(i => i.Count);
            }
            catch
            {
                // Для новых партнеров без продуктов сумма будет 0
                sum = 0;
            }

            string perc;

            if (sum < 10000) { perc = "0%"; }
            else if (sum < 50000) { perc = "5%"; }
            else if (sum < 300000) { perc = "10%"; }
            else { perc = "15%"; }

            percent.Text = perc;
            // 
            // rating
            // 
            rating.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            rating.Location = new Point(20, 93);
            rating.Name = "rating";
            rating.Size = new Size(278, 25);
            rating.TabIndex = 3;
            rating.Text = $"Рейтинг: {rate}";
            rating.ForeColor = Color.FromArgb(60, 60, 60);
            // 
            // phone
            // 
            phone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            phone.Location = new Point(20, 68);
            phone.Name = "phone";
            phone.Size = new Size(278, 25);
            phone.TabIndex = 2;
            phone.Text = $"+7 {number}";
            phone.ForeColor = Color.FromArgb(60, 60, 60);
            // 
            // nameOfDirector
            // 
            nameOfDirector.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            nameOfDirector.Location = new Point(20, 43);
            nameOfDirector.Name = "nameOfDirector";
            nameOfDirector.Size = new Size(278, 25);
            nameOfDirector.TabIndex = 1;
            nameOfDirector.Text = director.ToString();
            nameOfDirector.ForeColor = Color.FromArgb(60, 60, 60);
            // 
            // nameOfPartner
            // 
            nameOfPartner.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point, 204);
            nameOfPartner.Location = new Point(20, 15);
            nameOfPartner.Name = "nameOfPartner";
            nameOfPartner.Size = new Size(400, 28);
            nameOfPartner.TabIndex = 0;
            nameOfPartner.Text = $"{type} | {name}";
            nameOfPartner.ForeColor = Color.FromArgb(70, 130, 180);

            // Добавляем элементы управления на панель
            panel.Controls.Add(percent);
            panel.Controls.Add(rating);
            panel.Controls.Add(phone);
            panel.Controls.Add(nameOfDirector);
            panel.Controls.Add(nameOfPartner);
            
            // Добавляем обработчики событий
            panel.MouseDown += Panel_MouseDown;
            // Обработчик изменения размера формы для этой конкретной панели
            EventHandler resizeHandler = null;
            resizeHandler = (s, e) => {
                if (panel != null && !panel.IsDisposed && panel.Parent != null)
                {
                    panel.Width = flowLayoutPartners.Width - 30;
                    try
                    {
                        panel.Invalidate(); // Перерисовываем панель для обновления обводки
                    }
                    catch
                    {
                        // Игнорируем ошибки при создании региона
                    }
                }
                else
                {
                    // Если панель удалена, удаляем обработчик
                    if (this != null && !this.IsDisposed)
                        this.SizeChanged -= resizeHandler;
                }
            };
            this.SizeChanged += resizeHandler;
            
           
            // Добавляем обработчик клика для всей панели
            panel.Click += Panel_Click;
            // Добавляем обработчики клика для всех элементов внутри панели
            foreach (Control control in panel.Controls)
            {
                control.Click += (s, e) => Panel_Click(panel, e);
            }

            flowLayoutPartners.Controls.Add(panel);
        }

        private void DeletePanel(Panel panel)
        {
            flowLayoutPartners.Controls.Remove(panel);
            selectedPanel = null;
        }

        private void ButtonCheckHistory_Click(object sender, EventArgs e)
        {
            if (selectedPanel == null)
                return;

            var form = new FormPartnersProducts(id);
            form.Show();
        }

        private void ButtonTypesOfPartner_Click(object sender, EventArgs e)
        {
            var form = new FormTypesOfPartner();
            form.Show();
        }

        private void ButtonTypesOfProduct_Click(object sender, EventArgs e)
        {
            var form = new FormTypesOfProduct();
            form.Show();
        }
    }
}
