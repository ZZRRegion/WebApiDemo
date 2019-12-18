/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：WebApiDemo.Middlewares
* 类 名 称：LogMiddleware
* 创建日期：2019/12/18 15:37:36
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：LogMiddleware
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using Microsoft.Owin;

namespace WebApiDemo.Middlewares
{
    public class LogMiddleware : Microsoft.Owin.OwinMiddleware
    {
        public LogMiddleware(OwinMiddleware next)
            :base(next)
        {

        }
        public override Task Invoke(IOwinContext context)
        {
            RLog.Add($"{context.Request.RemoteIpAddress}:{context.Request.RemotePort}");
            return this.Next.Invoke(context);

        }
    }
}
