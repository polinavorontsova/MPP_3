using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Core.Entities;
using WpfApplication.Services;
using WpfApplication.Services.Implementations;

namespace WpfApplication.Views
{
    public class ApplicationView : INotifyPropertyChanged
    {
        private const string FileFilter = "Assemblies (*.dll) | *.dll";
        private IEnumerable<NamespaceView> _namespaces;

        private Command _openAssembly;

        public IEnumerable<NamespaceView> Namespaces
        {
            get => _namespaces;
            set
            {
                _namespaces = value;
                OnPropertyChanged();
            }
        }

        public Command OpenAssembly
        {
            get
            {
                return _openAssembly ??= new Command(item =>
                {
                    IDialogService dialogService = new DialogService();
                    var filePath = dialogService.Open(FileFilter);
                    if (filePath == null) return;
                    try
                    {
                        var assemblyInfo = new AssemblyInformation(filePath);
                        Namespaces = assemblyInfo.Namespaces.Select(namespaceInfo => new NamespaceView(namespaceInfo));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        Namespaces = ImmutableList<NamespaceView>.Empty;
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}