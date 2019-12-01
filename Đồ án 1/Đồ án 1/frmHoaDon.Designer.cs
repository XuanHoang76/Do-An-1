namespace Đồ_án_1
{
    partial class frmHoaDon
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.QLHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLXeDataSet = new Đồ_án_1.QLXeDataSet();
            this.QLKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLXeDataSet1 = new Đồ_án_1.QLXeDataSet1();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLHoaDonTableAdapter = new Đồ_án_1.QLXeDataSetTableAdapters.QLHoaDonTableAdapter();
            this.QLKhachHangTableAdapter = new Đồ_án_1.QLXeDataSet1TableAdapters.QLKhachHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QLHoaDonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLXeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLKhachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLXeDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // QLHoaDonBindingSource
            // 
            this.QLHoaDonBindingSource.DataMember = "QLHoaDon";
            this.QLHoaDonBindingSource.DataSource = this.QLXeDataSet;
            // 
            // QLXeDataSet
            // 
            this.QLXeDataSet.DataSetName = "QLXeDataSet";
            this.QLXeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // QLKhachHangBindingSource
            // 
            this.QLKhachHangBindingSource.DataMember = "QLKhachHang";
            this.QLKhachHangBindingSource.DataSource = this.QLXeDataSet1;
            // 
            // QLXeDataSet1
            // 
            this.QLXeDataSet1.DataSetName = "QLXeDataSet1";
            this.QLXeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "HoaDon";
            reportDataSource1.Value = this.QLHoaDonBindingSource;
            reportDataSource2.Name = "KhachHang";
            reportDataSource2.Value = this.QLKhachHangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Đồ_án_1.HoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(523, 509);
            this.reportViewer1.TabIndex = 0;
            // 
            // QLHoaDonTableAdapter
            // 
            this.QLHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // QLKhachHangTableAdapter
            // 
            this.QLKhachHangTableAdapter.ClearBeforeFill = true;
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 509);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmHoaDon";
            this.Text = "frmHoaDon";
            this.Load += new System.EventHandler(this.frmHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLHoaDonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLXeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLKhachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLXeDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource QLHoaDonBindingSource;
        private QLXeDataSet QLXeDataSet;
        private System.Windows.Forms.BindingSource QLKhachHangBindingSource;
        private QLXeDataSet1 QLXeDataSet1;
        private QLXeDataSetTableAdapters.QLHoaDonTableAdapter QLHoaDonTableAdapter;
        private QLXeDataSet1TableAdapters.QLKhachHangTableAdapter QLKhachHangTableAdapter;
    }
}