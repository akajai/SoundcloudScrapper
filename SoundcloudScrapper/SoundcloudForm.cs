using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundcloudScrapper
{
    public partial class SoundcloudForm : Form
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SoundcloudForm()
        {
            InitializeComponent();
            textBoxURL.Text = System.Configuration.ConfigurationSettings.AppSettings["groupurl"].ToString();
   
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            log.Info("Start Clicked");
            WebScrapping.WebScrapping.ScrapHTML();
            log.Info("Start End");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            log.Info("Stop Clicked");
            log.Info("Stop End");
            this.Close();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            log.Info("Export Clicked");
            if (saveFileDialogFile.ShowDialog() == DialogResult.OK)
            {
                log.Info(" Export File path :" + saveFileDialogFile.FileName);
            }
            log.Info("Export End");

        }
    }
}
