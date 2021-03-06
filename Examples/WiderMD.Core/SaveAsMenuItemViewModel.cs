﻿#region License
// Copyright (c) 2018 Mark Kromis
// Copyright (c) 2013 Chandramouleswaran Ravichandran
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

#endregion

using Prism.Events;
using Prism.Ioc;
using System;
using System.Windows.Input;
using System.Windows.Media;
using Wider.Core.Controls;
using Wider.Core.Events;
using Wider.Core.Services;

namespace Wider.Interfaces.Controls
{
    /// <summary>
    /// Class SaveAsMenuItemViewModel - simple menu implementation with events
    /// </summary>
    public sealed class SaveAsMenuItemViewModel : AbstractMenuItem
    {
        #region CTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItemViewModel"/> class.
        /// </summary>
        /// <param name="header">The header.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="command">The command.</param>
        /// <param name="gesture">The gesture.</param>
        /// <param name="isCheckable">if set to <c>true</c> this menu acts as a checkable menu.</param>
        /// <param name="hideDisabled">if set to <c>true</c> this menu is not visible when disabled.</param>
        /// <param name="container">The container.</param>
        public SaveAsMenuItemViewModel( IContainerProvider containerProvider,
            String header, Int32 priority, ImageSource icon = null, ICommand command = null,
            KeyGesture gesture = null, Boolean isCheckable = false, Boolean hideDisabled = false)
            : base(header, priority, icon, command, gesture, isCheckable, hideDisabled)
        {
            if (containerProvider != null)
            {
                IEventAggregator eventAggregator = containerProvider.Resolve<IEventAggregator>();
                eventAggregator.GetEvent<ActiveContentChangedEvent>().Subscribe(SaveAs);
            }
        }
        #endregion

        private void SaveAs(ContentViewModel cvm)
        {
            if (cvm != null)
            {
                Header = "Save " + cvm.Title + " As...";
            }
            else
            {
                Header = "Save As...";
            }
        }
    }
}