namespace WinFormUI
{
    partial class FrmDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabDashboard = new System.Windows.Forms.TabControl();
            this.tabLowStock = new System.Windows.Forms.TabPage();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.btnFilterLowStock = new System.Windows.Forms.Button();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.numThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.tabBestSelling = new System.Windows.Forms.TabPage();
            this.splitBestSelling = new System.Windows.Forms.SplitContainer();
            this.dgvBestSelling = new System.Windows.Forms.DataGridView();
            this.chartBestSelling = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnFilterBestSelling = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.chkUseDateFilter = new System.Windows.Forms.CheckBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.tabAgentRevenue = new System.Windows.Forms.TabPage();
            this.dgvAgentRevenue = new System.Windows.Forms.DataGridView();
            this.lblTotalRevenueSummary = new System.Windows.Forms.Label();
            this.btnFilterRevenue = new System.Windows.Forms.Button();
            this.cboAgents = new System.Windows.Forms.ComboBox();
            this.lblSelectAgent = new System.Windows.Forms.Label();
            this.tabDashboard.SuspendLayout();
            this.tabLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).BeginInit();
            this.tabBestSelling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBestSelling)).BeginInit();
            this.splitBestSelling.Panel1.SuspendLayout();
            this.splitBestSelling.Panel2.SuspendLayout();
            this.splitBestSelling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSelling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBestSelling)).BeginInit();
            this.tabAgentRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgentRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDashboard
            // 
            this.tabDashboard.Controls.Add(this.tabLowStock);
            this.tabDashboard.Controls.Add(this.tabBestSelling);
            this.tabDashboard.Controls.Add(this.tabAgentRevenue);
            this.tabDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDashboard.Location = new System.Drawing.Point(0, 0);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.SelectedIndex = 0;
            this.tabDashboard.Size = new System.Drawing.Size(1046, 813);
            this.tabDashboard.TabIndex = 0;
            // 
            // tabLowStock
            // 
            this.tabLowStock.Controls.Add(this.dgvLowStock);
            this.tabLowStock.Controls.Add(this.btnFilterLowStock);
            this.tabLowStock.Controls.Add(this.lblLowStockCount);
            this.tabLowStock.Controls.Add(this.numThreshold);
            this.tabLowStock.Controls.Add(this.lblThreshold);
            this.tabLowStock.Location = new System.Drawing.Point(4, 29);
            this.tabLowStock.Name = "tabLowStock";
            this.tabLowStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabLowStock.Size = new System.Drawing.Size(1038, 780);
            this.tabLowStock.TabIndex = 0;
            this.tabLowStock.Text = "Low-Stock Warning";
            this.tabLowStock.UseVisualStyleBackColor = true;
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.AllowUserToAddRows = false;
            this.dgvLowStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Location = new System.Drawing.Point(20, 65);
            this.dgvLowStock.MultiSelect = false;
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.ReadOnly = true;
            this.dgvLowStock.RowHeadersWidth = 51;
            this.dgvLowStock.RowTemplate.Height = 24;
            this.dgvLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLowStock.Size = new System.Drawing.Size(996, 705);
            this.dgvLowStock.TabIndex = 4;
            this.dgvLowStock.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLowStock_CellContentClick);
            // 
            // btnFilterLowStock
            // 
            this.btnFilterLowStock.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFilterLowStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterLowStock.ForeColor = System.Drawing.Color.White;
            this.btnFilterLowStock.Location = new System.Drawing.Point(295, 16);
            this.btnFilterLowStock.Name = "btnFilterLowStock";
            this.btnFilterLowStock.Size = new System.Drawing.Size(110, 34);
            this.btnFilterLowStock.TabIndex = 3;
            this.btnFilterLowStock.Text = "Filter";
            this.btnFilterLowStock.UseVisualStyleBackColor = false;
            this.btnFilterLowStock.Click += new System.EventHandler(this.btnFilterLowStock_Click);
            // 
            // lblLowStockCount
            // 
            this.lblLowStockCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLowStockCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLowStockCount.ForeColor = System.Drawing.Color.Firebrick;
            this.lblLowStockCount.Location = new System.Drawing.Point(720, 22);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new System.Drawing.Size(295, 23);
            this.lblLowStockCount.TabIndex = 2;
            this.lblLowStockCount.Text = "Total Low-Stock Items: 0";
            this.lblLowStockCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numThreshold
            // 
            this.numThreshold.Location = new System.Drawing.Point(180, 19);
            this.numThreshold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numThreshold.Name = "numThreshold";
            this.numThreshold.Size = new System.Drawing.Size(100, 27);
            this.numThreshold.TabIndex = 1;
            this.numThreshold.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblThreshold
            // 
            this.lblThreshold.Location = new System.Drawing.Point(20, 22);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(155, 23);
            this.lblThreshold.TabIndex = 0;
            this.lblThreshold.Text = "Stock Threshold (<=):";
            // 
            // tabBestSelling
            // 
            this.tabBestSelling.Controls.Add(this.splitBestSelling);
            this.tabBestSelling.Controls.Add(this.btnFilterBestSelling);
            this.tabBestSelling.Controls.Add(this.dtpTo);
            this.tabBestSelling.Controls.Add(this.dtpFrom);
            this.tabBestSelling.Controls.Add(this.chkUseDateFilter);
            this.tabBestSelling.Controls.Add(this.lblTo);
            this.tabBestSelling.Controls.Add(this.lblFrom);
            this.tabBestSelling.Location = new System.Drawing.Point(4, 29);
            this.tabBestSelling.Name = "tabBestSelling";
            this.tabBestSelling.Padding = new System.Windows.Forms.Padding(3);
            this.tabBestSelling.Size = new System.Drawing.Size(1038, 780);
            this.tabBestSelling.TabIndex = 1;
            this.tabBestSelling.Text = "Best-Selling Items";
            this.tabBestSelling.UseVisualStyleBackColor = true;
            // 
            // splitBestSelling
            // 
            this.splitBestSelling.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitBestSelling.Location = new System.Drawing.Point(20, 65);
            this.splitBestSelling.Name = "splitBestSelling";
            // 
            // splitBestSelling.Panel1
            // 
            this.splitBestSelling.Panel1.Controls.Add(this.dgvBestSelling);
            // 
            // splitBestSelling.Panel2
            // 
            this.splitBestSelling.Panel2.Controls.Add(this.chartBestSelling);
            this.splitBestSelling.Size = new System.Drawing.Size(996, 705);
            this.splitBestSelling.SplitterDistance = 495;
            this.splitBestSelling.SplitterWidth = 6;
            this.splitBestSelling.TabIndex = 6;
            this.splitBestSelling.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // dgvBestSelling
            // 
            this.dgvBestSelling.AllowUserToAddRows = false;
            this.dgvBestSelling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBestSelling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBestSelling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBestSelling.Location = new System.Drawing.Point(0, 0);
            this.dgvBestSelling.Name = "dgvBestSelling";
            this.dgvBestSelling.ReadOnly = true;
            this.dgvBestSelling.RowHeadersWidth = 51;
            this.dgvBestSelling.RowTemplate.Height = 24;
            this.dgvBestSelling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBestSelling.Size = new System.Drawing.Size(495, 705);
            this.dgvBestSelling.TabIndex = 0;
            // 
            // chartBestSelling
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBestSelling.ChartAreas.Add(chartArea1);
            this.chartBestSelling.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartBestSelling.Legends.Add(legend1);
            this.chartBestSelling.Location = new System.Drawing.Point(0, 0);
            this.chartBestSelling.Name = "chartBestSelling";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartBestSelling.Series.Add(series1);
            this.chartBestSelling.Size = new System.Drawing.Size(495, 705);
            this.chartBestSelling.TabIndex = 0;
            this.chartBestSelling.Text = "chart1";
            // 
            // btnFilterBestSelling
            // 
            this.btnFilterBestSelling.BackColor = System.Drawing.Color.SeaGreen;
            this.btnFilterBestSelling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterBestSelling.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterBestSelling.ForeColor = System.Drawing.Color.White;
            this.btnFilterBestSelling.Location = new System.Drawing.Point(590, 16);
            this.btnFilterBestSelling.Name = "btnFilterBestSelling";
            this.btnFilterBestSelling.Size = new System.Drawing.Size(120, 34);
            this.btnFilterBestSelling.TabIndex = 5;
            this.btnFilterBestSelling.Text = "Analyze";
            this.btnFilterBestSelling.UseVisualStyleBackColor = false;
            this.btnFilterBestSelling.Click += new System.EventHandler(this.btnFilterBestSelling_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Enabled = false;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(435, 19);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(135, 27);
            this.dtpTo.TabIndex = 4;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Enabled = false;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(255, 19);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(135, 27);
            this.dtpFrom.TabIndex = 3;
            // 
            // chkUseDateFilter
            // 
            this.chkUseDateFilter.Location = new System.Drawing.Point(20, 21);
            this.chkUseDateFilter.Name = "chkUseDateFilter";
            this.chkUseDateFilter.Size = new System.Drawing.Size(175, 25);
            this.chkUseDateFilter.TabIndex = 2;
            this.chkUseDateFilter.Text = "Filter by Date Range";
            this.chkUseDateFilter.UseVisualStyleBackColor = true;
            this.chkUseDateFilter.CheckedChanged += new System.EventHandler(this.chkUseDateFilter_CheckedChanged);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(400, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(33, 20);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(205, 22);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(53, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabAgentRevenue
            // 
            this.tabAgentRevenue.Controls.Add(this.dgvAgentRevenue);
            this.tabAgentRevenue.Controls.Add(this.lblTotalRevenueSummary);
            this.tabAgentRevenue.Controls.Add(this.btnFilterRevenue);
            this.tabAgentRevenue.Controls.Add(this.cboAgents);
            this.tabAgentRevenue.Controls.Add(this.lblSelectAgent);
            this.tabAgentRevenue.Location = new System.Drawing.Point(4, 29);
            this.tabAgentRevenue.Name = "tabAgentRevenue";
            this.tabAgentRevenue.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgentRevenue.Size = new System.Drawing.Size(1038, 780);
            this.tabAgentRevenue.TabIndex = 2;
            this.tabAgentRevenue.Text = "Revenue by Agent";
            this.tabAgentRevenue.UseVisualStyleBackColor = true;
            // 
            // dgvAgentRevenue
            // 
            this.dgvAgentRevenue.AllowUserToAddRows = false;
            this.dgvAgentRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAgentRevenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgentRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgentRevenue.Location = new System.Drawing.Point(20, 65);
            this.dgvAgentRevenue.MultiSelect = false;
            this.dgvAgentRevenue.Name = "dgvAgentRevenue";
            this.dgvAgentRevenue.ReadOnly = true;
            this.dgvAgentRevenue.RowHeadersWidth = 51;
            this.dgvAgentRevenue.RowTemplate.Height = 24;
            this.dgvAgentRevenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgentRevenue.Size = new System.Drawing.Size(996, 705);
            this.dgvAgentRevenue.TabIndex = 4;
            // 
            // lblTotalRevenueSummary
            // 
            this.lblTotalRevenueSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRevenueSummary.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenueSummary.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalRevenueSummary.Location = new System.Drawing.Point(615, 21);
            this.lblTotalRevenueSummary.Name = "lblTotalRevenueSummary";
            this.lblTotalRevenueSummary.Size = new System.Drawing.Size(400, 25);
            this.lblTotalRevenueSummary.TabIndex = 3;
            this.lblTotalRevenueSummary.Text = "Total Revenue: 0 VND";
            this.lblTotalRevenueSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFilterRevenue
            // 
            this.btnFilterRevenue.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFilterRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterRevenue.ForeColor = System.Drawing.Color.White;
            this.btnFilterRevenue.Location = new System.Drawing.Point(385, 16);
            this.btnFilterRevenue.Name = "btnFilterRevenue";
            this.btnFilterRevenue.Size = new System.Drawing.Size(155, 34);
            this.btnFilterRevenue.TabIndex = 2;
            this.btnFilterRevenue.Text = "Calculate Revenue";
            this.btnFilterRevenue.UseVisualStyleBackColor = false;
            this.btnFilterRevenue.Click += new System.EventHandler(this.btnFilterRevenue_Click);
            // 
            // cboAgents
            // 
            this.cboAgents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgents.FormattingEnabled = true;
            this.cboAgents.Location = new System.Drawing.Point(131, 19);
            this.cboAgents.Name = "cboAgents";
            this.cboAgents.Size = new System.Drawing.Size(250, 28);
            this.cboAgents.TabIndex = 1;
            this.cboAgents.SelectedIndexChanged += new System.EventHandler(this.cboAgents_SelectedIndexChanged);
            // 
            // lblSelectAgent
            // 
            this.lblSelectAgent.AutoSize = true;
            this.lblSelectAgent.Location = new System.Drawing.Point(20, 22);
            this.lblSelectAgent.Name = "lblSelectAgent";
            this.lblSelectAgent.Size = new System.Drawing.Size(109, 20);
            this.lblSelectAgent.TabIndex = 0;
            this.lblSelectAgent.Text = "Select Agent:";
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 813);
            this.Controls.Add(this.tabDashboard);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Executive Sales & Inventory Dashboard";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.tabDashboard.ResumeLayout(false);
            this.tabLowStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).EndInit();
            this.tabBestSelling.ResumeLayout(false);
            this.tabBestSelling.PerformLayout();
            this.splitBestSelling.Panel1.ResumeLayout(false);
            this.splitBestSelling.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBestSelling)).EndInit();
            this.splitBestSelling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSelling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBestSelling)).EndInit();
            this.tabAgentRevenue.ResumeLayout(false);
            this.tabAgentRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgentRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDashboard;
        private System.Windows.Forms.TabPage tabLowStock;
        private System.Windows.Forms.TabPage tabBestSelling;
        private System.Windows.Forms.TabPage tabAgentRevenue;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.Button btnFilterLowStock;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.NumericUpDown numThreshold;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.CheckBox chkUseDateFilter;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnFilterBestSelling;
        private System.Windows.Forms.SplitContainer splitBestSelling;
        private System.Windows.Forms.DataGridView dgvBestSelling;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBestSelling;
        private System.Windows.Forms.DataGridView dgvAgentRevenue;
        private System.Windows.Forms.Label lblTotalRevenueSummary;
        private System.Windows.Forms.Button btnFilterRevenue;
        private System.Windows.Forms.ComboBox cboAgents;
        private System.Windows.Forms.Label lblSelectAgent;
    }
}