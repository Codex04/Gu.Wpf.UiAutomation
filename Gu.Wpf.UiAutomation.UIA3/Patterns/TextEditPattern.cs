﻿using Gu.Wpf.UiAutomation;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns;
using Gu.Wpf.UiAutomation.Tools;
using Gu.Wpf.UiAutomation.UIA3.Converters;
using Gu.Wpf.UiAutomation.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    public class TextEditPattern : TextPattern, ITextEditPattern
    {
        public new static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TextEditPatternId, "TextEdit", AutomationObjectIds.IsTextEditPatternAvailableProperty);
        public static readonly EventId ConversionTargetChangedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_TextEdit_ConversionTargetChangedEventId, "ConversionTargetChanged");
        public static readonly EventId TextChangedEvent2 = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_TextEdit_TextChangedEventId, "TextChanged");

        public TextEditPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTextEditPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
            ExtendedNativePattern = nativePattern;
        }

        public UIA.IUIAutomationTextEditPattern ExtendedNativePattern { get; }

        ITextEditPatternEvents ITextEditPattern.Events => Automation.EventLibrary.TextEdit;

        public ITextRange GetActiveComposition()
        {
            var nativeRange = ComCallWrapper.Call(() => ExtendedNativePattern.GetActiveComposition());
            return TextRangeConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRange);
        }

        public ITextRange GetConversionTarget()
        {
            var nativeRange = ComCallWrapper.Call(() => ExtendedNativePattern.GetConversionTarget());
            return TextRangeConverter.NativeToManaged((UIA3Automation)BasicAutomationElement.Automation, nativeRange);
        }
    }

    public class TextEditPatternEvents : TextPatternEvents, ITextEditPatternEvents
    {
        public EventId ConversionTargetChangedEvent => TextEditPattern.ConversionTargetChangedEvent;
        public EventId TextChangedEvent2 => TextEditPattern.TextChangedEvent2;
    }
}
