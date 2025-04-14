using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartnersDB
{
    public partial class FormPartnersProducts : Form
    {
        private readonly short id;

        public FormPartnersProducts(short id)
        {
            InitializeComponent();
            this.id = id;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            using (Models.PartnersDbContext db = new())
            {
                historyOfProducts.DataSource = db.PartnersProducts
                    .Include(i => i.IdProductNavigation)
                    .Select(i => new { i.Count, i.DateSelling, i.IdProductNavigation.Name, i.IdPartner })
                    .Where(i => i.IdPartner == id)
                    .ToList();
            }

            historyOfProducts.Columns["IdPartner"].Visible = false;
        }
    }
}
