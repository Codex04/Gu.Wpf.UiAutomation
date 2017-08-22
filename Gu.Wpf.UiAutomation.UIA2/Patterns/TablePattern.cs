﻿using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Patterns;
using Gu.Wpf.UiAutomation.UIA2.Converters;
using Gu.Wpf.UiAutomation.UIA2.Identifiers;
using UIA = System.Windows.Automation;

namespace Gu.Wpf.UiAutomation.UIA2.Patterns
{
    public class TablePattern : TablePatternBase<UIA.TablePattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA2, UIA.TablePattern.Pattern.Id, "Table", AutomationObjectIds.IsTablePatternAvailableProperty);
        public static readonly PropertyId ColumnHeadersProperty = PropertyId.Register(AutomationType.UIA2, UIA.TablePattern.ColumnHeadersProperty.Id, "ColumnHeaders").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId RowHeadersProperty = PropertyId.Register(AutomationType.UIA2, UIA.TablePattern.RowHeadersProperty.Id, "RowHeaders").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly PropertyId RowOrColumnMajorProperty = PropertyId.Register(AutomationType.UIA2, UIA.TablePattern.RowOrColumnMajorProperty.Id, "RowOrColumnMajor");

        public TablePattern(BasicAutomationElementBase basicAutomationElement, UIA.TablePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }
    }

    public class TablePatternProperties : ITablePatternProperties
    {
        public PropertyId ColumnHeaders => TablePattern.ColumnHeadersProperty;
        public PropertyId RowHeaders => TablePattern.RowHeadersProperty;
        public PropertyId RowOrColumnMajor => TablePattern.RowOrColumnMajorProperty;
    }
}
