using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttSoft.FrameFunc;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.DataCtl;
using HttSoft.MLTERP.Sys;
using HttSoft.WinUIBase;
using DevComponents.DotNetBar;
using DevExpress.XtraGrid.Views.Base;

namespace MLTERP
{
    /// <summary>
    /// ���ܣ�����ⱨ��
    /// 
    /// </summary>
    public partial class frmPiBuWHInOut : frmAPBaseUIRpt
    {
        #region ȫ�ֱ���
        //���߳�
        BackgroundWorker work;
        //ʱ��ؼ�
        System.Windows.Forms.Timer timer = new Timer();
        //GridView���õ�Table
        DataTable GridView1Table = new DataTable();
        //ʱ��
        public int StartM { get; set; }
        #endregion
        public frmPiBuWHInOut()
        {
            InitializeComponent();
        }

        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtOrderDateS.DateTime) + " AND " + SysString.ToDBString(txtOrderDateE.DateTime);
            }
            if (SysConvert.ToString(drpVendorID.EditValue) != string.Empty)
            {
                tempStr += " AND VendorID=" + SysString.ToDBString(drpVendorID.EditValue.ToString());
            }
            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }
            if (txtBatch.Text.Trim() != string.Empty)
            {
                tempStr += " AND Batch=" + SysString.ToDBString(txtBatch.Text.Trim());
            }

            if (txtJarNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtJarNum.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }

            if (txtItemModel.Text.Trim() != "")
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if (SysConvert.ToString(drpSaleOPID.EditValue) != string.Empty)
            {
                tempStr += " AND SaleOPID=" + SysString.ToDBString(drpSaleOPID.EditValue.ToString());
            }
            tempStr += " AND WHID IN (SELECT WHID FROM WH_WH WHERE WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(this.FormListAID) + "))";

            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            if (!work.IsBusy)
            {
                timer1.Start();
                work.RunWorkerAsync();
            }
        }
        /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            //BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            this.HTDataDtsAttach = new DevExpress.XtraGrid.Views.Grid.GridView[] { gridView2 };
            this.IsPostBack = false;
            Common.BindVendor(drpVendorID, new int[] { (int)EnumVendorType.�ͻ�, (int)EnumVendorType.��Ӧ��, (int)EnumVendorType.Ⱦ��, (int)EnumVendorType.�ӹ���, (int)EnumVendorType.֯��, (int)EnumVendorType.�����ӹ��� }, true);
            new VendorProc(drpVendorID);
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            Common.BindSubType(drpSubType, new int[] { this.FormListAID, this.FormListAID + 1 }, true);
            Common.BindOP(drpSaleOPID, true);
            work = new BackgroundWorker();
            work.DoWork += new DoWorkEventHandler(work_DoWork);
            work.RunWorkerCompleted += new RunWorkerCompletedEventHandler(work_RunWorkerCompleted);
            gridViewBaseRowChangedA1 += new gridViewBaseRowChangedA(gridViewRowChanged1);//��GridView1�¼�
            gridViewBindEventA1(gridView1);
        }

        #endregion
        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            return entity;
        }
        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="sender"></param>
        public override void gridViewRowChanged1(object sender)
        {
            try
            {
                this.BaseFocusLabel.Focus();
                ColumnView view = sender as ColumnView;
                int DID = SysConvert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "DtsID"));

                string sql = string.Empty;
                sql += " SELECT * FROM UV1_WH_PackBox WHERE BoxNo IN ( SELECT BoxNo FROM WH_IOFormDtsPack WHERE CONVERT(VARCHAR,MainID)+','+CONVERT(VARCHAR,Seq)=(SELECT  CONVERT(VARCHAR,MainID)+','+CONVERT(VARCHAR,Seq)  FROM WH_IOFormDts WHERE ID=" + DID + "))";
                DataTable dt = SysUtils.Fill(sql);
                gridView2.GridControl.DataSource = dt;
                gridView2.GridControl.Show();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        #region ������ط���

        /// <summary>
        /// ���ٲ�ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFormNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GetCondtion();
                BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ���ٲ�ѯ(�س�������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    GetCondtion();
                    BindGrid();
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion
        #region ��ѯʱ��
        public override void ToolIniCreateBar()
        {
            base.ToolIniCreateBar();
            this.ToolBarLItemAdd(ToolButtonName.lblFormStatus.ToString(), Color.Red);
        }
        void work_DoWork(object sender, DoWorkEventArgs e)
        {
            IOFormRule rule = new IOFormRule();
            GridView1Table = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1));
        }
        void work_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartM = 0;
            timer1.Stop();
            gridView1.GridControl.DataSource = GridView1Table;
            gridView1.GridControl.Show();
            LabelItem label = this.ToolBarLItemGet(-1, ToolButtonName.lblFormStatus.ToString());
            label.Text = "��ѯ����";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            StartM++;
            LabelItem label = this.ToolBarLItemGet(-1, ToolButtonName.lblFormStatus.ToString());
            label.Text = "��ѯ��ʼ������������Ҫ�����ӣ������ĵȴ����������Ѿ���ʱ" + StartM + "S";
        }
        #endregion
        private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e != null)
            {
                e.Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(SysConvert.ToString(gridView2.GetRowCellValue(e.RowHandle, "ColorStr")));
            }
        }


    }
}