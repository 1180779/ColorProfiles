using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorProfiles
{
    public partial class BusyForm : Form
    {
        public BusyForm()
        {
            InitializeComponent();
            this.Shown += (s, e) => _readyTask.SetResult(true);
        }

        private TaskCompletionSource<bool> _readyTask = new TaskCompletionSource<bool>();

        public Task WaitForReadyAsync()
        {
            return _readyTask.Task;
        }
    }
}
