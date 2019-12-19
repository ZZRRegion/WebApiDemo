/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：WebApiDemo.Middlewares
* 类 名 称：ComputerMiddleware
* 创建日期：2019/12/19 18:35:09
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：ComputerMiddleware
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using Microsoft.Owin;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using WebApiDemo.Models;

namespace WebApiDemo.Middlewares
{
    public class ComputerMiddleware : OwinMiddleware
    {
        private Computer computer;
        private UpdateVisitor updateVisitor;
        private System.Windows.Threading.DispatcherTimer timer;
        private ComputerModel model = new ComputerModel();
        public ComputerMiddleware(OwinMiddleware next)
            :base(next)
        {
            this.updateVisitor = new UpdateVisitor();
            this.computer = new Computer();
            this.computer.CPUEnabled = true;
            this.computer.RAMEnabled = true;
            this.computer.HDDEnabled = true;
            this.computer.Open();
            this.timer = new System.Windows.Threading.DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1);
            this.timer.Tick += Timer_Tick;
            this.timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.computer.Accept(this.updateVisitor);
            try
            {
                for (int i = 0; i < computer.Hardware.Length; i++)
                {
                    if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                            {
                                float CPUTem = (float)computer.Hardware[i].Sensors[j].Value;
                                this.model.CPUTem = CPUTem.ToString() + "℃";
                            }

                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Load)
                            {
                                float CPULoad = (float)computer.Hardware[i].Sensors[j].Value;
                                this.model.CPU = Math.Round(CPULoad, 1).ToString() + "%";
                            }
                        }
                    }

                    if (computer.Hardware[i].HardwareType == HardwareType.RAM)
                    {
                        for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                        {
                            if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Load)
                            {
                                double RAMsyl = (double)computer.Hardware[i].Sensors[j].Value;
                                this.model.RAM = Math.Round(RAMsyl, 1).ToString() + " %";
                            }
                        }
                    }
                }
            }
            catch { }
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
        public override Task Invoke(IOwinContext context)
        {
            if(context.Request.Uri.LocalPath == "/computer")
            {
                context.Response.ContentType = "application/json";
                string result = Newtonsoft.Json.JsonConvert.SerializeObject(this.model);
                context.Response.Write(result);
                return Task.FromResult(0);
            }
            return this.Next.Invoke(context);
        }
    }
    public class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }

        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware)
                subHardware.Accept(this);
        }

        public void VisitSensor(ISensor sensor) { }

        public void VisitParameter(IParameter parameter) { }

    }
    
}
