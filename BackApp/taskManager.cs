using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackApp
{
    public partial class taskManager : Form
    {
        public taskManager()
        {
            InitializeComponent();
            using (TaskService ts = new TaskService())
            {
                List<Microsoft.Win32.TaskScheduler.Task> tc = ts.RootFolder.Tasks.Where(t => t.Name.Contains("BackApp Schedule")).ToList();
                foreach (Microsoft.Win32.TaskScheduler.Task t in tc)
                {
                    dataGridView1.Rows.Add(t.Name, t.NextRunTime);
                }
            }
        }

        private void deleteSingleButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            if (MessageBox.Show("Are you sure you want to delete this/these task(s)?", "Warning", buttons) == DialogResult.OK){
                using (TaskService ts = new TaskService())
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                       ts.RootFolder.DeleteTask(row.Cells[0].Value.ToString());
                    }
                    this.Refresh();
                }
            }
        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            if (MessageBox.Show("Are you sure you want to delete ALL tasks?", "Warning", buttons) == DialogResult.OK)
            {
                using (TaskService ts = new TaskService())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        ts.RootFolder.DeleteTask(row.Cells[0].Value.ToString());
                    }
                    this.Refresh();
                }
            }
        }
    }
}
