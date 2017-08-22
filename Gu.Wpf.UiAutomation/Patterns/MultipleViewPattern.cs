﻿using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns.Infrastructure;

namespace Gu.Wpf.UiAutomation.Patterns
{
    public interface IMultipleViewPattern : IPattern
    {
        IMultipleViewPatternProperties Properties { get; }

        AutomationProperty<int> CurrentView { get; }
        AutomationProperty<int[]> SupportedViews { get; }

        string GetViewName(int view);
        void SetCurrentView(int view);
    }

    public interface IMultipleViewPatternProperties
    {
        PropertyId CurrentView { get; }
        PropertyId SupportedViews { get; }
    }

    public abstract class MultipleViewPatternBase<TNativePattern> : PatternBase<TNativePattern>, IMultipleViewPattern
    {
        private AutomationProperty<int> _currentView;
        private AutomationProperty<int[]> _supportedViews;

        protected MultipleViewPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IMultipleViewPatternProperties Properties => Automation.PropertyLibrary.MultipleView;

        public AutomationProperty<int> CurrentView => GetOrCreate(ref _currentView, Properties.CurrentView);
        public AutomationProperty<int[]> SupportedViews => GetOrCreate(ref _supportedViews, Properties.SupportedViews);

        public abstract string GetViewName(int view);
        public abstract void SetCurrentView(int view);
    }
}
