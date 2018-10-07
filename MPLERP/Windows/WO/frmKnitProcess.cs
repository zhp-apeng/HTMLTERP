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
using DevComponents.DotNetBar;
using HttSoft.WinUIBase;

namespace MLTERP
{
    public partial class frmKnitProcess : frmAPBaseUIForm
    {
        public frmKnitProcess()
        {
            InitializeComponent();
        }


        int saveNoLoadCheckDayNum = 0;//δ���رȶ���������ֹ����ʱ�������ϵͳ����

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

            if (chkReqDate.Checked)
            {
                tempStr += " AND ReqDate BETWEEN " + SysString.ToDBString(txtReqDateS.DateTime) + " AND " + SysString.ToDBString(txtReqDateE.DateTime);
            }

            if (txtDyeFactory.Text.Trim() != string.Empty)
            {
                tempStr += " AND DyeFactoryName LIKE " + SysString.ToDBString("%" + txtDyeFactory.Text.Trim() + "%");
            }

            if (drpDyeFactorty.EditValue != string.Empty)
            {
                tempStr += " AND DyeFactorty LIKE " + SysString.ToDBString("%" + drpDyeFactorty.EditValue + "%");
            }

            if (txtItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemCode LIKE " + SysString.ToDBString("%" + txtItemCode.Text.Trim() + "%");
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }
            //if (SysConvert.ToBoolean(ProductParamSet.GetIntValueByID(5430)) && !FParamConfig.LoginHTFlag)//���۶���ҵ��Աֻ�鿴�Լ��ĵĶ���
            //{
            //    tempStr += " AND SaleOPID IN(" + WCommon.GetStructureMemberOPStr() + ")";
            //}

            if (txtGoodsCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND GoodsCode LIKE " + SysString.ToDBString("%" + txtGoodsCode.Text.Trim() + "%");
            }

            if (txtColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
            }

            if (txtColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
            }

            if (txtMWeightS.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight>" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightS.Text.Trim()));
            }

            if (txtMWeightE.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWeight<" + SysString.ToDBString(SysConvert.ToDecimal(txtMWeightE.Text.Trim()));
            }

            if (txtMWidth.Text.Trim() != string.Empty)
            {
                tempStr += " AND MWidth=" + SysString.ToDBString(txtMWidth.Text.Trim());
            }

            if (txtItemName.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemName LIKE " + SysString.ToDBString("%" + txtItemName.Text.Trim() + "%");
            }

            if (txtVColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorNum LIKE " + SysString.ToDBString("%" + txtVColorNum.Text.Trim() + "%");
            }

            if (txtVColorName.Text.Trim() != string.Empty)
            {
                tempStr += " AND VColorName LIKE " + SysString.ToDBString("%" + txtVColorName.Text.Trim() + "%");
            }

            if (chkSubmitFlag.Checked)
            {
                tempStr += " AND SubmitFlag=1";
            }

            if(txtDtsSO.Text.Trim()!=string.Empty)  //��ͬ��ʹ�ôӱ��е�DtsSO
            {
                tempStr += " AND DtsSO LIKE " + SysString.ToDBString("%"+txtDtsSO.Text.Trim()+"%"); ;
            }
            tempStr += " AND ProcessTypeID=2";  //֯��ӹ���
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            FabricProcessRule rule = new FabricProcessRule();
            DataTable dt = rule.RShowDts(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("FormStatusName", "'' FormStatusName"));

            ItemBuyStatusProc.ProcColorStatusName(dt);
            ProcDataSourceQty(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();

            string sql = "SELECT distinct ID  FROM UV1_WO_FabricProcessDts WHERE 1=1";
            sql += HTDataConditionStr;
            dt = SysUtils.Fill(sql);
            lbCount.Text = "�ӹ�������" + dt.Rows.Count.ToString();
            ProcessGrid.SetGridEdit(gridView1, new string[] { "HandleStatus", "HandleStatusDate" }, true);
          
        }

        
        /// <summary>
        /// ɾ��
        /// </summary>
        public override void EntityDelete()
        {
            FabricProcessDtsRule rule = new FabricProcessDtsRule();
            FabricProcess entity = EntityGet();
            rule.RDelete(entity);
        }
        
         /// <summary>
        /// ���ö�λ���ݼ�״̬
        /// </summary>
        /// <param name="p_ID">ID</param>
        public override void SetPosStatus(int p_ID)
        {
            int tempID = HTDataID;
            BindGrid();
            ProcessGrid.GridViewFocus(gridView1, new string[] { "ID" }, new string[] { tempID.ToString() });
        }
        

        /// <summary>
        /// ���ݳ�ʼ��(��д�������󶨿��ơ���ʼ���������Ե�)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Buy_ItemBuyForm";
            this.HTDataList = gridView1;
            this.HTQryContainer = groupControlQuery;
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            txtReqDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtReqDateE.DateTime = DateTime.Now.Date;
            txtBuyMakeDateS.DateTime = DateTime.Now.AddMonths(-3).Date;
            txtBuyMakeDateE.DateTime = DateTime.Now.Date;
            Common.BindVendor(drpDyeFactorty, new int[] { (int)EnumVendorType.֯��, (int)EnumVendorType.�����ӹ��� }, true);
            //drpDyeFactorty.Tag = (int)EnumVendorType.����;
            new VendorProc(drpDyeFactorty);

            Common.BindVendor(drpGridDVendorID, new int[] { (int)EnumVendorType.�ͻ� }, true);

            if (ItemBuyStatusProc.ColorIniFlag)
            {
                ucStatusBarStand1.UCDataSource = ItemBuyStatusProc.ColorStatusDt;
                ucStatusBarStand1.UCAct();
            }
            Common.BindCLS(drpGridHandleStatus, "WO_FabricProcess", "KnitHandleStatus", true);
            this.ToolBarItemAdd(28, "btnSave", "����", false, btnSaveHandleStatus_Click);

            ParamSetRule psrule = new ParamSetRule();
            saveNoLoadCheckDayNum = psrule.RShowIntByCode((int)ParamSetEnum.δ�������ݱȶ�����);
            //this.ToolBarItemAdd(32, "btnUpdateOrderStatus", "�޸ĺ�ͬ״̬", true, UpdateOrderStatusToolStripMenuItem_Click, eShortcut.F9);
        }

        /// <summary>
        /// �޸ĺ�ͬ״̬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateOrderStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��3))
                {
                    this.ShowMessage("û�д�Ȩ�ޣ�����ϵ����Ա");
                    return;
                }
                frmUpdateBuyFormStatus frm = new frmUpdateBuyFormStatus();
                frm.StartPosition = FormStartPosition.Manual;
                frm.Location = new Point(580, 280);
                frm.ID = SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                frm.OrderStatusName = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "FormStatusName"));
                frm.ShowDialog(); 
                btnQuery_Click(null, null);
                ProcessGrid.GridViewFocus(gridView1, new string[1] { "ID" }, new string[1] { frm.ID.ToString() });
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        /// <summary>
        /// ����״̬
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSaveHandleStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FCommon.RightCheck(this.FormID, this.RightFormID, this.FormListAID, this.FormListBID, RightSub.Ȩ��0))
                {
                    this.ShowMessage("��û�д˲���Ȩ��");
                    return;
                }

                this.BaseFocusLabel.Focus();

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    int DtsID = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "DtsID"));
                    string HandleStatus = SysConvert.ToString(gridView1.GetRowCellValue(i, "HandleStatus"));
                    DateTime HandleStatusDate = SysConvert.ToDateTime(gridView1.GetRowCellValue(i, "HandleStatusDate"));
                    string sql = "Update WO_FabricProcessDts set HandleStatus=" + SysString.ToDBString(HandleStatus);
                    if (HandleStatusDate != SystemConfiguration.DateTimeDefaultValue)
                    {
                        sql += " , HandleStatusDate=" + SysString.ToDBString(HandleStatusDate);
                    }
                    sql += " where ID=" + DtsID;
                    SysUtils.ExecuteNonQuery(sql);

                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region �Զ��巽��
        /// <summary>
        /// ���ʵ��
        /// </summary>
        /// <returns></returns>
        private FabricProcess EntityGet()
        {
            FabricProcess entity = new FabricProcess();
            entity.ID = HTDataID;      
            return entity;
        }

        /// <summary>
        /// ��������ԴǷ��
        /// </summary>
        /// <param name="dt"></param>
        void ProcDataSourceQty(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["RemainQty"] = SysConvert.ToDecimal(dr["Qty"]) - SysConvert.ToDecimal(dr["TotalRecQty"]);
                if(SysConvert.ToDecimal(dr["Qty"]) !=0)
                {
                    dr["RemainRate"] = SysConvert.ToDecimal(SysConvert.ToDecimal(dr["RemainQty"]) / SysConvert.ToDecimal(dr["Qty"]), 3);
                }
            }
        }
        #endregion

        #region �����¼�
        

      

        /// <summary>
        /// ��ɫ�仯 ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void _HTDataDts_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                base._HTDataDts_RowCellStyle(sender, e);
                if (e.Column.FieldName == "FormStatusName")
                {
                    e.Appearance.BackColor = ItemBuyStatusProc.GetGridRowBackColor(SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "FormStatusName")));
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
       

       
        #endregion

    }
}