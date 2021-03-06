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
	/// 目的：Data_AuthGrpWinList实体控制类
	/// 作者:周富春
	/// 创建日期:2012-4-24
	/// </summary>
	public sealed class AuthGrpWinListCtl : BaseControl
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
	    /// <summary>
        /// 构造函数
        /// </summary>
        public AuthGrpWinListCtl()
		{
		    
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public AuthGrpWinListCtl(IDBTransAccess p_SqlCmd)
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
                AuthGrpWinList MasterEntity=(AuthGrpWinList)p_Entity;
                if (MasterEntity.AuthGrpID==0)
                {
                    return 0;
                }

                //新增主表数据
                StringBuilder MasterField=new StringBuilder();
                StringBuilder MasterValue=new StringBuilder();
                MasterField.Append("INSERT INTO Data_AuthGrpWinList(");
                MasterValue.Append(" VALUES(");
                MasterField.Append("AuthGrpID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.AuthGrpID)+","); 
  				MasterField.Append("WinListID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.WinListID)+","); 
  				MasterField.Append("HeadTypeID"+","); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.HeadTypeID)+","); 
  				MasterField.Append("SubTypeID"+")"); 
  				MasterValue.Append(SysString.ToDBString(MasterEntity.SubTypeID)+")"); 
 
                
                

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
                AuthGrpWinList MasterEntity=(AuthGrpWinList)p_Entity;
                if (MasterEntity.AuthGrpID==0)
                {
                    return 0;
                }

                //更新主表数据
                StringBuilder UpdateBuilder=new StringBuilder();
                UpdateBuilder.Append("UPDATE Data_AuthGrpWinList SET ");
                UpdateBuilder.Append(" AuthGrpID="+SysString.ToDBString(MasterEntity.AuthGrpID)+","); 
  				UpdateBuilder.Append(" WinListID="+SysString.ToDBString(MasterEntity.WinListID)+","); 
  				UpdateBuilder.Append(" HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+","); 
  				UpdateBuilder.Append(" SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID)); 
 
                UpdateBuilder.Append(" WHERE "+ "AuthGrpID="+SysString.ToDBString(MasterEntity.AuthGrpID)+" AND WinListID="+SysString.ToDBString(MasterEntity.WinListID)+" AND HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID));
                
                

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
                AuthGrpWinList MasterEntity=(AuthGrpWinList)p_Entity;
                if (MasterEntity.AuthGrpID==0)
                {
                    return 0;
                }

                //删除主表数据
                string Sql="";
                Sql="DELETE FROM Data_AuthGrpWinList WHERE "+ "AuthGrpID="+SysString.ToDBString(MasterEntity.AuthGrpID)+" AND WinListID="+SysString.ToDBString(MasterEntity.WinListID)+" AND HeadTypeID="+SysString.ToDBString(MasterEntity.HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(MasterEntity.SubTypeID);
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
