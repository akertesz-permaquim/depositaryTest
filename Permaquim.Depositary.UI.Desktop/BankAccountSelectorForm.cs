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


                newButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
                newButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
                newButton.BorderColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
                newButton.BorderRadius = 5;
                newButton.BorderSize = 0;
                newButton.FlatAppearance.BorderSize = 0;
                newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                newButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                newButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
                newButton.Location = new System.Drawing.Point(3, 3);
                newButton.Name = "BankAccounttButton" + item.Id.ToString();
                newButton.Size = new System.Drawing.Size(MainPanel.Width - 5, 77);
                newButton.TabIndex = 0;
                newButton.Text = item.CuentaId.Nombre + " - "  + item.CuentaId.Numero + " (" + item.CuentaId.BancoId.Nombre + ")";
                newButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
                newButton.UseVisualStyleBackColor = false;

                newButton.Click += new System.EventHandler(BankAccountButton_Click);

                newButton.Tag = item;

                this.MainPanel.Controls.Add(newButton);

            }
        }
        private void LoadBackButton()
        {
            CustomButton backButton = new CustomButton();

            backButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            backButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            backButton.BorderColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            backButton.BorderRadius = 5;
            backButton.BorderSize = 0;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            backButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            backButton.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            backButton.Location = new System.Drawing.Point(3, 3);
            backButton.Name = "BackButton";
            backButton.TabIndex = 3;
            backButton.Text = MultilanguangeController.GetText("Salir");
            backButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            backButton.UseVisualStyleBackColor = false;
            backButton.Size = new System.Drawing.Size(MainPanel.Width - 5, 77);
  

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
