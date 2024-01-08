using ASP.NET_Core_Razor_Page.Enums;

namespace ASP.NET_Core_Razor_Page.Model.ViewModel
{
    public class Notification
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}
