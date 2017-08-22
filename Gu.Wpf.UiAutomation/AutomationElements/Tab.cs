﻿namespace Gu.Wpf.UiAutomation.AutomationElements
{
    using System;
    using System.Linq;
    using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
    using Gu.Wpf.UiAutomation.Definitions;

    public class Tab : AutomationElement
    {
        public Tab(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// The currently selected <see cref="TabItem" />
        /// </summary>
        public TabItem SelectedTabItem
        {
            get { return TabItems.FirstOrDefault(t => t.IsSelected); }
        }

        /// <summary>
        /// The index of the currently selected <see cref="TabItem" />
        /// </summary>
        public int SelectedTabItemIndex => GetIndexOfSelectedTabItem();

        /// <summary>
        /// All <see cref="TabItem" /> objects from this <see cref="Tab" />
        /// </summary>
        public TabItem[] TabItems => GetTabItems();

        /// <summary>
        /// Selects a <see cref="TabItem" /> by index
        /// </summary>
        public TabItem SelectTabItem(int index)
        {
            var tabItem = TabItems[index];
            tabItem.Select();
            return tabItem;
        }

        /// <summary>
        /// Selects a <see cref="TabItem" /> by a give text (name property)
        /// </summary>
        public TabItem SelectTabItem(string text)
        {
            var tabItems = TabItems;
            var foundTabItemIndex = Array.FindIndex(tabItems, t => t.Properties.Name == text);
            if (foundTabItemIndex < 0)
            {
                throw new Exception($"No TabItem found with text '{text}'");
            }
            var tabItem = tabItems[foundTabItemIndex];
            if (SelectedTabItemIndex != foundTabItemIndex)
            {
                // It is not the selected one, so select it
                tabItem.Select();
            }
            return tabItem;
        }

        /// <summary>
        /// Gets all the <see cref="TabItem" /> objects for this <see cref="Tab" />
        /// </summary>
        private TabItem[] GetTabItems()
        {
            return FindAll(TreeScope.Children, ConditionFactory.ByControlType(ControlType.TabItem))
                .Select(e => e.AsTabItem()).ToArray();
        }

        private int GetIndexOfSelectedTabItem()
        {
            return Array.FindIndex(TabItems, t => t.IsSelected);
        }
    }
}
