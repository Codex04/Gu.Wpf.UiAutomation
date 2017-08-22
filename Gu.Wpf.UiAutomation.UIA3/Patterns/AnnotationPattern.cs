﻿using Gu.Wpf.UiAutomation;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns;
using Gu.Wpf.UiAutomation.UIA3.Converters;
using Gu.Wpf.UiAutomation.UIA3.Identifiers;
using UIA = Interop.UIAutomationClient;

namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    public class AnnotationPattern : AnnotationPatternBase<UIA.IUIAutomationAnnotationPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_AnnotationPatternId, "Annotation", AutomationObjectIds.IsAnnotationPatternAvailableProperty);
        public static readonly PropertyId AnnotationTypeIdProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeIdPropertyId, "AnnotationTypeId");
        public static readonly PropertyId AnnotationTypeNameProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAnnotationTypeNamePropertyId, "AnnotationTypeName");
        public static readonly PropertyId AuthorProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationAuthorPropertyId, "Author");
        public static readonly PropertyId DateTimeProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationDateTimePropertyId, "DateTime");
        public static readonly PropertyId TargetProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_AnnotationTargetPropertyId, "Target").SetConverter(AutomationElementConverter.NativeToManaged);

        public AnnotationPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationAnnotationPattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }
    }

    public class AnnotationPatternProperties : IAnnotationPatternProperties
    {
        public PropertyId AnnotationTypeId => AnnotationPattern.AnnotationTypeIdProperty;
        public PropertyId AnnotationTypeName => AnnotationPattern.AnnotationTypeNameProperty;
        public PropertyId Author => AnnotationPattern.AuthorProperty;
        public PropertyId DateTime => AnnotationPattern.DateTimeProperty;
        public PropertyId Target => AnnotationPattern.TargetProperty;
    }
}
