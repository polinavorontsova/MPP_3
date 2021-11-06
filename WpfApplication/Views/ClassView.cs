using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Entities;

namespace WpfApplication.Views
{
    public class ClassView : INotifyPropertyChanged
    {
        private string _name;

        public ClassView(ClassInformation classInformation)
        {
            Name = classInformation.Name;
        }


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}