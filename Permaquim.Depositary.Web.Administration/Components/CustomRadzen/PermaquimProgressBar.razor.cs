using Microsoft.AspNetCore.Components;
using System;
using Radzen;

namespace Permaquim.Depositary.Web.Administration.Components.CustomRadzen
{
    /// <summary>
    /// PermaquimProgressBar component.
    /// </summary>
    /// <example>
    /// <code>
    /// &lt;RadzenProgressBar @bind-Value="@value" Max="200" /&gt;
    /// </code>
    /// </example>
    public partial class PermaquimProgressBar : RadzenComponent
    {
        /// <inheritdoc />
        protected override string GetComponentCssClass()
        {
            return Mode == ProgressBarMode.Determinate ? "rz-progressbar rz-progressbar-determinate" : "rz-progressbar rz-progressbar-indeterminate";
        }

        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        /// <value>The mode.</value>
        [Parameter]
        public ProgressBarMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        [Parameter]
        public string Unit { get; set; } = "%";

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [Parameter]
        public float Value { get; set; }

        /// <summary>
        /// Determines the maximum value.
        /// </summary>
        /// <value>The maximum value.</value>
        [Parameter]
        public double Max { get; set; } = 100;

        /// <summary>
        /// Gets or sets a value indicating whether value is shown.
        /// </summary>
        /// <value><c>true</c> if value is shown; otherwise, <c>false</c>.</value>
        [Parameter]
        public bool ShowValue { get; set; } = true;

        /// <summary>
        /// Gets or sets the value changed callback.
        /// </summary>
        /// <value>The value changed callback.</value>
        [Parameter]
        public Action<double> ValueChanged { get; set; }

        /// <summary>
        /// Gets or sets the value changed callback.
        /// </summary>
        /// <value>The value changed callback.</value>
        [Parameter]
        public string BarColor { get; set; }
    }
}