using Permaquim.Depositary.UI.Desktop.Controllers;

namespace Permaquim.Depositary.UI.Desktop
{
    public partial class BankAccountSelectorForm : Form
    {
        private List<Permaquim.Depositario.Entities.Relations.Banca.UsuarioCuenta> _userBankAccounts = DatabaseController.GetUserBankAccounts();
        public BankAccountSelectorForm()
        {
            InitializeComponent();

            CenterPanel();
            LoadBankAccountsButtons();
            LoadBackButton();
            ChechSingleAccount();
        }

        private void ChechSingleAccount()
        {
            if (_userBankAccounts.Count <= 1)
                   DatabaseController.CurrentUserBankAccount = _userBankAccounts.FirstOrDefault();
                AppController.OpenChildForm(new BillDepositForm(),
                 (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);
           
        }

        private void CenterPanel()
        {

            MainPanel.Location = new Point()
            {
                X = this.Width / 2 - MainPanel.Width / 2,
                Y = this.Height / 2 - MainPanel.Height / 2
            };
        }
        private void LoadBankAccountsButtons()
        {


            foreach (var item in _userBankAccounts)
            {

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
                newButton.Name = "BankAccounttButton" + item.Id.ToString();
                newButton.Size = new System.Drawing.Size(MainPanel.Width - 5, 77);
                newButton.TabIndex = 0;
                newButton.Text = item.CuentaId.Nombre + " - "  + item.CuentaId.Numero + " (" + item.CuentaId.BancoId.Nombre + ")";
                newButton.TextColor = System.Drawing.Color.White;
                newButton.UseVisualStyleBackColor = false;

                newButton.Click += new System.EventHandler(BankAccountButton_Click);

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
            backButton.Size = new System.Drawing.Size(MainPanel.Width - 5, 77);
            backButton.TabIndex = 3;
            backButton.Text = MultilanguangeController.GetText("Salir");
            backButton.TextColor = System.Drawing.Color.White;
            backButton.UseVisualStyleBackColor = false;

            this.MainPanel.Controls.Add(backButton);

            backButton.Click += new System.EventHandler(BackButton_Click);
        }
        private void BankAccountButton_Click(object sender, EventArgs e)
        {
            DatabaseController.CurrentUserBankAccount = (Permaquim.Depositario.Entities.Relations.Banca.UsuarioCuenta)((CustomButton)sender).Tag;

            AppController.OpenChildForm(new BillDepositForm(),
            (Permaquim.Depositary.UI.Desktop.Components.Device)this.Tag);

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
