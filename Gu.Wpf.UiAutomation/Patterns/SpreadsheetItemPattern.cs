﻿using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
using Gu.Wpf.UiAutomation.Definitions;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns.Infrastructure;

namespace Gu.Wpf.UiAutomation.Patterns
{
    public interface ISpreadsheetItemPattern : IPattern
    {
        ISpreadsheetItemPatternProperties Properties { get; }

        AutomationProperty<string> Formula { get; }
        AutomationProperty<AutomationElement[]> AnnotationObjects { get; }
        AutomationProperty<AnnotationType[]> AnnotationTypes { get; }
    }

    public interface ISpreadsheetItemPatternProperties
    {
        PropertyId Formula { get; }
        PropertyId AnnotationObjects { get; }
        PropertyId AnnotationTypes { get; }
    }

    public abstract class SpreadsheetItemPatternBase<TNativePattern> : PatternBase<TNativePattern>, ISpreadsheetItemPattern
    {
        private AutomationProperty<string> _formula;
        private AutomationProperty<AutomationElement[]> _annotationObjects;
        private AutomationProperty<AnnotationType[]> _annotationTypes;

        protected SpreadsheetItemPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ISpreadsheetItemPatternProperties Properties => Automation.PropertyLibrary.SpreadsheetItem;

        public AutomationProperty<string> Formula => GetOrCreate(ref _formula, Properties.Formula);
        public AutomationProperty<AutomationElement[]> AnnotationObjects => GetOrCreate(ref _annotationObjects, Properties.AnnotationObjects);
        public AutomationProperty<AnnotationType[]> AnnotationTypes => GetOrCreate(ref _annotationTypes, Properties.AnnotationTypes);
    }
}
