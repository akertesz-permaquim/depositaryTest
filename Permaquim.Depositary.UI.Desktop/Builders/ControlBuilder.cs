using Permaquim.Depositary.UI.Desktop.Controllers;
using Permaquim.Depositary.UI.Desktop.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Builders
{
    internal static class ControlBuilder
    {
        private static System.Windows.Forms.Button BuildButton()
        {
            System.Windows.Forms.Button newButton = new();



            newButton.FlatAppearance.BorderSize = 0;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.Font = new Font("Verdana", 14F, FontStyle.Bold, GraphicsUnit.Point);
            newButton.TabIndex = 0;
            newButton.UseVisualStyleBackColor = false;
            return newButton;
        }

        public static System.Windows.Forms.Button BuildStandardButton(string name, string text, int width,int height = 77)
        {

            System.Windows.Forms.Button newButton = BuildButton();

            newButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAceptar);

            newButton.Name = name;
            newButton.Text = text;
            newButton.Size = new Size(width - 5, height);
            newButton.TabIndex = 0;
            newButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            return newButton;
        }
        public static System.Windows.Forms.Button BuildExitButton(string name, string text, int width, int height = 77)
        {
            System.Windows.Forms.Button newButton = BuildButton();

            newButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonSalir);
            newButton.Name = name;
            newButton.Text = text;
            newButton.Size = new Size(width - 5, height);
            newButton.TabIndex = 0;
            newButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            return newButton;
        }
        public static System.Windows.Forms.Button BuildCancelButton(string name, string text, int width, int height = 77)
        {
            System.Windows.Forms.Button newButton = BuildButton();

            newButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonCancelar);
            newButton.Name = name;
            newButton.Text = text;
            newButton.Size = new Size(width - 5, height);
            newButton.TabIndex = 0;
            newButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            return newButton;
        }
        public static System.Windows.Forms.Button BuildAlternateButton(string name, string text, int width, int height = 77)
        {
            System.Windows.Forms.Button newButton = BuildButton();

            newButton.BackColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonAlternativo);
            newButton.Name = name;
            newButton.Text = text;
            newButton.Size = new Size(width - 5, height);
            newButton.TabIndex = 0;
            newButton.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.FuenteContraste);

            return newButton;
        }

        public static CustomTextBox BuildStandardTextBox(string name, string placeholder, int width, int height = 77)
        {

            CustomTextBox newTextBox = new CustomTextBox();
            newTextBox.BackColor = Color.White;
            newTextBox.BorderColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonEstandar);
            newTextBox.BorderFocusColor = Color.MediumSlateBlue;
            newTextBox.BorderRadius = 4;
            newTextBox.BorderSize = 2;
            newTextBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            newTextBox.ForeColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonEstandar);
            newTextBox.Margin = new Padding(4);
            newTextBox.Multiline = false;
            newTextBox.Name = name;
            newTextBox.Padding = new Padding(10, 7, 10, 7);
            newTextBox.PasswordChar = false;
            newTextBox.PlaceholderColor = StyleController.GetColor(Enumerations.ColorNameEnum.BotonEstandar);
            newTextBox.PlaceholderText = placeholder;
            newTextBox.Size = new Size(width - 5, height);
            newTextBox.Texts = "";
            newTextBox.UnderlinedStyle = false;
            newTextBox.Visible = false;

            return newTextBox;
        }

    }
}
