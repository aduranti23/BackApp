using Ookii.Dialogs.WinForms;

namespace BackApp
{
    public partial class GUI : Form
    {
        Procedures procedures = new Procedures();
        String source = String.Empty;
        String output = String.Empty;
        Boolean isRecursive = false;
        public GUI()
        {
            InitializeComponent();
            sourceBox.Text = source;
            outBox.Text = output;
            chkIsRecursive.Checked = isRecursive;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => procedures.mainProcedure(chkIsRecursive.Checked, sourceBox.Text, outBox.Text));
            if (!String.IsNullOrEmpty(sourceBox.Text) && !String.IsNullOrEmpty(outBox.Text))
            {
                t.Start();
            }
            else if (String.IsNullOrEmpty(sourceBox.Text))
            {
                MessageBox.Show("Select a source folder");
            }
            else if (String.IsNullOrEmpty(outBox.Text))
            {
                MessageBox.Show("Select an output folder");
            }
        }
        private void sourceBox_TextChanged(object sender, EventArgs e)
        {
            source = sourceBox.Text;
        }
        private void outBox_TextChanged(object sender, EventArgs e)
        {
            output = outBox.Text;
        }
        private void sourceSelection_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog browser = new VistaFolderBrowserDialog();
            browser.Description = "Select source folder...";
            browser.UseDescriptionForTitle = true;
            if (browser.ShowDialog() == DialogResult.OK)
            {
                sourceBox.Text = browser.SelectedPath;
            }
        }

        private void outputSelection_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog browser = new VistaFolderBrowserDialog();
            browser.Description = "Select output folder...";
            browser.UseDescriptionForTitle = true;
            if (browser.ShowDialog() == DialogResult.OK)
            {
                outBox.Text = browser.SelectedPath;
            }
        }

        private void scheduleTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form scheduleTool = new scheduleTool();
            scheduleTool.ShowDialog();
        }

        private void showScheduledTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form taskManager = new taskManager();
            taskManager.ShowDialog();
        }
    }
}