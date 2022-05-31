namespace Permaquim.Depositary.UI.Desktop
{
    public partial class StackerFullDialog : Form
    {
        public StackerFullDialog()
        {
            InitializeComponent();
        }

        private void ConfirmDepositButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelDepositButton_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void ContinueDepositButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Continue;
            this.Close();
        }
    }
}
