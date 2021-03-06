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
using DevExpress.XtraEditors.Controls;
using HttSoft.WinUIBase;

namespace MLTERP
{
    /// <summary>
    /// 期初数据维护
    /// </summary>
    public partial class frmBVendorAmountEdit : frmAPBaseUISinEdit
    {
        public frmBVendorAmountEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
            //if (txtTitle.Text.Trim() == "")
            //{
            //    this.ShowMessage("请输入标题");
            //    txtTitle.Focus();
            //    return false;
            //}            

            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            BVendorAmountRule rule = new BVendorAmountRule();
            BVendorAmount entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            BVendorAmountRule rule = new BVendorAmountRule();
            BVendorAmount entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            BVendorAmount entity = new BVendorAmount();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
            drpVendorID.EditValue = entity.VendorID;
  			txtBQty.Text = entity.BQty.ToString(); 
  			txtBAmount.Text = entity.BAmount.ToString(); 
  			txtRemark.Text = entity.Remark.ToString();
            drpDZType.EditValue = entity.DZTypeID;


            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            BVendorAmountRule rule = new BVendorAmountRule();
            BVendorAmount entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Finance_BVendorAmount";

            Common.BindDZType(drpDZType, true);
          
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private BVendorAmount EntityGet()
        {
            BVendorAmount entity = new BVendorAmount();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.VendorID = SysConvert.ToString(drpVendorID.EditValue);
  			entity.BQty = SysConvert.ToDecimal(txtBQty.Text.Trim()); 
  			entity.BAmount = SysConvert.ToDecimal(txtBAmount.Text.Trim()); 
  			entity.Remark = txtRemark.Text.Trim();

            entity.DZTypeID = SysConvert.ToInt32(drpDZType.EditValue);
         
            entity.UpdateOP = FParamConfig.LoginName;
            entity.UpdateDate = DateTime.Now;
  			
            return entity;
        }
        #endregion

        private void drpDZType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (SysConvert.ToInt32(drpDZType.EditValue) != 0)
                {
                    int DZType = SysConvert.ToInt32(drpDZType.EditValue);
                    Common.BindVendorByDZTypeID(drpVendorID, DZType, true);                   
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
    }
}