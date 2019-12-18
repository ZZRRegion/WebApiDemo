/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：WebApiDemo
* 类 名 称：Startup
* 创建日期：2019/12/18 14:25:50
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：Startup
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Controls;
namespace WebApiDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            app.UseWebApi(config);
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
