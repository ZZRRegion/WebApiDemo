/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：WebApiDemo.Controllers
* 类 名 称：ControllerBase
* 创建日期：2019/12/18 15:43:36
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：ControllerBase
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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Controls;
namespace WebApiDemo.Controllers
{
    public class ControllerBase:ApiController
    {
        protected IHttpActionResult SendFile(string fileName)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            ByteArrayContent arrayContent = new ByteArrayContent(File.ReadAllBytes(fileName));
            httpResponse.Content = arrayContent;
            return this.ResponseMessage(httpResponse);
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
