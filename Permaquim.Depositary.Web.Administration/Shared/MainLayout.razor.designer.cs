﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Identity;
using Microsoft.JSInterop;

namespace Permaquim.Depositary.Web.Administration.Layouts
{
    public partial class MainLayoutComponent : LayoutComponentBase
    {

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        //[Inject]
        //protected SecurityService Security { get; set; }

        //[Inject]
        //protected CrmService Crm { get; set; }

        protected RadzenBody body0;
        protected RadzenSidebar sidebar0;

        private void Authenticated()
        {
             StateHasChanged();
        }

    }
}
