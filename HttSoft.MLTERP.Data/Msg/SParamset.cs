using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：SMS_SParamset实体类
	/// 作者:章文强
	/// 创建日期:2012/7/11
	/// </summary>
	public sealed class SParamset : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public SParamset()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public SParamset(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "SMS_SParamset";
		 
  		private int m_ID = 0; 
  		public int ID 
  		{ 
  			get 
  			{ 
  				return m_ID ; 
  			}  
  			set 
  			{ 
  				m_ID = value ; 
  			}  
  		} 
  
  		private string m_Code = string.Empty ; 
  		public string Code 
  		{ 
  			get 
  			{ 
  				return m_Code ; 
  			}  
  			set 
  			{ 
  				m_Code = value ; 
  			}  
  		} 
  
  		private string m_Name = string.Empty ; 
  		public string Name 
  		{ 
  			get 
  			{ 
  				return m_Name ; 
  			}  
  			set 
  			{ 
  				m_Name = value ; 
  			}  
  		} 
  
  		private string m_SetValueStr = string.Empty ; 
  		public string SetValueStr 
  		{ 
  			get 
  			{ 
  				return m_SetValueStr ; 
  			}  
  			set 
  			{ 
  				m_SetValueStr = value ; 
  			}  
  		} 
  
  		private int m_SetValueInt = 0; 
  		public int SetValueInt 
  		{ 
  			get 
  			{ 
  				return m_SetValueInt ; 
  			}  
  			set 
  			{ 
  				m_SetValueInt = value ; 
  			}  
  		} 
  
  		private DateTime m_SetValueDt = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime SetValueDt 
  		{ 
  			get 
  			{ 
  				return m_SetValueDt ; 
  			}  
  			set 
  			{ 
  				m_SetValueDt = value ; 
  			}  
  		} 
  
  		private string m_Remark = string.Empty ; 
  		public string Remark 
  		{ 
  			get 
  			{ 
  				return m_Remark ; 
  			}  
  			set 
  			{ 
  				m_Remark = value ; 
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
            string Sql="SELECT * FROM SMS_SParamset WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM SMS_SParamset WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
                m_ID=SysConvert.ToInt32(MasterTable.Rows[0]["ID"]); 
  				m_Code=SysConvert.ToString(MasterTable.Rows[0]["Code"]); 
  				m_Name=SysConvert.ToString(MasterTable.Rows[0]["Name"]); 
  				m_SetValueStr=SysConvert.ToString(MasterTable.Rows[0]["SetValueStr"]); 
  				m_SetValueInt=SysConvert.ToInt32(MasterTable.Rows[0]["SetValueInt"]); 
  				m_SetValueDt=SysConvert.ToDateTime(MasterTable.Rows[0]["SetValueDt"]); 
  				m_Remark=SysConvert.ToString(MasterTable.Rows[0]["Remark"]); 
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
