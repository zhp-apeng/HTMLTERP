using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttSoft.Framework;
using DevExpress.XtraGrid.Columns;

namespace HttSoft.UCFab
{
    /// <summary>
    /// ���ܣ��鿴�뵥 ����ģʽ
    /// ���ߣ��¼Ӻ�
    /// ���ڣ�2014-3-31
    /// </summary>
    public partial class UCFabSVHori : UCFabBaseSelectCtl
    {
        public UCFabSVHori()
        {
            InitializeComponent();
        }


        #region ��ʱ��̬�����������ƶ���ȫ�ֱ��������������ݿ���
        static Color UCBackColor = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 192
        static Color UCBackColor2 = Color.FromArgb(255, 255, 255);//Ĭ��ɫϵ 255, 255, 128
        static Color UCBorderColor = Color.FromArgb(192, 255, 255);//Ĭ��ɫϵ

        static Color UCBackColorS = Color.FromArgb(255, 255, 192);//ż����ɫϵ 192, 255, 192
        static Color UCBackColorS2 = Color.AliceBlue;//ż����ɫϵ 128, 255, 128Color.AliceBlueColor.FromArgb(255, 255, 128)

        static Color UCSelectColor = Color.FromArgb(255, 192, 255);//ѡ��ɫϵ
        static Color UCTitleColor = Color.FromArgb(224, 224, 224);//Color.Gray;//Color.FromArgb(255, 192, 255);//ѡ��ɫϵ
        #endregion


        #region �ⲿ���÷���


        /// <summary>
        /// ִ�л滭
        /// һ����ȫ����ֵ��ɺ�
        /// </summary>
        public override void UCAct()
        {
            BindGrid();
        }


        /// <summary>
        /// ȡ��һ��
        /// </summary>
        public override void UCCancelOne(string p_ISN)
        {
            base.UCCancelOne(p_ISN);
        }

        #endregion


        #region �ڲ�����
        void BindGrid()
        {
            gridView1.GridControl.DataSource = ConvertDataSource(UCDataSource);
            gridView1.GridControl.Show();

            lblFabCount.Text = UCDataSource.Rows.Count.ToString();
            lblFabQty.Text = SysConvert.ToString(UCDataSource.Compute("SUM(Qty)", ""));
            lblFabWeight.Text = SysConvert.ToString(UCDataSource.Compute("SUM(Weight)", ""));
            lblFabYard.Text = SysConvert.ToString(UCDataSource.Compute("SUM(Yard)", ""));
        }



        /// <summary>
        /// ת������ԴΪ����
        /// </summary>
        /// <returns>��һ��Ϊ���⣻ÿ������ռ���У���һ��ƥ�ţ��ڶ�������</returns>
        DataTable ConvertDataSource(DataTable dtSource)
        {
            gridView1.Columns.Clear();
            //���� UCColumnCount;
            DataTable outdt = new DataTable();
            outdt.Columns.Add(new DataColumn("ColTitle", typeof(string)));
            gridView1.Columns.Add(CreateGridColumnOne("ColTitle", "����", 0, 0));//����һ��

            int colWidth = UCFabParamSet.GetIntValueByID(6003);//�뵥��ʾ����ģʽ�п���
            if (colWidth <= 0)
            {
                colWidth = 0;
            }


            for (int i = 1; i <= UCColumnCount; i++)
            {
                outdt.Columns.Add(new DataColumn("ColVal" + i, typeof(string)));


                gridView1.Columns.Add(CreateGridColumnOne("ColVal" + i.ToString(), (i).ToString(), colWidth, i + 1));//����һ��
            }
            //��������ϣ���ʼת������
            int rowIndex = 0;//ת�����к�
            int colIndex = 0;//ת�����к�
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                rowIndex = i / UCColumnCount;
                colIndex = i % UCColumnCount;

                if (colIndex == 0)//��һ�У�����������
                {
                    DataRow dr = outdt.NewRow();
                    dr["ColTitle"] = "ƥ��";
                    outdt.Rows.Add(dr);


                    DataRow dr2 = outdt.NewRow();
                    dr2["ColTitle"] = "����";
                    outdt.Rows.Add(dr2);

                    DataRow dr3 = outdt.NewRow();
                    dr3["ColTitle"] = "����";
                    outdt.Rows.Add(dr3);
                    DataRow dr5 = outdt.NewRow();
                    dr5["ColTitle"] = "����";
                    outdt.Rows.Add(dr5);
                    DataRow dr4 = outdt.NewRow();
                    dr4["ColTitle"] = "�ȼ�";
                    outdt.Rows.Add(dr4);
                }

                //��ʼ��ֵ
                outdt.Rows[rowIndex * 5]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["SubSeq"].ToString();//ƥ��
                outdt.Rows[rowIndex * 5 + 1]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Qty"].ToString();//����
                outdt.Rows[rowIndex * 5 + 2]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Weight"].ToString();//����
                outdt.Rows[rowIndex * 5 + 3]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["Yard"].ToString();//����
                outdt.Rows[rowIndex * 5 + 4]["ColVal" + (colIndex + 1)] = dtSource.Rows[i]["GoodsLevel"].ToString();//�ȼ�
            }

            return outdt;

        }


        /// <summary>
        /// ����һ��Grid��
        /// </summary>
        /// <param name="p_FiledName"></param>
        /// <param name="p_Title"></param>
        /// <param name="p_ColSize"></param>
        /// <param name="p_VIndex"></param>
        /// <returns></returns>
        GridColumn CreateGridColumnOne(string p_FiledName, string p_Title, int p_ColSize, int p_VIndex)
        {
            GridColumn col = new GridColumn();
            col.Name = "col" + p_FiledName;
            col.FieldName = p_FiledName;
            col.Caption = p_Title;
            col.OptionsColumn.ReadOnly = true;
            if (p_ColSize != 0)
            {
                col.Width = p_ColSize;
            }
            col.VisibleIndex = p_VIndex;
            return col;

        }
        #endregion


        #region �����¼�
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

        #region �����¼�
        /// <summary>
        /// �б���ɫ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "ColTitle")//����
                {
                    e.Appearance.BackColor = UCTitleColor;
                }
                else
                {
                    if (e.RowHandle % 6 == 0 || e.RowHandle % 6 == 1 || e.RowHandle % 6 == 2)//����ֵ��2�У�
                    {
                        e.Appearance.BackColor = UCBackColor2;
                    }
                    else//ż��ֵ(2��)
                    {
                        e.Appearance.BackColor = UCBackColorS2;
                    }
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