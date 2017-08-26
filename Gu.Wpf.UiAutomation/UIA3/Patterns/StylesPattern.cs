﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.UIA3.Converters;
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;

    public class StylesPattern : StylesPatternBase<Interop.UIAutomationClient.IUIAutomationStylesPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(Interop.UIAutomationClient.UIA_PatternIds.UIA_StylesPatternId, "Styles", AutomationObjectIds.IsStylesPatternAvailableProperty);
        public static readonly PropertyId ExtendedPropertiesProperty = PropertyId.Register(Interop.UIAutomationClient.UIA_PropertyIds.UIA_StylesExtendedPropertiesPropertyId, "ExtendedProperties");
        public static readonly PropertyId FillColorProperty = PropertyId.Register(Interop.UIAutomationClient.UIA_PropertyIds.UIA_StylesFillColorPropertyId, "FillColor");
        public static readonly PropertyId FillPatternColorProperty = PropertyId.Register(Interop.UIAutomationClient.UIA_PropertyIds.UIA_StylesFillPatternColorPropertyId, "FillPatternColor");
        public static readonly PropertyId FillPatternStyleProperty = PropertyId.Register(Interop.UIAutomationClient.UIA_PropertyIds.UIA_StylesFillPatternStylePropertyId, "FillPatternStyle");
        public static readonly PropertyId ShapeProperty = PropertyId.Register(Interop.UIAutomationClient.UIA_PropertyIds.UIA_StylesShapePropertyId, "Shape");
        public static readonly PropertyId StyleIdProperty = PropertyId.Register(Interop.UIAutomationClient.UIA_PropertyIds.UIA_StylesStyleIdPropertyId, "StyleId").SetConverter((a, o) => StyleTypeConverter.ToStyleType(o));
        public static readonly PropertyId StyleNameProperty = PropertyId.Register(Interop.UIAutomationClient.UIA_PropertyIds.UIA_StylesStyleNamePropertyId, "StyleName");

        public StylesPattern(BasicAutomationElementBase basicAutomationElement, Interop.UIAutomationClient.IUIAutomationStylesPattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }

        // TODO: Any way to implement that?
        ////public void GetCachedExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
        ////public void GetCurrentExtendedPropertiesAsArray(IntPtr propertyArray, out int propertyCount){}
    }
}
