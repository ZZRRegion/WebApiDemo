/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：WebApiDemo.Models
* 类 名 称：ComputerModel
* 创建日期：2019/12/19 18:52:50
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：ComputerModel
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
namespace WebApiDemo.Models
{
    public class ComputerModel:INotifyPropertyChanged
    {
        private string cpu;
        public string CPU
        {
            get => this.cpu;
            set => this.OnPropertyChanged(ref this.cpu, value);
        }
        private string cputem;
        /// <summary>
        /// CPU温度
        /// </summary>
        public string CPUTem
        {
            get => this.cputem;
            set => this.OnPropertyChanged(ref this.cputem, value);
        }
        private string ram;
        public string RAM
        {
            get => this.ram;
            set => this.OnPropertyChanged(ref this.ram, value);
        }
        private void OnPropertyChanged<T>(ref T property, T value, [CallerMemberName]string propertyName = "")
        {
            property = value;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
