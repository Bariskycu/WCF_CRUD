using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crud.ServiceReference1;


namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            List<Product> productLt = new List<Product>();
            Service1Client service = new Service1Client();

            dataGridView1.DataSource = service.GetAllProduct();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            //p.Id = Convert.ToInt32(txtId.Text);
            p.Name = txtName.Text;
            p.Price = txtPrice.Text;
            p.Stock = Convert.ToInt32(txtStock.Text);

            Service1Client service = new Service1Client();

            if (service.InsertProduct(p) == 1)
            {
                MessageBox.Show("Ekleme İşlemi Başarılı👌.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product p = new Product()
            {
                Id = Convert.ToInt32(txtId.Text),
                Name = txtName.Text,
                Price = txtPrice.Text,
                Stock = Convert.ToInt32(txtStock.Text)
            };

            Service1Client service = new Service1Client();

            if (service.UpdateProduct(p) == 1)
            {
                MessageBox.Show("Güncelleme İşlemi Başarılı👌.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product p = new Product()
            {
                Id = Convert.ToInt32(txtId.Text)
                
            };
            Service1Client service = new Service1Client();

            if (service.DeleteProduct(p) == 1)
            {
                MessageBox.Show("Silme İşlemi Başarılı👌.");
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            txtId.Text = row.Cells["Id"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtPrice.Text = row.Cells["Price"].Value.ToString();
            txtStock.Text = row.Cells["Stock"].Value.ToString();
        }
    }
}
