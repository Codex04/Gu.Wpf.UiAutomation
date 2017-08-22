﻿namespace Gu.Wpf.UiAutomation.AutomationElements
{
    using Gu.Wpf.UiAutomation.AutomationElements.PatternElements;

    /// <summary>
    /// Represents an item in a combobox
    /// </summary>
    public class ComboBoxItem : SelectionItemAutomationElement
    {
        public ComboBoxItem(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        public virtual string Text
        {
            get
            {
                if (this.FrameworkType == FrameworkType.Wpf)
                {
                    // In WPF, the Text is actually an inner content only (text) element
                    // which can be accessed only with a raw walker.
                    var rawTreeWalker = this.Automation.TreeWalkerFactory.GetRawViewWalker();
                    var rawElement = rawTreeWalker.GetFirstChild(this);
                    if (rawElement != null)
                    {
                        return rawElement.Properties.Name.Value;
                    }
                }
                return this.BasicAutomationElement.Properties.Name.Value;
            }
        }
    }
}
