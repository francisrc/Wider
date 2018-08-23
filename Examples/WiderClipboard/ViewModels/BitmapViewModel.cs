﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Wider.Core.Services;
using WiderClipboard.Models;
using WiderClipboard.Views;

namespace WiderClipboard.ViewModels
{
    class BitmapViewModel : ContentViewModel
    {
        public ImageSource ImageSource { get; set; }

        public BitmapViewModel(IWorkspace workspace, ICommandManager commandManager, ILoggerService logger, IMenuService menuService) :
            base(workspace, commandManager, logger, menuService)
        {
            Model = new EmptyModel();
            View = new BitmapView();
        }
    }
}
