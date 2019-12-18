/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：WebApiDemo.Controllers
* 类 名 称：LogController
* 创建日期：2019/12/18 15:43:13
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：LogController
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
using System.Web.Http;
using System.Windows.Controls;
namespace WebApiDemo.Controllers
{
    public class LogController:ControllerBase
    {
        public IHttpActionResult Get()
        {
            if (File.Exists(RLog.FileName))
            {
                return this.SendFile(RLog.FileName);
            }
            return this.Content(System.Net.HttpStatusCode.NotFound, "文件不存在");
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
