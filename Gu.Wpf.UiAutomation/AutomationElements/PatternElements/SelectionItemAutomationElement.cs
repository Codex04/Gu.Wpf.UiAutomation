﻿namespace Gu.Wpf.UiAutomation.AutomationElements.PatternElements
{
    using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
    using Gu.Wpf.UiAutomation.Patterns;

    /// <summary>
    /// An UI-item which supports the <see cref="ISelectionItemPattern" />
    /// </summary>
    public class SelectionItemAutomationElement : AutomationElement
    {
        public SelectionItemAutomationElement(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        protected ISelectionItemPattern SelectionItemPattern => Patterns.SelectionItem.Pattern;

        /// <summary>
        /// Flag to get/set the selection of this element.
        /// </summary>
        public bool IsSelected
        {
            get { return SelectionItemPattern.IsSelected; }
            set
            {
                if (IsSelected == value) return;
                if (value && !IsSelected)
                {
                    Select();
                }
            }
        }

        /// <summary>
        /// Select this element.
        /// </summary>
        public SelectionItemAutomationElement Select()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.Select());
            return this;
        }

        /// <summary>
        /// Add this element to the selection.
        /// </summary>
        public SelectionItemAutomationElement AddToSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.AddToSelection());
            return this;
        }

        /// <summary>
        /// Remove this element from the selection.
        /// </summary>
        public SelectionItemAutomationElement RemoveFromSelection()
        {
            ExecuteInPattern(SelectionItemPattern, true, pattern => pattern.RemoveFromSelection());
            return this;
        }
    }
}
