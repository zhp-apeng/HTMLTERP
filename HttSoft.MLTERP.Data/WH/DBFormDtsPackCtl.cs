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
	/// 目的：WH_DBFormDtsPack实体控制类
	/// 作者:周富春
	/// 创建日期:2015/7/27
	/// </summary>
	public sealed class DBFormDtsPackCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public DBFormDtsPackCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public DBFormDtsPackCtl(IDBTransAccess p_SqlCmd)
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
                DBFormDtsPack MasterEntity=(DBFormDtsPack)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO WH_DBFormDtsPack(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("ID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.ID)+","); 
  				MasterField.Append("MainID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.MainID)+","); 
  				MasterField.Append("Seq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Seq)+","); 
  				MasterField.Append("SubSeq"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				MasterField.Append("PackNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.PackNo)+","); 
  				MasterField.Append("BoxNo"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.BoxNo)+","); 
  				MasterField.Append("Qty"+","); 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("FactQty"+","); 
  				if(MasterEntity.FactQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.FactQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("PDQty"+","); 
  				if(MasterEntity.PDQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.PDQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("Remark"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Remark)+","); 
  				MasterField.Append("DID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.DID)+","); 
  				MasterField.Append("Unit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.Unit)+","); 
  				MasterField.Append("InputQty"+","); 
  				if(MasterEntity.InputQty!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputQty)+","); 
  				} 
  				else 
  				{ 
  			 		MasterValue.Append("null,"); 
  				} 
  
  				MasterField.Append("InputUnit"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.InputUnit)+","); 
  				MasterField.Append("InputConvertXS"+")"); 
  				if(MasterEntity.InputConvertXS!=0) 
  				{ 
  			 		MasterValue.Append(SysString.ToDBString(MasterEntity.InputConvertXS)+")"); 
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
                DBFormDtsPack MasterEntity=(DBFormDtsPack)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE WH_DBFormDtsPack SET ");
                UpdateBuilder.Append(" ID="+SysString.ToDBString(MasterEntity.ID)+","); 
  				UpdateBuilder.Append(" MainID="+SysString.ToDBString(MasterEntity.MainID)+","); 
  				UpdateBuilder.Append(" Seq="+SysString.ToDBString(MasterEntity.Seq)+","); 
  				UpdateBuilder.Append(" SubSeq="+SysString.ToDBString(MasterEntity.SubSeq)+","); 
  				UpdateBuilder.Append(" PackNo="+SysString.ToDBString(MasterEntity.PackNo)+","); 
  				UpdateBuilder.Append(" BoxNo="+SysString.ToDBString(MasterEntity.BoxNo)+","); 
  				 
  				if(MasterEntity.Qty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" Qty="+SysString.ToDBString(MasterEntity.Qty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" Qty=null,");  
  				} 
  
  				 
  				if(MasterEntity.FactQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" FactQty="+SysString.ToDBString(MasterEntity.FactQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" FactQty=null,");  
  				} 
  
  				 
  				if(MasterEntity.PDQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" PDQty="+SysString.ToDBString(MasterEntity.PDQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" PDQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" Remark="+SysString.ToDBString(MasterEntity.Remark)+","); 
  				UpdateBuilder.Append(" DID="+SysString.ToDBString(MasterEntity.DID)+","); 
  				UpdateBuilder.Append(" Unit="+SysString.ToDBString(MasterEntity.Unit)+","); 
  				 
  				if(MasterEntity.InputQty!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputQty="+SysString.ToDBString(MasterEntity.InputQty)+","); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputQty=null,");  
  				} 
  
  				UpdateBuilder.Append(" InputUnit="+SysString.ToDBString(MasterEntity.InputUnit)+","); 
  				 
  				if(MasterEntity.InputConvertXS!=0) 
  				{ 
  			 		UpdateBuilder.Append(" InputConvertXS="+SysString.ToDBString(MasterEntity.InputConvertXS)); 
  				} 
  				else 
  				{ 
  			 		UpdateBuilder.Append(" InputConvertXS=null");  
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
                DBFormDtsPack MasterEntity=(DBFormDtsPack)p_Entity;
                if (MasterEntity.ID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM WH_DBFormDtsPack WHERE "+ "ID="+SysString.ToDBString(MasterEntity.ID);
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
