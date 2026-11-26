namespace WinFormUI
{
    partial class FrmOrderManagement
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
            this.lblMasterTitle = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cboFilterStatus = new System.Windows.Forms.ComboBox();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.lblSelectedOrder = new System.Windows.Forms.Label();
            this.lblChangeStatus = new System.Windows.Forms.Label();
            this.cboNewStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnPrintManifest = new System.Windows.Forms.Button();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMasterTitle
            // 
            this.lblMasterTitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterTitle.Location = new System.Drawing.Point(22, 15);
            this.lblMasterTitle.Name = "lblMasterTitle";
            this.lblMasterTitle.Size = new System.Drawing.Size(275, 25);
            this.lblMasterTitle.TabIndex = 0;
            this.lblMasterTitle.Text = "INCOMING WEB ORDERS";
            // 
            // lblFilter
            // 
            this.lblFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(693, 18);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(144, 25);
            this.lblFilter.TabIndex = 1;
            this.lblFilter.Text = "Filter by Status:";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboFilterStatus
            // 
            this.cboFilterStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterStatus.FormattingEnabled = true;
            this.cboFilterStatus.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Shipped",
            "Delivered",
            "Cancelled"});
            this.cboFilterStatus.Location = new System.Drawing.Point(839, 15);
            this.cboFilterStatus.Name = "cboFilterStatus";
            this.cboFilterStatus.Size = new System.Drawing.Size(187, 33);
            this.cboFilterStatus.TabIndex = 2;
            this.cboFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cboFilterStatus_SelectedIndexChanged_1);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(22, 59);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersWidth = 51;
            this.dgvOrders.RowTemplate.Height = 24;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1004, 355);
            this.dgvOrders.TabIndex = 3;
            this.dgvOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellClick);
            this.dgvOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellContentClick);
            // 
            // lblSelectedOrder
            // 
            this.lblSelectedOrder.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedOrder.Location = new System.Drawing.Point(28, 433);
            this.lblSelectedOrder.Name = "lblSelectedOrder";
            this.lblSelectedOrder.Size = new System.Drawing.Size(253, 25);
            this.lblSelectedOrder.TabIndex = 4;
            this.lblSelectedOrder.Text = "Selected Order: None";
            this.lblSelectedOrder.Click += new System.EventHandler(this.lblSelectedOrder_Click);
            // 
            // lblChangeStatus
            // 
            this.lblChangeStatus.AutoSize = true;
            this.lblChangeStatus.Location = new System.Drawing.Point(287, 434);
            this.lblChangeStatus.Name = "lblChangeStatus";
            this.lblChangeStatus.Size = new System.Drawing.Size(137, 25);
            this.lblChangeStatus.TabIndex = 5;
            this.lblChangeStatus.Text = "Update Status:";
            this.lblChangeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboNewStatus
            // 
            this.cboNewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNewStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.cboNewStatus.FormattingEnabled = true;
            this.cboNewStatus.Items.AddRange(new object[] {
            "Pending",
            "Shipped",
            "Delivered",
            "Cancelled"});
            this.cboNewStatus.Location = new System.Drawing.Point(430, 431);
            this.cboNewStatus.Name = "cboNewStatus";
            this.cboNewStatus.Size = new System.Drawing.Size(192, 33);
            this.cboNewStatus.TabIndex = 6;
            this.cboNewStatus.SelectedIndexChanged += new System.EventHandler(this.cboNewStatus_SelectedIndexChanged);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateStatus.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Location = new System.Drawing.Point(628, 429);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(170, 33);
            this.btnUpdateStatus.TabIndex = 7;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnPrintManifest
            // 
            this.btnPrintManifest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintManifest.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPrintManifest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintManifest.ForeColor = System.Drawing.Color.White;
            this.btnPrintManifest.Location = new System.Drawing.Point(801, 429);
            this.btnPrintManifest.Name = "btnPrintManifest";
            this.btnPrintManifest.Size = new System.Drawing.Size(225, 33);
            this.btnPrintManifest.TabIndex = 8;
            this.btnPrintManifest.Text = "Print Shipping Manifest";
            this.btnPrintManifest.UseVisualStyleBackColor = false;
            this.btnPrintManifest.Click += new System.EventHandler(this.btnPrintManifest_Click);
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.Location = new System.Drawing.Point(20, 482);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(260, 25);
            this.lblDetailTitle.TabIndex = 9;
            this.lblDetailTitle.Text = "ORDER LINE ITEMS (DETAIL)";
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(20, 512);
            this.dgvOrderDetails.MultiSelect = false;
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.RowHeadersWidth = 51;
            this.dgvOrderDetails.RowTemplate.Height = 24;
            this.dgvOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrderDetails.Size = new System.Drawing.Size(1006, 288);
            this.dgvOrderDetails.TabIndex = 10;
            this.dgvOrderDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderDetails_CellContentClick);
            // 
            // FrmOrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 813);
            this.Controls.Add(this.dgvOrderDetails);
            this.Controls.Add(this.lblDetailTitle);
            this.Controls.Add(this.btnPrintManifest);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.cboNewStatus);
            this.Controls.Add(this.lblChangeStatus);
            this.Controls.Add(this.lblSelectedOrder);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.cboFilterStatus);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblMasterTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmOrderManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Management & Shipping Manifest";
            this.Load += new System.EventHandler(this.FrmOrderManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMasterTitle;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label lblSelectedOrder;
        private System.Windows.Forms.Label lblChangeStatus;
        private System.Windows.Forms.ComboBox cboNewStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnPrintManifest;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
    }
}