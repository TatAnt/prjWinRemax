namespace prjWinRemaxTaianaAntokhine
{
    partial class frmManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManagement));
            this.btnManageClients = new System.Windows.Forms.Button();
            this.btnManageHouses = new System.Windows.Forms.Button();
            this.btnManageEmployees = new System.Windows.Forms.Button();
            this.lblRoleId = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnManageClients
            // 
            this.btnManageClients.BackColor = System.Drawing.Color.SandyBrown;
            this.btnManageClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageClients.Location = new System.Drawing.Point(750, 59);
            this.btnManageClients.Name = "btnManageClients";
            this.btnManageClients.Size = new System.Drawing.Size(269, 126);
            this.btnManageClients.TabIndex = 1;
            this.btnManageClients.Text = "Manage Clients";
            this.btnManageClients.UseVisualStyleBackColor = false;
            this.btnManageClients.Click += new System.EventHandler(this.btnManageClients_Click);
            // 
            // btnManageHouses
            // 
            this.btnManageHouses.BackColor = System.Drawing.Color.SandyBrown;
            this.btnManageHouses.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageHouses.Location = new System.Drawing.Point(750, 229);
            this.btnManageHouses.Name = "btnManageHouses";
            this.btnManageHouses.Size = new System.Drawing.Size(269, 126);
            this.btnManageHouses.TabIndex = 2;
            this.btnManageHouses.Text = "Manage Houses";
            this.btnManageHouses.UseVisualStyleBackColor = false;
            this.btnManageHouses.Click += new System.EventHandler(this.btnManageHouses_Click);
            // 
            // btnManageEmployees
            // 
            this.btnManageEmployees.BackColor = System.Drawing.Color.SandyBrown;
            this.btnManageEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageEmployees.Location = new System.Drawing.Point(750, 419);
            this.btnManageEmployees.Name = "btnManageEmployees";
            this.btnManageEmployees.Size = new System.Drawing.Size(269, 126);
            this.btnManageEmployees.TabIndex = 3;
            this.btnManageEmployees.Text = "Manage Employees";
            this.btnManageEmployees.UseVisualStyleBackColor = false;
            this.btnManageEmployees.Click += new System.EventHandler(this.btnManageEmployees_Click);
            // 
            // lblRoleId
            // 
            this.lblRoleId.AutoSize = true;
            this.lblRoleId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblRoleId.Location = new System.Drawing.Point(52, 542);
            this.lblRoleId.Name = "lblRoleId";
            this.lblRoleId.Size = new System.Drawing.Size(44, 13);
            this.lblRoleId.TabIndex = 6;
            this.lblRoleId.Text = "RoleId: ";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblId.Location = new System.Drawing.Point(52, 566);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 8;
            this.lblId.Text = "ID:";
            // 
            // frmManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1234, 611);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblRoleId);
            this.Controls.Add(this.btnManageEmployees);
            this.Controls.Add(this.btnManageHouses);
            this.Controls.Add(this.btnManageClients);
            this.IsMdiContainer = true;
            this.Name = "frmManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManagement";
            this.Load += new System.EventHandler(this.frmManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnManageClients;
        private System.Windows.Forms.Button btnManageHouses;
        public System.Windows.Forms.Button btnManageEmployees;
        public System.Windows.Forms.Label lblRoleId;
        public System.Windows.Forms.Label lblId;
    }
}