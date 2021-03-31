using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c968
{
    public partial class MainScreen : Form
    {
        public void displayProductsList()
        {
            foreach (DataGridViewColumn column in dgvProducts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvProducts.Rows.Clear();
            dgvProducts.Refresh();
            for (int i = 0; i < Inventory.lstProducts.Count; i++)
            {
                dgvProducts.Rows.Add();
                dgvProducts.Rows[i].Cells[0].Value = Inventory.lstProducts[i].getProductID();
                dgvProducts.Rows[i].Cells[1].Value = Inventory.lstProducts[i].getName();
                dgvProducts.Rows[i].Cells[2].Value = Inventory.lstProducts[i].getInStock();
                dgvProducts.Rows[i].Cells[3].Value = Inventory.lstProducts[i].getPrice();
                dgvProducts.Rows[i].Cells[4].Value = Inventory.lstProducts[i].getMin();
                dgvProducts.Rows[i].Cells[5].Value = Inventory.lstProducts[i].getMax();
            }
        }

        public void displayPartsList()
        {
            foreach (DataGridViewColumn column in dgvParts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvParts.Rows.Clear();
            dgvParts.Refresh();
            for (int i = 0; i < Inventory.lstAllParts.Count; i++)
            {
                dgvParts.Rows.Add();
                dgvParts.Rows[i].Cells[0].Value = Inventory.lstAllParts[i].getPartID();
                dgvParts.Rows[i].Cells[1].Value = Inventory.lstAllParts[i].getName();
                dgvParts.Rows[i].Cells[2].Value = Inventory.lstAllParts[i].getInStock();
                dgvParts.Rows[i].Cells[3].Value = Inventory.lstAllParts[i].getPrice();
                dgvParts.Rows[i].Cells[4].Value = Inventory.lstAllParts[i].getMin();
                dgvParts.Rows[i].Cells[5].Value = Inventory.lstAllParts[i].getMax();
            }
            
        }

        public void formatDGV(DataGridView d)
        {
            d.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            d.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            d.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            d.RowHeadersVisible = false;
            if (d == dgvParts)
            {
                d.Columns.Add("ID", "Part ID");
            }
            else
            {
                d.Columns.Add("ID", "Product ID");
            }
            d.Columns.Add("Name", "Name");
            d.Columns.Add("Inventory", "Inventory");
            d.Columns.Add("Price", "Price");
            d.Columns.Add("Min", "Min");
            d.Columns.Add("Max", "Max");
        }

        public MainScreen()
        {
            InitializeComponent();

            // build, format, and display dgvParts
            formatDGV(dgvParts);
            displayPartsList();

            // build, format, and display dgvProducts
            formatDGV(dgvProducts);
            displayProductsList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            // Load the Part Screen
            this.Hide();
            PartScreen partScreen = new PartScreen();
            partScreen.lblAddModify.Text = "Add Part";
            partScreen.txtID.Text = Inventory.createPartID().ToString();
            partScreen.txtName.BackColor = System.Drawing.Color.Salmon;
            partScreen.txtInventory.BackColor = System.Drawing.Color.Salmon;
            partScreen.txtPrice.BackColor = System.Drawing.Color.Salmon;
            partScreen.txtMin.BackColor = System.Drawing.Color.Salmon;
            partScreen.txtMax.BackColor = System.Drawing.Color.Salmon;
            partScreen.txtMachineIDCompanyName.BackColor = System.Drawing.Color.Salmon;
            partScreen.Show();
            partScreen.txtName.Focus();
        }

        private void btnModifyPart_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrentPartIndex >= 0)
            {
                // Load the Part Screen
                this.Hide();
                PartScreen partScreen = new PartScreen();

                // Load the currently selected part to modify
                int index = Inventory.CurrentPartIndex;
                BindingList<Part> parts = Inventory.lstAllParts;

                partScreen.txtID.Text = parts.ElementAt(index).getPartID().ToString();
                partScreen.txtName.Text = parts.ElementAt(index).getName().ToString();
                partScreen.txtInventory.Text = parts.ElementAt(index).getInStock().ToString();
                partScreen.txtPrice.Text = parts.ElementAt(index).getPrice().ToString();
                partScreen.txtMin.Text = parts.ElementAt(index).getMin().ToString();
                partScreen.txtMax.Text = parts.ElementAt(index).getMax().ToString();
                // Inhouse or Outsourced?
                if (parts.ElementAt(index) is Inhouse)
                {
                    partScreen.rdbOutsourced.Checked = false;
                    partScreen.txtMachineIDCompanyName.Text = ((Inhouse)parts.ElementAt(index)).getMachineID().ToString();
                }
                else
                {
                    partScreen.rdbOutsourced.Checked = true;
                    partScreen.txtMachineIDCompanyName.Text = ((Outsourced)parts.ElementAt(index)).getCompanyName();
                }

                partScreen.Show();
                partScreen.txtName.Focus();
            }
            else
            {
                MessageBox.Show("Please select a part to modify");
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Load the Product Screen
            this.Hide();
            ProductScreen productScreen = new ProductScreen();
            productScreen.lblAddModify.Text = "Add Product";
            productScreen.txtID.Text = Inventory.createProductID().ToString();
            productScreen.txtName.BackColor = System.Drawing.Color.Salmon;
            productScreen.txtInventory.BackColor = System.Drawing.Color.Salmon;
            productScreen.txtPrice.BackColor = System.Drawing.Color.Salmon;
            productScreen.txtMin.BackColor = System.Drawing.Color.Salmon;
            productScreen.txtMax.BackColor = System.Drawing.Color.Salmon;
            productScreen.Show();

            productScreen.txtName.Focus();
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrentProductIndex >= 0)
            {
                // Load the Product Screen
                this.Hide();
                ProductScreen productScreen = new ProductScreen();

                // Load the currently selected product to modify
                int index = Inventory.CurrentProductIndex;
                BindingList<Product> product = Inventory.lstProducts;

                productScreen.txtID.Text = product.ElementAt(index).getProductID().ToString();
                productScreen.txtName.Text = product.ElementAt(index).getName().ToString();
                productScreen.txtInventory.Text = product.ElementAt(index).getInStock().ToString();
                productScreen.txtPrice.Text = product.ElementAt(index).getPrice().ToString();
                productScreen.txtMin.Text = product.ElementAt(index).getMin().ToString();
                productScreen.txtMax.Text = product.ElementAt(index).getMax().ToString();
                // load the associated parts
                int i = 0;
                foreach (Part part in product.ElementAt(index).getAssociatedParts())
                {
                    productScreen.dgvParts.Rows.Add();
                    productScreen.dgvParts.Rows[i].Cells[0].Value = part.getPartID();
                    productScreen.dgvParts.Rows[i].Cells[1].Value = part.getName();
                    productScreen.dgvParts.Rows[i].Cells[2].Value = part.getInStock();
                    productScreen.dgvParts.Rows[i].Cells[3].Value = part.getPrice();
                    productScreen.dgvParts.Rows[i].Cells[4].Value = part.getMin();
                    productScreen.dgvParts.Rows[i].Cells[5].Value = part.getMax();
                    i++;
                }

                productScreen.Show();
                productScreen.txtName.Focus();
            }
            else
            {
                MessageBox.Show("Please select a product to modify");
            }

        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dgvParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvParts.CurrentCell != null)
            {
                Inventory.CurrentPartIndex = dgvParts.CurrentCell.RowIndex;
                dgvParts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
            }
        }

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrentPartIndex >= 0)
            {
                // if selected part is associated with a product, alert user and break
                foreach (Product product in Inventory.lstProducts)
                {
                    foreach (Part part in product.getAssociatedParts())
                    {
                        if (Inventory.lstAllParts[Inventory.CurrentPartIndex].getPartID() == part.getPartID())
                        {
                            MessageBox.Show("Cannot delete a part that is associated with a product");
                            return;
                        }
                    }
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected part?",
                    "Delete?", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    Inventory.deletePart(Inventory.CurrentPartIndex);
                    Inventory.CurrentPartIndex = -1;
                    displayPartsList();
                }
                dgvParts.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            else
            {
                MessageBox.Show("Please select a part to delete");
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.CurrentCell != null)
            {
                Inventory.CurrentProductIndex = dgvProducts.CurrentCell.RowIndex;
                dgvProducts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
            }
        }

        private void btnSearchParts_Click(object sender, EventArgs e)
        {
            string part = txtSearchParts.Text.Trim();

            if (part != "")
            {
                foreach (DataGridViewRow row in dgvParts.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains(part))
                    {
                        row.Selected = true;
                        dgvParts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
                        Inventory.CurrentPartIndex = row.Index;
                    }
                }
            }
        }

        private void btnSearchProducts_Click(object sender, EventArgs e)
        {
            string product = txtSearchProducts.Text.Trim();

            if (product != "")
            {
                foreach (DataGridViewRow row in dgvProducts.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains(product))
                    {
                        row.Selected = true;
                        dgvProducts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
                        Inventory.CurrentProductIndex = row.Index;
                    }
                }
            }

        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (Inventory.CurrentProductIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected product?",
                    "Delete?", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    Inventory.removeProduct(Inventory.lstProducts[Inventory.CurrentProductIndex].getProductID());
                    Inventory.CurrentProductIndex = -1;
                    displayProductsList();
                }
                dgvProducts.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            }
            else
            {
                MessageBox.Show("Please select a product to delete");
            }
        }
    }

    
}

