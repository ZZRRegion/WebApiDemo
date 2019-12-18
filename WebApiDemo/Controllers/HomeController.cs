/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：WebApiDemo.Controllers
* 类 名 称：HomeController
* 创建日期：2019/12/18 14:29:51
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：HomeController
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
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class HomeController:ApiController
    {
        public IHttpActionResult Get()
        {
            return this.Json(new Models.HomeModel());
        }
        /// <summary>
        /// 直接从主体中获取值
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]HomeModel model)
        {
            return this.Json(model);
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
