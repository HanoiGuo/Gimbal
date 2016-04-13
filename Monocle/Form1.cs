using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//FileStream
using System.Timers;

/************************************************************************/
//多语言
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
/************************************************************************/

/************************************************************************/
//Chart
using System.Windows.Forms.DataVisualization.Charting;
/************************************************************************/


namespace Monocle
{
    public partial class Form1 : Form
    {
        int returnValue = 0;
        string sErrorMessage;
        ResourceManager resourceManager;

        //public delegate void UpdateUI();//采用委托，在线程里面跟新UI界面

        public Form1()
        {
            InitializeComponent();
            InitialUI();
        }

        public void ShowErrorMessage(string error)
        {
            //MessageBox.Show(error);
            this.ShowMessage.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
            this.ShowMessage.Text = error;
            this.labelNotice.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);

        }


#region  LOAD配置文件
        public void LoadConfigFile()
        {

        }

#endregion

        //处理函数返回值函数
        void DealFunctionReturnValue(int iReturn)
        {
            String strDealFunctionValue = "";
            ShowErrorMessage(strDealFunctionValue);
        }


        /************************************************************************/
        /* 配置编辑框的是否能够编辑                                             */
        /************************************************************************/
        public void ControlsStatus(bool state)
        {
          
        }


        public void UpdateUI()
        {

        }
#region 初始化UI
        /************************************************************************/
        /* 初始化UI                                                             */
        /************************************************************************/
        public void InitialUI()
        {
            //Bitmap bitmap = Monocle.Properties.Resources.Initial;
            //this.showPicture.Image = bitmap;
            //resourceManager = new ResourceManager("Monocle.Resource.ResourceChina", Assembly.GetExecutingAssembly());

            LoadConfigFile(); 
        }

#endregion


#region 启动测试
        /************************************************************************/
        /* 启动自动测试                                                         */
        /************************************************************************/
        private void StartTest_Click(object sender, EventArgs e)
        {
            CPPDLL.ShowDlg();
        }  
#endregion

        /************************************************************************/
        /* 停止测试                                                             */
        /************************************************************************/
        private void StopTest_Click(object sender, EventArgs e)
        {
            this.labelNotice.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
        }

        /************************************************************************/
        /* LOAD UI的一些东西
        /************************************************************************/
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /************************************************************************/
        /* 预览画面                                                             */
        //用户可以启动相机，获取相机的值，显示在界面上
        /************************************************************************/
        private void View_Click(object sender, EventArgs e)
        {
            BeamProfiler test = new BeamProfiler();
            test.Run();
        }
    }
}
