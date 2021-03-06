using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HttSoft.UCFab
{
    /// <summary>
    /// 功能：查看码单GridView模式
    /// 作者：陈加海
    /// 日期：2014-3-31
    /// </summary>
    public partial class UCFabVGridView : UCFabBaseViewCtl
    {
        public UCFabVGridView()
        {
            InitializeComponent();
        }

        #region 临时静态变量，后续移动到全局变量，或配置数据库内
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//默认色系 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//默认色系

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//偶数列色系 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//偶数列色系 128, 255, 128

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//选择色系
        #endregion


        #region 外部调用方法


        /// <summary>
        /// 执行绘画
        /// 一般在全部赋值完成后
        /// </summary>
        public override void UCAct()
        {
            if (UCQtyConvertMode)
            {
                gridView1.Columns["InputQty"].Visible = true;
                gridView1.Columns["InputQty"].Caption = "转换数量("+UCQtyConvertModeInputUnit+")";
                //gridView1.Columns["InputQty"].VisibleIndex = 3;
            }
            else
            {
                //gridView1.Columns["InputQty"].VisibleIndex = -1;
                gridView1.Columns["InputQty"].Visible = false;
            }

            if (UCColumnISNHide)//如果条码列隐藏
            {
                gridView1.Columns["BoxNo"].Visible = false;
            }
            BindGrid();
        }


        #endregion


        #region 内部方法
        void BindGrid()
        {
            gridView1.GridControl.DataSource = UCDataSource;
            gridView1.GridControl.Show();
        }
        #endregion


        #region 加载事件
        private void UCFabSGridView_Load(object sender, EventArgs e)
        {
            try
            {
                //gridView1.OptionsBehavior.ShowEditorOnMouseUp = false;
                //UCFabCommon.GridViewRowIndexBind(gridView1);
            }
            catch (Exception E)
            {
                this.ShowMessage(E.Message);
            }
        }
        #endregion

        #region 其它事件
        /// <summary>
        /// 行变颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle % 2 == 1)
                {
                    e.Appearance.BackColor = UCBackColorS2;
                }
                else
                {
                    e.Appearance.BackColor = UCBackColor2;
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
