// project=LibBuilder.Core, file=MainViewModel.cs, create=09:16 Copyright (c) 2021
// Timeline Financials GmbH & Co. KG. All rights reserved.
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace LibBuilder.Core.ViewModels
{
    public class MainViewModel : MvxNavigationViewModel
    {
        private bool _contentVis;

        private bool _menuVis;

        public bool ContentVis
        {
            get => _contentVis;
            set => SetProperty(ref _contentVis, value);
        }

        public bool MenuVis
        {
            get => _menuVis;
            set => SetProperty(ref _menuVis, value);
        }

        public IMvxCommand OpenColorsCommand { get; set; }

        public IMvxCommand OpenContentCommand { get; set; }

        public IMvxCommand OpenProcessesCommand { get; set; }

        public IMvxCommand OpenSettingsCommand { get; set; }

        public MainViewModel(ILoggerFactory logProvider, IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
        {
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public override void Prepare()
        {
            base.Prepare();
        }
    }
}