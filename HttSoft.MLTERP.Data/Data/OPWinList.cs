using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Data_OPWinList实体类
	/// 作者:陈加海
	/// 创建日期:2006-12-12
	/// </summary>
	public sealed class OPWinList : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public OPWinList()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public OPWinList(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		 
  		private string m_OPID = string.Empty ; 
  		public string OPID 
  		{ 
  			get 
  			{ 
  				return m_OPID ; 
  			}  
  			set 
  			{ 
  				m_OPID = value ; 
  			}  
  		} 
  
  		private int m_WinListID = 0; 
  		public int WinListID 
  		{ 
  			get 
  			{ 
  				return m_WinListID ; 
  			}  
  			set 
  			{ 
  				m_WinListID = value ; 
  			}  
  		} 
  
  		private int m_HeadTypeID = 0; 
  		public int HeadTypeID 
  		{ 
  			get 
  			{ 
  				return m_HeadTypeID ; 
  			}  
  			set 
  			{ 
  				m_HeadTypeID = value ; 
  			}  
  		} 
  
  		private int m_SubTypeID = 0; 
  		public int SubTypeID 
  		{ 
  			get 
  			{ 
  				return m_SubTypeID ; 
  			}  
  			set 
  			{ 
  				m_SubTypeID = value ; 
  			}  
  		} 
 
		#endregion
		
		/// <summary>
        /// 按ID查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>ID为关键字</remarks>
        public override bool SelectByID()
        {
            string Sql="SELECT * FROM Data_OPWinList WHERE "+ "OPID="+SysString.ToDBString(m_OPID)+" AND WinListID="+SysString.ToDBString(m_WinListID)+" AND HeadTypeID="+SysString.ToDBString(m_HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(m_SubTypeID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Data_OPWinList WHERE "+ "OPID="+SysString.ToDBString(m_OPID)+" AND WinListID="+SysString.ToDBString(m_WinListID)+" AND HeadTypeID="+SysString.ToDBString(m_HeadTypeID)+" AND SubTypeID="+SysString.ToDBString(m_SubTypeID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按传入的SQL语句查询后给属性赋值
        /// </summary>
        /// <param name="p_Sql">SQL语句</param>
        /// <returns>记录存在回true，不存在返回false</returns>
        protected override bool Select(string p_Sql)
        {
            DataTable MasterTable=new DataTable();
            if(!this.sqlTransFlag)
			{
				MasterTable=this.Fill(p_Sql);
			}
			else
			{
				MasterTable=sqlTrans.Fill(p_Sql);
			}
				
            if (MasterTable.Rows.Count>0)
            {
                //查询主表记录
                m_OPID=SysConvert.ToString(MasterTable.Rows[0]["OPID"]); 
  				m_WinListID=SysConvert.ToInt32(MasterTable.Rows[0]["WinListID"]); 
  				m_HeadTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["HeadTypeID"]); 
  				m_SubTypeID=SysConvert.ToInt32(MasterTable.Rows[0]["SubTypeID"]); 
                MasterTable.Dispose();
                return true;
            }
            else
            {
                MasterTable.Dispose();
                return false;
            }
        }
	}
}
