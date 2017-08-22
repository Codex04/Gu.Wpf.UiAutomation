﻿using Gu.Wpf.UiAutomation.Definitions;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns;
using Gu.Wpf.UiAutomation.Tools;
using Gu.Wpf.UiAutomation.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    public class ScrollPattern : ScrollPatternBase<UIA.IUIAutomationScrollPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_ScrollPatternId, "Scroll", AutomationObjectIds.IsScrollPatternAvailableProperty);
        public static readonly PropertyId HorizontallyScrollableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollHorizontallyScrollablePropertyId, "HorizontallyScrollable");
        public static readonly PropertyId HorizontalScrollPercentProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollHorizontalScrollPercentPropertyId, "HorizontalScrollPercent");
        public static readonly PropertyId HorizontalViewSizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollHorizontalViewSizePropertyId, "HorizontalViewSize");
        public static readonly PropertyId VerticallyScrollableProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollVerticallyScrollablePropertyId, "VerticallyScrollable");
        public static readonly PropertyId VerticalScrollPercentProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollVerticalScrollPercentPropertyId, "VerticalScrollPercent");
        public static readonly PropertyId VerticalViewSizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_ScrollVerticalViewSizePropertyId, "VerticalViewSize");

        public ScrollPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationScrollPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public override void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount)
        {
            ComCallWrapper.Call(() => NativePattern.Scroll((UIA.ScrollAmount)horizontalAmount, (UIA.ScrollAmount)verticalAmount));
        }

        public override void SetScrollPercent(double horizontalPercent, double verticalPercent)
        {
            ComCallWrapper.Call(() => NativePattern.SetScrollPercent(horizontalPercent, verticalPercent));
        }
    }

    public class ScrollPatternProperties : IScrollPatternProperties
    {
        public PropertyId HorizontallyScrollable => ScrollPattern.HorizontallyScrollableProperty;

        public PropertyId HorizontalScrollPercent => ScrollPattern.HorizontalScrollPercentProperty;

        public PropertyId HorizontalViewSize => ScrollPattern.HorizontalViewSizeProperty;

        public PropertyId VerticallyScrollable => ScrollPattern.VerticallyScrollableProperty;

        public PropertyId VerticalScrollPercent => ScrollPattern.VerticalScrollPercentProperty;

        public PropertyId VerticalViewSize => ScrollPattern.VerticalViewSizeProperty;
    }
}
