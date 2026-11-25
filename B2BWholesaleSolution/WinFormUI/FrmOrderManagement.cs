using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Services;
using DAL;
using WinFormUI.Utils;

namespace WinFormUI
{
    public partial class FrmOrderManagement : Form
    {
        private readonly OrderService _orderService;
        private List<Order> _allOrdersCache;
        private int _selectedOrderId = 0;

        public FrmOrderManagement()
        {
            InitializeComponent();
            _orderService = new OrderService();
        }

        private void FrmOrderManagement_Load(object sender, EventArgs e)
        {
            if (cboFilterStatus.Items.Count == 0)
            {
                cboFilterStatus.Items.AddRange(new object[] { "All", "Pending", "Shipped", "Delivered", "Cancelled" });
            }
            cboFilterStatus.SelectedIndex = 0; // Default to "All"

            LoadOrdersData();
        }

        private void LoadOrdersData()
        {
            try
            {
                _allOrdersCache = _orderService.GetAllOrders();
                ApplyStatusFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "System Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyStatusFilter()
        {
            if (_allOrdersCache == null) return;

            string selectedStatus = cboFilterStatus.SelectedItem?.ToString() ?? "All";

            var filteredList = selectedStatus == "All"
                ? _allOrdersCache
                : _allOrdersCache.Where(o => o.OrderStatus == selectedStatus).ToList();

            var masterView = filteredList.Select(o => new
            {
                OrderID = o.OrderID,
                OrderDate = o.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                AgentName = o.Agent != null ? o.Agent.AgentName : "Unknown Agent",
                OrderStatus = o.OrderStatus,
                TotalAmount = _orderService.CalculateOrderTotal(o.OrderID)
            }).ToList();

            dgvOrders.DataSource = masterView;

            if (dgvOrders.Columns["TotalAmount"] != null)
            {
                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (masterView.Count == 0)
            {
                _selectedOrderId = 0;
                lblSelectedOrder.Text = "Selected Order: None";
                dgvOrderDetails.DataSource = null;
            }

            SelectCurrentOrder();
        }


        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.CurrentRow == null || dgvOrders.CurrentRow.Index < 0)
                return;

            var cellValue = dgvOrders.CurrentRow.Cells["OrderID"].Value;
            if (cellValue == null) return;

            _selectedOrderId = Convert.ToInt32(cellValue);
            string currentStatus = dgvOrders.CurrentRow.Cells["OrderStatus"].Value?.ToString();

            lblSelectedOrder.Text = $"Selected Order: #{_selectedOrderId}";
            cboNewStatus.SelectedItem = currentStatus;

            LoadOrderDetails(_selectedOrderId);
        }

        private void LoadOrderDetails(int orderId)
        {
            try
            {
                var order = _orderService.GetOrderWithDetails(orderId);
                if (order?.OrderDetails == null)
                {
                    dgvOrderDetails.DataSource = null;
                    return;
                }

                var detailView = order.OrderDetails.Select(d => new
                {
                    ItemID = d.ItemID,
                    ItemName = d.Item != null ? d.Item.ItemName : "N/A",
                    Size = d.Item != null ? d.Item.Size : "",
                    Quantity = d.Quantity,
                    UnitPrice = d.Item != null ? d.Item.Price : 0m,
                    UnitAmount = d.UnitAmount
                }).ToList();

                dgvOrderDetails.DataSource = detailView;

                if (dgvOrderDetails.Columns["UnitPrice"] != null)
                {
                    dgvOrderDetails.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
                    dgvOrderDetails.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (dgvOrderDetails.Columns["UnitAmount"] != null)
                {
                    dgvOrderDetails.Columns["UnitAmount"].DefaultCellStyle.Format = "N0";
                    dgvOrderDetails.Columns["UnitAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId <= 0)
            {
                MessageBox.Show("Please select an order from the list.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNewStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a new status.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newStatus = cboNewStatus.SelectedItem.ToString();

            try
            {
                _orderService.UpdateOrderStatus(_selectedOrderId, newStatus);
                MessageBox.Show($"Order #{_selectedOrderId} status updated to '{newStatus}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int keepSelectedId = _selectedOrderId;
                LoadOrdersData();

                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (Convert.ToInt32(row.Cells["OrderID"].Value) == keepSelectedId)
                    {
                        row.Selected = true;
                        dgvOrders.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Operation", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintManifest_Click(object sender, EventArgs e)
        {
            if (_selectedOrderId <= 0)
            {
                MessageBox.Show("Please select an order to print the shipping manifest.", "Notification", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var manifestData = _orderService.GetShippingManifestData(_selectedOrderId);
                if (manifestData == null || manifestData.Count == 0)
                {
                    MessageBox.Show(
                        "The order have not had detail information",
                        "Notification",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var frmReport = new FrmReportViewer(manifestData))
                    frmReport.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting Shipping Manifest: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboFilterStatus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ApplyStatusFilter();
        }
        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectCurrentOrder();
            }
        }

        private void SelectCurrentOrder()
        {
            if (dgvOrders.CurrentRow == null ||
                dgvOrders.CurrentRow.Index < 0)
                return;

            var idCell = dgvOrders.CurrentRow.Cells["OrderID"]?.Value;
            if (idCell == null) return;

            _selectedOrderId = Convert.ToInt32(idCell);
            string currentStatus = dgvOrders.CurrentRow.Cells["OrderStatus"]
                ?.Value?.ToString();

            lblSelectedOrder.Text = $"Selected Order: #{_selectedOrderId}";
            if (!string.IsNullOrEmpty(currentStatus))
            {
                cboNewStatus.SelectedItem = currentStatus;
            }

            LoadOrderDetails(_selectedOrderId);
        }

        private void cboNewStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSelectedOrder_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
