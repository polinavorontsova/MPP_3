using System.ComponentModel;
using System.Runtime.CompilerServices;
using Core.Entities;

namespace WpfApplication.Views
{
    public class MemberView : INotifyPropertyChanged
    {
        private string _name;

        public MemberView(FieldInformation field)
        {
            Name = field.Name;
        }

        public MemberView(PropertyInformation property)
        {
            Name = property.Name;
        }

        public MemberView(MethodInformation method)
        {
            Name = method.Name;
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