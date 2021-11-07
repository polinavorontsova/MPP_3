using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Core.Entities;

namespace WpfApplication.Views
{
    public class ClassView : INotifyPropertyChanged
    {
        private IEnumerable<MemberView> _members;

        private string _name;

        public ClassView(ClassInformation classInformation)
        {
            Name = classInformation.Name;
            var memberPropertyView = classInformation.Properties.Select(property => new MemberView(property));
            var memberMethodView = classInformation.Methods.Select(method => new MemberView(method));
            var memberFieldView = classInformation.Fields.Select(field => new MemberView(field));
            Members = memberPropertyView.Concat(memberMethodView).Concat(memberFieldView);
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

        public IEnumerable<MemberView> Members
        {
            get => _members;
            set
            {
                _members = value;
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