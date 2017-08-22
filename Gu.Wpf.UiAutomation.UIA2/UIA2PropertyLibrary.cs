﻿namespace Gu.Wpf.UiAutomation.UIA2
{
    using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
    using Gu.Wpf.UiAutomation.Patterns;
    using Gu.Wpf.UiAutomation.UIA2.Patterns;

    public class UIA2PropertyLibrary : IPropertyLibray
    {
        public UIA2PropertyLibrary()
        {
            PatternAvailability = new UIA2AutomationElementPatternAvailabilityProperties();
            Element = new UIA2AutomationElementProperties();
            Annotation = new AnnotationPatternProperties();
            Dock = new DockPatternProperties();
            Drag = new DragPatternProperties();
            DropTarget = new DropTargetPatternProperties();
            ExpandCollapse = new ExpandCollapsePatternProperties();
            GridItem = new GridItemPatternProperties();
            Grid = new GridPatternProperties();
            LegacyIAccessible = new LegacyIAccessiblePatternProperties();
            MultipleView = new MultipleViewPatternProperties();
            RangeValue = new RangeValuePatternProperties();
            Scroll = new ScrollPatternProperties();
            SelectionItem = new SelectionItemPatternProperties();
            Selection = new SelectionPatternProperties();
            SpreadsheetItem = new SpreadsheetItemPatternProperties();
            Styles = new StylesPatternProperties();
            TableItem = new TableItemPatternProperties();
            Table = new TablePatternProperties();
            Toggle = new TogglePatternProperties();
            Transform2 = new Transform2PatternProperties();
            Transform = new TransformPatternProperties();
            Value = new ValuePatternProperties();
            Window = new WindowPatternProperties();
        }

        public IAutomationElementPatternAvailabilityProperties PatternAvailability { get; }
        public IAutomationElementProperties Element { get; }
        public IAnnotationPatternProperties Annotation { get; }
        public IDockPatternProperties Dock { get; }
        public IDragPatternProperties Drag { get; }
        public IDropTargetPatternProperties DropTarget { get; }
        public IExpandCollapsePatternProperties ExpandCollapse { get; }
        public IGridItemPatternProperties GridItem { get; }
        public IGridPatternProperties Grid { get; }
        public ILegacyIAccessiblePatternProperties LegacyIAccessible { get; }
        public IMultipleViewPatternProperties MultipleView { get; }
        public IRangeValuePatternProperties RangeValue { get; }
        public IScrollPatternProperties Scroll { get; }
        public ISelectionItemPatternProperties SelectionItem { get; }
        public ISelectionPatternProperties Selection { get; }
        public ISpreadsheetItemPatternProperties SpreadsheetItem { get; }
        public IStylesPatternProperties Styles { get; }
        public ITableItemPatternProperties TableItem { get; }
        public ITablePatternProperties Table { get; }
        public ITogglePatternProperties Toggle { get; }
        public ITransform2PatternProperties Transform2 { get; }
        public ITransformPatternProperties Transform { get; }
        public IValuePatternProperties Value { get; }
        public IWindowPatternProperties Window { get; }
    }
}
