﻿using Gu.Wpf.UiAutomation.Definitions;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns;
using Gu.Wpf.UiAutomation.Tools;
using Gu.Wpf.UiAutomation.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    public class Transform2Pattern : Transform2PatternBase<UIA.IUIAutomationTransformPattern2>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TransformPattern2Id, "Transform2", AutomationObjectIds.IsTransformPattern2AvailableProperty);
        public static readonly PropertyId CanZoomProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2CanZoomPropertyId, "CanZoom");
        public static readonly PropertyId ZoomLevelProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomLevelPropertyId, "ZoomLevel");
        public static readonly PropertyId ZoomMaximumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMaximumPropertyId, "ZoomMaximum");
        public static readonly PropertyId ZoomMinimumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMinimumPropertyId, "ZoomMinimum");

        private readonly TransformPattern _transformPattern;

        public Transform2Pattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTransformPattern2 nativePattern) : base(basicAutomationElement, nativePattern)
        {
            _transformPattern = new TransformPattern(basicAutomationElement, nativePattern);
        }
        
        public override void Zoom(double zoom)
        {
            ComCallWrapper.Call(() => NativePattern.Zoom(zoom));
        }

        public override void ZoomByUnit(ZoomUnit zoomUnit)
        {
            ComCallWrapper.Call(() => NativePattern.ZoomByUnit((UIA.ZoomUnit)zoomUnit));
        }

        public override void Move(double x, double y)
        {
            _transformPattern.Move(x,y);
        }

        public override void Resize(double width, double height)
        {
            _transformPattern.Resize(width, height);
        }

        public override void Rotate(double degrees)
        {
            _transformPattern.Rotate(degrees);
        }
    }

    public class Transform2PatternProperties : TransformPatternProperties, ITransform2PatternProperties
    {
        public PropertyId CanZoom => Transform2Pattern.CanZoomProperty;
        public PropertyId ZoomLevel => Transform2Pattern.ZoomLevelProperty;
        public PropertyId ZoomMaximum => Transform2Pattern.ZoomMaximumProperty;
        public PropertyId ZoomMinimum => Transform2Pattern.ZoomMinimumProperty;
    }
}
