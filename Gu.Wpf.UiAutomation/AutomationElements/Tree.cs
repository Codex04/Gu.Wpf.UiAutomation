﻿namespace Gu.Wpf.UiAutomation
{
    using System.Linq;
    using Gu.Wpf.UiAutomation.Definitions;

    public class Tree : AutomationElement
    {
        public Tree(BasicAutomationElementBase basicAutomationElement)
            : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// The currently selected <see cref="TreeItem" />
        /// </summary>
        public TreeItem SelectedTreeItem => this.SearchSelectedItem(this.TreeItems);

        private TreeItem SearchSelectedItem(TreeItem[] treeItems)
        {
            // Search for a selected item in the direct children
            var directSelectedItem = treeItems.FirstOrDefault(t => t.IsSelected);
            if (directSelectedItem != null)
            {
                return directSelectedItem;
            }

            // Loop thru the children and search in their children
            foreach (var treeItem in treeItems)
            {
                var selectedInChildItem = this.SearchSelectedItem(treeItem.TreeItems);
                if (selectedInChildItem != null)
                {
                    return selectedInChildItem;
                }
            }

            return null;
        }

        /// <summary>
        /// All child <see cref="TreeItem" /> objects from this <see cref="Tree" />
        /// </summary>
        public TreeItem[] TreeItems => this.GetTreeItems();

        /// <summary>
        /// Gets all the <see cref="TreeItem" /> objects for this <see cref="Tree" />
        /// </summary>
        private TreeItem[] GetTreeItems()
        {
            return this.FindAllChildren(cf => cf.ByControlType(ControlType.TreeItem))
                .Select(e => e.AsTreeItem())
                .ToArray();
        }
    }
}
