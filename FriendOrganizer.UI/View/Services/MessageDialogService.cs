using System.Windows;

namespace FriendOrganizer.UI.View.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowOkCancelDialog(string text, string title)
        {
            // Render standard message box and show it
            var result = MessageBox.Show(text, title, MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                return MessageDialogResult.Ok;
            }

            return MessageDialogResult.Cancel;
        }
    }

    public enum MessageDialogResult
    {
        Ok,
        Cancel
    }
}
