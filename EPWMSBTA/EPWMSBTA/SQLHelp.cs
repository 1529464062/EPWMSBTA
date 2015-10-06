using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace EPWMSBTA
{
    public class SQLHelp
    {
        /// <summary>
        /// 根据数据库连接字符串，要执行的命令，返回受影响的行数,若是执行成功则返回字符串类型的数字，若是不成功返回异常消息，在使用时先做一遍判断，判断返回值是否是一个数字
        /// </summary>
        /// <param name="sqlConString">数据库连接字符串</param>
        /// <param name="sqlTextString">受影响的行数</param>
        /// <returns>返回消息</returns>
        public string ExecuteNonQuery(string sqlConString, string sqlTextString)
        {
            string result = "";
            try { 
            using (SqlConnection sqlcon = new SqlConnection(sqlConString))
            {
                sqlcon.Open();
                using (SqlCommand sqlcom = new SqlCommand(sqlTextString, sqlcon))
                {
                    result = sqlcom.ExecuteNonQuery().ToString();
                }
                sqlcon.Close();
            }
            }
            catch (Exception e)
            {
                result = "应用程序出现异常:";
                result = result + "\r\n异常消息:" + e.Message + "\r\n异常所在方法名称:" + e.TargetSite;
            }
            return result;
        }
    }
}
