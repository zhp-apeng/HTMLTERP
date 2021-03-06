using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using HttSoft.Framework;

namespace HttSoft.MLTERP.Data
{
	/// <summary>
	/// 目的：Finance_CheckOperationInvDts实体类
	/// 作者:章文强
	/// 创建日期:2012/7/30
	/// </summary>
	public sealed class CheckOperationInvDts : BaseEntity
	{
	    private bool sqlTransFlag=false;
		private IDBTransAccess sqlTrans;
		
		public CheckOperationInvDts()
		{
		     
		}
		
		/// <summary>
        /// 构造函数
        /// </summary>
        public CheckOperationInvDts(IDBTransAccess p_SqlCmd)
		{
		    sqlTrans=p_SqlCmd;
			sqlTransFlag=true;
		}
		#region 属性
		public static readonly string TableName = "Finance_CheckOperationInvDts";
		 
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
  
  		private int m_MainID = 0; 
  		public int MainID 
  		{ 
  			get 
  			{ 
  				return m_MainID ; 
  			}  
  			set 
  			{ 
  				m_MainID = value ; 
  			}  
  		} 
  
  		private int m_Seq = 0; 
  		public int Seq 
  		{ 
  			get 
  			{ 
  				return m_Seq ; 
  			}  
  			set 
  			{ 
  				m_Seq = value ; 
  			}  
  		} 
  
  		private string m_DInvoiceNo = string.Empty ; 
  		public string DInvoiceNo 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceNo ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceNo = value ; 
  			}  
  		} 
  
  		private decimal m_DInvoiceQty = 0; 
  		public decimal DInvoiceQty 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceQty ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceQty = value ; 
  			}  
  		} 
  
  		private decimal m_DInvoiceAmount = 0; 
  		public decimal DInvoiceAmount 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceAmount ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceAmount = value ; 
  			}  
  		} 
  
  		private DateTime m_DInvoiceDate = SystemConfiguration.DateTimeDefaultValue; 
  		public DateTime DInvoiceDate 
  		{ 
  			get 
  			{ 
  				return m_DInvoiceDate ; 
  			}  
  			set 
  			{ 
  				m_DInvoiceDate = value ; 
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
            string Sql="SELECT * FROM Finance_CheckOperationInvDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
            return this.Select(Sql);
        }
        
        /// <summary>
        /// 按Code查询
        /// </summary>
        /// <returns>记录存在回true，不存在返回false</returns>
        /// <remarks>Code必须唯一</remarks>
        public override bool SelectByCode()
        {
            string Sql="SELECT * FROM Finance_CheckOperationInvDts WHERE "+ "ID="+SysString.ToDBString(m_ID);
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
  				m_MainID=SysConvert.ToInt32(MasterTable.Rows[0]["MainID"]); 
  				m_Seq=SysConvert.ToInt32(MasterTable.Rows[0]["Seq"]); 
  				m_DInvoiceNo=SysConvert.ToString(MasterTable.Rows[0]["DInvoiceNo"]); 
  				m_DInvoiceQty=SysConvert.ToDecimal(MasterTable.Rows[0]["DInvoiceQty"]); 
  				m_DInvoiceAmount=SysConvert.ToDecimal(MasterTable.Rows[0]["DInvoiceAmount"]); 
  				m_DInvoiceDate=SysConvert.ToDateTime(MasterTable.Rows[0]["DInvoiceDate"]); 
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
