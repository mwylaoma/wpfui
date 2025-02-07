﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Windows;
using static System.String;

namespace WPFUI.Controls
{
    /// <summary>
    /// Button that opens a URL in a web browser.
    /// </summary>
    public class Hyperlink : WPFUI.Controls.Button
    {
        /// <summary>
        /// Property for <see cref="NavigateUri"/>.
        /// </summary>
        public static readonly DependencyProperty NavigateUriProperty = DependencyProperty.Register("NavigateUri",
            typeof(string), typeof(Hyperlink), new PropertyMetadata(Empty));

        /// <summary>
        /// The URL (or application shortcut) to open.
        /// </summary>
        public string NavigateUri
        {
            get => GetValue(NavigateUriProperty) as string;
            set => SetValue(NavigateUriProperty, value);
        }

        /// <summary>
        /// Action triggered when the button is clicked.
        /// </summary>
        public Hyperlink() => Click += RequestNavigate;

        private void RequestNavigate(object sender, RoutedEventArgs eventArgs)
        {
            if (IsNullOrEmpty(NavigateUri)) return;
            System.Diagnostics.ProcessStartInfo sInfo = new(new Uri(NavigateUri).AbsoluteUri)
            {
                UseShellExecute = true
            };

            System.Diagnostics.Process.Start(sInfo);
        }
    }
}