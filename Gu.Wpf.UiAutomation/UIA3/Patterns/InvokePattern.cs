﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;

    public class InvokePattern : InvokePatternBase<Interop.UIAutomationClient.IUIAutomationInvokePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(Interop.UIAutomationClient.UIA_PatternIds.UIA_InvokePatternId, "Invoke", AutomationObjectIds.IsInvokePatternAvailableProperty);
        public static readonly EventId InvokedEvent = EventId.Register(Interop.UIAutomationClient.UIA_EventIds.UIA_Invoke_InvokedEventId, "Invoked");

        public InvokePattern(BasicAutomationElementBase basicAutomationElement, Interop.UIAutomationClient.IUIAutomationInvokePattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        public override void Invoke()
        {
            ComCallWrapper.Call(() => this.NativePattern.Invoke());
        }
    }
}
