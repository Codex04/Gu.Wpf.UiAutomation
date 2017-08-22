﻿using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
using Gu.Wpf.UiAutomation.Definitions;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns;
using Gu.Wpf.UiAutomation.Shapes;
using Gu.Wpf.UiAutomation.UIA2.Converters;
using Gu.Wpf.UiAutomation.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace Gu.Wpf.UiAutomation.UIA2.Patterns
{
    public class TextPattern : TextPatternBase<UIA.TextPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TextPattern.Pattern.Id, "Text", AutomationObjectIds.IsTextPatternAvailableProperty);
        public static readonly EventId TextChangedEvent = EventId.Register(AutomationType.UIA2, UIA.TextPattern.TextChangedEvent.Id, "TextChanged");
        public static readonly EventId TextSelectionChangedEvent = EventId.Register(AutomationType.UIA2, UIA.TextPattern.TextSelectionChangedEvent.Id, "TextSelectionChanged");

        public TextPattern(BasicAutomationElementBase basicAutomationElement, UIA.TextPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public override ITextRange DocumentRange
        {
            get
            {
                var nativeRange = NativePattern.DocumentRange;
                return TextRangeConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRange);
            }
        }

        public override SupportedTextSelection SupportedTextSelection
        {
            get
            {
                var nativeObject = NativePattern.SupportedTextSelection;
                return (SupportedTextSelection)nativeObject;
            }
        }

        public override ITextRange[] GetSelection()
        {
            var nativeRanges = NativePattern.GetSelection();
            return TextRangeConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRanges);
        }

        public override ITextRange[] GetVisibleRanges()
        {
            var nativeRanges = NativePattern.GetVisibleRanges();
            return TextRangeConverter.NativeArrayToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRanges);
        }

        public override ITextRange RangeFromChild(AutomationElement child)
        {
            var nativeChild = child.ToNative();
            var nativeRange = NativePattern.RangeFromChild(nativeChild);
            return TextRangeConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRange);
        }

        public override ITextRange RangeFromPoint(Point point)
        {
            var nativeRange = NativePattern.RangeFromPoint(ValueConverter.ToNative(point));
            return TextRangeConverter.NativeToManaged((UIA2Automation)BasicAutomationElement.Automation, nativeRange);
        }
    }

    public class TextPatternEvents : ITextPatternEvents
    {
        public EventId TextChangedEvent => TextPattern.TextChangedEvent;
        public EventId TextSelectionChangedEvent => TextPattern.TextSelectionChangedEvent;
    }
}
