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
    /// 功能：部门管理
    /// 
    /// </summary>
    public partial class frmDepEdit : frmAPBaseUISinEdit
    {
        public frmDepEdit()
        {
            InitializeComponent();
        }


        #region 自定义虚方法定义[需要修改]     
        /// <summary>
        /// 数据校验
        /// </summary>
        public override bool CheckCorrect()
        {
           
            if (txtName.Text.Trim() == "")
            {
                this.ShowMessage("请输入名称");
                txtName.Focus();
                return false;
            }          
            return true;
        }


        /// <summary>
        /// 新增
        /// </summary>
        public override int EntityAdd()
        {
            DepRule rule = new DepRule();
            Dep entity = EntityGet();
            rule.RAdd(entity);
            return entity.ID;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public override void EntityUpdate()
        {
            DepRule rule = new DepRule();
            Dep entity = EntityGet();
            rule.RUpdate(entity);
        }

        /// <summary>
        /// 设置
        /// </summary>
        public override void EntitySet()
        {
            Dep entity = new Dep();
            entity.ID = HTDataID;
            bool findFlag = entity.SelectByID();
            txtCode.Text = entity.Code.ToString();
            txtName.Text = entity.Name.ToString();
            txtRemark.Text = entity.Remark.ToString();
            txtStructureID.Text = entity.StructureID.ToString();
            chkIncludeSubStructureFlag.Checked = SysConvert.ToBoolean(entity.IncludeSubStructureFlag);


            if (!findFlag)
            {
               
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            DepRule rule = new DepRule();
            Dep entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 控件状态方法设置
        /// </summary>
        public override void SetInputStatus(bool p_Flag)
        {
            ProcessCtl.ProcControlEdit(groupControlMainten, p_Flag);

            txtStructureID.Properties.ReadOnly = true;
        }

        /// <summary>
        /// 数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "Data_Dep";
            //
        }

        /// <summary>
        /// 新增单据初始化控件数据(哪些值需要设置的设定一下)
        /// </summary>
        public override void IniInsertSet()
        {
            chkIncludeSubStructureFlag.Checked = true;
        }

        #endregion

        #region 自定义方法
        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private Dep EntityGet()
        {
            Dep entity = new Dep();
            entity.ID = HTDataID;
            entity.SelectByID();
            entity.Code = txtCode.Text.Trim();
            entity.Name = txtName.Text.Trim();
            entity.StructureID = SysConvert.ToInt32(txtStructureID.Text.Trim());
  			entity.Remark = txtRemark.Text.Trim();
            entity.IncludeSubStructureFlag = SysConvert.ToInt32(chkIncludeSubStructureFlag.Checked);
  			
            return entity;
        }
        #endregion

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //在TextBox的KeyPress事件里判断输入值的ASC码,如果不为数字就把e.Handled设为Ture,取消KeyPress事件,控制txtID只能输入数字
            if (e.KeyChar > 57 || (e.KeyChar > 8 && e.KeyChar < 47) || e.KeyChar < 8)
            {
                e.Handled = true;
            }

        }
        #region 其它事件
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStructureID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (HTFormStatus != FormStatus.查询)
                {
                    frmLoadStructure frm = new frmLoadStructure();
                    frm.ShowDialog();
                    if (frm.HTLoadData.Count != 0)
                    {
                        txtStructureID.Text = frm.HTLoadData[0].ToString();
                    }
                }
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        /// <summary>
        /// 值改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStructureID_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtStructureName.Text = Common.GetStructureName(SysConvert.ToInt32(txtStructureID.Text));
               
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }

        #endregion

       

    }
}