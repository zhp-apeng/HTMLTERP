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
    /// <summary>
    /// 加载库存
    /// </summary>
    public partial class frmStorgeLoad : frmAPBaseLoad
    {
        public frmStorgeLoad()
        {
            InitializeComponent();
        }

        #region 全局变量
        private List<string> list = new List<string>();
        #endregion

        #region 属性
        /// <summary>
        /// 库存ID
        /// </summary>
        private int[] m_StorgeID;
        public int[] StorgeID
        {
            get
            {
                return m_StorgeID;
            }
            set
            {
                m_StorgeID = value;
            }
        }
        /// <summary>
        /// 公司别
        /// </summary>
        private int m_CompanyTypeID;
        public int CompanyTypeID
        {
            get
            {
                return m_CompanyTypeID;
            }
            set
            {
                m_CompanyTypeID = value;
            }
        }
        /// <summary>
        /// 仓库类型
        /// </summary>
        private int m_WHTypeID=1;   //默认是面料仓库
        public int WHTypeID
        {
            get
            {
                return m_WHTypeID;
            }
            set
            {
                m_WHTypeID = value;
            }
        }

        /// <summary>
        /// 仓库物料类型
        /// </summary>
        private int m_WHItemTypeID = 0;   //仓库物料类型
        /// <summary>
        /// 仓库物料类型
        /// </summary>
        public int WHItemTypeID
        {
            get
            {
                return m_WHItemTypeID;
            }
            set
            {
                m_WHItemTypeID = value;
            }
        }

        /// <summary>
        /// 是否包含寄库
        /// </summary>
        private bool m_IncludeJK;
        public bool IncludeJK
        {
            get
            {
                return m_IncludeJK;
            }
            set
            {
                m_IncludeJK = value;
            }
        }
        /// <summary>
        /// 原料编号
        /// </summary>
        private string m_ItemCode;
        public string ItemCode
        {
            get { return m_ItemCode; }
            set { m_ItemCode = value; }
        }

        /// <summary>
        /// 仓库编号
        /// </summary>
        private string m_WHID;
        public string WHID
        {
            get { return m_WHID; }
            set { m_WHID = value; }
        }

        #endregion

        #region 自定义虚方法定义[需要修改]
        /// <summary>
        /// 绑定Grid
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (SysConvert.ToString(drpQWHID.EditValue) != "")
            {
                tempStr += " AND WHID=" + SysString.ToDBString(SysConvert.ToString(drpQWHID.EditValue));
            }
            if (txtItemCode.Text.Trim() != "")
            {
                tempStr += " AND ItemCode LIKE "+SysString.ToDBString("%"+txtItemCode.Text.Trim()+"%");
            }
            if (txtItemStd.Text.Trim() != "")
            {
                tempStr += " AND ItemStd LIKE " + SysString.ToDBString("%" + txtItemStd.Text.Trim() + "%");
            }
            if (txtColorNum.Text.Trim() != string.Empty)
            {
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(8009)) == 0)//查询模式 0：模糊查询； 1精确查询
                {
                    tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtColorNum.Text.Trim() + "%");
                }
                else
                {
                    tempStr += " AND ColorNum = " + SysString.ToDBString(txtColorNum.Text.Trim());
                }

            }
            if (txtColorName.Text.Trim() != string.Empty)
            {
                if (SysConvert.ToInt32(ProductParamSet.GetIntValueByID(8009)) == 0)//查询模式 0：模糊查询； 1精确查询
                {
                    tempStr += " AND ColorName LIKE " + SysString.ToDBString("%" + txtColorName.Text.Trim() + "%");
                }
                else
                {
                    tempStr += " AND ColorName = " + SysString.ToDBString(txtColorName.Text.Trim());
                }
            }

            if (txtItemName.Text.Trim() != "")
            {
                tempStr += " AND ItemName LIKE "+SysString.ToDBString("%"+txtItemName.Text.Trim()+"%");
            }
            if (txtItemModel.Text.Trim() != "")
            {
                tempStr+=" AND ItemModel LIKE "+SysString.ToDBString("%"+txtItemModel.Text.Trim()+"%");
            }

            if (txtJarNum.Text.Trim() != "")
            {
                tempStr+=" AND JarNum LIKE "+SysString.ToDBString("%"+txtJarNum.Text.Trim()+"%");
            }

            if (txtOrderFormNo.Text.Trim() != "")
            {
                tempStr += " AND OrderFormNo LIKE " + SysString.ToDBString("%" + txtOrderFormNo.Text.Trim() + "%");
            }

            if (checkBox1.Checked)//查看已选
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
            if (this.FormListAID != 0)
            {
                tempStr += " AND WHID IN (SELECT WHID FROM WH_WH WHERE WHType IN(SELECT WHTypeID FROM Enum_FormList WHERE ParentID=" + SysString.ToDBString(this.FormListAID) + "))";
            }
            tempStr += Common.GetWHRightCondition();
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
        /// 绑定Grid
        /// </summary>
        public override void BindGrid()
        {
            StorgeRule rule = new StorgeRule();
            DataTable dt = rule.RShow(HTDataConditionStr, ProcessGrid.GetQueryField(gridView1).Replace("SelectFlag", "0 SelectFlag"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (list.Contains(SysConvert.ToString(dt.Rows[i]["ID"])))
                {
                    dt.Rows[i]["SelectFlag"] = 1;
                }
            }
            gridView1.GridControl.DataSource = dt;
            gridView1.GridControl.Show();


        }


        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_Storge";
            this.HTDataList = gridView1;
            Common.BindWHByFormList(drpQWHID, this.FormListAID, true);
            //Common.BindMLType(drpMLType, true);
            //Common.BindMLType(drpResMLType, true);
            drpQWHID.EditValue = WHID;
            drpQWHID_EditValueChanged(null, null);
            HTDataList.OptionsBehavior.ShowEditorOnMouseUp = false;
        }

        /// <summary>
        /// 重写初始化之后的方法
        /// </summary>
        public override void IniFormLoadBehind()
        {
            ProcessGrid.SetGridEdit(HTDataList, new string[] { "SelectFlag" }, true);
        }

        #endregion
          
        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Storge EntityGet()
        {
            Storge entity = new Storge();
            entity.ID = HTDataID;
            return entity;
        }
        #endregion

        #region 加载库存
        /// <summary>
        /// 取得库存数组
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
            //IsSelected = true;
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
        /// 加载数据
        /// </summary>
        public override void LoadData()
        {
            this.BaseFocusLabel.Focus();

            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (SysConvert.ToInt32(gridView1.GetRowCellValue(i, "SelectFlag")) == 1)
            //    {
            //        if (i != 0 && SysConvert.ToInt32(gridView1.GetRowCellValue(i, "CompanyTypeID")) != SysConvert.ToInt32(gridView1.GetRowCellValue(i - 1, "CompanyTypeID")))
            //        {
            //            this.ShowMessage("有明细单据不属于统一公司的");
            //            return;
            //        }
            //    }
            //}

            m_StorgeID = GetStorgeArray();
            if (m_StorgeID.Length == 0)
            {
                this.ShowMessage("没有选择任何数据");
                return;
            }
            else if (m_StorgeID.Length > 100)
            {
                if (DialogResult.Yes != ShowConfirmMessage("选择加载的数据行数为：" + m_StorgeID.Length.ToString() + Environment.NewLine + "超过100行，加载速度可能会很慢，确认加载吗？"))
                {
                    return;
                }
            }

            for (int i = 0; i < m_StorgeID.Length; i++)
            {
                HTLoadData.Add(SysConvert.ToInt32(m_StorgeID[i]));
            }
        }


        #endregion

        #region   其他事件
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drpQWHID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.GetCondtion();
                this.BindGrid();
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }



        /// <summary>
        /// 全选
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
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void SelectFlag_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                BaseFocusLabel.Focus();

                string ID = SysConvert.ToString(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"));
                if (1 == SysConvert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SelectFlag")))
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
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        private void txtJarNum_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.GetCondtion();
                    this.BindGrid();
                  
                }
            }
            catch (Exception E)
            {

                this.ShowMessage(E.Message);
            }
        }

        


    }
}