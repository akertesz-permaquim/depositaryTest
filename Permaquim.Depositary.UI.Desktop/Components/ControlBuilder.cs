using Permaquim.Depositary.UI.Desktop.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permaquim.Depositary.UI.Desktop.Components
{
    internal static class ControlBuilder
    {
        private static CustomButton BuildButton()
        {
            CustomButton newButton = new();


            newButton.BorderRadius = 5;
            newButton.BorderSize = 0;
            newButton.FlatAppearance.BorderSize = 0;
            newButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            newButton.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            newButton.TabIndex = 0;
            newButton.UseVisualStyleBackColor = false;
            return newButton;
        }

        public static CustomButton BuildStandardbutton(string name, string text,int width)
        {

            CustomButton newButton = BuildButton();

            newButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            newButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAceptar);
            newButton.Name = name;
            newButton.Text = text;
            newButton.Size = new System.Drawing.Size(width - 5, 77);
            newButton.TabIndex = 0;
            newButton.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            newButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);

            return newButton;
        }
        public static CustomButton BuildExitButton(string name, string text, int width)
        {
            CustomButton newButton = BuildButton();

            newButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            newButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            newButton.Name = name;
            newButton.Text = text;
            newButton.Size = new System.Drawing.Size(width -5, 77);
            newButton.TabIndex = 0;
            newButton.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            newButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);

            return newButton;
        }
        public static CustomButton BuildAlternateButton(string name, string text, int width)
        {
            CustomButton newButton = BuildButton();

            newButton.BackColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAlternativo);
            newButton.BackgroundColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonAlternativo);
            newButton.Name = name;
            newButton.Text = text;
            newButton.Size = new System.Drawing.Size(width - 5, 77);
            newButton.TabIndex = 0;
            newButton.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);
            newButton.TextColor = StyleController.GetColor(StyleController.ColorNameEnum.FuenteContraste);

            return newButton;
        }

        public static CustomTextBox BuildStandardTextBox(string name,string placeholder,int width)
        {

            CustomTextBox newTextBox = new CustomTextBox();
            newTextBox.BackColor = Color.White;
            newTextBox.BorderColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            newTextBox.BorderFocusColor = System.Drawing.Color.MediumSlateBlue;
            newTextBox.BorderRadius = 4;
            newTextBox.BorderSize = 2;
            newTextBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            newTextBox.ForeColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            newTextBox.Margin = new System.Windows.Forms.Padding(4);
            newTextBox.Multiline = false;
            newTextBox.Name = name;
            newTextBox.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            newTextBox.PasswordChar = false;
            newTextBox.PlaceholderColor = StyleController.GetColor(StyleController.ColorNameEnum.BotonEstandar);
            newTextBox.PlaceholderText = placeholder;
            newTextBox.Size = new System.Drawing.Size(width -5, 50);
            newTextBox.Texts = "";
            newTextBox.UnderlinedStyle = false;
            newTextBox.Visible = false;
            
            return newTextBox;
        }

    }
}
