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
	/// 目的：WO_PrintingProcess实体控制类
	/// 作者:翟晓东
	/// 创建日期:2012/8/29
	/// </summary>
	public sealed class PrintingProcessCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public PrintingProcessCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public PrintingProcessCtl(IDBTransAccess p_SqlCmd)
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
                PrintingProcess MasterEntity=(PrintingProcess)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WO_PrintingProcess(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("FormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.FormNo)+","); 
  				MasterField.Append("MakeOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				MasterField.Append("MakeOPName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				MasterField.Append("MakeDate"+","); 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("CheckOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				MasterField.Append("CheckDate"+","); 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("SubmitFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				MasterField.Append("DelFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				MasterField.Append("FormDate"+","); 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("VendorID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorID)+","); 
  				MasterField.Append("CustomerCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.CustomerCode)+","); 
  				MasterField.Append("OrderTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderTypeID)+","); 
  				MasterField.Append("OrderLevelID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderLevelID)+","); 
  				MasterField.Append("OrderDate"+","); 
  				if(MasterEntity.OrderDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("ReqDate"+","); 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OrderFormNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("PayMethodID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayMethodID)+","); 
  				MasterField.Append("PayMethodFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PayMethodFlag)+","); 
  				MasterField.Append("ContractDesc"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ContractDesc)+","); 
  				MasterField.Append("TotalQty"+","); 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("TotalAmount"+","); 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OrderPreStepID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderPreStepID)+","); 
  				MasterField.Append("OrderStepID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.OrderStepID)+","); 
  				MasterField.Append("StatusFlag"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StatusFlag)+","); 
  				MasterField.Append("StatusName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.StatusName)+","); 
  				MasterField.Append("WLAmountType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WLAmountType)+","); 
  				MasterField.Append("WLAmount"+","); 
  				if(MasterEntity.WLAmount!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.WLAmount)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("DyeFactorty"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DyeFactorty)+","); 
  				MasterField.Append("Pattern"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Pattern)+","); 
  				MasterField.Append("VendorPattern"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.VendorPattern)+","); 
  				MasterField.Append("NetCode"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.NetCode)+","); 
  				MasterField.Append("PrintingType"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintingType)+","); 
  				MasterField.Append("PrintingDBColorNum"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintingDBColorNum)+","); 
  				MasterField.Append("PrintingDBColorName"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintingDBColorName)+","); 
  				MasterField.Append("SendAddress"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SendAddress)+","); 
  				MasterField.Append("PrintingTec"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintingTec)+","); 
  				MasterField.Append("PrintingReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PrintingReq)+","); 
  				MasterField.Append("SGReq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SGReq)+","); 
  				MasterField.Append("SaleOPID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				MasterField.Append("NLQty"+","); 
  				if(MasterEntity.NLQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NLQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("NLFormDate"+","); 
  				if(MasterEntity.NLFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.NLFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InQty"+","); 
  				if(MasterEntity.InQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InFormDate"+","); 
  				if(MasterEntity.InFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OutQty"+","); 
  				if(MasterEntity.OutQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OutQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("OutFormDate"+")"); 
  				if(MasterEntity.OutFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.OutFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+")"); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null)"); 
  				} 
  
 
                
                

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
                PrintingProcess MasterEntity=(PrintingProcess)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WO_PrintingProcess SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" FormNo="+SysString.ToDBString(MasterEntity.FormNo)+","); 
  				UpdateBuilder.Append(" MakeOPID="+SysString.ToDBString(MasterEntity.MakeOPID)+","); 
  				UpdateBuilder.Append(" MakeOPName="+SysString.ToDBString(MasterEntity.MakeOPName)+","); 
  				 
  				if(MasterEntity.MakeDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate="+SysString.ToDBString(MasterEntity.MakeDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" MakeDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" CheckOPID="+SysString.ToDBString(MasterEntity.CheckOPID)+","); 
  				 
  				if(MasterEntity.CheckDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate="+SysString.ToDBString(MasterEntity.CheckDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" CheckDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" SubmitFlag="+SysString.ToDBString(MasterEntity.SubmitFlag)+","); 
  				UpdateBuilder.Append(" DelFlag="+SysString.ToDBString(MasterEntity.DelFlag)+","); 
  				 
  				if(MasterEntity.FormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" FormDate="+SysString.ToDBString(MasterEntity.FormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FormDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" VendorID="+SysString.ToDBString(MasterEntity.VendorID)+","); 
  				UpdateBuilder.Append(" CustomerCode="+SysString.ToDBString(MasterEntity.CustomerCode)+","); 
  				UpdateBuilder.Append(" OrderTypeID="+SysString.ToDBString(MasterEntity.OrderTypeID)+","); 
  				UpdateBuilder.Append(" OrderLevelID="+SysString.ToDBString(MasterEntity.OrderLevelID)+","); 
  				 
  				if(MasterEntity.OrderDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" OrderDate="+SysString.ToDBString(MasterEntity.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OrderDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.ReqDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate="+SysString.ToDBString(MasterEntity.ReqDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" ReqDate=null,");  
  				} 
  
  				UpdateBuilder.Append(" OrderFormNo="+SysString.ToDBString(MasterEntity.OrderFormNo)+","); 
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" PayMethodID="+SysString.ToDBString(MasterEntity.PayMethodID)+","); 
  				UpdateBuilder.Append(" PayMethodFlag="+SysString.ToDBString(MasterEntity.PayMethodFlag)+","); 
  				UpdateBuilder.Append(" ContractDesc="+SysString.ToDBString(MasterEntity.ContractDesc)+","); 
  				 
  				if(MasterEntity.TotalQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty="+SysString.ToDBString(MasterEntity.TotalQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.TotalAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount="+SysString.ToDBString(MasterEntity.TotalAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" TotalAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" OrderPreStepID="+SysString.ToDBString(MasterEntity.OrderPreStepID)+","); 
  				UpdateBuilder.Append(" OrderStepID="+SysString.ToDBString(MasterEntity.OrderStepID)+","); 
  				UpdateBuilder.Append(" StatusFlag="+SysString.ToDBString(MasterEntity.StatusFlag)+","); 
  				UpdateBuilder.Append(" StatusName="+SysString.ToDBString(MasterEntity.StatusName)+","); 
  				UpdateBuilder.Append(" WLAmountType="+SysString.ToDBString(MasterEntity.WLAmountType)+","); 
  				 
  				if(MasterEntity.WLAmount!=0) 
  				{ 
  			 		UpdateBuilder.Append(" WLAmount="+SysString.ToDBString(MasterEntity.WLAmount)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" WLAmount=null,");  
  				} 
  
  				UpdateBuilder.Append(" DyeFactorty="+SysString.ToDBString(MasterEntity.DyeFactorty)+","); 
  				UpdateBuilder.Append(" Pattern="+SysString.ToDBString(MasterEntity.Pattern)+","); 
  				UpdateBuilder.Append(" VendorPattern="+SysString.ToDBString(MasterEntity.VendorPattern)+","); 
  				UpdateBuilder.Append(" NetCode="+SysString.ToDBString(MasterEntity.NetCode)+","); 
  				UpdateBuilder.Append(" PrintingType="+SysString.ToDBString(MasterEntity.PrintingType)+","); 
  				UpdateBuilder.Append(" PrintingDBColorNum="+SysString.ToDBString(MasterEntity.PrintingDBColorNum)+","); 
  				UpdateBuilder.Append(" PrintingDBColorName="+SysString.ToDBString(MasterEntity.PrintingDBColorName)+","); 
  				UpdateBuilder.Append(" SendAddress="+SysString.ToDBString(MasterEntity.SendAddress)+","); 
  				UpdateBuilder.Append(" PrintingTec="+SysString.ToDBString(MasterEntity.PrintingTec)+","); 
  				UpdateBuilder.Append(" PrintingReq="+SysString.ToDBString(MasterEntity.PrintingReq)+","); 
  				UpdateBuilder.Append(" SGReq="+SysString.ToDBString(MasterEntity.SGReq)+","); 
  				UpdateBuilder.Append(" SaleOPID="+SysString.ToDBString(MasterEntity.SaleOPID)+","); 
  				 
  				if(MasterEntity.NLQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" NLQty="+SysString.ToDBString(MasterEntity.NLQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NLQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.NLFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" NLFormDate="+SysString.ToDBString(MasterEntity.NLFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" NLFormDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.InQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InQty="+SysString.ToDBString(MasterEntity.InQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.InFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" InFormDate="+SysString.ToDBString(MasterEntity.InFormDate.ToString("yyyy-MM-dd HH:mm:ss"))+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InFormDate=null,");  
  				} 
  
  				 
  				if(MasterEntity.OutQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" OutQty="+SysString.ToDBString(MasterEntity.OutQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OutQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.OutFormDate!=SystemConfiguration.DateTimeDefaultValue) 
  				{ 
  			 		UpdateBuilder.Append(" OutFormDate="+SysString.ToDBString(MasterEntity.OutFormDate.ToString("yyyy-MM-dd HH:mm:ss"))); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" OutFormDate=null");  
  				} 
  
 
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
                PrintingProcess MasterEntity=(PrintingProcess)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WO_PrintingProcess WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
