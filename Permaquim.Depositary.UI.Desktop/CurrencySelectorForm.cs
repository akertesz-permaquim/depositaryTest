using Permaquim.Depositary.UI.Desktop.Controllers;
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

        private void LoadCurrencyButtons()
        {


            foreach (var item in _currencies)
            {
                // Si la moneda no está habilitada para la sucursal 

                CustomButton newButton = new CustomButton();

                newButton.BackColor = System.Drawing.Color.SeaGreen;
                newButton.BackgroundColor = System.Drawing.Color.SeaGreen;
                newButton.BorderColor = System.Drawing.Color.LightGreen;
                newButton.BorderRadius = 5;
                newButton.BorderSize = 0;
                newButton.FlatAppearance.BorderSize = 0;
                newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                newButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                newButton.ForeColor = System.Drawing.Color.White;
                newButton.Location = new System.Drawing.Point(3, 3);
                newButton.Name = "DepositButton" + item.Id.ToString();
                newButton.Size = new System.Drawing.Size(293, 77);
                newButton.TabIndex = 0;
                newButton.Text = MultilanguangeController.GetText(item.Nombre);
                newButton.TextColor = System.Drawing.Color.White;
                newButton.UseVisualStyleBackColor = false;

                newButton.Click += new System.EventHandler(CurrencyButton_Click);

                newButton.Tag = item;

                this.MainPanel.Controls.Add(newButton);
            
            }
        }
        private void LoadBackButton()
        {
            CustomButton backButton = new CustomButton();
            backButton.BackColor = System.Drawing.Color.SteelBlue;
            backButton.BackgroundColor = System.Drawing.Color.SteelBlue;
            backButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            backButton.BorderRadius = 5;
            backButton.BorderSize = 0;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            backButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            backButton.ForeColor = System.Drawing.Color.White;
            backButton.Location = new System.Drawing.Point(3, 3);
            backButton.Name = "BackButton";
            backButton.Size = new System.Drawing.Size(293, 77);
            backButton.TabIndex = 3;
            backButton.Text = MultilanguangeController.GetText("Salir");
            backButton.TextColor = System.Drawing.Color.White;
            backButton.UseVisualStyleBackColor = false;

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void CurrencyButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentCurrency = (Permaquim.Depositario.Entities.Relations.Valor.Moneda)((CustomButton)sender).Tag;
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
