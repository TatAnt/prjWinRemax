namespace prjWinRemaxTaianaAntokhine
{
    partial class frmSearchAgent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchAgent));
            this.txtAgentId = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnFindAgent = new System.Windows.Forms.Button();
            this.gridAgents = new System.Windows.Forms.DataGridView();
            this.cboLocation = new System.Windows.Forms.ComboBox();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.cboRealEstate = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkType = new System.Windows.Forms.CheckBox();
            this.chkLanguage = new System.Windows.Forms.CheckBox();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.chkID = new System.Windows.Forms.CheckBox();
            this.lblAgentId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridAgents)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAgentId
            // 
            this.txtAgentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgentId.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtAgentId.Location = new System.Drawing.Point(640, 30);
            this.txtAgentId.MaximumSize = new System.Drawing.Size(332, 47);
            this.txtAgentId.Multiline = true;
            this.txtAgentId.Name = "txtAgentId";
            this.txtAgentId.Size = new System.Drawing.Size(249, 30);
            this.txtAgentId.TabIndex = 9;
            this.txtAgentId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAgentId.Enter += new System.EventHandler(this.txtAgentId_Enter);
            this.txtAgentId.Leave += new System.EventHandler(this.txtAgentId_Leave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(406, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 24);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "FIND an AGENT";
            // 
            // btnFindAgent
            // 
            this.btnFindAgent.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnFindAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindAgent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFindAgent.Location = new System.Drawing.Point(632, 96);
            this.btnFindAgent.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindAgent.Name = "btnFindAgent";
            this.btnFindAgent.Size = new System.Drawing.Size(261, 45);
            this.btnFindAgent.TabIndex = 6;
            this.btnFindAgent.Text = "Find an Agent";
            this.btnFindAgent.UseVisualStyleBackColor = false;
            this.btnFindAgent.Click += new System.EventHandler(this.btnFindAgent_Click);
            // 
            // gridAgents
            // 
            this.gridAgents.BackgroundColor = System.Drawing.Color.White;
            this.gridAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAgents.Location = new System.Drawing.Point(13, 363);
            this.gridAgents.Margin = new System.Windows.Forms.Padding(4);
            this.gridAgents.Name = "gridAgents";
            this.gridAgents.Size = new System.Drawing.Size(924, 255);
            this.gridAgents.TabIndex = 5;
            // 
            // cboLocation
            // 
            this.cboLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocation.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboLocation.FormattingEnabled = true;
            this.cboLocation.Location = new System.Drawing.Point(198, 30);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(249, 32);
            this.cboLocation.TabIndex = 11;
            this.cboLocation.DropDown += new System.EventHandler(this.cboLocation_DropDown);
            // 
            // cboLanguage
            // 
            this.cboLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLanguage.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(198, 68);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(249, 32);
            this.cboLanguage.TabIndex = 14;
            this.cboLanguage.DropDown += new System.EventHandler(this.cboLanguage_DropDown);
            // 
            // cboRealEstate
            // 
            this.cboRealEstate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRealEstate.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cboRealEstate.FormattingEnabled = true;
            this.cboRealEstate.Location = new System.Drawing.Point(198, 108);
            this.cboRealEstate.Name = "cboRealEstate";
            this.cboRealEstate.Size = new System.Drawing.Size(249, 32);
            this.cboRealEstate.TabIndex = 16;
            this.cboRealEstate.DropDown += new System.EventHandler(this.cboRealEstate_DropDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.chkType);
            this.groupBox1.Controls.Add(this.chkLanguage);
            this.groupBox1.Controls.Add(this.chkLocation);
            this.groupBox1.Controls.Add(this.chkID);
            this.groupBox1.Controls.Add(this.btnFindAgent);
            this.groupBox1.Controls.Add(this.cboRealEstate);
            this.groupBox1.Controls.Add(this.txtAgentId);
            this.groupBox1.Controls.Add(this.cboLanguage);
            this.groupBox1.Controls.Add(this.cboLocation);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(924, 161);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // chkType
            // 
            this.chkType.AutoSize = true;
            this.chkType.BackColor = System.Drawing.Color.Transparent;
            this.chkType.Location = new System.Drawing.Point(26, 116);
            this.chkType.Name = "chkType";
            this.chkType.Size = new System.Drawing.Size(170, 20);
            this.chkType.TabIndex = 20;
            this.chkType.Text = "By Real Estate Type";
            this.chkType.UseVisualStyleBackColor = false;
            // 
            // chkLanguage
            // 
            this.chkLanguage.AutoSize = true;
            this.chkLanguage.BackColor = System.Drawing.Color.Transparent;
            this.chkLanguage.Location = new System.Drawing.Point(26, 76);
            this.chkLanguage.Name = "chkLanguage";
            this.chkLanguage.Size = new System.Drawing.Size(118, 20);
            this.chkLanguage.TabIndex = 19;
            this.chkLanguage.Text = "By Language";
            this.chkLanguage.UseVisualStyleBackColor = false;
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.BackColor = System.Drawing.Color.Transparent;
            this.chkLocation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkLocation.Location = new System.Drawing.Point(26, 38);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(108, 20);
            this.chkLocation.TabIndex = 18;
            this.chkLocation.Text = "By Location";
            this.chkLocation.UseVisualStyleBackColor = false;
            // 
            // chkID
            // 
            this.chkID.AutoSize = true;
            this.chkID.BackColor = System.Drawing.Color.Transparent;
            this.chkID.Location = new System.Drawing.Point(558, 38);
            this.chkID.Name = "chkID";
            this.chkID.Size = new System.Drawing.Size(64, 20);
            this.chkID.TabIndex = 17;
            this.chkID.Text = "By ID";
            this.chkID.UseVisualStyleBackColor = false;
            // 
            // lblAgentId
            // 
            this.lblAgentId.AutoSize = true;
            this.lblAgentId.BackColor = System.Drawing.Color.Transparent;
            this.lblAgentId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgentId.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAgentId.Location = new System.Drawing.Point(53, 339);
            this.lblAgentId.Name = "lblAgentId";
            this.lblAgentId.Size = new System.Drawing.Size(57, 20);
            this.lblAgentId.TabIndex = 20;
            this.lblAgentId.Text = "Agent";
            // 
            // frmSearchAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(963, 651);
            this.Controls.Add(this.lblAgentId);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gridAgents);
            this.Name = "frmSearchAgent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSearchAgent";
            this.Load += new System.EventHandler(this.frmSearchAgent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAgents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAgentId;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnFindAgent;
        private System.Windows.Forms.DataGridView gridAgents;
        private System.Windows.Forms.ComboBox cboLocation;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.ComboBox cboRealEstate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkType;
        private System.Windows.Forms.CheckBox chkLanguage;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.CheckBox chkID;
        private System.Windows.Forms.Label lblAgentId;
    }
}