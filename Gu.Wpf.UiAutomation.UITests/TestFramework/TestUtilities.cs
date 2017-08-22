﻿using System;
using Gu.Wpf.UiAutomation.AutomationElements;
using Gu.Wpf.UiAutomation.Input;
using Gu.Wpf.UiAutomation.Shapes;
using Gu.Wpf.UiAutomation.UIA2;
using Gu.Wpf.UiAutomation.UIA3;
using NUnit.Framework;

namespace Gu.Wpf.UiAutomation.UITests.TestFramework
{
    /// <summary>
    /// Various helpful methods
    /// </summary>
    public static class TestUtilities
    {
        public static AutomationBase GetAutomation(AutomationType automationType)
        {
            if (TestContext.Parameters.Exists("uia"))
            {
                var uiaVersion = Convert.ToInt32(TestContext.Parameters["uia"]);
                if ((automationType == AutomationType.UIA2 && uiaVersion != 2) ||
                    (automationType == AutomationType.UIA3 && uiaVersion != 3))
                {
                    Assert.Inconclusive($"UIA parameter set to {uiaVersion} but automation of type {automationType} is requested");
                }
            }
            switch (automationType)
            {
                case AutomationType.UIA2:
                    return new UIA2Automation();
                case AutomationType.UIA3:
                    return new UIA3Automation();
                default:
                    throw new ArgumentOutOfRangeException(nameof(automationType), automationType, null);
            }
        }

        /// <summary>
        /// Closes the given window and invokes the "Don't save" button
        /// </summary>
        public static void CloseWindowWithDontSave(Window window)
        {
            window.Close();
            Helpers.WaitUntilInputIsProcessed();
            var modal = window.ModalWindows;
            var dontSaveButton = modal[0].FindFirstDescendant(cf => cf.ByAutomationId("CommandButton_7")).AsButton();
            dontSaveButton.Invoke();
        }

        public static void AssertPointsAreSame(Point p1, Point p2, double variance = 0)
        {
            Assert.That(p1.X, Is.EqualTo(p2.X).Within(variance));
            Assert.That(p1.Y, Is.EqualTo(p2.Y).Within(variance));
        }
    }
}
