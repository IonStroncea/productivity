using Common;
using ComputerInfo;
using System.Collections.Concurrent;
using System.Reflection.PortableExecutable;
using System.Timers;
using System.Net.Http;
using Computerinfo;
using Microsoft.VisualBasic.Devices;

namespace UserApp
{
    public partial class MainForm : Form
    {
        int computerId = 0;
        bool _closeApp = false;
        bool savedLatest = false;
        private static readonly HttpClient client = new HttpClient();
        string appToken;
        private GetComputerInfo computerInfo= new GetComputerInfo();

        ServerComunicator comunicator = default;

        ConcurrentQueue<MRSInfo> infos = default;
        MRSInfo lastInfo = new MRSInfo();
        List<ProcessUssageInfo> lastProccessInfo = new List<ProcessUssageInfo>();
        ProccessUssageGetter proccessUssageGetter = new ProccessUssageGetter();
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

            lastProccessInfo = proccessUssageGetter.GetProcessesInfo();

        }

        public void SendLatest()
        {
            ReturnStatus result = comunicator.SentMRSInfoLatest(lastInfo, computerId);
            ReturnStatus resultUssage = comunicator.SendProccesUssageInfo(lastProccessInfo, computerId);

            if (result != ReturnStatus.Success && !savedLatest)
            {
                infos.Enqueue(lastInfo);
                savedLatest = true;
            }

            Invoke((MethodInvoker)delegate { sendLabel.Text = $"Tansmited {sentData} data {remainData} reamining"; });
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
            writeInfosToFileTimer.Start();
            changeLabelsTimer.Start();


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

        private void loginButton_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(() => { 
                string token = LogIn().Result;

                Invoke((MethodInvoker)delegate {
                    if (token != "Error")
                    {
                        computerId = Int32.Parse(token.Split("==")[3]);

                        appToken = token;
                        userNameLabel.Visible = false;
                        userNameTextBox.Visible = false;

                        passwordLabel.Visible = false;
                        passwodTextBox.Visible = false;

                        loginButton.Visible = false;

                        compNameLabel.Visible = false;
                        compNameTextBox.Visible = false;
                        newCompCheckBox.Visible = false;

                        RefreshComputerInfoButton.Visible = true;

                        sendLabel.Visible = true;

                        readAndSendTimer.Start();
                        sendLatestMRSInfoTimer.Start();
                    }
                });
            });
            t1.Start();
            
        }

        private void userNameLabel_Click(object sender, EventArgs e)
        {
        }

        private async Task<string> LogIn()
        {
            try
            {
                var values = new Dictionary<string, string>
                {
                    { "username", userNameTextBox.Text },
                    { "password", passwodTextBox.Text },
                    { "compName", compNameTextBox.Text },
                    { "newComp", newCompCheckBox.Checked.ToString() }
                };

                string uri = "https://localhost:7155/api/User?" + values.ElementAt(0).Key + "=" + values.ElementAt(0).Value +
                                                                "&" + values.ElementAt(1).Key + "=" + values.ElementAt(1).Value +
                                                                "&" + values.ElementAt(2).Key + "=" + values.ElementAt(2).Value +
                                                                "&" + values.ElementAt(3).Key + "=" + values.ElementAt(3).Value;

                var response = await client.GetAsync(uri);

                var text = response.Content.ReadAsStringAsync().Result;

                return text;
            }
            catch (Exception e)
            {
                return "Error";
            }

        }

        private void RefreshComputerInfoButton_Click(object sender, EventArgs e)
        {
            computerInfo.RenewData();

            ReturnStatus result = comunicator.RenewComputerInfo(computerInfo, computerId);

        }
    }
}