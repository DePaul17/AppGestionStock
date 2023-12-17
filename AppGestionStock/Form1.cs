using AppGestionStock.WcfService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppGestionStock
{
    public partial class Form1 : Form
    {
        WcfService.Service1Client service = new WcfService.Service1Client();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgProduit.DataSource = service.getProduitList();
            
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            WcfService.Produit p = new WcfService.Produit();
            p.Description = txtDescription.Text;
            p.Libelle = txtLibelle.Text;
            p.PU = !string.IsNullOrEmpty(txtPU.Text) ? double.Parse(txtPU.Text) : 0;
            p.Qte = !string.IsNullOrEmpty(txtQte.Text) ? double.Parse(txtQte.Text) : 0;
            service.AjouterProduit(p);
            effacer();
        }

        private void effacer()
        {
            txtDescription.Text = string.Empty;
            txtLibelle.Text = string.Empty;
            txtPU.Text = string.Empty;
            txtQte.Text = string.Empty;
            txtId.Text = string.Empty;
            dgProduit.DataSource = service.getProduitList();
            txtLibelle.Focus();
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProduit.CurrentRow.Cells[4].Value.ToString());
            var p = service.getProduit(id);
            txtId.Text = p.idProduit.ToString();
            txtDescription.Text = p.Description.ToString();
            txtLibelle.Text = p.Libelle.ToString();
            txtPU.Text = p.PU.ToString();
            txtQte.Text = p.Qte.ToString();
            
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            WcfService.Produit p = new WcfService.Produit();
            p.idProduit = !string.IsNullOrEmpty(txtId.Text) ? int.Parse(txtId.Text) : 0;
            p.Description = txtDescription.Text;
            p.Libelle = txtLibelle.Text;
            p.PU = !string.IsNullOrEmpty(txtPU.Text) ? double.Parse(txtPU.Text) : 0;
            p.Qte = !string.IsNullOrEmpty(txtQte.Text) ? double.Parse(txtQte.Text) : 0;
            service.ModifierProduit(p);
            effacer();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(txtId.Text);
            var p = service.SupprimerProduit(id);
            effacer();
        }
    }
}
