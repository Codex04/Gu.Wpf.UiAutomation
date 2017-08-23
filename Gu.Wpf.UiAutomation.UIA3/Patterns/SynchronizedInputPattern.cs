﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.Definitions;
    using Gu.Wpf.UiAutomation.Identifiers;
    using Gu.Wpf.UiAutomation.Patterns;
    using Gu.Wpf.UiAutomation.Tools;
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;
    using UIA = Interop.UIAutomationClient;

    public class SynchronizedInputPattern : SynchronizedInputPatternBase<UIA.IUIAutomationSynchronizedInputPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_SynchronizedInputPatternId, "SynchronizedInput", AutomationObjectIds.IsSynchronizedInputPatternAvailableProperty);
        public static readonly EventId DiscardedEvent = EventId.Register(UIA.UIA_EventIds.UIA_InputDiscardedEventId, "Discarded");
        public static readonly EventId ReachedOtherElementEvent = EventId.Register(UIA.UIA_EventIds.UIA_InputReachedOtherElementEventId, "ReachedOtherElement");
        public static readonly EventId ReachedTargetEvent = EventId.Register(UIA.UIA_EventIds.UIA_InputReachedTargetEventId, "ReachedTarget");

        public SynchronizedInputPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationSynchronizedInputPattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        public override void Cancel()
        {
            ComCallWrapper.Call(() => this.NativePattern.Cancel());
        }

        public override void StartListening(SynchronizedInputType inputType)
        {
            ComCallWrapper.Call(() => this.NativePattern.StartListening((UIA.SynchronizedInputType)inputType));
        }
    }
}
