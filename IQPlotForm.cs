using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Pipes;
using System.IO;
using System.Diagnostics;

namespace IQPlot
{
    public partial class IQPlotForm : Form
    {

        public IQPlotForm()
        {
            InitializeComponent();
        }
        private enum SourceFrom
        {
            None,
            UART,
            NamedPipe,
        };
        private SourceFrom dataSource = SourceFrom.NamedPipe;


        private const int WorkerCount = 2;
        private SkytraqGps[] gps = new SkytraqGps[WorkerCount];
        private void IQPlotForm_Load(object sender, EventArgs e)
        {
            //this.Text = Program.Port + " " + Program.BaudRate.ToString();
            gps[0] = new SkytraqGps();
            InitBackgroundWorker();

            if (dataSource == SourceFrom.UART)
            {
                GPS_RESPONSE rep = gps[0].Open(Program.Port, GpsBaudRateConverter.BaudRate2Index(Program.BaudRate));
                if (rep == GPS_RESPONSE.UART_FAIL)
                {
                    MessageBox.Show("Con't open com port!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                    return;
                }
            }
            //Show version in title
            this.Text += " " + Application.ProductVersion;

            //Initial IQ Chart ===========================================
            iqChart.Series[0].MarkerBorderColor = Color.Blue;
            iqChart.Series[0].MarkerColor = Color.Transparent;
            iqChart.Series[0].MarkerSize = 8;
            iqChart.Series[0].ChartType = SeriesChartType.FastPoint;

            dopplerChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent; // X軸的刻度 縱線
            dopplerChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;  // Y軸的刻度 橫線
            dopplerChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            dopplerChart.ChartAreas[0].AxisY.IsLabelAutoFit = false;

            dopplerChart.ChartAreas[0].AxisY.IsLogarithmic = false;
            //dopplerChart.ChartAreas[0].AxisY.LogarithmBase = 10.0;
            dopplerChart.ChartAreas[0].AxisY.Minimum = 30300;
            dopplerChart.ChartAreas[0].AxisY.Maximum = 30350;

            dopplerChart.ChartAreas[0].AxisY.Title = "";
            dopplerChart.ChartAreas[0].AxisX.Title = "";

            dopplerChart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            dopplerChart.ChartAreas[0].AxisX.IntervalOffsetType = DateTimeIntervalType.Auto;
            dopplerChart.ChartAreas[0].AxisX.Minimum = 0.0;
            dopplerChart.ChartAreas[0].AxisX.Maximum = maxLineSize;

            String stime = DateTime.Now.ToString("yyyyMMdd-hhmmss");
            logPath = String.Format("{0}\\IQPlotLog{1}", Directory.GetCurrentDirectory(), stime);
            //"Type,SVID,HWCL,CN0,Integrateion Time,Divider,Cycle Slip,I,Q,Dopper"
            if (File.Exists(logPath + ".csv"))
            {
                int i = 1;
                for(; i < 1000; ++i)
                {
                    String f = String.Format("{0}({1}).csv", logPath, i);
                    if (!File.Exists(f))
                    {
                        break;
                    }
                }
                logPath = String.Format("{0}({1}).csv", logPath, i);
            }
            else
            {
                logPath += ".csv";
            }
            logLbl.Text = logPath;
            // Create a file to write to.  
            using (StreamWriter sw = File.CreateText(logPath))
            {
                sw.WriteLine("Time,Type,SVID,HWCL,CN0,Integrateion Time,Divider,Cycle Slip,I,Q,Dopper");
            }

            iqChart.Show();
            ++workerCount;
            bkWorker[0].RunWorkerAsync(gps[0]);
            ++workerCount;
            bkWorker[1].RunWorkerAsync(gps[1]);
        }

        public class IQInfo
        {
            public IQInfo(Byte tp, Byte cnl, UInt32 sv, Byte cl, Byte cn0, Byte ti, Byte div, Byte cs, Int32 dp, Int16 i, Int16 q)
            {
                gpsType = tp;
                gnssChannel = cnl;
                nmeaSvid = sv;
                hwcl = cl;
                this.cn0 = cn0;
                integrateionTime = ti;
                divider = div;
                cycleSlip = cs;
                doppler = dp;
                iValue = i;
                qValue = q;
            }

            public IQInfo(IQInfo iq)
            {
                gpsType = iq.gpsType;
                gnssChannel = iq.gnssChannel;
                nmeaSvid = iq.nmeaSvid;
                hwcl = iq.hwcl;
                cn0 = iq.cn0;
                integrateionTime = iq.integrateionTime;
                divider = iq.divider;
                cycleSlip = iq.cycleSlip;
                doppler = iq.doppler;
                iValue = iq.iValue;
                qValue = iq.qValue;
            }
            
            public string GetChannelString()
            {
                string[,] strTable = new string[7, 7] 
                { 
                    { "GPS-L1", "GPS-L2C", "", "GPS-L1C", "GPS-L5", "", "" }, 
                    { "SBAS-L1", "", "", "", "SBAS-L5", "", "" },
                    { "GLONASS-L1", "GLONASS-L2C", "GLONASS-L3OC", "", "", "", "" }, 
                    { "GAL-E1", "GAL-E5b", "GAL-E5b", "", "GAL-E5a", "GAL-E6", "", }, 
                    { "QZSS-L1", "QZSS-L2C", "", "QZSS-L1C", "QZSS-L5", "QZSS-L6-LEX", "" }, 
                    { "BEIDOU-B1I", "BEIDOU-B2I", "BEIDOU-B3I", "BEIDOU-B1C", "BEIDOU-B2a", "", "" }, 
                    { "", "", "", "", "NAVIC-L5", "", "NAVIC-S" } 
                };
                if (gpsType >= 7 || gnssChannel >= 7)
                    return "";

                return strTable[gpsType - 1, gnssChannel - 1];
            }
            public Byte gpsType;
            public Byte gnssChannel;
            public UInt32 nmeaSvid;
            public Byte hwcl;
            public Byte cn0;
            public Byte integrateionTime;
            public Byte divider;
            public Byte cycleSlip;
            public Int32 doppler;
            public Int16 iValue;
            public Int16 qValue;
        }

        private BackgroundWorker[] bkWorker = new BackgroundWorker[WorkerCount];
        private void InitBackgroundWorker()
        {

            bkWorker[0] = new BackgroundWorker();
            bkWorker[0].WorkerReportsProgress = true;
            bkWorker[0].WorkerSupportsCancellation = true;
            bkWorker[0].DoWork += new DoWorkEventHandler(bw_DoWork);
            bkWorker[0].ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bkWorker[0].RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            bkWorker[1] = new BackgroundWorker();
            bkWorker[1].WorkerReportsProgress = true;
            bkWorker[1].WorkerSupportsCancellation = true;
            bkWorker[1].DoWork += new DoWorkEventHandler(bwLog_DoWork);
            bkWorker[1].ProgressChanged += new ProgressChangedEventHandler(bwLog_ProgressChanged);
            bkWorker[1].RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwLog_RunWorkerCompleted);

        }

        enum ReceiveStatus
        {
            None,
            GetA0,
            GetA1,
            GetSize1,
            GetSize2,
            GetSlashR,
            FinishBinCommand,
            ErrorSlashR,
            GetSharpCommand,
            GetSharpSlashR,
            FinishSharpCommand,
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 0;
            BackgroundWorker worker = sender as BackgroundWorker;
            const int BufferSize = 2048;
            System.Diagnostics.Debug.WriteLine("Start Background Worker");

            if (dataSource == SourceFrom.UART)
            {
                SkytraqGps gps = e.Argument as SkytraqGps;
                byte[] buff = new byte[BufferSize];
                try
                {
                    while (!worker.CancellationPending)
                    {
                        int l = gps.ReadLineNoWait(buff, BufferSize, 1000);
                        if (buff[0] != 0xa0 || buff[1] != 0xa1 || buff[4] != 0x64 || buff[5] != 0xfd)
                        {
                            continue;
                        }
                        ++count;

                        worker.ReportProgress(count, new IQInfo(
                            buff[6],
                            buff[7],
                            (UInt32)buff[8] << 8 | (UInt32)buff[9],
                            buff[10],
                            buff[11],
                            buff[12],
                            buff[13],
                            buff[14],
                            (Int32)((UInt32)buff[15] << 24 | (UInt32)buff[16] << 16 | (UInt32)buff[17] << 8 | (UInt32)buff[18]),
                            (Int16)((UInt32)buff[19] << 8 | (UInt32)buff[20]),
                            (Int16)((UInt32)buff[21] << 8 | (UInt32)buff[22])));

                        //Console.WriteLine("{0},{1},{2},{3},{4},{5}",
                        //    gpsType, nmeaSvid, integrateionTime, doppler, iValue, qValue);
                    }
                }
                catch (Exception ep)
                {
                    Console.WriteLine(ep.ToString());
                }
            }
            else
            {
                //Initial Namedpipe ===========================================
                while (!worker.CancellationPending)
                {
                    System.Diagnostics.Debug.WriteLine("Pipe name :" + Program.pipeName);
                    using (NamedPipeServerStream pipeStream = new NamedPipeServerStream(Program.pipeName,
                        PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
                    {
                        ReceiveStatus rs = ReceiveStatus.None;
                        int packageSize = 0;
                        int ptr = 0;
                        int sharpLen = 0;
                        byte[] buff = new byte[BufferSize];
                        System.Diagnostics.Debug.WriteLine("Create Named Pipe :" + Program.pipeName);
                        //Wait for connection
                        while (!worker.CancellationPending)
                        {
                            try
                            {
                                if (!pipeStream.IsConnected)
                                {
                                    //pipeStream.WaitForConnection();
                                    var asyncResult = pipeStream.BeginWaitForConnection(null, null);
                                    while (!worker.CancellationPending)
                                    {
                                        if (asyncResult.AsyncWaitHandle.WaitOne(5))
                                        {
                                            pipeStream.EndWaitForConnection(asyncResult);
                                            break;
                                        }
                                    }
                                }
                            }
                            catch (Exception ep)
                            {
                                Console.WriteLine(ep.ToString());
                                Thread.Sleep(10);
                                break;
                            }

                            if (worker.CancellationPending)
                            {
                                return;
                            }

                            var asyncResult2 = pipeStream.BeginRead(buff, ptr, 1, null, null);
                            //Wait for data in
                            while (!worker.CancellationPending)
                            {
                                if (asyncResult2.AsyncWaitHandle.WaitOne(5))
                                {
                                    pipeStream.EndRead(asyncResult2);
                                    ++ptr;
                                    break;
                                }
                            }

                            if (worker.CancellationPending)
                            {
                                return;
                            }
                            System.Diagnostics.Debug.Write(buff[ptr - 1]);

                            if (rs == ReceiveStatus.None && buff[ptr - 1] == '#')
                            {
                                rs = ReceiveStatus.GetSharpCommand;
                            }
                            else if (rs == ReceiveStatus.GetSharpCommand && buff[ptr - 1] == 0x0d)
                            {
                                rs = ReceiveStatus.GetSharpSlashR;
                                sharpLen = ptr - 1;
                            }
                            else if (rs == ReceiveStatus.GetSharpSlashR && buff[ptr - 1] == 0x0a)
                            {
                                rs = ReceiveStatus.FinishSharpCommand;
                            }
                            else if (rs == ReceiveStatus.GetSharpSlashR && buff[ptr - 1] != 0x0a)
                            {
                                rs = ReceiveStatus.GetSharpCommand;
                            }
                            else if (rs == ReceiveStatus.None && buff[ptr - 1] == 0xA0)
                            {
                                rs = ReceiveStatus.GetA0;
                            }
                            else if (rs == ReceiveStatus.GetA0 && buff[ptr - 1] == 0xA1)
                            {
                                rs = ReceiveStatus.GetA1;
                            }
                            else if (rs == ReceiveStatus.GetA1)
                            {
                                packageSize = buff[ptr - 1] << 8;
                                rs = ReceiveStatus.GetSize1;
                            }
                            else if (rs == ReceiveStatus.GetSize1)
                            {
                                packageSize |= buff[ptr - 1];
                                rs = ReceiveStatus.GetSize2;
                            }
                            else if (rs == ReceiveStatus.GetSize2)
                            {
                                if (ptr > (7 + packageSize) || ptr == BufferSize)
                                {
                                    ptr = 0;
                                    rs = ReceiveStatus.None;
                                }
                                if (ptr == (6 + packageSize) && buff[ptr - 1] == 0x0d)
                                {
                                    rs = ReceiveStatus.GetSlashR;
                                }
                            }
                            else if (rs == ReceiveStatus.GetSlashR && buff[ptr - 1] == 0x0a)
                            {
                                rs = ReceiveStatus.FinishBinCommand;
                            }
                            else if (buff[ptr - 1] == 0x0d)
                            {
                                rs = ReceiveStatus.ErrorSlashR;
                            }
                            else if (rs == ReceiveStatus.ErrorSlashR && buff[ptr - 1] == 0x0a)
                            {
                                rs = ReceiveStatus.None;
                                ptr = 0;
                            }

                            if (rs == ReceiveStatus.FinishBinCommand)
                            {
                                if (buff[0] != 0xa0 || buff[1] != 0xa1 || buff[4] != 0x64 || buff[5] != 0xfd)
                                {
                                    rs = ReceiveStatus.None;
                                    ptr = 0;
                                    continue;
                                }
                                ++count;

                                worker.ReportProgress(count, new IQInfo(
                                    buff[6],
                                    buff[7],
                                    (UInt32)buff[8] << 8 | (UInt32)buff[9],
                                    buff[10],
                                    buff[11],
                                    buff[12],
                                    buff[13],
                                    buff[14],
                                    (Int32)((UInt32)buff[15] << 24 | (UInt32)buff[16] << 16 | (UInt32)buff[17] << 8 | (UInt32)buff[18]),
                                    (Int16)((UInt32)buff[19] << 8 | (UInt32)buff[20]),
                                    (Int16)((UInt32)buff[21] << 8 | (UInt32)buff[22])));
                                rs = ReceiveStatus.None;
                                ptr = 0;
                            }

                            if (rs == ReceiveStatus.FinishSharpCommand)
                            {
                                string s2 = Encoding.UTF8.GetString(buff).Substring(0, sharpLen);
                                if(s2 == "#QUIT")
                                {
                                    Close();
                                    return;
                                }
                            }

                            if (ptr == BufferSize)
                            {
                                rs = ReceiveStatus.None;
                                ptr = 0;
                            }
                        }   //while(worker.CancellationPending)

                    }   //using (NamedPipeServerStream pipeStrea...
                }
            }   //if (dataSource == SourceFrom.UART) else
        }   //private void bw_DoWork(object sender, DoWorkEventArgs e)

        private int maxPointsSize = 100;
        private int maxLineSize = 200;
        //private int dataPointIndex = 0;

        private uint lastSvid = 0xffff;
        private void AddIQ(uint svid, int iValue, int qValue)
        {
            iqChart.Series.ResumeUpdates();
            if (svid != lastSvid)
            {
                lastSvid = svid;
                iqChart.Series[0].Points.Clear();
            }

            if (iqChart.Series[0].Points.Count == maxPointsSize)
            {
                iqChart.Series[0].Points.RemoveAt(0);
            }

            int max = (Math.Abs(iValue) > Math.Abs(qValue)) ? Math.Abs(iValue) : Math.Abs(qValue);
            if (autoChk.Checked && iqChart.ChartAreas[0].AxisX.Maximum < max)
            {
                SetIqScale(max);
            }

            int idx = iqChart.Series[0].Points.AddXY(iValue, qValue);
            iqChart.Series[0].Points[idx].MarkerBorderColor = Color.Red;
            iqChart.DataBind();
            iqChart.Series.Invalidate();
            iqChart.Series.SuspendUpdates();       

        }

        const int DopplerScaleRange = 25;
        private int dopplerScale = 50;
        const int DopplerAutoScale = 50;
        private void RescaleDoppler(int freq)
        {
            if (dopplerChart.Series[0].Points.Count > 0)
            {
                int min = int.MaxValue;
                int max = int.MinValue;
                double avg = 0;
                foreach (DataPoint pt in dopplerChart.Series[0].Points)
                {
                    if (pt.YValues[0] > max)
                        max = (int)pt.YValues[0];
                    if (pt.YValues[0] < min)
                        min = (int)pt.YValues[0];
                    avg += pt.YValues[0];
                }
                avg /= dopplerChart.Series[0].Points.Count;
                if (autoScaleChk.Checked)
                {
                    //avoid sway
                    max += 10;
                    min -= 10;
                    if (min > 0)
                    {
                        dopplerChart.ChartAreas[0].AxisY.Minimum = (min / DopplerAutoScale) * DopplerAutoScale;
                    }
                    else
                    {
                        dopplerChart.ChartAreas[0].AxisY.Minimum = ((min - DopplerAutoScale - 1) / DopplerAutoScale) * DopplerAutoScale;
                    }
                    if (max > 0)
                    {
                        dopplerChart.ChartAreas[0].AxisY.Maximum = ((max + DopplerAutoScale - 1) / DopplerAutoScale) * DopplerAutoScale;
                    }
                    else
                    {
                        dopplerChart.ChartAreas[0].AxisY.Maximum = (max / DopplerAutoScale) * DopplerAutoScale;
                    }
                }
                else
                {
                    int center = ((int)(avg + (double)DopplerScaleRange / 2) / DopplerScaleRange) * DopplerScaleRange;
                    dopplerChart.ChartAreas[0].AxisY.Minimum = center - dopplerScale;
                    dopplerChart.ChartAreas[0].AxisY.Maximum = center + dopplerScale;
                }
            }
            else
            {
                dopplerChart.ChartAreas[0].AxisY.Minimum = ((freq - 49) / 50) * 50;
                dopplerChart.ChartAreas[0].AxisY.Maximum = ((freq + 49) / 50) * 50;

            }
            scaleLbl.Text = (dopplerChart.ChartAreas[0].AxisY.Maximum - dopplerChart.ChartAreas[0].AxisY.Minimum).ToString();
        }

        private void AddDoppler(int count, int freq)
        {
            dopplerChart.Series.ResumeUpdates();
            //if (svid != lastSvid)
            //{
            //    lastSvid = svid;
            //    iqChart.Series[0].Points.Clear();
            //}

            if (dopplerChart.Series[0].Points.Count == maxLineSize)
            {
                dopplerChart.Series[0].Points.RemoveAt(0);
                dopplerChart.ChartAreas[0].AxisX.Minimum = dopplerChart.Series[0].Points[0].XValue;
                dopplerChart.ChartAreas[0].AxisX.Maximum = dopplerChart.ChartAreas[0].AxisX.Minimum + maxLineSize;
            }

            if (!autoScaleChk.Checked || (autoScaleChk.Checked && (freq > dopplerChart.ChartAreas[0].AxisY.Maximum || freq < dopplerChart.ChartAreas[0].AxisY.Minimum || count % maxLineSize == 0)))
            {
                RescaleDoppler(freq);
            }

            int idx = dopplerChart.Series[0].Points.AddXY(count, freq);
            dopplerChart.Series.SuspendUpdates();

        }
 
        private Queue<IQInfo> iqQueue = new Queue<IQInfo>();
        String logPath = "";
        //"Type,SVID,HWCL,CN0,Integrateion Time,Divider,Cycle Slip,I,Q,Dopper"
        private void bwLog_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (!worker.CancellationPending)
            {
                if (iqQueue.Count == 0)
                {
                    Thread.Sleep(50);
                    continue;
                }

                IQInfo iq = iqQueue.Dequeue();
                // This text is always added, making the file longer over time  
                // if it is not deleted.  
                try {
                    using (StreamWriter sw = File.AppendText(logPath))
                    {
                        //"Time,Type,SVID,HWCL,CN0,Integrateion Time,Divider,Cycle Slip,I,Q,Dopper"
                        String s = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                            DateTime.Now.ToString("HH:mm:ss.fff"), iq.gpsType, iq.gnssChannel, iq.nmeaSvid, iq.hwcl, iq.cn0, 
                            iq.integrateionTime, iq.divider, iq.cycleSlip, iq.iValue, iq.qValue, iq.doppler);
                        sw.WriteLine(s);
                    }
                }
                catch(Exception e1)
                {
                    Console.WriteLine(e1.ToString());
                }
            }


        }

        private void PushIqInfo(IQInfo iq)
        {
            iqQueue.Enqueue(iq);
            Console.WriteLine(iqQueue.Count);
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (workerCount == 0)
            {
                return;
            }

            IQInfo iq = e.UserState as IQInfo;
            PushIqInfo(iq);
            switch(iq.gpsType)
            {
                case 1:
                    typeLbl.Text = "GPS";
                    break;
                case 2:
                    typeLbl.Text = "SBAS";
                    break;
                case 3:
                    typeLbl.Text = "GLONASS";
                    break;
                case 4:
                    typeLbl.Text = "GALILEO";
                    break;
                case 5:
                    typeLbl.Text = "QZSS";
                    break;
                case 6:
                    typeLbl.Text = "BD2";
                    break;
                case 7:
                    typeLbl.Text = "NAVIC";
                    break;
                default:
                    typeLbl.Text = "";
                    break;
            }
            channelLbl.Text = iq.GetChannelString();
            //switch(iq.gnssChannel)
            //{
            //    case 1:
            //        channelLbl.Text = "CHANNEL_1";
            //        break;
            //    case 2:
            //        channelLbl.Text = "CHANNEL_2";
            //        break;
            //    case 3:
            //        channelLbl.Text = "CHANNEL_3";
            //        break;
            //    case 4:
            //        channelLbl.Text = "CHANNEL_1C";
            //        break;
            //    case 5:
            //        channelLbl.Text = "CHANNEL_5";
            //        break;
            //    case 6:
            //        channelLbl.Text = "CHANNEL_6";
            //        break;
            //    case 7:
            //        channelLbl.Text = "CHANNEL_S";
            //        break;
            //    default:
            //        channelLbl.Text = "";
            //        break;
            //}            
            svidLbl.Text = iq.nmeaSvid.ToString();
            ingTimeLbl.Text = iq.integrateionTime.ToString() + " / " + iq.divider.ToString();
            freqLbl.Text = iq.doppler.ToString();
            clLbl.Text = (iq.hwcl == 0) ? "HWCL" : "SWCL";
            cn0Lbl.Text = iq.cn0.ToString();
            //dividerLbl.Text = iq.divider.ToString();
            csLbl.Text = iq.cycleSlip.ToString();

            AddIQ(iq.nmeaSvid, iq.iValue, iq.qValue);
            AddDoppler(e.ProgressPercentage, iq.doppler);
        }

        private void bwLog_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (workerCount == 0)
            {
                return;
            }
        }

        //執行完成
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker b = (sender as BackgroundWorker);
            --workerCount;
            if(workerCount == 0)
            {
                this.Close();
            }
        }

        private void bwLog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker b = (sender as BackgroundWorker);
            --workerCount;
            if (workerCount == 0)
            {
                this.Close();
            }
        }


        int workerCount = 0;
        private void IQPlotForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < WorkerCount; ++i)
            {
                if (bkWorker[i].IsBusy)
                {
                    bkWorker[i].CancelAsync();
                }
            }
            Thread.Sleep(100);
            if(workerCount > 0)
            { 
                e.Cancel = true;
            }

            if (gps[0] != null)
            {
                gps[0].Close();
            }
        }

        private int ZoomScale = 2000;
        private int MinZoomSize = 8000;
        private void SetIqScale(int max)
        {
            max = ZoomScale * (1 + (max - 1) / ZoomScale);
            iqChart.ChartAreas[0].AxisX.Maximum = max;
            iqChart.ChartAreas[0].AxisX.Minimum = 0 - max;
            iqChart.ChartAreas[0].AxisX.Interval = max / 4;
            iqChart.ChartAreas[0].AxisY.Maximum = max;
            iqChart.ChartAreas[0].AxisY.Minimum = 0 - max;
            iqChart.ChartAreas[0].AxisY.Interval = max / 4;
        }

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
            int newScale = (int)iqChart.ChartAreas[0].AxisX.Maximum - ZoomScale;
            autoChk.Checked = false;
            if(newScale < MinZoomSize)
            {
                return;
            }
            iqChart.Series.ResumeUpdates();
            SetIqScale(newScale);
            iqChart.Series.Invalidate();
            iqChart.Series.SuspendUpdates();
        }

        private void zoomOutBtn_Click(object sender, EventArgs e)
        {
            int newScale = (int)iqChart.ChartAreas[0].AxisX.Maximum + ZoomScale;
            autoChk.Checked = false;
            iqChart.Series.ResumeUpdates();
            SetIqScale(newScale);
            iqChart.Series.Invalidate();
            iqChart.Series.SuspendUpdates();
        }

        private void zoomInDopplerBtn_Click(object sender, EventArgs e)
        {
            if(dopplerScale > DopplerScaleRange)
            {
                autoScaleChk.Checked = false;
                dopplerScale -= DopplerScaleRange;
                dopplerChart.Invalidate();
            }
        }

        private void zoomOutDopplerBtn_Click(object sender, EventArgs e)
        {
            autoScaleChk.Checked = false;
            dopplerScale += DopplerScaleRange;
            dopplerChart.Invalidate();
        }

        private void autoScaleChk_CheckedChanged(object sender, EventArgs e)
        {
            dopplerChart.Invalidate();
        }

        private void autoChk_CheckedChanged(object sender, EventArgs e)
        {
            iqChart.Invalidate();
        }

        private void openLogBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select, \"" + logPath + "\"");
        }
    }


}
