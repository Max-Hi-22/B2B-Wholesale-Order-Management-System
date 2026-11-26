using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Services;
using DAL;

namespace WinFormUI
{
    public partial class FrmItemManagement : Form
    {
        private readonly ItemService _itemService;
        public FrmItemManagement()
        {
            InitializeComponent();
            _itemService = new ItemService();
        }

        private void grpItemInfo_Enter(object sender, EventArgs e)
        {

        }

        private void FrmItemManagement_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void LoadItems(string keyword = "")
        {
            var items = _itemService.SearchItemsByName(keyword);
            dgvItems.DataSource = items.Select(i => new
            {
                i.ItemID,
                i.ItemName,
                i.Size,
                i.Price,
                i.StockQuantity
            }).ToList();
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvItems.Rows[e.RowIndex];
            txtItemId.Text = row.Cells["ItemID"].Value?.ToString();
            txtItemName.Text = row.Cells["ItemName"].Value?.ToString();
            txtSize.Text = row.Cells["Size"].Value?.ToString();
            numPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);
            numStock.Value = Convert.ToDecimal(row.Cells["StockQuantity"].Value ?? 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newItem = new Item
                {
                    ItemName = txtItemName.Text,
                    Size = txtSize.Text,
                    Price = numPrice.Value,
                    StockQuantity = (int)numStock.Value
                };

                _itemService.AddItem(newItem);
                MessageBox.Show("Add new item successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadItems(txtSearch.Text);
                ClearInputs();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearInputs()
        {
            txtItemId.Clear();
            txtItemName.Clear();
            txtSize.Clear();
            numPrice.Value = 0;
            numStock.Value = 0;
            txtItemName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtItemId.Text, out int itemId))
                {
                    MessageBox.Show(
                        "Please choose a product from the below table to update.", "Notification", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var updatedItem = new Item
                {
                    ItemID = itemId,
                    ItemName = txtItemName.Text,
                    Size = txtSize.Text,
                    Price = numPrice.Value,
                    StockQuantity = (int)numStock.Value
                };

                _itemService.UpdateItem(updatedItem);
                MessageBox.Show("Update product & inventory successfully!", "Notification", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadItems(txtSearch.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error updating item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtItemId.Text, out int itemId))
                {
                    MessageBox.Show("Please select a product to delete.", "Notification", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show($"Are you sure you want to delete the product '{txtItemName.Text}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _itemService.DeleteItem(itemId);
                    MessageBox.Show("Product deleted successfully!", "Notification", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadItems();
                    ClearInputs();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot delete product", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadItems(txtSearch.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
    }
}
