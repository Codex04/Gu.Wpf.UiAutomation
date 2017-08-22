﻿using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns;
using Gu.Wpf.UiAutomation.Tools;
using Gu.Wpf.UiAutomation.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    public class TransformPattern : TransformPatternBase<UIA.IUIAutomationTransformPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TransformPatternId, "Transform", AutomationObjectIds.IsTransformPatternAvailableProperty);
        public static readonly PropertyId CanMoveProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TransformCanMovePropertyId, "CanMove");
        public static readonly PropertyId CanResizeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TransformCanResizePropertyId, "CanResize");
        public static readonly PropertyId CanRotateProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_TransformCanRotatePropertyId, "CanRotate");

        public TransformPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTransformPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public override void Move(double x, double y)
        {
            ComCallWrapper.Call(() => NativePattern.Move(x, y));
        }

        public override void Resize(double width, double height)
        {
            ComCallWrapper.Call(() => NativePattern.Resize(width, height));
        }

        public override void Rotate(double degrees)
        {
            ComCallWrapper.Call(() => NativePattern.Rotate(degrees));
        }
    }

    public class TransformPatternProperties : ITransformPatternProperties
    {
        public PropertyId CanMove => TransformPattern.CanMoveProperty;

        public PropertyId CanResize => TransformPattern.CanResizeProperty;

        public PropertyId CanRotate => TransformPattern.CanRotateProperty;
    }
}
