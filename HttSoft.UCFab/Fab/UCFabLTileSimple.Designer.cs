﻿namespace HttSoft.UCFab
{
    partial class UCFabLTileSimple
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panTile = new DevExpress.XtraEditors.PanelControl();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panTile)).BeginInit();
            this.panTile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTile
            // 
            this.panTile.Appearance.BackColor = System.Drawing.Color.White;
            this.panTile.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panTile.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panTile.Appearance.Options.UseBackColor = true;
            this.panTile.Appearance.Options.UseBorderColor = true;
            this.panTile.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panTile.Controls.Add(this.lblInfo2);
            this.panTile.Controls.Add(this.lblInfo1);
            this.panTile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTile.Location = new System.Drawing.Point(0, 0);
            this.panTile.Name = "panTile";
            this.panTile.Size = new System.Drawing.Size(85, 44);
            this.panTile.TabIndex = 269;
            this.panTile.Text = "panelControl1";
            this.panTile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panTile_MouseClick);
            // 
            // lblInfo2
            // 
            this.lblInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInfo2.Location = new System.Drawing.Point(2, 22);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(81, 21);
            this.lblInfo2.TabIndex = 271;
            this.lblInfo2.Text = "202.5";
            this.lblInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panTile_MouseClick);
            // 
            // lblInfo1
            // 
            this.lblInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblInfo1.Location = new System.Drawing.Point(2, 2);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(81, 21);
            this.lblInfo1.TabIndex = 270;
            this.lblInfo1.Text = "201";
            this.lblInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInfo1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panTile_MouseClick);
            // 
            // UCFabLTileSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panTile);
            this.Name = "UCFabLTileSimple";
            this.Size = new System.Drawing.Size(85, 44);
            this.Load += new System.EventHandler(this.UCFabLTileSimple_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panTile)).EndInit();
            this.panTile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panTile;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblInfo1;

    }
}
