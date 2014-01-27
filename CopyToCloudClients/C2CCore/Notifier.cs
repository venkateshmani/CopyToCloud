using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using C2CWindowsDesktopClient.WebServices;
using C2CWindowsDesktopClient.ServerCallClasses;

namespace C2CWindowsDesktopClient
{
    public partial class Notifier : Form
    {
        Configuration configuration = null;
        C2CServiceClient m_Client = null;
        ClientInfo m_ClientInfo;

        public Notifier()
        {
            InitializeComponent();
            LoadConfiguration();

            clipboardMonitor.ClipboardChanged += clipboardMonitor_ClipboardChanged;
            this.RegisterClient();
            clipboardMonitor.Start();
        }


        private void RegisterClient()
        {
            if ((m_Client != null))
            {
                m_Client.Abort();
                m_Client = null;
            }

            BroadcastorCallback cb = new BroadcastorCallback();
            cb.SetHandler(this.HandleBroadcast);

            System.ServiceModel.InstanceContext context =
                new System.ServiceModel.InstanceContext(cb);
            m_Client = new C2CServiceClient(context);

            m_ClientInfo = new ClientInfo()
            {
                C2CID = Convert.ToInt64(1),
                Name = "Hello Mr.",
                LoginID = "mr@testing.com",
                MacAddress = Utils.Helpers.GetMacAddress().ToString(),
            };

            m_Client.RegisterClient(m_ClientInfo);
        }

        private delegate void HandleBroadcastCallback(object sender, EventArgs e);
        public void HandleBroadcast(object sender, EventArgs e)
        {
            CopiedDetails eventData = sender as CopiedDetails;
            if (eventData != null)
            {
                Clipboard.SetText(eventData.Text);
            }
        }

        #region UI Handlers

            private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
            {
                configuration.IsPaused = pauseToolStripMenuItem.Checked;
            }

            private void c2cNotifier_Click(object sender, EventArgs e)
            {
                //Need to show the context menu here
                MethodInfo methodInfo = typeof(NotifyIcon).GetMethod("ShowContextMenu",
                    BindingFlags.Instance | BindingFlags.NonPublic);
                methodInfo.Invoke(this.c2cNotifier, null);
            }

            private void c2cNotifier_DoubleClick(object sender, EventArgs e)
            {
                this.Show();
            }

        #endregion 

        #region Just For Testing

        public String CurrentString
        {
            get
            {
                return copiedText.Text;
            }
            set
            {
                copiedText.Text = value;
            }
        }

        #endregion 

        #region Core Events

            void clipboardMonitor_ClipboardChanged(object sender, ClipboardChangedEventArgs e)
            {
                if (!configuration.IsPaused)
                {
                    if (Clipboard.ContainsText())
                    {
                        CurrentString = e.DataObject.GetData(typeof(string)) as String;

                        CopiedDetails copyDetails = new CopiedDetails();
                        copyDetails.C2CID = m_ClientInfo.C2CID;
                        copyDetails.MacAddress = m_ClientInfo.MacAddress;
                        copyDetails.Text = CurrentString;

                        m_Client.PostToServerAsync(copyDetails);
                    }
                }
            }

            private void Notifier_FormClosed(object sender, FormClosedEventArgs e)
            {
                SaveConfiguration();
                c2cNotifier.Dispose();
            }

        #endregion 

        #region Client Configuration

            public void LoadConfiguration()
            {
                if (File.Exists(ClientConfigurationFilePath))
                {
                    var serializer = new XmlSerializer(typeof(Configuration));
                    using (TextReader reader = new StreamReader(ClientConfigurationFilePath))
                    {
                        configuration = (Configuration)serializer.Deserialize(reader);
                    }
                }
                else
                {
                    configuration = new Configuration();
                }
            }

            public void SaveConfiguration()
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration));
                // Create an instance of stream writer.
                TextWriter txtWriter = new StreamWriter(ClientConfigurationFilePath, false);
                // Serialize the instance of BasicSerialization
                xmlSerializer.Serialize(txtWriter, configuration);
                // Close the stream writer
                txtWriter.Close();
            }

            public string ClientConfigurationFilePath
            {
                get
                {
                    string userDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    if (Directory.Exists(userDataPath))
                    {
                        userDataPath = Path.Combine(userDataPath, "CopyToCloud");

                        if (!Directory.Exists(userDataPath))
                        {
                            Directory.CreateDirectory(userDataPath);
                        }

                        userDataPath = Path.Combine(userDataPath, "ClientConfiguration.xml");
                    }

                    return userDataPath;
                }
            }

            #endregion 

    }
}
