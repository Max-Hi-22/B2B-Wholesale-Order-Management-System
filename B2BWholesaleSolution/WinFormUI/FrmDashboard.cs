using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL.Services;
using DAL;
using DAL.DTOs;

namespace WinFormUI
{
    public partial class FrmDashboard : Form
    {
        private readonly DashboardService _dashboardService;
        private readonly AgentService _agentService;

        public FrmDashboard()
        {
            InitializeComponent();
            _dashboardService = new DashboardService();
            _agentService = new AgentService();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(2026, 10, 1);
            dtpTo.Value = DateTime.Now;

            LoadAgentDropdown();
            LoadLowStockData();
            LoadBestSellingData();
            LoadAgentRevenueData();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        // ==========================================================
        // TAB 1: LOW STOCK ALERT
        // ==========================================================
        private void LoadLowStockData()
        {
            try
            {
                int threshold = (int)numThreshold.Value;
                var lowStockItems = _dashboardService.GetLowStockItems(threshold);

                dgvLowStock.DataSource = lowStockItems.Select(i => new
                {
                    i.ItemID,
                    i.ItemName,
                    i.Size,
                    i.Price,
                    i.StockQuantity
                }).ToList();

                if (dgvLowStock.Columns["Price"] != null)
                    dgvLowStock.Columns["Price"].DefaultCellStyle.Format = "N0";

                lblLowStockCount.Text = $"Warning: {lowStockItems.Count} item(s) " +
                    $"at or below {threshold} units.";
                lblLowStockCount.ForeColor = lowStockItems.Count > 0 ? Color.Firebrick : Color.SeaGreen;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loaded inventory data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterLowStock_Click(object sender, EventArgs e)
        {
            LoadLowStockData();
        }

        // mark alert region by color
        private void dgvLowStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvLowStock.Rows[e.RowIndex];
            if (row.Cells["StockQuantity"].Value != null &&
                int.TryParse(row.Cells["StockQuantity"].Value.ToString(), out int stock))
            {
                if (stock <= 5)
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                }
            }
        }

        // ==========================================================
        // TAB 2: BEST-SELLING ITEMS
        // ==========================================================
        private void chkUseDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Enabled = chkUseDateFilter.Checked;
            dtpTo.Enabled = chkUseDateFilter.Checked;
        }

        private void LoadBestSellingData()
        {
            try
            {
                DateTime? fromDate = chkUseDateFilter.Checked
                    ? (DateTime?)dtpFrom.Value : null;
                DateTime? toDate = chkUseDateFilter.Checked
                    ? (DateTime?)dtpTo.Value : null;

                if (fromDate.HasValue &&
                    toDate.HasValue &&
                    fromDate.Value.Date > toDate.Value.Date)
                {
                    MessageBox.Show("Start day must be less than or equal end day."
                        , "Error at interval time",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var bestSellingList = _dashboardService.GetBestSellingItems(fromDate, toDate);
                dgvBestSelling.DataSource = bestSellingList;

                if (dgvBestSelling.Columns["TotalRevenue"] != null)
                    dgvBestSelling.Columns["TotalRevenue"].DefaultCellStyle.Format = "N0";

                RenderBestSellingChart(bestSellingList.Take(5).ToList());
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message, "Product Statistics Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderBestSellingChart(List<BestSellingItemDTO> topItems)
        {
            chartBestSelling.Series.Clear();
            chartBestSelling.Titles.Clear();
            chartBestSelling.Titles.Add("Top 5 Best-Selling Products (Units Sold)");

            var series = new Series("Units Sold")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = Color.SteelBlue
            };

            foreach (var item in topItems)
            {
                string shortName = item.ItemName.Length > 18
                    ? item.ItemName.Substring(0, 15) + "..."
                    : item.ItemName;
                series.Points.AddXY($"{shortName} ({item.Size})", item.TotalQuantitySold);
            }

            chartBestSelling.Series.Add(series);
            chartBestSelling.ChartAreas[0].AxisX.Interval = 1;
            chartBestSelling.ChartAreas[0].AxisX.LabelStyle.Angle = -20;
        }

        private void btnFilterBestSelling_Click(object sender, EventArgs e)
        {
            LoadBestSellingData();
        }

        private void cboAgents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // ==========================================================
        // TAB 3: REVENUE BY SPECIFIC AGENT
        // ==========================================================
        private void LoadAgentDropdown()
        {
            var agents = _agentService.GetAllAgents();

            var dropdownList = new List<Agent>
            {
                new Agent
                {
                    AgentID = 0,
                    AgentName = "-- All Agents --"
                }
            };
            dropdownList.AddRange(agents);

            cboAgents.DataSource = dropdownList;
            cboAgents.DisplayMember = "AgentName";
            cboAgents.ValueMember = "AgentID";
            cboAgents.SelectedIndex = 0;
        }

        private void LoadAgentRevenueData()
        {
            try
            {
                int selectedAgentId = 0;
                if (cboAgents.SelectedValue != null)
                {
                    int.TryParse(cboAgents.SelectedValue.ToString(), out selectedAgentId);
                }

                int? filterId = selectedAgentId > 0 ? (int?)selectedAgentId : null;
                var revenueList = _dashboardService.GetRevenueByAgent(filterId);

                dgvAgentRevenue.DataSource = revenueList;

                if (dgvAgentRevenue.Columns["TotalRevenue"] != null)
                    dgvAgentRevenue.Columns["TotalRevenue"].DefaultCellStyle.Format = "N0";

                decimal grandTotal = revenueList.Sum(r => r.TotalRevenue);
                lblTotalRevenueSummary.Text = $"Total Confirmed Revenue (Shipped & Delivered): {grandTotal:N0} VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Revenue Statistics Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilterRevenue_Click(object sender, EventArgs e)
        {
            LoadAgentRevenueData();
        }
    }
}
