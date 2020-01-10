using BlToast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlToast.Components
{
    public class ToastBase : ComponentBase, IDisposable
    {
        [Inject] public ToastService ToastService { get; set; }

        public bool ShouldShow = false;

        protected override void OnInitialized()
        {
            ToastService.Show += OnShow;
        }

        private void OnShow()
        {
            ShouldShow = true;
            base.InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            ToastService.Show -= OnShow;
        }
    }
}
