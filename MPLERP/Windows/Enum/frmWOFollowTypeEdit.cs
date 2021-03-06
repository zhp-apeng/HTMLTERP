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
    /// 功能：加工跟单枚举表单带配置功能
    /// 
    /// </summary>
    public partial class frmWOFollowTypeEdit : frmAPBaseUISinEdit
    {
        public frmWOFollowTypeEdit()
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
            WOFollowTypeRule rule = new WOFollowTypeRule();
            WOFollowType entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            WOFollowTypeRule rule = new WOFollowTypeRule();
            WOFollowType entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            WOFollowType entity = new WOFollowType();
            entity.ID = HTDataID;
            bool findFlag=entity.SelectByID();
             txtCode.Text = entity.Code.ToString(); 
  			txtName.Text = entity.Name.ToString();
            drpUseFlag.EditValue = entity.UseFlag;
            drpSaleProcedureID.EditValue = entity.SaleProcedureID;
  			txtRemark.Text = entity.Remark.ToString(); 
  			txtQryTableName.Text = entity.QryTableName.ToString(); 
  			txtQryIDFieldName.Text = entity.QryIDFieldName.ToString(); 
  			txtQryFieldName.Text = entity.QryFieldName.ToString(); 
  			txtQryShowCaption.Text = entity.QryShowCaption.ToString(); 
  			txtQryOrderByFieldName.Text = entity.QryOrderByFieldName.ToString(); 
  			txtQryWhereConFirst.Text = entity.QryWhereConFirst.ToString(); 
  			txtUIImgUrl.Text = entity.UIImgUrl.ToString(); 
  			

            if (!findFlag)
            {
              
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            WOFollowTypeRule rule = new WOFollowTypeRule();
            WOFollowType entity = EntityGet();
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
            this.HTDataTableName = "Enum_WOFollowType";
          
            Common.BindSaleProcedure(drpSaleProcedureID, true);
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private WOFollowType EntityGet()
        {
            WOFollowType entity = new WOFollowType();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim(); 
  			entity.Name = txtName.Text.Trim(); 
  			entity.UseFlag = SysConvert.ToInt32(drpUseFlag.EditValue); 
  			entity.SaleProcedureID = SysConvert.ToInt32(drpSaleProcedureID.EditValue); 
  			entity.Remark = txtRemark.Text.Trim(); 
  			entity.QryTableName = txtQryTableName.Text.Trim(); 
  			entity.QryIDFieldName = txtQryIDFieldName.Text.Trim(); 
  			entity.QryFieldName = txtQryFieldName.Text.Trim(); 
  			entity.QryShowCaption = txtQryShowCaption.Text.Trim(); 
  			entity.QryOrderByFieldName = txtQryOrderByFieldName.Text.Trim(); 
  			entity.QryWhereConFirst = txtQryWhereConFirst.Text.Trim(); 
  			entity.UIImgUrl = txtUIImgUrl.Text.Trim(); 
  			
            return entity;
        }
        #endregion

      
    }
}