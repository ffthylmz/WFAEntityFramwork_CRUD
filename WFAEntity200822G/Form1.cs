using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAEntity200822G
{

    public partial class Form1 : Form
    {
        public void DgvDoldur()
        {
            dataGridView1.DataSource = entities.Customers.ToList();
            dataGridView1.ClearSelection();
            txtId.Clear();
            txtName.Clear();
        }

        NorthwindEntities1 entities = new NorthwindEntities1();

        public Form1()
        {
            InitializeComponent();
            
        }

        //ID'ye ve AD'a göre silme işlemi...

        private void btnListele_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerID = txtId.Text;
            customer.ContactName = txtName.Text;

            dataGridView1.DataSource = entities.Customers.Where(s => s.CustomerID == customer.CustomerID && s.ContactName == customer.ContactName).ToList();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //ID'ye göre bulma işlemi...
        private void btnId_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerID = txtId.Text;

            dataGridView1.DataSource = entities.Customers.Where(s => s.CustomerID == customer.CustomerID).ToList();           
        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            DgvDoldur();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerID = txtId.Text;
            customer.CompanyName = txtName.Text;

            entities.Customers.Add(customer);
            entities.SaveChanges();

            MessageBox.Show(customer.CustomerID + " - " + customer.CompanyName + " isimli kayıt oluşturulmuştur.");

            DgvDoldur();
        }

        //ID'ye göre güncelleme işlemi...

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Customer customer = entities.Customers.Find(txtId.Text);
            if (customer != null)
            {
                customer.CompanyName = txtName.Text;
                entities.SaveChanges();
                MessageBox.Show(customer.CustomerID + " ID'li kayıt güncellenmiştir.");
            }
            else
                MessageBox.Show(txtId.Text + " ilgili kayıt bulunamadı.");

            DgvDoldur();
        }

        //ID'ye göre silme işlemi...

        private void btnSil_Click(object sender, EventArgs e)
        {
            Customer customer = entities.Customers.Find(txtId.Text);
            if (customer != null)
            {
                entities.Customers.Remove(customer);
                entities.SaveChanges();
                MessageBox.Show(txtId.Text + " ID'li veri silinmiştir.");

            }

            DgvDoldur();
        }
    }
}
