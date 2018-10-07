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

namespace MLTERP
{
    public partial class frmLoadIOFormTotal : frmAPBaseLoad
    {
        public frmLoadIOFormTotal()
        {
            InitializeComponent();
        }

        #region ����
        private List<string> list = new List<string>();



        /// <summary>
        /// �ֿ�ID
        /// </summary>
        private int[] m_DtsID = new int[] { };
        public int[] DtsID
        {
            get
            {
                return m_DtsID;
            }
            set
            {
                m_DtsID = value;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private int m_DZTypeID=0;
        public int DZTypeID
        {
            get
            {
                return m_DZTypeID;
            }
            set
            {
                m_DZTypeID = value;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        private int m_DZFlag = 0;
        public int DZFlag
        {
            get
            {
                return m_DZFlag;
            }
            set
            {
                m_DZFlag = value;
            }
        }

        /// <summary>
        /// ��Ʊ
        /// </summary>
        private int m_InvoiceFlag = 0;
        public int InvoiceFlag
        {
            get
            {
                return m_InvoiceFlag;
            }
            set
            {
                m_InvoiceFlag = value;
            }
        }



        /// <summary>
        /// �˻���ѯ����
        /// </summary>
        private string  m_THConditionStr=string.Empty;
        public string THConditionStr
        {
            get
            {
                return m_THConditionStr;
            }
            set
            {
                m_THConditionStr = value;
            }
        }

        /// <summary>
        /// �������Ʒ����
        /// </summary>
        private int m_MLTypeID = 0;
        public int MLTypeID
        {
            get
            {
                return m_MLTypeID;
            }
            set
            {
                m_MLTypeID = value;
            }
        }
        #endregion
        #region �Զ����鷽������[��Ҫ�޸�]
        /// <summary>
        /// ��Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE "+SysString.ToDBString("%"+txtFormNo.Text.Trim()+"%");
            }

            if (chkOrderDate.Checked&&m_InvoiceFlag!=1)
            {
                tempStr += " AND FormDate BETWEEN "+SysString.ToDBString(txtOrderDateS.DateTime)+" AND "+SysString.ToDBString(txtOrderDateE.DateTime);
            }

            if (SysConvert.ToString(drpVendorID.EditValue)!= string.Empty)
            {
                tempStr += " AND VendorID="+SysString.ToDBString(drpVendorID.EditValue.ToString());
            }


            if(txtInvoiceNo.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND InvoiceNo LIKE "+SysString.ToDBString("%"+txtInvoiceNo.Text.Trim()+"%");
            }

            if(txtQDtsSO.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND DtsSO LIKE "+SysString.ToDBString("%"+txtQDtsSO.Text.Trim()+"%");
            }

            if(txtQty.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND Qty LIKE "+SysString.ToDBString(txtQty.Text.Trim());
            }

            if (txtItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtItemModel.Text.Trim() + "%");
            }

            if(txtGoodsCode.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND GoodsCode LIKE "+SysString.ToDBString("%"+txtGoodsCode.Text.Trim()+"%");
            }

            if(txtColorNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorNum LIKE "+SysString.ToDBString("%"+txtColorNum.Text.Trim()+"%");
            }

            if(txtColorName.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND ColorName LIKE "+SysString.ToDBString("%"+txtColorName.Text.Trim()+"%");
            }


            if(txtBatch.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND Batch="+SysString.ToDBString(txtBatch.Text.Trim());
            }

            if(txtJarNum.Text.Trim()!=string.Empty)
            {
                tempStr+=" AND JarNum LIKE "+SysString.ToDBString("%"+txtJarNum.Text.Trim()+"%");
            }
            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }
            if (m_THConditionStr == string.Empty)//ʹ��Ĭ�ϲ�ѯ����
            {
                tempStr += " AND SubType IN(SELECT ID FROM Enum_FormList WHERE DZFlag<>0 ";
                if (m_DZTypeID != 0)
                {
                    tempStr += "  AND DZType=" + SysString.ToDBString(m_DZTypeID);
                }
                tempStr += ")";
            }
            else//ʹ���˻���ѯ����
            {
                tempStr += " AND SubType IN(" + m_THConditionStr + ")";
            }

            if (m_MLTypeID != 0)
            {
                tempStr += " AND MLType=" + m_MLTypeID;
            }
            if (chkDZDate.Checked && m_InvoiceFlag == 1)
            {
                tempStr += " AND DZTime BETWEEN "+SysString.ToDBString(txtDZDateS.DateTime)+" AND "+SysString.ToDBString(txtDZDateE.DateTime);
            }



            if (checkBox1.Checked)//�鿴��ѡ
            {
                if (GetListStr() != "" && GetListStr() != string.Empty)
                {
                    tempStr += " AND ID in (" + GetListStr() + ")";
                }
                else
                {
                    tempStr += " AND 1=0 ";
                }
            }


          

            tempStr += HTLoadConditionStr;
            tempStr += " AND ISNULL(DtsID,0)<>0";
            tempStr += " AND ISNULL(SubmitFlag,0)=1";
            HTDataConditionStr = tempStr;
        }



        private string GetListStr()
        {
            string str = string.Empty;
            for (int i = 0; i < list.Count; i++)
            {
                if (str != string.Empty && SysConvert.ToString(list[i]) != "" && SysConvert.ToString(list[i]) != "0")
                {
                    str += ",";
                }
                if (SysConvert.ToString(list[i]) != "" && SysConvert.ToString(list[i]) != "0")
                {
                    str += SysConvert.ToString(list[i]);
                }
            }
            return str;
        }



        /// <summary>
        /// ��Grid
        /// </summary>
        public override void BindGrid()
        {
            IOFormRule rule = new IOFormRule();
            HTDataConditionStr += "GROUP BY FormNo,";
            HTDataConditionStr += "FormDate,ItemCode,DtsOrderFormNo,";
            HTDataConditionStr += "WHNM,FormNM,ColorNum,ColorName,MWidth,";
            HTDataConditionStr += "MWeight,SinglePrice,ID,ItemName,ItemStd,ItemModel";
            DataTable dt = rule.RShowDtsTotal(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag").Replace("Amount", "SUM(Amount) Amount").Replace("Qty", "SUM(Qty) Qty"));
            //if (m_DZFlag == 1)
            //{
            //    SetDZGridView(dt);
            //}
            //if (m_InvoiceFlag == 1)
            //{
            //    SetInvoiceGridView(dt);
            //}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (list.Contains(SysConvert.ToString(dt.Rows[i]["ID"])))
                {
                    dt.Rows[i]["SelectFlag"] = 1;
                }
            }

            //SetWHQty(dt);
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();




        }

        private void SetWHQty(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToInt32(dr["FormDZFlag"]) ==(int)EnumDZFlag.���ʸ�)
                {
                    dr["Qty"] = 0 - SysConvert.ToDecimal(dr["Qty"]);
                }
            }
        }

        private void SetInvoiceGridView(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToDecimal(dr["InvoiceQty"]) > 0)
                {
                    if (SysConvert.ToDecimal(dr["Qty"]) != SysConvert.ToDecimal(dr["InvoiceQty"]))
                    {
                        dr["InvoiceFlagStr"] = "�ѿ�Ʊ";
                        string sql = "SELECT FormNo,DInvoiceQty FROM UV1_Finance_InvoiceOperationDts WHERE DLOADDtsID=" + SysString.ToDBString(SysConvert.ToInt32(dr["DtsID"]));
                        sql += " AND SubmitFlag=1";
                        DataTable dto = SysUtils.Fill(sql);
                        if (dto.Rows.Count > 0)
                        {
                            string InvoiceRemark = "�ѿ�Ʊ����Ϊ��";
                            decimal Qty = 0;
                            for (int i = 0; i < dto.Rows.Count; i++)
                            {
                                InvoiceRemark += SysConvert.ToString(dto.Rows[i][0]);
                                InvoiceRemark += "_";
                                Qty += SysConvert.ToDecimal(dto.Rows[i][1]);
                            }
                            InvoiceRemark += ",�ѿ�Ʊ�����ϼ�Ϊ" + Qty.ToString(); ;

                            dr["InvoiceRemark"] = InvoiceRemark;
                        }
                    }
                }
                else
                {
                    if (SysConvert.ToDecimal(dr["Qty"]) !=0- SysConvert.ToDecimal(dr["InvoiceQty"]))
                    {
                        dr["InvoiceFlagStr"] = "�ѿ�Ʊ";
                        string sql = "SELECT FormNo,DInvoiceQty FROM UV1_Finance_InvoiceOperationDts WHERE DLOADDtsID=" + SysString.ToDBString(SysConvert.ToInt32(dr["DtsID"]));
                        sql += " AND SubmitFlag=1";
                        DataTable dto = SysUtils.Fill(sql);
                        if (dto.Rows.Count > 0)
                        {
                            string InvoiceRemark = "�ѿ�Ʊ����Ϊ��";
                            decimal Qty = 0;
                            for (int i = 0; i < dto.Rows.Count; i++)
                            {
                                InvoiceRemark += SysConvert.ToString(dto.Rows[i][0]);
                                InvoiceRemark += "_";
                                Qty += SysConvert.ToDecimal(dto.Rows[i][1]);
                            }
                            InvoiceRemark += ",�ѿ�Ʊ�����ϼ�Ϊ" + Qty.ToString(); ;

                            dr["InvoiceRemark"] = InvoiceRemark;
                        }
                    }
                }

            }
        }

        private void SetDZGridView(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (SysConvert.ToInt32(dr["DZFlag"]) == 1)
                {
                    dr["DZFlagStr"] = "�Ѷ���";
                    string sql = "SELECT FormNo,DCheckQty FROM UV1_Finance_CheckOperationDts WHERE DLOADDtsID=" + SysString.ToDBString(SysConvert.ToInt32(dr["DtsID"]));
                    sql += " AND SubmitFlag=1";
                    DataTable dto = SysUtils.Fill(sql);
                    if (dto.Rows.Count > 0)
                    {
                        string DZRemark = "�Ѷ��˵���Ϊ��";
                        decimal Qty = 0;
                        for (int i = 0; i < dto.Rows.Count; i++)
                        {
                            DZRemark += SysConvert.ToString(dto.Rows[i][0]);
                            DZRemark += "_";
                            Qty += SysConvert.ToDecimal(dto.Rows[i][1]);
                        }
                        DZRemark += ",�Ѷ��������ϼ�Ϊ" + Qty.ToString(); ;

                        dr["DZRemark"] = DZRemark;
                    }
                }
               
            }
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
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            //Common.BindVendor(drpVendorID, new int[] {(int)EnumVendorType.�ͻ�,(int)EnumVendorType.���� }, true);
         
            txtOrderDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtOrderDateE.DateTime = DateTime.Now.Date;
            Common.BindSubType(drpSubType, this.FormListAID, true);
            //Common.BindVendorByDZTypeID(drpVendorID, m_DZTypeID, true);//�󶨿ͻ�
            //new VendorProc(drpVendorID);
            DevMethod.BindVendorByDZTypeID(drpVendorID, m_DZTypeID, true);//2015.4.8 CX UPDATE
         
            if (m_InvoiceFlag != 1)
            {
                chkDZDate.Visible = false;
                txtDZDateS.Visible = false;
                lbDZ.Visible = false;
                txtDZDateE.Visible = false;
               
            }
           
            txtDZDateS.DateTime = DateTime.Now.AddDays(-1).Date;
            txtDZDateE.DateTime = DateTime.Now.AddDays(1).Date;
            btnQuery_Click(null, null);

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
        /// ��д��ʼ��֮��ķ���
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }
        
        #endregion

        #region ���عҰ���Ϣ

        /// <summary>
        /// ��ȡѡ���ID����
        /// </summary>
        /// <returns></returns>
        private int[] GetStorgeArray()
        {
            int index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    index++;
                }
            }
            int[] tempstorge = new int[index];
            index = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
                {
                    tempstorge[index] = SysConvert.ToInt32(gridView1.GetRowCellValue(i, "ID"));
                    index++;
                }
            }
            return tempstorge;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();

            m_DtsID = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                m_DtsID[i] = SysConvert.ToInt32(list[i]);
            }

            //m_DtsID = GetStorgeArray();
            if (m_DtsID.Length == 0)
            {
                this.ShowMessage("û��ѡ���κ�����");
                return;
            }
            else if (m_DtsID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("ѡ����ص���������Ϊ��" + m_DtsID.Length.ToString() + Environment.NewLine + "����100�У������ٶȿ��ܻ������ȷ�ϼ�����"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_DtsID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_DtsID[i]));
            }
        }


        


        #endregion

        #region �����¼�

        /// <summary>
        /// ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (chkAll.Checked)
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 1);
                    }
                    else
                    {
                        gridView1.SetRowCellValue(i, "SelectFlag", 0);
                    }
                }
                SelectFlag_CheckedChanged(null, null);

            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        private void SelectFlag_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SelectFlag")
            {
                string ID = SysConvert.ToString(gridView1.GetRowCellValue(e.RowHandle, "ID"));
                if (1 == SysConvert.ToInt32(gridView1.GetRowCellValue(e.RowHandle, "SelectFlag")))
                {
                    if (!list.Contains(ID))
                    {
                        list.Add(ID);
                    }
                }
                else
                {
                    list.Remove(ID);
                }
            }
        }

        




    }
}