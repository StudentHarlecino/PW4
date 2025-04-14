using Microsoft.EntityFrameworkCore;
using PartnersDB.Models;
using System.ComponentModel;
using System.Windows.Forms;

namespace PartnersDB
{
    public partial class FormTypesOfProduct : Form
    {
        private PartnersDbContext db;
        private short selectedId;

        public FormTypesOfProduct()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Инициализация контекста базы данных
            db = new PartnersDbContext();
            db.TypesOfProducts.Load();

            // Привязка данных к DataGridView
            dataGridViewTypes.DataSource = db.TypesOfProducts.Local.ToBindingList();

            // Настройка DataGridView
            ConfigureDataGridView();

            // Очистка полей ввода
            ClearInputFields();
        }

        private void ConfigureDataGridView()
        {
            // Настройка отображения столбцов
            dataGridViewTypes.Columns["Id"].HeaderText = "Код";
            dataGridViewTypes.Columns["TypeOfProduct"].HeaderText = "Тип продукции";
            dataGridViewTypes.Columns["TypeCoefficient"].HeaderText = "Коэффициент";
            dataGridViewTypes.Columns["Products"].Visible = false;

            // Настройка выбора строк
            dataGridViewTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTypes.MultiSelect = false;
            dataGridViewTypes.ReadOnly = true;

            // Настройка автоматического изменения размера столбцов
            dataGridViewTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ClearInputFields()
        {
            textBoxType.Text = string.Empty;
            numericUpDownCoefficient.Value = 1.00m;
            selectedId = 0;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            buttonAdd.Enabled = true;
            textBoxType.Focus();
        }

        private void dataGridViewTypes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTypes.SelectedRows.Count > 0)
                {
                    var selectedRow = dataGridViewTypes.SelectedRows[0];
                    if (selectedRow.Cells["Id"].Value != null && 
                        selectedRow.Cells["TypeOfProduct"].Value != null &&
                        selectedRow.Cells["TypeCoefficient"].Value != null)
                    {
                        selectedId = (short)selectedRow.Cells["Id"].Value;
                        textBoxType.Text = selectedRow.Cells["TypeOfProduct"].Value.ToString();
                        numericUpDownCoefficient.Value = (decimal)selectedRow.Cells["TypeCoefficient"].Value;
                        buttonUpdate.Enabled = true;
                        buttonDelete.Enabled = true;
                        buttonAdd.Enabled = false;
                    }
                    else
                    {
                        ClearInputFields();
                    }
                }
                else
                {
                    ClearInputFields();
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения
                ClearInputFields();
                MessageBox.Show($"Ошибка при выборе строки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxType.Text))
            {
                MessageBox.Show("Введите название типа продукции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Создание нового типа продукции
                var newType = new TypesOfProduct
                {
                    TypeOfProduct = textBoxType.Text.Trim(),
                    TypeCoefficient = numericUpDownCoefficient.Value
                };

                // Добавление в базу данных
                db.TypesOfProducts.Add(newType);
                db.SaveChanges();

                // Очистка полей ввода
                ClearInputFields();

                MessageBox.Show("Тип продукции успешно добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении типа продукции: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Выберите тип продукции для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxType.Text))
            {
                MessageBox.Show("Введите название типа продукции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Поиск типа продукции по ID
                var typeToUpdate = db.TypesOfProducts.Find(selectedId);
                if (typeToUpdate == null)
                {
                    MessageBox.Show("Тип продукции не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Обновление данных
                typeToUpdate.TypeOfProduct = textBoxType.Text.Trim();
                typeToUpdate.TypeCoefficient = numericUpDownCoefficient.Value;
                db.SaveChanges();

                // Обновление DataGridView
                dataGridViewTypes.Refresh();

                MessageBox.Show("Тип продукции успешно обновлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении типа продукции: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Выберите тип продукции для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Проверка наличия связанных записей
                var hasRelatedProducts = db.Products.Any(p => p.IdTypeOfProduct == selectedId);
                if (hasRelatedProducts)
                {
                    MessageBox.Show("Невозможно удалить тип продукции, так как существуют связанные записи продукции", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Подтверждение удаления
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранный тип продукции?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;

                // Поиск типа продукции по ID
                var typeToDelete = db.TypesOfProducts.Find(selectedId);
                if (typeToDelete == null)
                {
                    MessageBox.Show("Тип продукции не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Удаление из базы данных
                db.TypesOfProducts.Remove(typeToDelete);
                db.SaveChanges();

                // Очистка полей ввода
                ClearInputFields();

                MessageBox.Show("Тип продукции успешно удален", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении типа продукции: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            dataGridViewTypes.ClearSelection();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            db?.Dispose();
            db = null;
        }
    }
}
