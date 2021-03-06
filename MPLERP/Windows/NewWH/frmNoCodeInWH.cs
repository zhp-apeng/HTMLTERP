﻿using System;
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
    public partial class frmNoCodeInWH : frmAPBaseUIForm
    {
        #region 全局变量
        //多线程
        BackgroundWorker work;
        //时间控件
        System.Windows.Forms.Timer timer = new Timer();
        //GridView绑定用的Table
        DataTable GridView1Table = new DataTable();
        //时间
        public int StartM { get; set; }
        #endregion
        public frmNoCodeInWH()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查询条件
        /// </summary>
        public override void GetCondtion()
        {
            string tempStr = string.Empty;
            if (txtFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND FormNo LIKE " + SysString.ToDBString("%" + txtFormNo.Text.Trim() + "%");
            }
            if (txtQItemCode.Text.Trim() != string.Empty)
            {
                tempStr += " AND  ItemCode LIKE " + SysString.ToDBString("%" + txtQItemCode.Text.Trim() + "%");
            }
            if (txtQItemModel.Text.Trim() != string.Empty)
            {
                tempStr += " AND ItemModel LIKE " + SysString.ToDBString("%" + txtQItemModel.Text.Trim() + "%");
            }
            if (txtVendorAttn.Text.Trim() != string.Empty)
            {
                tempStr += " AND VendorAttn LIKE " + SysString.ToDBString("%" + txtVendorAttn.Text.Trim() + "%");
            }
            if (txtQJarNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND JarNum LIKE " + SysString.ToDBString("%" + txtQJarNum.Text.Trim() + "%");
            }
            if (txtQColorNum.Text.Trim() != string.Empty)
            {
                tempStr += " AND ColorNum LIKE " + SysString.ToDBString("%" + txtQColorNum.Text.Trim() + "%");
            }
            if (chkOrderDate.Checked)
            {
                tempStr += " AND FormDate BETWEEN " + SysString.ToDBString(txtQFormDateS.DateTime) + " AND " + SysString.ToDBString(txtQFormDateE.DateTime);
            }
            if (txtDtsOrderFormNo.Text.Trim() != string.Empty)
            {
                tempStr += " AND DtsOrderFormNo LIKE " + SysString.ToDBString("%" + txtDtsOrderFormNo.Text.Trim() + "%");
            }
            if (SysConvert.ToString(drpSubType.EditValue) != string.Empty)
            {
                tempStr += " AND SubType=" + SysString.ToDBString(SysConvert.ToInt32(drpSubType.EditValue));
            }
            if (this.FormListAID != 0)
            {
                tempStr += " AND HeadType=" + this.FormListAID;
            }
            tempStr += Common.GetWHRightCondition();
            tempStr += " AND ISNULL(DelFlag,0)<>1";
            tempStr += " ORDER BY FormDate DESC,ID DESC";
            HTDataConditionStr = tempStr;
        }
        /// <summary>
        /// 绑定GridView
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
        /// 删除
        /// </summary>
        public override void EntityDelete()
        {
            IOFormRule rule = new IOFormRule();
            IOForm entity = EntityGet();
            rule.RDelete(entity);
        }

        /// <summary>
        /// 获得实体
        /// </summary>
        /// <returns></returns>
        private IOForm EntityGet()
        {
            IOForm entity = new IOForm();
            entity.ID = HTDataID;
            return entity;
        }
        /// <summary>
        ///  数据初始化(填写表名、绑定控制、初始化界面属性等)
        /// </summary>
        public override void IniData()
        {
            this.HTDataTableName = "WH_IOForm";
            this.HTDataList = gridView1;
            this.HTQryContainer = groupControlQuery;
            this.IsPostBack = false;
            txtQFormDateS.DateTime = DateTime.Now.AddMonths(-1).Date;
            txtQFormDateE.DateTime = DateTime.Now.Date;
            Common.BindSubType(drpSubType, this.FormListAID, true);
            work = new BackgroundWorker();
            work.DoWork += new DoWorkEventHandler(work_DoWork);
            work.RunWorkerCompleted += new RunWorkerCompletedEventHandler(work_RunWorkerCompleted);
        }
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
            label.Text = "查询结束";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StartM++;
            LabelItem label = this.ToolBarLItemGet(-1, ToolButtonName.lblFormStatus.ToString());
            label.Text = "查询开始，分析数据需要几分钟，请耐心等待。。。。已经用时" + StartM + "S";
        }
        /// <summary>
        /// 快速查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnQuery_Click(object sender, EventArgs e)
        {
            base.btnQuery_Click(sender, e);
        }

    }
}
