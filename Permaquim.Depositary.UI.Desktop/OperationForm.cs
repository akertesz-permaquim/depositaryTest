using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OperationForm : Form
    {
        public OperationForm()
        {
            InitializeComponent();
        }

        private void OperationForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                MainPanel.Controls.Add(new CustomButton()
                    {
                        Text = i.ToString(),
                    }
                );
            }
        }
    }
}
