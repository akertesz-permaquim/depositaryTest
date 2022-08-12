using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using static Permaquim.Depositary.UI.Desktop.Global.Enumerations;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class OriginSelectorForm : Form
    {
        private List<Permaquim.Depositario.Entities.Relations.Valor.OrigenValor> 
            _depositOrigin = DatabaseController.GetDepositOrigin();

        private System.Windows.Forms.Timer _pollingTimer = new System.Windows.Forms.Timer();
        public OriginSelectorForm()
        {
            InitializeComponent();

            CenterPanel();
            LoadOriginButtons();
            LoadBackButton();
            ChechSingleOrigin();

            TimeOutController.Reset();
            _pollingTimer = new System.Windows.Forms.Timer()
            {
                Interval = DeviceController.GetPollingInterval()
            };
            _pollingTimer.Tick += PollingTimer_Tick;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP = base.CreateParams;
                CP.ExStyle = CP.ExStyle | 0x02000000; // WS_EX_COMPOSITED
                return CP;
            }
        }
        private void PollingTimer_Tick(object? sender, EventArgs e)
        {
            if (TimeOutController.IsTimeOut())
            {
                _pollingTimer.Enabled = false;
                DatabaseController.LogOff(true);
                FormsController.LogOff();
            }
        }
        private void ChechSingleOrigin()
        {
            if (_depositOrigin.Count <= 1)
                DatabaseController.CurrentDepositOrigin = _depositOrigin.FirstOrDefault();
            FormsController.OpenChildForm(this, new BillDepositForm(),
             (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }

        private void CenterPanel()
        {
            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }
        private void LoadOriginButtons()
        {


            foreach (var item in _depositOrigin)
            {

                CustomButton newButton = ControlBuilder.BuildStandardButton(
                "OriginButton" + item.Id.ToString(),
                item.Nombre + " (" + item.Descripcion + ")"
                , MainPanel.Width);

                newButton.Click += new System.EventHandler(OriginButton_Click);

                newButton.Tag = item;

                this.MainPanel.Controls.Add(newButton);

            }
        }
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildStandardButton(
                "BackButton", MultilanguangeController.GetText(MultiLanguageEnum.VOLVER), MainPanel.Width);


            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void OriginButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentDepositOrigin = (Permaquim.Depositario.Entities.Relations.Valor.OrigenValor)((CustomButton)sender).Tag;

            FormsController.OpenChildForm(this, new BillDepositForm(),
            (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            FormsController.OpenChildForm(this, new CurrencySelectorForm(),
                  (Permaquim.Depositary.UI.Desktop.Components.CounterDevice)this.Tag);
        }

        private void OriginSelectorForm_VisibleChanged(object sender, EventArgs e)
        {
            _pollingTimer.Enabled = this.Visible;
            if (!this.Visible)
                InitializeLocals();
            FormsController.SetInformationMessage(InformationTypeEnum.None, string.Empty);
        }

        private void InitializeLocals()
        {
            _depositOrigin = new();

        }

        private void OriginSelectorForm_MouseClick(object sender, MouseEventArgs e)
        {
            TimeOutController.Reset();
        }
    }
}
