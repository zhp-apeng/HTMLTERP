using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;
using HttSoft.MLTERP.Data;
using HttSoft.MLTERP.Sys;

namespace HttSoft.MLTERP.DataCtl
{
	/// <summary>
	/// 目的：WH_YQFormDts实体控制类
	/// 作者:章文强
	/// 创建日期:2013/6/22
	/// </summary>
	public sealed class YQFormDtsCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public YQFormDtsCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public YQFormDtsCtl(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		
		/// <summary>
        /// 新增
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int AddNew(BaseEntity p_Entity)
        {
            try
            {
                YQFormDts MasterEntity=(YQFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_YQFormDts(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("CompanyTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				MasterField.Append("WHTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				MasterField.Append("WHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WHID)+","); 
  				MasterField.Append("SectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SectionID)+","); 
  				MasterField.Append("SBitID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SBitID)+","); 
  				MasterField.Append("DtsVendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsVendorID)+","); 
  				MasterField.Append("FromWHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FromWHID)+","); 
  				MasterField.Append("FromSectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FromSectionID)+","); 
  				MasterField.Append("FromSBitID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FromSBitID)+","); 
  				MasterField.Append("ItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				MasterField.Append("ItemName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemName)+","); 
  				MasterField.Append("ItemStd"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				MasterField.Append("ItemModel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				MasterField.Append("Batch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Batch)+","); 
  				MasterField.Append("VendorBatch"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				MasterField.Append("ColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				MasterField.Append("ColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ColorName)+","); 
  				MasterField.Append("JarNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNum)+","); 
  				MasterField.Append("YarnStatus"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YarnStatus)+","); 
  				MasterField.Append("YarnTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YarnTypeID)+","); 
  				MasterField.Append("SizeName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SizeName)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("Weight"+","); 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SinglePrice"+","); 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Amount"+","); 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WAmount"+","); 
  				if(MasterEntity.WAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DtsSO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsSO)+","); 
  				MasterField.Append("DtsSaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsSaleOPID)+","); 
  				MasterField.Append("Needle"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Needle)+","); 
  				MasterField.Append("YarnType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.YarnType)+","); 
  				MasterField.Append("SourceQty"+","); 
  				if(MasterEntity.SourceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SourceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MoveQty"+","); 
  				if(MasterEntity.MoveQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MoveQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SourceWeight"+","); 
  				if(MasterEntity.SourceWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SourceWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MoveWeight"+","); 
  				if(MasterEntity.MoveWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MoveWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TubeGW"+","); 
  				if(MasterEntity.TubeGW!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TubeGW)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SourceTubeQty"+","); 
  				if(MasterEntity.SourceTubeQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SourceTubeQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MoveTubeQty"+","); 
  				if(MasterEntity.MoveTubeQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MoveTubeQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TubeQty"+","); 
  				if(MasterEntity.TubeQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TubeQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SourcePieceQty"+","); 
  				if(MasterEntity.SourcePieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.SourcePieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MovePieceQty"+","); 
  				if(MasterEntity.MovePieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MovePieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PieceQty"+","); 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PieceQtyDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PieceQtyDesc)+","); 
  				MasterField.Append("JarNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.JarNo)+","); 
  				MasterField.Append("Twist"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Twist)+","); 
  				MasterField.Append("DLCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLCode)+","); 
  				MasterField.Append("GoodsCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				MasterField.Append("GoodsLevel"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				MasterField.Append("VColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				MasterField.Append("VColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VColorName)+","); 
  				MasterField.Append("VItemCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				MasterField.Append("PFPrice"+","); 
  				if(MasterEntity.PFPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PFPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ToWHID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ToWHID)+","); 
  				MasterField.Append("ToSectionID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ToSectionID)+","); 
  				MasterField.Append("ToSBitID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ToSBitID)+","); 
  				MasterField.Append("MWidth"+","); 
  				if(MasterEntity.MWidth!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MWidth)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("MWeight"+","); 
  				if(MasterEntity.MWeight!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MWeight)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("WeightUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				MasterField.Append("DtsInVendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsInVendorID)+","); 
  				MasterField.Append("InSO"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InSO)+","); 
  				MasterField.Append("InOrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InOrderFormNo)+","); 
  				MasterField.Append("InvoiceQty"+","); 
  				if(MasterEntity.InvoiceQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InvoiceAmount"+","); 
  				if(MasterEntity.InvoiceAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PayAmount"+","); 
  				if(MasterEntity.PayAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DtsInvoiceDelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsInvoiceDelFlag)+","); 
  				MasterField.Append("DtsInvoiceDelOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsInvoiceDelOPID)+","); 
  				MasterField.Append("DtsInvoiceDelTime"+","); 
  				if(MasterEntity.DtsInvoiceDelTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DtsInvoiceDelTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DtsInvoiceNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsInvoiceNo)+","); 
  				MasterField.Append("DZQty"+","); 
  				if(MasterEntity.DZQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DZQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DZSinglePrice"+","); 
  				if(MasterEntity.DZSinglePrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DZSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DZAmount"+","); 
  				if(MasterEntity.DZAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DZFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DZFlag)+","); 
  				MasterField.Append("DZOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DZOPID)+","); 
  				MasterField.Append("DZTime"+","); 
  				if(MasterEntity.DZTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DZTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DZNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DZNo)+","); 
  				MasterField.Append("FreeNum1"+","); 
  				if(MasterEntity.FreeNum1!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FreeNum1)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DtsOrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DtsOrderFormNo)+","); 
  				MasterField.Append("InSaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InSaleOPID)+","); 
  				MasterField.Append("Tax"+","); 
  				if(MasterEntity.Tax!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Tax)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TaxAmount"+","); 
  				if(MasterEntity.TaxAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TaxAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PackDts"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackDts)+","); 
  				MasterField.Append("MLType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MLType)+","); 
  				MasterField.Append("DYPrice"+","); 
  				if(MasterEntity.DYPrice!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.DYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DLaodDtsID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLaodDtsID)+","); 
  				MasterField.Append("DLoadFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLoadFormNo)+","); 
  				MasterField.Append("DLoadSubType"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DLoadSubType)+")"); 
 
                
                

                //执行
                int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(MasterField.Append(MasterValue.ToString()).ToString());
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
               throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBInsert),E);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Update(BaseEntity p_Entity)
        {
            try
            {
                YQFormDts MasterEntity=(YQFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_YQFormDts SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" CompanyTypeID="+SysString.ToDBString(MasterEntity.CompanyTypeID)+","); 
  				UpdateBuilder.Append(" WHTypeID="+SysString.ToDBString(MasterEntity.WHTypeID)+","); 
  				UpdateBuilder.Append(" WHID="+SysString.ToDBString(MasterEntity.WHID)+","); 
  				UpdateBuilder.Append(" SectionID="+SysString.ToDBString(MasterEntity.SectionID)+","); 
  				UpdateBuilder.Append(" SBitID="+SysString.ToDBString(MasterEntity.SBitID)+","); 
  				UpdateBuilder.Append(" DtsVendorID="+SysString.ToDBString(MasterEntity.DtsVendorID)+","); 
  				UpdateBuilder.Append(" FromWHID="+SysString.ToDBString(MasterEntity.FromWHID)+","); 
  				UpdateBuilder.Append(" FromSectionID="+SysString.ToDBString(MasterEntity.FromSectionID)+","); 
  				UpdateBuilder.Append(" FromSBitID="+SysString.ToDBString(MasterEntity.FromSBitID)+","); 
  				UpdateBuilder.Append(" ItemCode="+SysString.ToDBString(MasterEntity.ItemCode)+","); 
  				UpdateBuilder.Append(" ItemName="+SysString.ToDBString(MasterEntity.ItemName)+","); 
  				UpdateBuilder.Append(" ItemStd="+SysString.ToDBString(MasterEntity.ItemStd)+","); 
  				UpdateBuilder.Append(" ItemModel="+SysString.ToDBString(MasterEntity.ItemModel)+","); 
  				UpdateBuilder.Append(" Batch="+SysString.ToDBString(MasterEntity.Batch)+","); 
  				UpdateBuilder.Append(" VendorBatch="+SysString.ToDBString(MasterEntity.VendorBatch)+","); 
  				UpdateBuilder.Append(" ColorNum="+SysString.ToDBString(MasterEntity.ColorNum)+","); 
  				UpdateBuilder.Append(" ColorName="+SysString.ToDBString(MasterEntity.ColorName)+","); 
  				UpdateBuilder.Append(" JarNum="+SysString.ToDBString(MasterEntity.JarNum)+","); 
  				UpdateBuilder.Append(" YarnStatus="+SysString.ToDBString(MasterEntity.YarnStatus)+","); 
  				UpdateBuilder.Append(" YarnTypeID="+SysString.ToDBString(MasterEntity.YarnTypeID)+","); 
  				UpdateBuilder.Append(" SizeName="+SysString.ToDBString(MasterEntity.SizeName)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.Weight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Weight="+SysString.ToDBString(MasterEntity.Weight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Weight=null,");  
  				} 
  
  				 
  				if(MasterEntity.SinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice="+SysString.ToDBString(MasterEntity.SinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.Amount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Amount="+SysString.ToDBString(MasterEntity.Amount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Amount=null,");  
  				} 
  
  				 
  				if(MasterEntity.WAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" WAmount="+SysString.ToDBString(MasterEntity.WAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" DtsSO="+SysString.ToDBString(MasterEntity.DtsSO)+","); 
  				UpdateBuilder.Append(" DtsSaleOPID="+SysString.ToDBString(MasterEntity.DtsSaleOPID)+","); 
  				UpdateBuilder.Append(" Needle="+SysString.ToDBString(MasterEntity.Needle)+","); 
  				UpdateBuilder.Append(" YarnType="+SysString.ToDBString(MasterEntity.YarnType)+","); 
  				 
  				if(MasterEntity.SourceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SourceQty="+SysString.ToDBString(MasterEntity.SourceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SourceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.MoveQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MoveQty="+SysString.ToDBString(MasterEntity.MoveQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MoveQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.SourceWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SourceWeight="+SysString.ToDBString(MasterEntity.SourceWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SourceWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.MoveWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MoveWeight="+SysString.ToDBString(MasterEntity.MoveWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MoveWeight=null,");  
  				} 
  
  				 
  				if(MasterEntity.TubeGW!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TubeGW="+SysString.ToDBString(MasterEntity.TubeGW)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TubeGW=null,");  
  				} 
  
  				 
  				if(MasterEntity.SourceTubeQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SourceTubeQty="+SysString.ToDBString(MasterEntity.SourceTubeQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SourceTubeQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.MoveTubeQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MoveTubeQty="+SysString.ToDBString(MasterEntity.MoveTubeQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MoveTubeQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TubeQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TubeQty="+SysString.ToDBString(MasterEntity.TubeQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TubeQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.SourcePieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" SourcePieceQty="+SysString.ToDBString(MasterEntity.SourcePieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" SourcePieceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.MovePieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MovePieceQty="+SysString.ToDBString(MasterEntity.MovePieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MovePieceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.PieceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty="+SysString.ToDBString(MasterEntity.PieceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PieceQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" PieceQtyDesc="+SysString.ToDBString(MasterEntity.PieceQtyDesc)+","); 
  				UpdateBuilder.Append(" JarNo="+SysString.ToDBString(MasterEntity.JarNo)+","); 
  				UpdateBuilder.Append(" Twist="+SysString.ToDBString(MasterEntity.Twist)+","); 
  				UpdateBuilder.Append(" DLCode="+SysString.ToDBString(MasterEntity.DLCode)+","); 
  				UpdateBuilder.Append(" GoodsCode="+SysString.ToDBString(MasterEntity.GoodsCode)+","); 
  				UpdateBuilder.Append(" GoodsLevel="+SysString.ToDBString(MasterEntity.GoodsLevel)+","); 
  				UpdateBuilder.Append(" VColorNum="+SysString.ToDBString(MasterEntity.VColorNum)+","); 
  				UpdateBuilder.Append(" VColorName="+SysString.ToDBString(MasterEntity.VColorName)+","); 
  				UpdateBuilder.Append(" VItemCode="+SysString.ToDBString(MasterEntity.VItemCode)+","); 
  				 
  				if(MasterEntity.PFPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PFPrice="+SysString.ToDBString(MasterEntity.PFPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PFPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" ToWHID="+SysString.ToDBString(MasterEntity.ToWHID)+","); 
  				UpdateBuilder.Append(" ToSectionID="+SysString.ToDBString(MasterEntity.ToSectionID)+","); 
  				UpdateBuilder.Append(" ToSBitID="+SysString.ToDBString(MasterEntity.ToSBitID)+","); 
  				 
  				if(MasterEntity.MWidth!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MWidth="+SysString.ToDBString(MasterEntity.MWidth)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MWidth=null,");  
  				} 
  
  				 
  				if(MasterEntity.MWeight!=0) 
  				{ 
  			 		UpdateBuilder.Append(" MWeight="+SysString.ToDBString(MasterEntity.MWeight)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MWeight=null,");  
  				} 
  
  				UpdateBuilder.Append(" WeightUnit="+SysString.ToDBString(MasterEntity.WeightUnit)+","); 
  				UpdateBuilder.Append(" DtsInVendorID="+SysString.ToDBString(MasterEntity.DtsInVendorID)+","); 
  				UpdateBuilder.Append(" InSO="+SysString.ToDBString(MasterEntity.InSO)+","); 
  				UpdateBuilder.Append(" InOrderFormNo="+SysString.ToDBString(MasterEntity.InOrderFormNo)+","); 
  				 
  				if(MasterEntity.InvoiceQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceQty="+SysString.ToDBString(MasterEntity.InvoiceQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.InvoiceAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceAmount="+SysString.ToDBString(MasterEntity.InvoiceAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InvoiceAmount=null,");  
  				} 
  
  				 
  				if(MasterEntity.PayAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PayAmount="+SysString.ToDBString(MasterEntity.PayAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PayAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" DtsInvoiceDelFlag="+SysString.ToDBString(MasterEntity.DtsInvoiceDelFlag)+","); 
  				UpdateBuilder.Append(" DtsInvoiceDelOPID="+SysString.ToDBString(MasterEntity.DtsInvoiceDelOPID)+","); 
  				 
  				if(MasterEntity.DtsInvoiceDelTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" DtsInvoiceDelTime="+SysString.ToDBString(MasterEntity.DtsInvoiceDelTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DtsInvoiceDelTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" DtsInvoiceNo="+SysString.ToDBString(MasterEntity.DtsInvoiceNo)+","); 
  				 
  				if(MasterEntity.DZQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DZQty="+SysString.ToDBString(MasterEntity.DZQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DZQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.DZSinglePrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DZSinglePrice="+SysString.ToDBString(MasterEntity.DZSinglePrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DZSinglePrice=null,");  
  				} 
  
  				 
  				if(MasterEntity.DZAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DZAmount="+SysString.ToDBString(MasterEntity.DZAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DZAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" DZFlag="+SysString.ToDBString(MasterEntity.DZFlag)+","); 
  				UpdateBuilder.Append(" DZOPID="+SysString.ToDBString(MasterEntity.DZOPID)+","); 
  				 
  				if(MasterEntity.DZTime!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" DZTime="+SysString.ToDBString(MasterEntity.DZTime.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DZTime=null,");  
  				} 
  
  				UpdateBuilder.Append(" DZNo="+SysString.ToDBString(MasterEntity.DZNo)+","); 
  				 
  				if(MasterEntity.FreeNum1!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FreeNum1="+SysString.ToDBString(MasterEntity.FreeNum1)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FreeNum1=null,");  
  				} 
  
  				UpdateBuilder.Append(" DtsOrderFormNo="+SysString.ToDBString(MasterEntity.DtsOrderFormNo)+","); 
  				UpdateBuilder.Append(" InSaleOPID="+SysString.ToDBString(MasterEntity.InSaleOPID)+","); 
  				 
  				if(MasterEntity.Tax!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Tax="+SysString.ToDBString(MasterEntity.Tax)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Tax=null,");  
  				} 
  
  				 
  				if(MasterEntity.TaxAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TaxAmount="+SysString.ToDBString(MasterEntity.TaxAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TaxAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" PackDts="+SysString.ToDBString(MasterEntity.PackDts)+","); 
  				UpdateBuilder.Append(" MLType="+SysString.ToDBString(MasterEntity.MLType)+","); 
  				 
  				if(MasterEntity.DYPrice!=0) 
  				{ 
  			 		UpdateBuilder.Append(" DYPrice="+SysString.ToDBString(MasterEntity.DYPrice)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" DYPrice=null,");  
  				} 
  
  				UpdateBuilder.Append(" DLaodDtsID="+SysString.ToDBString(MasterEntity.DLaodDtsID)+","); 
  				UpdateBuilder.Append(" DLoadFormNo="+SysString.ToDBString(MasterEntity.DLoadFormNo)+","); 
  				UpdateBuilder.Append(" DLoadSubType="+SysString.ToDBString(MasterEntity.DLoadSubType)); 
 
                UpdateBuilder.Append(" WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID));
                
                

               //执行
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(UpdateBuilder.ToString());
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(UpdateBuilder.ToString());
				}
                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBUpdate),E);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="p_Entity">实体类</param>
        /// <returns>操作影响的记录行数</returns>
        public override int Delete(BaseEntity p_Entity)
        {
            try
            {
                YQFormDts MasterEntity=(YQFormDts)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_YQFormDts WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
                //执行
				int AffectedRows=0;
				if(!this.sqlTransFlag)
				{
					AffectedRows=this.ExecuteNonQuery(Sql);
				}
				else
				{
					AffectedRows=sqlTrans.ExecuteNonQuery(Sql);
				}

                return AffectedRows;
            }
            catch(BaseException E)
            {
                throw new BaseException(E.Message,E);
            }
            catch(Exception E)
            {
                throw new BaseException(FrameWorkMessage.GetAlertMessage((int)Message.CommonDBDelete),E);
            }
        }
	}
}
