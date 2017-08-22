﻿namespace Gu.Wpf.UiAutomation.Patterns.Infrastructure
{
    using System;
    using Gu.Wpf.UiAutomation.Identifiers;

    public abstract class PatternBase<TNativePattern> : IPattern
    {
        public BasicAutomationElementBase BasicAutomationElement { get; }

        public AutomationBase Automation => BasicAutomationElement.Automation;

        public TNativePattern NativePattern { get; private set; }

        protected PatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern)
        {
            if (basicAutomationElement == null)
            {
                throw new ArgumentNullException(nameof(basicAutomationElement));
            }
            if (nativePattern == null)
            {
                throw new ArgumentNullException(nameof(nativePattern));
            }
            BasicAutomationElement = basicAutomationElement;
            NativePattern = nativePattern;
        }

        protected AutomationProperty<T> GetOrCreate<T>(ref AutomationProperty<T> val, PropertyId propertyId)
        {
            return val ?? (val = new AutomationProperty<T>(propertyId, BasicAutomationElement));
        }
    }
}
