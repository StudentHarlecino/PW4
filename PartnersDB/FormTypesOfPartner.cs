using Microsoft.EntityFrameworkCore;
using PartnersDB.Models;
using System.ComponentModel;
using System.Windows.Forms;

namespace PartnersDB
{
    public partial class FormTypesOfPartner : Form
    {
        private PartnersDbContext db;
        private short selectedId;

        public FormTypesOfPartner()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Инициализация контекста базы данных
            db = new PartnersDbContext();
            db.TypesOfPartners.Load();

            // Привязка данных к DataGridView
            dataGridViewTypes.DataSource = db.TypesOfPartners.Local.ToBindingList();

            // Настройка DataGridView
            ConfigureDataGridView();

            // Очистка полей ввода
            ClearInputFields();
        }

        private void ConfigureDataGridView()
        {
            // Настройка отображения столбцов
            dataGridViewTypes.Columns["Id"].HeaderText = "Код";
            dataGridViewTypes.Columns["TypeOfPartner"].HeaderText = "Тип партнера";
            dataGridViewTypes.Columns["Partners"].Visible = false;

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
                    if (selectedRow.Cells["Id"].Value != null && selectedRow.Cells["TypeOfPartner"].Value != null)
                    {
                        selectedId = (short)selectedRow.Cells["Id"].Value;
                        textBoxType.Text = selectedRow.Cells["TypeOfPartner"].Value.ToString();
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
                MessageBox.Show("Введите название типа партнера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Создание нового типа партнера
                var newType = new TypesOfPartner
                {
                    TypeOfPartner = textBoxType.Text.Trim()
                };

                // Добавление в базу данных
                db.TypesOfPartners.Add(newType);
                db.SaveChanges();

                // Очистка полей ввода
                ClearInputFields();

                MessageBox.Show("Тип партнера успешно добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении типа партнера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Выберите тип партнера для редактирования", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxType.Text))
            {
                MessageBox.Show("Введите название типа партнера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Поиск типа партнера по ID
                var typeToUpdate = db.TypesOfPartners.Find(selectedId);
                if (typeToUpdate == null)
                {
                    MessageBox.Show("Тип партнера не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Обновление данных
                typeToUpdate.TypeOfPartner = textBoxType.Text.Trim();
                db.SaveChanges();

                // Обновление DataGridView
                dataGridViewTypes.Refresh();

                MessageBox.Show("Тип партнера успешно обновлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении типа партнера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("Выберите тип партнера для удаления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Проверка наличия связанных записей
                var hasRelatedPartners = db.Partners.Any(p => p.IdTypeOfPartner == selectedId);
                if (hasRelatedPartners)
                {
                    MessageBox.Show("Невозможно удалить тип партнера, так как существуют связанные записи партнеров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Подтверждение удаления
                var result = MessageBox.Show("Вы уверены, что хотите удалить выбранный тип партнера?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;

                // Поиск типа партнера по ID
                var typeToDelete = db.TypesOfPartners.Find(selectedId);
                if (typeToDelete == null)
                {
                    MessageBox.Show("Тип партнера не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Удаление из базы данных
                db.TypesOfPartners.Remove(typeToDelete);
                db.SaveChanges();

                // Очистка полей ввода
                ClearInputFields();

                MessageBox.Show("Тип партнера успешно удален", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении типа партнера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
