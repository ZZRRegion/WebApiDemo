/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：WebApiDemo
* 类 名 称：RLog
* 创建日期：2019/12/18 15:40:15
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：RLog
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
namespace WebApiDemo
{
    public static class RLog
    {
        public static string FileName { get; set; } = "record.log";
        static RLog()
        {
            FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
        }
        public static void Add(string log)
        {
            log = $"{DateTime.Now}{Environment.NewLine}{log}{Environment.NewLine}";
            try
            {
                if (File.Exists(FileName))
                {
                    FileInfo fi = new FileInfo(FileName);
                    if(fi.Length > 1024 * 100)
                    {
                        fi.Delete();
                    }
                }
                File.AppendAllText(FileName, log);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #region 构造函数
        #endregion
        #region Variables
        #endregion
        #region private Variables
        #endregion
        #region Methods
        #endregion
        #region private Methods
        #endregion
        #region Event
        #endregion
    }
}
