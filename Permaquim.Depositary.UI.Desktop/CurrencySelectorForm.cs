using Permaquim.Depositary.UI.Desktop.Builders;
using Permaquim.Depositary.UI.Desktop.Components;
using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
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
    public partial class CurrencySelectorForm : Form
    {
        public Device _device { get; set; }

        private List<Permaquim.Depositario.Entities.Relations.Valor.Moneda> _currencies = DatabaseController.GetCurrencies();
        public CurrencySelectorForm()
        {
            InitializeComponent();
            CenterPanel();
            LoadCurrencyButtons();
            LoadBackButton();
        }

        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }

        private void CurrencySelectorForm_Load(object sender, EventArgs e)
        {
            _device = (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag;
            LoadStyles();
        }
        private void LoadStyles()
        {
            this.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.Contenido);
        }
        #region CurrencyButtons

       private void LoadCurrencyButtons()
        {


            foreach (var item in _currencies)
            {

                CustomButton newButton = ControlBuilder.BuildStandardButton(
                    "CurrencyButton" + item.Id.ToString(), 
                    MultilanguangeController.GetText(item.Nombre), MainPanel.Width);

                newButton.Click += new System.EventHandler(CurrencyButton_Click);

                newButton.Tag = item;

                this.MainPanel.Controls.Add(newButton);
            
            }
        }
        private void CurrencyButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentCurrency = (Permaquim.Depositario.Entities.Relations.Valor.Moneda)((CustomButton)sender).Tag;
            
            _device.SwitchCurrency(DatabaseController.CurrentCurrency.IndiceEnContadora);

            if (DatabaseController.CurrentOperation.Id == 1)
            {
                if (DatabaseController.GetUserBankAccounts().Count == 0)
                {
                     AppController.OpenChildForm(new BillDepositForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                }
                else
                {
                    AppController.OpenChildForm(new BankAccountSelectorForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                }
            }
            if (DatabaseController.CurrentOperation.Id == 3)
            {

                if (DatabaseController.GetUserBankAccounts().Count == 0)
                {
                    AppController.OpenChildForm(new EnvelopeDepositForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                }
                else
                {
                    AppController.OpenChildForm(new BankAccountSelectorForm(),
                    (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
                }

            }

        }
        #endregion

        #region BackButton
        private void LoadBackButton()
        {
            CustomButton backButton = ControlBuilder.BuildExitButton(
                "BackButton", MultilanguangeController.GetText("Salir"), MainPanel.Width);

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            AppController.OpenChildForm(new OperationForm(), _device);
            this.Close();
        }
        #endregion

    }
}
