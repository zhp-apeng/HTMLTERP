namespace MLTERP
{
    partial class frmFVendorForm
    {
        /// <summary>
        /// ����������������
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// ������������ʹ�õ���Դ��
        /// </summary>
        /// <param name="disposing">���Ӧ�ͷ��й���Դ��Ϊ true������Ϊ false��</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows ������������ɵĴ���

        /// <summary>
        /// �����֧������ķ��� - ��Ҫ
        /// ʹ�ô���༭���޸Ĵ˷��������ݡ�
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFVendorForm));
            this.groupControlDataList = new DevExpress.XtraEditors.GroupControl();
            this.gridControlDetail = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCLSA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCLSB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVendorTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControlQuery = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).BeginInit();
            this.groupControlDataList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).BeginInit();
            this.groupControlQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseIlYesOrNo
            // 
            this.BaseIlYesOrNo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BaseIlYesOrNo.ImageStream")));
            this.BaseIlYesOrNo.Images.SetKeyName(0, "");
            this.BaseIlYesOrNo.Images.SetKeyName(1, "");
            // 
            // BaseIlAll
            // 
            this.BaseIlAll.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BaseIlAll.ImageStream")));
            this.BaseIlAll.Images.SetKeyName(0, "");
            this.BaseIlAll.Images.SetKeyName(1, "");
            this.BaseIlAll.Images.SetKeyName(2, "");
            this.BaseIlAll.Images.SetKeyName(3, "");
            this.BaseIlAll.Images.SetKeyName(4, "");
            this.BaseIlAll.Images.SetKeyName(5, "");
            this.BaseIlAll.Images.SetKeyName(6, "");
            this.BaseIlAll.Images.SetKeyName(7, "");
            this.BaseIlAll.Images.SetKeyName(8, "");
            this.BaseIlAll.Images.SetKeyName(9, "");
            this.BaseIlAll.Images.SetKeyName(10, "");
            this.BaseIlAll.Images.SetKeyName(11, "");
            this.BaseIlAll.Images.SetKeyName(12, "");
            this.BaseIlAll.Images.SetKeyName(13, "");
            this.BaseIlAll.Images.SetKeyName(14, "");
            this.BaseIlAll.Images.SetKeyName(15, "");
            this.BaseIlAll.Images.SetKeyName(16, "");
            this.BaseIlAll.Images.SetKeyName(17, "");
            this.BaseIlAll.Images.SetKeyName(18, "");
            this.BaseIlAll.Images.SetKeyName(19, "");
            this.BaseIlAll.Images.SetKeyName(20, "");
            this.BaseIlAll.Images.SetKeyName(21, "");
            this.BaseIlAll.Images.SetKeyName(22, "");
            this.BaseIlAll.Images.SetKeyName(23, "");
            this.BaseIlAll.Images.SetKeyName(24, "");
            this.BaseIlAll.Images.SetKeyName(25, "");
            this.BaseIlAll.Images.SetKeyName(26, "");
            this.BaseIlAll.Images.SetKeyName(27, "");
            this.BaseIlAll.Images.SetKeyName(28, "");
            this.BaseIlAll.Images.SetKeyName(29, "");
            this.BaseIlAll.Images.SetKeyName(30, "");
            this.BaseIlAll.Images.SetKeyName(31, "");
            this.BaseIlAll.Images.SetKeyName(32, "");
            this.BaseIlAll.Images.SetKeyName(33, "");
            this.BaseIlAll.Images.SetKeyName(34, "");
            // 
            // groupControlDataList
            // 
            this.groupControlDataList.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlDataList.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlDataList.Controls.Add(this.gridControlDetail);
            this.groupControlDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDataList.Location = new System.Drawing.Point(0, 73);
            this.groupControlDataList.Name = "groupControlDataList";
            this.groupControlDataList.Size = new System.Drawing.Size(870, 365);
            this.groupControlDataList.TabIndex = 33;
            this.groupControlDataList.Text = "�����б�";
            // 
            // gridControlDetail
            // 
            this.gridControlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.gridControlDetail.EmbeddedNavigator.Name = "";
            this.gridControlDetail.Location = new System.Drawing.Point(2, 17);
            this.gridControlDetail.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.gridControlDetail.MainView = this.gridView1;
            this.gridControlDetail.Name = "gridControlDetail";
            this.gridControlDetail.Size = new System.Drawing.Size(866, 345);
            this.gridControlDetail.TabIndex = 33;
            this.gridControlDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnID,
            this.gridColumnName,
            this.gridColumnCLSA,
            this.gridColumnCLSB,
            this.gridColumnVendorTypeID,
            this.gridColumnRemark,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControlDetail;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            this.gridColumnID.Visible = true;
            this.gridColumnID.VisibleIndex = 0;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "����";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            // 
            // gridColumnCLSA
            // 
            this.gridColumnCLSA.Caption = "����";
            this.gridColumnCLSA.FieldName = "CLSA";
            this.gridColumnCLSA.Name = "gridColumnCLSA";
            this.gridColumnCLSA.Visible = true;
            this.gridColumnCLSA.VisibleIndex = 2;
            // 
            // gridColumnCLSB
            // 
            this.gridColumnCLSB.Caption = "�ֶ���";
            this.gridColumnCLSB.FieldName = "CLSB";
            this.gridColumnCLSB.Name = "gridColumnCLSB";
            this.gridColumnCLSB.Visible = true;
            this.gridColumnCLSB.VisibleIndex = 3;
            // 
            // gridColumnVendorTypeID
            // 
            this.gridColumnVendorTypeID.Caption = "�ͻ�����";
            this.gridColumnVendorTypeID.FieldName = "VendorTypeID";
            this.gridColumnVendorTypeID.Name = "gridColumnVendorTypeID";
            this.gridColumnVendorTypeID.Visible = true;
            this.gridColumnVendorTypeID.VisibleIndex = 4;
            // 
            // gridColumnRemark
            // 
            this.gridColumnRemark.Caption = "��ע";
            this.gridColumnRemark.FieldName = "Remark";
            this.gridColumnRemark.Name = "gridColumnRemark";
            this.gridColumnRemark.Visible = true;
            this.gridColumnRemark.VisibleIndex = 5;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "�ͻ�����";
            this.gridColumn1.FieldName = "VendorTypeName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // groupControlQuery
            // 
            this.groupControlQuery.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupControlQuery.AppearanceCaption.Options.UseForeColor = true;
            this.groupControlQuery.Controls.Add(this.label2);
            this.groupControlQuery.Controls.Add(this.txtName);
            this.groupControlQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControlQuery.Location = new System.Drawing.Point(0, 25);
            this.groupControlQuery.Name = "groupControlQuery";
            this.groupControlQuery.Size = new System.Drawing.Size(870, 48);
            this.groupControlQuery.TabIndex = 32;
            this.groupControlQuery.Text = "��ѯ����";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 269;
            this.label2.Text = "����";
            // 
            // txtName
            // 
            this.txtName.EditValue = "";
            this.txtName.Location = new System.Drawing.Point(70, 19);
            this.txtName.Name = "txtName";
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.txtName.Size = new System.Drawing.Size(90, 23);
            this.txtName.TabIndex = 1;
            // 
            // frmFVendorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 438);
            this.Controls.Add(this.groupControlDataList);
            this.Controls.Add(this.groupControlQuery);
            this.Name = "frmFVendorForm";
            this.Text = "frmFVendorForm";
            this.Controls.SetChildIndex(this.BaseFocusLabelTemp, 0);
            this.Controls.SetChildIndex(this.groupControlQuery, 0);
            this.Controls.SetChildIndex(this.groupControlDataList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HTBaseUIDBRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDataList)).EndInit();
            this.groupControlDataList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlQuery)).EndInit();
            this.groupControlQuery.ResumeLayout(false);
            this.groupControlQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlDataList;
        private DevExpress.XtraGrid.GridControl gridControlDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCLSA; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnCLSB; 
  		private DevExpress.XtraGrid.Columns.GridColumn gridColumnVendorTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRemark; 
  		
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox drpGridYesOrNo;
        private DevExpress.XtraEditors.GroupControl groupControlQuery;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label2;
    }
}