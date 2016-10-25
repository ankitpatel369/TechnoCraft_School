using System.Web.Mvc;

namespace TechnoCraft_School.Utils.Notification
{
	public static class ControllerExtensions
	{
        public static void ShowMessage(this Controller controller, MessageType messageType, string message, bool showAfterRedirect = false, bool showErrorInPopup = false)
		{
			var messageTypeKey = messageType.ToString();
			if (showAfterRedirect)
			{
				controller.TempData[messageTypeKey] = message;
			}
			else
			{
				controller.ViewData[messageTypeKey] = message;
			}
            controller.ViewData["showErrorInPopup"] = showErrorInPopup;
		}
	}
}