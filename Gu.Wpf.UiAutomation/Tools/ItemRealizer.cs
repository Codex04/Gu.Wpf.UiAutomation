namespace Gu.Wpf.UiAutomation
{
    using System.Windows.Automation;

    /// <summary>
    /// Helper class which tries to load all items for an item container.
    /// </summary>
    public static class ItemRealizer
    {
        public static void RealizeItems(UiElement itemContainerElement)
        {
            if (itemContainerElement is null)
            {
                throw new System.ArgumentNullException(nameof(itemContainerElement));
            }

            // We save the scroll value to restore it afterwards
            if (itemContainerElement.AutomationElement.TryGetScrollPattern(out var scrollPattern))
            {
                var currHScroll = scrollPattern.Current.HorizontalScrollPercent;
                var currVScroll = scrollPattern.Current.VerticalScrollPercent;

                // First we try with the item container pattern and realize each item
                if (itemContainerElement.AutomationElement.TryGetItemContainerPattern(out var itemContainerPattern))
                {
                    // There's the item container pattern so we can go thru all elements and just realize them
                    AutomationElement? currElement = null;
                    while (true)
                    {
                        currElement = itemContainerPattern.FindItemByProperty(currElement, null, null);
                        if (currElement is null)
                        {
                            break;
                        }

                        if (currElement.TryGetVirtualizedItemPattern(out var virtualizedItemPattern))
                        {
                            virtualizedItemPattern.Realize();
                        }
                    }
                }
                else
                {
                    // Second we use the scroll pattern to scroll from top to bottom
                    scrollPattern.SetScrollPercent(0, 0);
                    do
                    {
                        scrollPattern.Scroll(ScrollAmount.NoAmount, ScrollAmount.SmallIncrement);
                    }
                    while (scrollPattern.Current.VerticalScrollPercent < 100);
                }

                ResetScroll(scrollPattern, currHScroll, currVScroll);
                return;
            }

            // Third we try by using the scrollbar controls itself
            {
                // TODO
            }
        }

        private static void ResetScroll(ScrollPattern scrollPattern, double hScrollPercentage, double vScrollPercentage)
        {
            scrollPattern.SetScrollPercent(hScrollPercentage, vScrollPercentage);
        }
    }
}
