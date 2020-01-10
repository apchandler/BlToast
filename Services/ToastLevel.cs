using System;
using System.Threading.Tasks;
using System.Timers;

namespace BlToast.Services
{
    public enum ToastLevel
    {
        Info, Success, Warning, Error
    }

    public class ToastService
    {

        public string Heading { get; set; }
        public string Message { get; set; }
        public string BackgroundCssClass { get; set; }
        public string IconCssClass { get; set; }
        public string VisibleCssClass { get; set; }


        public event Action Show;

        public void ShowToast(string message, ToastLevel level)
        {
            BuildToastSettings(level, message);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => Show?.Invoke();

        private void BuildToastSettings(ToastLevel level, string message)
        {
            switch (level)
            {
                case ToastLevel.Info:
                    BackgroundCssClass = "bg-info";
                    IconCssClass = "info";
                    Heading = "Info";
                    break;
                case ToastLevel.Success:
                    BackgroundCssClass = "bg-success";
                    IconCssClass = "check";
                    Heading = "Success";
                    break;
                case ToastLevel.Warning:
                    BackgroundCssClass = "bg-warning";
                    IconCssClass = "exclamation";
                    Heading = "Warning";
                    break;
                case ToastLevel.Error:
                    BackgroundCssClass = "bg-danger";
                    IconCssClass = "times";
                    Heading = "Error";
                    break;
            }

            VisibleCssClass = VisibleCssClass == null || VisibleCssClass == "toast-visible1"
                ? "toast-visible" : "toast-visible1";

            Message = message;
        }

    }
}
