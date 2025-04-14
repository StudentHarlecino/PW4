using Microsoft.EntityFrameworkCore;
using PartnersDB.Models;
using System.ComponentModel;

namespace PartnersDB
{
    public partial class FormAdd : Form
    {
        //private const string msgEmpty = "Поля не могут быть пустыми";
        //private const string convertError = "Не удалось преобразовать строку в число";


        public FormAdd(DbSet<TypesOfPartner> typesOfPartners)
        {
            InitializeComponent();
            if (!IsEmpty())
            {
                buttonSave.Enabled = true;
            }
            else
            {
                buttonSave.Enabled = false;
            }

            typeOfPartner.DataSource = typesOfPartners.Local.ToBindingList();
            typeOfPartner.DisplayMember = "TypeOfPartner";
            typeOfPartner.ValueMember = "Id";
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!IsEmpty())
            {
                buttonSave.Enabled = true;
            }
            else
            {
                buttonSave.Enabled = false;
            }
        }

        private bool IsEmpty()
        {
            if (name.Text == ""
                || legalAdress.Text == ""
                || inn.Text == ""
                || nameOfDirector.Text == ""
                || phone.Text == ""
                || email.Text == "")
            {
                return true;
            }
            return false;
        }
    }
}
