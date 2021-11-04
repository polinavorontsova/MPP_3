using Microsoft.Win32;

namespace WpfApplication.Services.Implementations
{
    public class DialogService : IDialogService
    {
        public string? Open(string fileFilter)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = fileFilter
            };
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : null;
        }
    }
}