﻿using Gu.Wpf.UiAutomation.Definitions;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns.Infrastructure;

namespace Gu.Wpf.UiAutomation.Patterns
{
    public class ScrollPatternConstants
    {
        public const double NoScroll = -1.0;
    }

    public interface IScrollPattern : IPattern
    {
        IScrollPatternProperties Properties { get; }

        AutomationProperty<bool> HorizontallyScrollable { get; }
        AutomationProperty<double> HorizontalScrollPercent { get; }
        AutomationProperty<double> HorizontalViewSize { get; }
        AutomationProperty<bool> VerticallyScrollable { get; }
        AutomationProperty<double> VerticalScrollPercent { get; }
        AutomationProperty<double> VerticalViewSize { get; }

        void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
        void SetScrollPercent(double horizontalPercent, double verticalPercent);
    }

    public interface IScrollPatternProperties
    {
        PropertyId HorizontallyScrollable { get; }
        PropertyId HorizontalScrollPercent { get; }
        PropertyId HorizontalViewSize { get; }
        PropertyId VerticallyScrollable { get; }
        PropertyId VerticalScrollPercent { get; }
        PropertyId VerticalViewSize { get; }
    }

    public abstract class ScrollPatternBase<TNativePattern> : PatternBase<TNativePattern>, IScrollPattern
    {
        private AutomationProperty<bool> _horizontallyScrollable;
        private AutomationProperty<double> _horizontalScrollPercent;
        private AutomationProperty<double> _horizontalViewSize;
        private AutomationProperty<bool> _verticallyScrollable;
        private AutomationProperty<double> _verticalScrollPercent;
        private AutomationProperty<double> _verticalViewSize;

        protected ScrollPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IScrollPatternProperties Properties => Automation.PropertyLibrary.Scroll;

        public AutomationProperty<bool> HorizontallyScrollable => GetOrCreate(ref _horizontallyScrollable, Properties.HorizontallyScrollable);
        public AutomationProperty<double> HorizontalScrollPercent => GetOrCreate(ref _horizontalScrollPercent, Properties.HorizontalScrollPercent);
        public AutomationProperty<double> HorizontalViewSize => GetOrCreate(ref _horizontalViewSize, Properties.HorizontalViewSize);
        public AutomationProperty<bool> VerticallyScrollable => GetOrCreate(ref _verticallyScrollable, Properties.VerticallyScrollable);
        public AutomationProperty<double> VerticalScrollPercent => GetOrCreate(ref _verticalScrollPercent, Properties.VerticalScrollPercent);
        public AutomationProperty<double> VerticalViewSize => GetOrCreate(ref _verticalViewSize, Properties.VerticalViewSize);

        public abstract void Scroll(ScrollAmount horizontalAmount, ScrollAmount verticalAmount);
        public abstract void SetScrollPercent(double horizontalPercent, double verticalPercent);
    }
}
