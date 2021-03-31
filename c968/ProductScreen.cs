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
    public partial class ProductScreen : Form
    {
        bool[] blnValid = new bool[6];
        ToolTip toolTipName = new ToolTip();
        ToolTip toolTipInventory = new ToolTip();
        ToolTip toolTipPrice = new ToolTip();
        ToolTip toolTipMax = new ToolTip();
        ToolTip toolTipMin = new ToolTip();
        ToolTip toolTipParts = new ToolTip();

        private static int partIndex { get; set; } = -1;
        BindingList<Part> associatedParts = new BindingList<Part>();

        public void formatDGV(DataGridView d)
        {
            d.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            d.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            d.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            d.RowHeadersVisible = false;
            d.Columns.Add("0", "Part ID");
            d.Columns.Add("Name", "Name");
            d.Columns.Add("Inventory", "Inventory");
            d.Columns.Add("Price", "Price");
            d.Columns.Add("Min", "Min");
            d.Columns.Add("Max", "Max");
        }

        public void displayAllPartsList()
        {
            foreach (DataGridViewColumn column in dgvAllParts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgvAllParts.Rows.Clear();
            dgvAllParts.Refresh();
            for (int i = 0; i < Inventory.lstAllParts.Count; i++)
            {
                dgvAllParts.Rows.Add();
                dgvAllParts.Rows[i].Cells[0].Value = Inventory.lstAllParts[i].getPartID();
                dgvAllParts.Rows[i].Cells[1].Value = Inventory.lstAllParts[i].getName();
                dgvAllParts.Rows[i].Cells[2].Value = Inventory.lstAllParts[i].getInStock();
                dgvAllParts.Rows[i].Cells[3].Value = Inventory.lstAllParts[i].getPrice();
                dgvAllParts.Rows[i].Cells[4].Value = Inventory.lstAllParts[i].getMin();
                dgvAllParts.Rows[i].Cells[5].Value = Inventory.lstAllParts[i].getMax();
            }
        }

        public ProductScreen()
        {
            InitializeComponent();

            // build, format, and display dgvAllParts
            formatDGV(dgvAllParts);
            displayAllPartsList();

            // format and display dgvParts
            formatDGV(dgvParts);
            foreach (DataGridViewColumn column in dgvParts.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // break if no parts have been added and alert user
            if (dgvParts.Rows.Count <= 0)
            {
                MessageBox.Show("Product must contain at least one part");
                blnValid[5] = false;
                return;
            }
            else
            {
                blnValid[5] = true;
            }
            
            // if the form has not been validated, alert user and break
            for (int i = 0; i < 6; i++)
            {
                if (blnValid[i] == false)
                {
                    MessageBox.Show("Please correct the form prior to submission");
                    return;
                }
            }

            // if the product is being modified, remove it from the list
            if (lblAddModify.Text == "Modify Product")
            {
                Inventory.removeProduct(Inventory.lstProducts[Inventory.CurrentProductIndex].getProductID());
            }

            // if the product already exists, alert the user and break
            foreach (Product p in Inventory.lstProducts)
            {
                if (txtName.Text == p.getName())
                {
                    MessageBox.Show("Product already exists");
                    return;
                }
            }

            // add parts to product
            foreach (DataGridViewRow row in dgvParts.Rows)
            {
                associatedParts.Add(Inventory.lookupPart(Int32.Parse(row.Cells[0].Value.ToString())));
            }

            // build the new product
            Product product = new Product(
            Int32.Parse(txtID.Text),
            txtName.Text,
            float.Parse(txtPrice.Text),
            Int32.Parse(txtInventory.Text),
            Int32.Parse(txtMin.Text),
            Int32.Parse(txtMax.Text),
            associatedParts);

            // save the new product to the list
            Inventory.addProduct(product);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Inventory.CurrentPartIndex = -1;
            Inventory.CurrentProductIndex = -1;
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            if (partIndex >= 0)
            {
                // check to see if the part is already on the list
                foreach (DataGridViewRow row in dgvParts.Rows)
                {
                    if ((string)row.Cells[1].Value == Inventory.lstAllParts[partIndex].getName())
                    {
                        // if so, alert the user
                        MessageBox.Show("Part has already been added");
                        return;
                    }
                }

                // add the part selected in dgvAllParts to dgvParts
                int i = dgvParts.Rows.Add();
                dgvParts.Rows[i].Cells[0].Value = Inventory.lstAllParts[partIndex].getPartID();
                dgvParts.Rows[i].Cells[1].Value = Inventory.lstAllParts[partIndex].getName();
                dgvParts.Rows[i].Cells[2].Value = Inventory.lstAllParts[partIndex].getInStock();
                dgvParts.Rows[i].Cells[3].Value = Inventory.lstAllParts[partIndex].getPrice();
                dgvParts.Rows[i].Cells[4].Value = Inventory.lstAllParts[partIndex].getMin();
                dgvParts.Rows[i].Cells[5].Value = Inventory.lstAllParts[partIndex].getMax();

                partIndex = -1;
                dgvAllParts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            }
        }

        private void dgvAllParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAllParts.CurrentCell != null)
            {
                partIndex = dgvAllParts.CurrentCell.RowIndex;
                dgvAllParts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
            }
        }

    private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvParts.CurrentCell != null && partIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected part?",
                 "Delete?", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    // remove selected part from dgvParts
                    dgvParts.Rows.Remove(dgvParts.Rows[partIndex]);
                }
            }
        }

        private void dgvParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvParts.CurrentCell != null)
            {
                partIndex = dgvParts.CurrentCell.RowIndex;
                dgvParts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
            }
        }

        public void btnSearchParts_Click(object sender, EventArgs e)
        {
            string part = txtSearchParts.Text.Trim();

            if (part != "")
            {
                foreach (DataGridViewRow row in dgvAllParts.Rows)
                {
                    if (row.Cells[1].Value.ToString().Contains(part))
                    {
                        row.Selected = true;
                        dgvAllParts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
                        partIndex = row.Index;
                    }
                }
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // verify the textbox is not empty
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                for (int i = 0; i < txtName.Text.Length; i++)
                {
                    // verify only letters were entered
                    if (!char.IsLetter(txtName.Text[i]))
                    {
                        txtName.BackColor = System.Drawing.Color.Salmon;
                        toolTipName.SetToolTip(txtName, "Please enter letters only");
                        blnValid[0] = false;
                        return;
                    }
                    txtName.BackColor = System.Drawing.Color.White;
                    toolTipName.RemoveAll();
                    blnValid[0] = true;
                }
            }
            else
            {
                // if nothing was entered
                txtName.BackColor = System.Drawing.Color.Salmon;
                toolTipName.SetToolTip(txtName, "Please enter a product name");
                blnValid[0] = false;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            // trim whitespace
            txtName.Text = txtName.Text.Trim().ToLower();
            if (txtName.Text == "")
            {
                // if nothing was entered
                txtName.BackColor = System.Drawing.Color.Salmon;
                toolTipName.SetToolTip(txtName, "Please enter a product name");
            }
        }

        private void txtInventory_TextChanged(object sender, EventArgs e)
        {
            txtInventory.Text = txtInventory.Text.Trim();
            // verify the textbox is not empty
            if (!String.IsNullOrEmpty(txtInventory.Text))
            {
                for (int i = 0; i < txtInventory.Text.Length; i++)
                {
                    // verify only numbers were entered
                    if (!char.IsDigit(txtInventory.Text[i]))
                    {
                        txtInventory.BackColor = System.Drawing.Color.Salmon;
                        toolTipInventory.SetToolTip(txtInventory, "Please enter numbers only");
                        blnValid[1] = false;
                        return;
                    }
                }

                // verify inventory quantity is between min and max amounts
                try
                {
                    if ((Int32.Parse(txtInventory.Text) >= Int32.Parse(txtMin.Text)) &&
                        (Int32.Parse(txtInventory.Text) <= Int32.Parse(txtMax.Text)))
                    {
                        txtInventory.BackColor = System.Drawing.Color.White;
                        toolTipInventory.RemoveAll();
                        blnValid[1] = true;
                    }
                    else
                    {
                        txtInventory.BackColor = System.Drawing.Color.Salmon;
                        toolTipInventory.SetToolTip(txtInventory, "Inventory quantity must be within min and max amounts");
                        blnValid[1] = false;
                    }
                }
                catch
                {
                    txtInventory.BackColor = System.Drawing.Color.Salmon;
                    toolTipInventory.SetToolTip(txtInventory, "Inventory quantity must be within min and max amounts");
                    blnValid[1] = false;
                }
            }
            else
            {
                // if nothing was entered
                txtInventory.BackColor = System.Drawing.Color.Salmon;
                toolTipInventory.SetToolTip(txtInventory, "Please enter an inventory quantity");
                blnValid[1] = false;
            }
        }

        private void txtInventory_Leave(object sender, EventArgs e)
        {
            // trim whitespace
            txtInventory.Text = txtInventory.Text.Trim();

            if (txtInventory.Text == "")
            {
                // if nothing was entered
                txtInventory.BackColor = System.Drawing.Color.Salmon;
                toolTipInventory.SetToolTip(txtInventory, "Please enter an inventory quantity");
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            // verify the textbox is not empty
            if (!String.IsNullOrEmpty(txtPrice.Text))
            {
                // verify input type
                double dblResult;
                double.TryParse(txtPrice.Text, out dblResult);

                if (dblResult == 0)
                {
                    txtPrice.BackColor = System.Drawing.Color.Salmon;
                    toolTipPrice.SetToolTip(txtPrice, "Please enter only valid numbers and decimals");
                    blnValid[2] = false;
                    return;
                }

                dblResult = Math.Round(dblResult, 2);
                txtPrice.BackColor = System.Drawing.Color.White;
                toolTipPrice.RemoveAll();
                blnValid[2] = true;
            }
            else
            {
                // if nothing was entered
                txtPrice.BackColor = System.Drawing.Color.Salmon;
                toolTipPrice.SetToolTip(txtPrice, "Please enter a price");
                blnValid[2] = false;
            }
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            // trim whitespace
            txtPrice.Text = txtPrice.Text.Trim();

            if (txtPrice.Text == "")
            {
                // if nothing was entered
                txtPrice.BackColor = System.Drawing.Color.Salmon;
                toolTipPrice.SetToolTip(txtPrice, "Please enter a price");
                blnValid[2] = false;
            }
            else
            {
                // format the price
                txtPrice.Text = String.Format("{0:0.00}", double.Parse(txtPrice.Text));
            }
        }

        private void txtMax_TextChanged(object sender, EventArgs e)
        {
            // verify the textbox is not empty
            if (!String.IsNullOrEmpty(txtMax.Text))
            {
                for (int i = 0; i < txtMax.Text.Length; i++)
                {
                    // verify only numbers were entered
                    if (!char.IsDigit(txtMax.Text[i]))
                    {
                        txtMax.BackColor = System.Drawing.Color.Salmon;
                        toolTipMax.SetToolTip(txtMax, "Please enter numbers only");
                        blnValid[3] = false;
                        return;
                    }
                }

                // verify max is greater than or equal to min 
                try
                {
                    if (Int32.Parse(txtMax.Text) >= Int32.Parse(txtMin.Text))
                    {
                        txtMax.BackColor = System.Drawing.Color.White;
                        toolTipMax.RemoveAll();
                        txtMin.BackColor = System.Drawing.Color.White;
                        toolTipMin.RemoveAll();
                        blnValid[3] = true;
                        blnValid[4] = true;
                    }
                    else
                    {
                        txtMax.BackColor = System.Drawing.Color.Salmon;
                        toolTipMax.SetToolTip(txtMax, "Maximum amount cannot be less than minimum");
                        txtMin.BackColor = System.Drawing.Color.Salmon;
                        toolTipMin.SetToolTip(txtMin, "Minimum amount cannot exceed maximum");
                        blnValid[3] = false;
                        blnValid[4] = false;
                    }
                    //txtMin_TextChanged(sender, e);
                    txtInventory_TextChanged(sender, e);
                }
                catch
                {
                    txtMax.BackColor = System.Drawing.Color.Salmon;
                    toolTipMax.SetToolTip(txtMax, "Maximum amount cannot be less than minimum");
                    blnValid[3] = false;
                }
            }
            else
            {
                // if nothing was entered
                txtMax.BackColor = System.Drawing.Color.Salmon;
                toolTipMax.SetToolTip(txtMax, "Please enter a maximum quantity");
                blnValid[3] = false;
            }
        }

        private void txtMax_Leave(object sender, EventArgs e)
        {
            // trim whitespace
            txtMax.Text = txtMax.Text.Trim();

            if (txtMax.Text == "")
            {
                // if nothing was entered
                txtMax.BackColor = System.Drawing.Color.Salmon;
                toolTipMax.SetToolTip(txtMax, "Please enter a maximum quantity");
                blnValid[3] = false;
            }
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
        {
            // verify the textbox is not empty
            if (!String.IsNullOrEmpty(txtMin.Text))
            {
                for (int i = 0; i < txtMin.Text.Length; i++)
                {
                    // verify only numbers were entered
                    if (!char.IsDigit(txtMin.Text[i]))
                    {
                        txtMin.BackColor = System.Drawing.Color.Salmon;
                        toolTipMin.SetToolTip(txtMin, "Please enter numbers only");
                        blnValid[4] = false;
                        return;
                    }
                }

                // verify min is less than or equal to max 
                try
                {
                    if (Int32.Parse(txtMin.Text) <= Int32.Parse(txtMax.Text))
                    {
                        txtMin.BackColor = System.Drawing.Color.White;
                        toolTipMin.RemoveAll();
                        txtMax.BackColor = System.Drawing.Color.White;
                        toolTipMax.RemoveAll();
                        blnValid[4] = true;
                        blnValid[3] = true;
                    }
                    else
                    {
                        txtMin.BackColor = System.Drawing.Color.Salmon;
                        toolTipMin.SetToolTip(txtMin, "Minimum amount cannot exceed maximum");
                        txtMax.BackColor = System.Drawing.Color.Salmon;
                        toolTipMax.SetToolTip(txtMax, "Maximum amount cannot be less than minimum");
                        blnValid[4] = false;
                        blnValid[3] = false;
                    }
                    //txtMax_TextChanged(sender, e);
                    txtInventory_TextChanged(sender, e);
                }
                catch
                {
                    txtMin.BackColor = System.Drawing.Color.Salmon;
                    toolTipMin.SetToolTip(txtMin, "Minimum amount cannot exceed maximum");
                    blnValid[4] = false;
                }
            }
            else
            {
                // if nothing was entered
                txtMin.BackColor = System.Drawing.Color.Salmon;
                toolTipMin.SetToolTip(txtMin, "Please enter a minimum quantity");
                blnValid[4] = false;
            }
        }

        private void txtMin_Leave(object sender, EventArgs e)
        {
            // trim whitespace
            txtMin.Text = txtMin.Text.Trim();

            if (txtMin.Text == "")
            {
                // if nothing was entered
                txtMin.BackColor = System.Drawing.Color.Salmon;
                toolTipMin.SetToolTip(txtMin, "Please enter a minimum quantity");
                blnValid[4] = false;
            }
        }
    }
}
