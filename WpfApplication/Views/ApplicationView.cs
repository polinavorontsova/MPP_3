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

        private Command _openAssembly;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}