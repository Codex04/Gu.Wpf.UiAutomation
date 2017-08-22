﻿namespace Gu.Wpf.UiAutomation.Logging
{
    using System;

    public static class Logger
    {
        private static ILogger _default = new ConsoleLogger();

        public static ILogger Default
        {
            get
            {
                return _default;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _default = value;
            }
        }
    }
}
