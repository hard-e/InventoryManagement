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
    public partial class PartScreen : Form
    {
        bool[] blnValid = new bool[6];
        private bool blnInHouse = true;
        ToolTip toolTipName = new ToolTip();
        ToolTip toolTipInventory = new ToolTip();
        ToolTip toolTipPrice = new ToolTip();
        ToolTip toolTipMax = new ToolTip();
        ToolTip toolTipMin = new ToolTip();
        ToolTip toolTipMachineIDCompanyName = new ToolTip();

        public PartScreen()
        {
            InitializeComponent();
        }

        private void PartScreen_Load(object sender, EventArgs e)
        {
            if (rdbOutsourced.Checked == true)
            {
                blnInHouse = false;
            }
            else
            {
                blnInHouse = true;
            }
        }

        private void lblMachineIDCompanyNameUpdate()
        {
            if (rdbOutsourced.Checked)
            {
                lblMachineIDCompanyName.Text = "Company Name";
                blnInHouse = false;
            }
            else
            {
                lblMachineIDCompanyName.Text = "      Machine ID";
                blnInHouse = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // if the form has not been validated, alert user and break
            for (int i = 0; i < 6; i++)
            {
                if (blnValid[i] == false)
                {
                    MessageBox.Show("Please correct the form prior to submission");
                    return;
                }
            }

            // if the part is being modified, remove it from the list
            if (lblAddModify.Text == "Modify Part")
            {
                Inventory.deletePart(Inventory.CurrentPartIndex);
            }
            else
            {
                // if the part already exists, alert the user and break
                foreach (Part p in Inventory.lstAllParts)
                {
                    if (txtName.Text == p.getName())
                    {
                        MessageBox.Show("Part already exists");
                        return;
                    }
                }
            }

            // create and save the new part
            BasePart part = new BasePart();
            part.intPartID = Int32.Parse(txtID.Text);
            part.strName = txtName.Text;
            part.intInStock = Int32.Parse(txtInventory.Text);
            part.fltPrice = float.Parse(txtPrice.Text);
            part.intMin = Int32.Parse(txtMin.Text);
            part.intMax = Int32.Parse(txtMax.Text);

            if (blnInHouse)
            {
                Inhouse inhouse = new Inhouse(part, Int32.Parse(txtMachineIDCompanyName.Text));
                Inventory.addPart(inhouse);
            }
            else
            {
                Outsourced outsourced = new Outsourced(part, txtMachineIDCompanyName.Text);
                Inventory.addPart(outsourced);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PartScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainScreen mainScreen = new MainScreen();
            mainScreen.Show();
        }

        private void rdbInHouse_CheckedChanged(object sender, EventArgs e)
        {
            lblMachineIDCompanyNameUpdate();
        }

        private void rdbOutsourced_CheckedChanged(object sender, EventArgs e)
        {
            lblMachineIDCompanyNameUpdate();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            // trim whitespace
            txtName.Text = txtName.Text.Trim().ToLower();
            if (txtName.Text == "")
            {
                // if nothing was entered
                txtName.BackColor = System.Drawing.Color.Salmon;
                toolTipName.SetToolTip(txtName, "Please enter a part name");
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
                toolTipName.SetToolTip(txtName, "Please enter a part name");
                blnValid[0] = false;
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
            else if (txtMin.Text == "" || txtMax.Text == "")
            {
                txtInventory.BackColor = System.Drawing.Color.White;
                toolTipInventory.RemoveAll();
                blnValid[1] = true;
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

        private void rdbOutsourced_Click(object sender, EventArgs e)
        {
            txtMachineIDCompanyName_TextChanged(sender, e);
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
                    if (Int32.Parse(txtInventory.Text) <= Int32.Parse(txtMax.Text))
                    {
                        if (Int32.Parse(txtInventory.Text) >= Int32.Parse(txtMin.Text))
                        {
                            txtInventory.BackColor = System.Drawing.Color.White;
                            toolTipInventory.RemoveAll();
                            blnValid[1] = true;
                        }
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

        private void txtMachineIDCompanyName_TextChanged(object sender, EventArgs e)
        {
            // verify the textbox is not empty
            if (!String.IsNullOrEmpty(txtMachineIDCompanyName.Text))
            {
                if (lblMachineIDCompanyName.Text == "Company Name")
                {
                    for (int i = 0; i < txtMachineIDCompanyName.Text.Length; i++)
                    {
                        // verify only letters were entered
                        if (!char.IsLetter(txtMachineIDCompanyName.Text[i]))
                        {
                            txtMachineIDCompanyName.BackColor = System.Drawing.Color.Salmon;
                            toolTipMachineIDCompanyName.SetToolTip(txtMachineIDCompanyName, "Please enter letters only");
                            blnValid[5] = false;
                            return;
                        }
                    }
                    toolTipMachineIDCompanyName.SetToolTip(txtMachineIDCompanyName, "Please enter a company name");
                }
                else
                {
                    for (int i = 0; i < txtMachineIDCompanyName.Text.Length; i++)
                    {
                        // verify only numbers were entered
                        if (!char.IsDigit(txtMachineIDCompanyName.Text[i]))
                        {
                            txtMachineIDCompanyName.BackColor = System.Drawing.Color.Salmon;
                            toolTipMachineIDCompanyName.SetToolTip(txtMachineIDCompanyName, "Please enter numbers only");
                            blnValid[5] = false;
                            return;
                        }
                    }

                    toolTipMachineIDCompanyName.SetToolTip(txtMachineIDCompanyName, "Please enter a machine id");
                }

                txtMachineIDCompanyName.BackColor = System.Drawing.Color.White;
                toolTipMachineIDCompanyName.RemoveAll();
                blnValid[5] = true;
                return;
            }
            else
            {
                // if nothing was entered
                txtMachineIDCompanyName.BackColor = System.Drawing.Color.Salmon;
                if (lblMachineIDCompanyName.Text == "Company Name")
                {
                    toolTipMachineIDCompanyName.SetToolTip(txtMachineIDCompanyName, "Please enter a company name");
                }
                else
                {
                    toolTipMachineIDCompanyName.SetToolTip(txtMachineIDCompanyName, "Please enter a machine id");
                }
                blnValid[5] = false;
            }
        }

        private void txtMachineIDCompanyName_Leave(object sender, EventArgs e)
        {
            // trim whitespace
            txtMachineIDCompanyName.Text = txtMachineIDCompanyName.Text.Trim();

            if (txtMachineIDCompanyName.Text == "")
            {
                // if nothing was entered
                txtMachineIDCompanyName.BackColor = System.Drawing.Color.Salmon;
                if (lblMachineIDCompanyName.Text == "Company Name")
                {
                    toolTipMachineIDCompanyName.SetToolTip(txtMachineIDCompanyName, "Please enter a company name");
                }
                else
                {
                    toolTipMachineIDCompanyName.SetToolTip(txtMachineIDCompanyName, "Please enter a machine id");
                }
                blnValid[5] = false;
            }
        }

        private void rdbInHouse_Click(object sender, EventArgs e)
        {
            txtMachineIDCompanyName_TextChanged(sender, e);
        }
    }
}
