using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using AvaloniaAppMVVM_1.ViewModels.Visitor;
using ReactiveUI;

namespace AvaloniaAppMVVM_1.Views.Visitor
{
    public partial class AddVisitorWindowView : ReactiveWindow<AddVisitorWindowViewModel>
    {
        public AddVisitorWindowView()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.AddVisitorCommand.Subscribe(Close)));
            this.WhenActivated(d => d(ViewModel!.CancelCommand.Subscribe(Close)));
        }
    }
}
