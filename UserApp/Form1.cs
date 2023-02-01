using Common;
using ComputerInfo;
using System.Collections.Concurrent;
using System.Reflection.PortableExecutable;
using System.Timers;

namespace UserApp
{
    public partial class MainForm : Form
    {
        int computerId = 1;
        bool _closeApp = false;
        bool savedLatest = false;

        ServerComunicator comunicator = default;

        ConcurrentQueue<MRSInfo> infos = default;
        MRSInfo lastInfo = new MRSInfo();
        ResourseUsageInfo resourseUsage = default;
        InfoWriter writer = default;
        int sentData = 0;
        int remainData = 0;

        Thread getSystemInfoTimer = default;
        Thread changeLabelsTimer = default;
        Thread writeInfosToFileTimer = default;
        Thread readAndSendTimer = default;
        Thread sendLatestMRSInfoTimer = default;

        bool appRunning = true;

        public void GetSystemInfo()
        {
            MRSInfo info = resourseUsage.GetAllInfo();

            lastInfo = info;
            savedLatest = false;
            //infos.Enqueue(info);
        }

        public void SendLatest()
        {
            ReturnStatus result = comunicator.SentMRSInfoLatest(lastInfo, computerId);

            if (result != ReturnStatus.Success && !savedLatest)
            {
                infos.Enqueue(lastInfo);
                savedLatest = true;
            }
        }

        public void WriteInfosToFile()
        {
            List<RSInfo> rsinfos = new List<RSInfo>();

            foreach (MRSInfo info in infos)
            {
                foreach (RSInfo rsInfo in info.GetInfos())
                {
                    rsinfos.Add(rsInfo);
                }
            }

            int writeStatus = writer.WriteRSInfo(rsinfos);

            if (writeStatus == 1)
            {
                infos.Clear();
            }
        }

        public void ReadAndSend()
        {
            List<RSInfo> rSInfos = writer.ReadUnsendRSInfo();

            List<RSInfo> sentData = comunicator.SendInfo(rSInfos, computerId);

            sentData.ForEach(x => rSInfos.Remove(x));

            writer.DeleteInfos(sentData);

            this.sentData = sentData.Count;
            this.remainData = rSInfos.Count;

        }

        public void ChangeLabels()
        {
            try
            {
                Invoke((MethodInvoker)delegate { cpuUssageLabel.Text = lastInfo.GetInfo(RSInfoType.CPU).Usage.ToString() + "%"; });
                Invoke((MethodInvoker)delegate { gpuUssageLabel.Text = lastInfo.GetInfo(RSInfoType.GPU).Usage.ToString() + "%"; });
                Invoke((MethodInvoker)delegate { ramUssageLabel.Text = lastInfo.GetInfo(RSInfoType.RAM).Usage.ToString() + "%"; });
                Invoke((MethodInvoker)delegate { sendLabel.Text = $"Tansmited {sentData} data {remainData} reamining"; });
            }
            catch { }
        }

        public MainForm()
        {
            comunicator = new ServerComunicator();
            infos = new ConcurrentQueue<MRSInfo>();
            resourseUsage = new ResourseUsageInfo();
            writer = new InfoWriter("..\\..\\..\\resultFiles");            

            InitializeComponent();

            getSystemInfoTimer = new Thread(() => { while (appRunning) { Thread.Sleep(1000); GetSystemInfo();} });
            changeLabelsTimer = new Thread(() => { while (appRunning) { Thread.Sleep(1500); ChangeLabels();} });
            writeInfosToFileTimer = new Thread(() => { while (appRunning) { Thread.Sleep(1500); WriteInfosToFile();} });
            readAndSendTimer = new Thread(() => { while (appRunning) { Thread.Sleep(1000); ReadAndSend();} });
            sendLatestMRSInfoTimer = new Thread(() => { while (appRunning) { Thread.Sleep(1000); SendLatest(); } });

            getSystemInfoTimer.Start();
            changeLabelsTimer.Start();
            writeInfosToFileTimer.Start();
            readAndSendTimer.Start();
            sendLatestMRSInfoTimer.Start();

        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_closeApp)
            {
                e.Cancel = true;
                Hide();
            }
            else
            {
                appRunning = false;
            }
        }

        private void iconMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "Stop")
            {
                _closeApp = true;
                Close();

                return;
            }

            if (e.ClickedItem.Name == "OpenWindow")
            {
                if (this.Visible)
                {
                    return;
                }

                Show();

                return;
            }
        }
    }
}