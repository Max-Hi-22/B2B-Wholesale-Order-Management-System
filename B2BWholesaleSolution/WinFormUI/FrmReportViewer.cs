using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.DTOs;
using Microsoft.Reporting.WinForms;

namespace WinFormUI
{
    public partial class FrmReportViewer : Form
    {
        private readonly List<ShippingManifestDTO> _manifestData;
        private ReportViewer reportViewr1;

        public FrmReportViewer()
        {
            InitializeComponent();
        }

        public FrmReportViewer(List<ShippingManifestDTO> manifestData)
        {
            InitializeComponent();
            _manifestData = manifestData;

            this.Text = "Shipping Manifest Preview";
            this.Size = new Size(950, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.ReportEmbeddedResource = 
                "WinFormUI.ShippingManifest.rdlc";

            var rds = new ReportDataSource("ManifestDataSet", _manifestData);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            reportViewer1.RefreshReport();
        }
    }
}
