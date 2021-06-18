﻿// project=LibBuilder.WPF.Core, file=MvxWpfSetup.cs, creation=2020:8:24 Copyright (c) 2020
// Timeline Financials GmbH & Co. KG. All rights reserved.
using Data;
using LibBuilder.WPF.Core.Region;
using Microsoft.Extensions.Logging;
using MvvmCross.IoC;
using MvvmCross.Logging;
using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.ViewModels;
using Serilog;
using Serilog.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;

namespace LibBuilder.WPF.App
{
    public class MvxWpfSetup<TApplication> : MvvmCross.Platforms.Wpf.Core.MvxWpfSetup<TApplication> where TApplication : class, IMvxApplication, new()
    {
        public override IEnumerable<Assembly> GetViewAssemblies()
        {
            var list = new List<Assembly>();
            list.AddRange(base.GetViewAssemblies());
            list.Add(typeof(LibBuilder.WPF.Core.Views.MainWindow).Assembly);
            return list.ToArray();
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            // serilog configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.RollingFile(Constants.LogPath)
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override IMvxWpfViewPresenter CreateViewPresenter(ContentControl root)
        {
            return new MvxWpfPresenter(root);
        }
    }
}