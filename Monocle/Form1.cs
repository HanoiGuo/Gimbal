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

/************************************************************************/
//List
using System.Collections.Generic;
/************************************************************************/

namespace Monocle
{
    public partial class Form1 : Form
    {
        int returnValue = 0;
        string sErrorMessage;
        ResourceManager resourceManager;
        int err = 0;
        int iRadionIndex = 1;          //选择哪一轴运动
        Thread startTestThread = null; //点击Test buttopn启动的线程
        bool bStartTestFlag = false;   //BeamProfiler开始启动测试
        List<double> totalData = new List<double>(); //BeamProfiler的power total
        List<double> averageData = new List<double>();//BeamProfiler的power average
        List<double> peakData = new List<double>();   //BeamProfiler的power peak
        List<double> PowerMeterData = new List<double>();//Power meter的power
        int iBeamProfilerExp = 0;  //BeamProfiler的曝光时间
  


        public Form1()
        {
            InitializeComponent();
            InitialUI();

            //1:链接HXP controler
            
        }

        public void ShowErrorMessage(string error)
        {
            //MessageBox.Show(error);
            this.ShowMessage.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
            this.ShowMessage.Text = error;
            //this.labelNotice.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);

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
            switch(iReturn)
            {
                case -116:
                    strDealFunctionValue = "OPEN_CONFIGFILE_FAIL";
                    break;
                case -117:
                    strDealFunctionValue = "CONNECT_TCP_FAIL";
                    break;
            }
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
            TestFunctionTimer.Start();
            X_Radio.Checked = true;
            LoadConfigFile();

            //1:X
            X_Start.Text = "0";
            X_Step.Text = "0";
            X_End.Text = "0";

            //1:Y
            Y_Start.Text = "0";
            Y_Step.Text = "0";
            Y_End.Text = "0";

            //1:Z
            Z_Start.Text = "0";
            Z_Step.Text = "0";
            Z_End.Text = "0";

            //1:U
            U_Start.Text = "0";
            U_Step.Text = "0";
            U_End.Text = "0";

            //1:V
            V_Start.Text = "0";
            V_Step.Text = "0";
            V_End.Text = "0";

            //1:W
            W_Start.Text = "0";
            W_Step.Text = "0";
            W_End.Text = "0";

            for(int i=0; i<10; i++)
            {
                totalData.Add(i*3);
                averageData.Add(i * 2);
                peakData.Add(i);
                PowerMeterData.Add(i * 4);
            }
            DrawChart(0, totalData, averageData, peakData, PowerMeterData);
            DrawChart(1, totalData, averageData, peakData, PowerMeterData);


            Bitmap bitmap = Monocle.Properties.Resources.heatmap;
            BeamProfilerImage.Image = bitmap;

            EnableControls(false);
        }

#endregion


#region 启动测试
        /************************************************************************/
        //点击按钮连接6轴控制器
        /************************************************************************/
        private void StartTest_Click(object sender, EventArgs e)
        {
            err = CPPDLL.Entrance_Connect_TCP();
            if(err != 0)
            {
                DealFunctionReturnValue(err);
                EnableControls(false);
                return;
            }
            EnableControls(true);
        }  
#endregion

        /************************************************************************/
        /* 停止测试                                                             */
        /************************************************************************/
        private void StopTest_Click(object sender, EventArgs e)
        {
            //this.labelNotice.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
        }

        /************************************************************************/
        /* LOAD UI的一些东西
        /************************************************************************/
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /************************************************************************/
        //启动6轴控制的Debug界面
        /************************************************************************/
        private void View_Click(object sender, EventArgs e)
        {
            CPPDLL.ShowDlg();
        }


        /************************************************************************/
        //开始BemaProfiler的测试
        /************************************************************************/
        private void TestStart_Click(object sender, EventArgs e)
        {
            TestStart.Enabled = false;
            TestStart.Text = "Wait......I am testing!";
            bStartTestFlag = true;
            //开启线程
            if (startTestThread == null)
            {
                startTestThread = new Thread(new ThreadStart(ThreadFunctionTest));
                startTestThread.IsBackground = true;
                startTestThread.Start();
            }            
        }

        /************************************************************************/
        /* 清掉测试值                                                           */
        /************************************************************************/
        private void Clear_Value()
        {
            Power_Total.Text = "";
            Power_Min.Text = "";
            Power_Peak.Text = "";

        }

        /************************************************************************/
        /* 获取选择的Radion index                                               */
        /************************************************************************/
        private void GetRadioIndex(object sender, EventArgs e)
        {
           if(X_Radio.Checked == true)
           {
               iRadionIndex = 1;

           }
           else if(Y_Radio.Checked == true)
           {
               iRadionIndex = 2;
           }
           else if (Z_Radio.Checked == true)
           {
               iRadionIndex = 3;
           }
           else if (U_Radio.Checked == true)
           {
               iRadionIndex = 4;
           }
           else if (V_Radio.Checked == true)
           {
               iRadionIndex = 5;
           }
           else if (W_Radio.Checked == true)
           {
               iRadionIndex = 6;
           }           
        }

        private void GoHomeBtn_Click(object sender, EventArgs e)
        {

            totalData.Clear();
            averageData.Clear();
            peakData.Clear();
            PowerMeterData.Clear();
            for(int i=0; i<10; i++)
            {
                totalData.Add(i * 0.1);
                averageData.Add(i * 0.2);
                peakData.Add(i * 0.3);
                PowerMeterData.Add(i * 0.5);
            }

            
            DrawChart(1, totalData, averageData, peakData, PowerMeterData);
            
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            DrawImage("E:\\项目\\LCD\\My Images\\baise.png");
        }

        private int TestFunction(double min, double step, double max)
        {

            return 0;
        }

        /************************************************************************/
        //绘制曲线图
        //mode = 0 BeamProfiler mode =1:power meter
        /************************************************************************/
        private int DrawChart(int moode,List<double> totalData,List<double>averageData,List<double>peakData,List<double>PowerMeterData)
        {
            if(moode == 0)
            {
                int num = totalData.Count;
                //clear the chart data
                BeamProfilerChart.Series.Clear();
                Series totalSeries = new Series("TotalPower");
                Series avreageSeries = new Series("AveragePower");
                Series peakSeries = new Series("PeakPower");
                totalSeries.ChartType = SeriesChartType.Spline;
                avreageSeries.ChartType = SeriesChartType.Spline;
                peakSeries.ChartType = SeriesChartType.Spline;
                totalSeries.IsValueShownAsLabel = true;
                avreageSeries.IsValueShownAsLabel = true;
                peakSeries.IsValueShownAsLabel = true;
                totalSeries.MarkerSize = 10;
                avreageSeries.MarkerSize = 10;
                peakSeries.MarkerSize = 10;
                totalSeries.MarkerStyle = MarkerStyle.Circle;
                avreageSeries.MarkerStyle = MarkerStyle.Circle;
                peakSeries.MarkerStyle = MarkerStyle.Circle;

                //totalSeries.Points.AddXY(0, 1);
                for (int i = 0; i < num; i++)
                {
                    totalSeries.Points.AddXY(i, totalData[i]);
                    avreageSeries.Points.AddXY(i, averageData[i]);
                    peakSeries.Points.AddXY(i, peakData[i]);
                }

                BeamProfilerChart.Series.Add(totalSeries);
                BeamProfilerChart.Series.Add(avreageSeries);
                BeamProfilerChart.Series.Add(peakSeries);
            }
            else
            {
                int num = PowerMeterData.Count;
                //clear the chart data
                PowerMeterChart.Series.Clear();
                Series powermeterSeries = new Series("Power");
                powermeterSeries.IsValueShownAsLabel = true;
                powermeterSeries.MarkerSize = 10;
                powermeterSeries.MarkerStyle = MarkerStyle.Circle;
                for (int i = 0; i < num; i++)
                {
                    powermeterSeries.Points.AddXY(i, PowerMeterData[i]);
                }
                PowerMeterChart.Series.Add(powermeterSeries);
            }
            return 0;
        }


        /************************************************************************/
        //绘制图像
        /************************************************************************/
        private void DrawImage(string imagePath)
        {
            //load图像到UI上面
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            this.BeamProfilerImage.Image = Image.FromStream(fileStream);
            fileStream.Close();
            fileStream.Dispose();
        }

        /************************************************************************/
        //开启线程开始测试
        /************************************************************************/
        public void ThreadFunctionTest()
        {
            while(true)
            {
                if(bStartTestFlag == false)
                {
                    Thread.Sleep(1000);
                    continue;
                }
                //1:clear the UI value
                Clear_Value();

                //2:get the value
                double move_min = 0;
                double move_step = 0;
                double move_max = 0;
                string strTempMin = "", strTempStep = "", strTempMax = "";
                switch (iRadionIndex)
                {
                    case 1:
                        //min
                        strTempMin = X_Start.Text;
                        //step
                        strTempStep = X_Step.Text;
                        //max
                        strTempMax = X_End.Text;
                        break;
                    case 2:
                        //min
                        strTempMin = Y_Start.Text;
                        //step
                        strTempStep = Y_Step.Text;
                        //max
                        strTempMax = Y_End.Text;
                        break;
                    case 3:
                        //min
                        strTempMin = Z_Start.Text;
                        //step
                        strTempStep = Z_Step.Text;
                        //max
                        strTempMax = Z_End.Text;
                        break;
                    case 4:
                        //min
                        strTempMin = U_Start.Text;
                        //step
                        strTempStep = U_Step.Text;
                        //max
                        strTempMax = U_End.Text;
                        break;
                    case 5:
                        //min
                        strTempMin = V_Start.Text;
                        //step
                        strTempStep = V_Step.Text;
                        //max
                        strTempMax = V_End.Text;
                        break;
                    case 6:
                        //min
                        strTempMin = W_Start.Text;
                        //step
                        strTempStep = W_Step.Text;
                        //max
                        strTempMax = W_End.Text;
                        break;
                }
                if (strTempMin.Length != 0)
                {
                    move_min = Convert.ToDouble(strTempMin);
                }
                else
                {
                    move_min = 0;
                }

                if (strTempStep.Length != 0)
                {
                    move_step = Convert.ToDouble(strTempStep);
                }
                else
                {
                    move_step = 0;
                }

                if (strTempMax.Length != 0)
                {
                    move_max = Convert.ToDouble(strTempMax);
                }
                else
                {
                    move_max = 0;
                }

                string test;
                test = move_max.ToString();
                MessageBox.Show(test);
                bStartTestFlag = false;
                
            }
        }

        private void TestFunctionTimer_Tick(object sender, EventArgs e)
        {
            TestFunctionTimer.Stop();
            if(bStartTestFlag == false)
            {
                TestStart.Enabled = true;
                TestStart.Text = "BeamProfiler Test";
            }
            TestFunctionTimer.Start();
        }


        private void EnableControls(bool state)
        {
            MotionGroup.Enabled = state;
            PowerMeterGroup.Enabled = state;
            ManualDebug.Enabled = state;
            PowerMeterGroup.Enabled = state;
        }


        /************************************************************************/
        //power meter测试
        /************************************************************************/
        private void PowerMeterBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
