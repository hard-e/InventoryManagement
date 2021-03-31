
namespace c968
{
    partial class PartScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.RadioButton rdbInHouse;
            this.lblAddModify = new System.Windows.Forms.Label();
            this.rdbOutsourced = new System.Windows.Forms.RadioButton();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMachineIDCompanyName = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtInventory = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtMachineIDCompanyName = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            rdbInHouse = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdbInHouse
            // 
            rdbInHouse.AutoSize = true;
            rdbInHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rdbInHouse.Location = new System.Drawing.Point(174, 12);
            rdbInHouse.Name = "rdbInHouse";
            rdbInHouse.Size = new System.Drawing.Size(68, 17);
            rdbInHouse.TabIndex = 0;
            rdbInHouse.TabStop = true;
            rdbInHouse.Text = "In-House";
            rdbInHouse.UseVisualStyleBackColor = true;
            rdbInHouse.CheckedChanged += new System.EventHandler(this.rdbInHouse_CheckedChanged);
            rdbInHouse.Click += new System.EventHandler(this.rdbInHouse_Click);
            // 
            // lblAddModify
            // 
            this.lblAddModify.AutoSize = true;
            this.lblAddModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddModify.Location = new System.Drawing.Point(12, 9);
            this.lblAddModify.Name = "lblAddModify";
            this.lblAddModify.Size = new System.Drawing.Size(99, 20);
            this.lblAddModify.TabIndex = 0;
            this.lblAddModify.Text = "Modify Part";
            // 
            // rdbOutsourced
            // 
            this.rdbOutsourced.AutoSize = true;
            this.rdbOutsourced.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbOutsourced.Location = new System.Drawing.Point(272, 12);
            this.rdbOutsourced.Name = "rdbOutsourced";
            this.rdbOutsourced.Size = new System.Drawing.Size(80, 17);
            this.rdbOutsourced.TabIndex = 1;
            this.rdbOutsourced.TabStop = true;
            this.rdbOutsourced.Text = "Outsourced";
            this.rdbOutsourced.UseVisualStyleBackColor = true;
            this.rdbOutsourced.CheckedChanged += new System.EventHandler(this.rdbOutsourced_CheckedChanged);
            this.rdbOutsourced.Click += new System.EventHandler(this.rdbOutsourced_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(169, 70);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(152, 102);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Location = new System.Drawing.Point(136, 138);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(51, 13);
            this.lblInventory.TabIndex = 5;
            this.lblInventory.Text = "Inventory";
            this.lblInventory.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(124, 177);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(63, 13);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price / Cost";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(160, 211);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(27, 13);
            this.lblMax.TabIndex = 7;
            this.lblMax.Text = "Max";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblMachineIDCompanyName
            // 
            this.lblMachineIDCompanyName.AutoSize = true;
            this.lblMachineIDCompanyName.Location = new System.Drawing.Point(105, 245);
            this.lblMachineIDCompanyName.Name = "lblMachineIDCompanyName";
            this.lblMachineIDCompanyName.Size = new System.Drawing.Size(82, 13);
            this.lblMachineIDCompanyName.TabIndex = 8;
            this.lblMachineIDCompanyName.Text = "Company Name";
            this.lblMachineIDCompanyName.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(278, 211);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(24, 13);
            this.lblMin.TabIndex = 9;
            this.lblMin.Text = "Min";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(245, 312);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 29);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(319, 312);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(193, 67);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(109, 20);
            this.txtID.TabIndex = 12;
            this.txtID.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(193, 99);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(109, 20);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtInventory
            // 
            this.txtInventory.Location = new System.Drawing.Point(193, 135);
            this.txtInventory.Name = "txtInventory";
            this.txtInventory.Size = new System.Drawing.Size(109, 20);
            this.txtInventory.TabIndex = 3;
            this.txtInventory.TextChanged += new System.EventHandler(this.txtInventory_TextChanged);
            this.txtInventory.Leave += new System.EventHandler(this.txtInventory_Leave);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(193, 174);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(109, 20);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // txtMachineIDCompanyName
            // 
            this.txtMachineIDCompanyName.Location = new System.Drawing.Point(193, 242);
            this.txtMachineIDCompanyName.Name = "txtMachineIDCompanyName";
            this.txtMachineIDCompanyName.Size = new System.Drawing.Size(109, 20);
            this.txtMachineIDCompanyName.TabIndex = 7;
            this.txtMachineIDCompanyName.TextChanged += new System.EventHandler(this.txtMachineIDCompanyName_TextChanged);
            this.txtMachineIDCompanyName.Leave += new System.EventHandler(this.txtMachineIDCompanyName_Leave);
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(193, 208);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(70, 20);
            this.txtMax.TabIndex = 5;
            this.txtMax.TextChanged += new System.EventHandler(this.txtMax_TextChanged);
            this.txtMax.Leave += new System.EventHandler(this.txtMax_Leave);
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(308, 208);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(70, 20);
            this.txtMin.TabIndex = 6;
            this.txtMin.TextChanged += new System.EventHandler(this.txtMin_TextChanged);
            this.txtMin.Leave += new System.EventHandler(this.txtMin_Leave);
            // 
            // PartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(450, 374);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMachineIDCompanyName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtInventory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblMachineIDCompanyName);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.rdbOutsourced);
            this.Controls.Add(rdbInHouse);
            this.Controls.Add(this.lblAddModify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PartScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Part";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PartScreen_FormClosed);
            this.Load += new System.EventHandler(this.PartScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Label lblAddModify;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtInventory;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.TextBox txtMachineIDCompanyName;
        public System.Windows.Forms.TextBox txtMax;
        public System.Windows.Forms.TextBox txtMin;
        public System.Windows.Forms.RadioButton rdbOutsourced;
        public System.Windows.Forms.Label lblMachineIDCompanyName;
    }
}