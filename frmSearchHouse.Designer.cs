namespace prjWinRemaxTaianaAntokhine
{
    partial class frmSearchHouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchHouse));
            this.gridHouses = new System.Windows.Forms.DataGridView();
            this.btnSearchAllHouses = new System.Windows.Forms.Button();
            this.btnSearchHouseById = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtHouseId = new System.Windows.Forms.TextBox();
            this.lstHouseType = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridHouses)).BeginInit();
            this.SuspendLayout();
            // 
            // gridHouses
            // 
            this.gridHouses.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.gridHouses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHouses.Location = new System.Drawing.Point(52, 403);
            this.gridHouses.Margin = new System.Windows.Forms.Padding(4);
            this.gridHouses.Name = "gridHouses";
            this.gridHouses.Size = new System.Drawing.Size(1017, 285);
            this.gridHouses.TabIndex = 0;
            // 
            // btnSearchAllHouses
            // 
            this.btnSearchAllHouses.BackColor = System.Drawing.Color.MediumBlue;
            this.btnSearchAllHouses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchAllHouses.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchAllHouses.Location = new System.Drawing.Point(737, 181);
            this.btnSearchAllHouses.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchAllHouses.Name = "btnSearchAllHouses";
            this.btnSearchAllHouses.Size = new System.Drawing.Size(206, 47);
            this.btnSearchAllHouses.TabIndex = 1;
            this.btnSearchAllHouses.Text = "Find All Houses";
            this.btnSearchAllHouses.UseVisualStyleBackColor = false;
            this.btnSearchAllHouses.Click += new System.EventHandler(this.btnSearchAllHouses_Click);
            // 
            // btnSearchHouseById
            // 
            this.btnSearchHouseById.BackColor = System.Drawing.Color.MediumBlue;
            this.btnSearchHouseById.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchHouseById.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchHouseById.Location = new System.Drawing.Point(737, 90);
            this.btnSearchHouseById.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchHouseById.Name = "btnSearchHouseById";
            this.btnSearchHouseById.Size = new System.Drawing.Size(206, 47);
            this.btnSearchHouseById.TabIndex = 2;
            this.btnSearchHouseById.Text = "FindHouse By ID";
            this.btnSearchHouseById.UseVisualStyleBackColor = false;
            this.btnSearchHouseById.Click += new System.EventHandler(this.btnSearchHouseById_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(465, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(185, 24);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "SEARCH HOUSES";
            // 
            // txtHouseId
            // 
            this.txtHouseId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHouseId.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtHouseId.Location = new System.Drawing.Point(485, 96);
            this.txtHouseId.MaximumSize = new System.Drawing.Size(332, 47);
            this.txtHouseId.Multiline = true;
            this.txtHouseId.Name = "txtHouseId";
            this.txtHouseId.Size = new System.Drawing.Size(232, 35);
            this.txtHouseId.TabIndex = 4;
            this.txtHouseId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHouseId.Enter += new System.EventHandler(this.txtHouseId_Enter);
            this.txtHouseId.Leave += new System.EventHandler(this.txtHouseId_Leave);
            // 
            // lstHouseType
            // 
            this.lstHouseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHouseType.FormattingEnabled = true;
            this.lstHouseType.ItemHeight = 24;
            this.lstHouseType.Location = new System.Drawing.Point(52, 90);
            this.lstHouseType.Name = "lstHouseType";
            this.lstHouseType.Size = new System.Drawing.Size(222, 148);
            this.lstHouseType.TabIndex = 5;
            this.lstHouseType.SelectedIndexChanged += new System.EventHandler(this.lstHouseType_SelectedIndexChanged);
            // 
            // frmSearchHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1115, 701);
            this.Controls.Add(this.lstHouseType);
            this.Controls.Add(this.txtHouseId);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSearchHouseById);
            this.Controls.Add(this.btnSearchAllHouses);
            this.Controls.Add(this.gridHouses);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSearchHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSearchHouse";
            this.Load += new System.EventHandler(this.frmSearchHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridHouses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridHouses;
        private System.Windows.Forms.Button btnSearchAllHouses;
        private System.Windows.Forms.Button btnSearchHouseById;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtHouseId;
        private System.Windows.Forms.ListBox lstHouseType;
    }
}