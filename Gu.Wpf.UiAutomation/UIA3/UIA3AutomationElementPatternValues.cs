﻿namespace Gu.Wpf.UiAutomation.UIA3
{
    using System;
    using Gu.Wpf.UiAutomation.UIA3.Patterns;

    public class UIA3AutomationElementPatternValues : AutomationElementPatternValuesBase
    {
        public UIA3AutomationElementPatternValues(UIA3BasicAutomationElement basicAutomationElement)
            : base(basicAutomationElement)
        {
        }

        public override IAutomationPattern<T> GetCustomPattern<T, TNative>(PatternId pattern, Func<BasicAutomationElementBase, TNative, T> patternCreateFunc)
        {
            return new AutomationPattern<T, TNative>(pattern, this.BasicAutomationElement, patternCreateFunc);
        }

        protected override IAutomationPattern<IAnnotationPattern> InitializeAnnotationPattern()
        {
            return new AutomationPattern<IAnnotationPattern, Interop.UIAutomationClient.IUIAutomationAnnotationPattern>(
                AnnotationPattern.Pattern, this.BasicAutomationElement, (b, p) => new AnnotationPattern(b, p));
        }

        protected override IAutomationPattern<IDockPattern> InitializeDockPattern()
        {
            return new AutomationPattern<IDockPattern, Interop.UIAutomationClient.IUIAutomationDockPattern>(
                DockPattern.Pattern, this.BasicAutomationElement, (b, p) => new DockPattern(b, p));
        }

        protected override IAutomationPattern<IDragPattern> InitializeDragPattern()
        {
            return new AutomationPattern<IDragPattern, Interop.UIAutomationClient.IUIAutomationDragPattern>(
                DragPattern.Pattern, this.BasicAutomationElement, (b, p) => new DragPattern(b, p));
        }

        protected override IAutomationPattern<IDropTargetPattern> InitializeDropTargetPattern()
        {
            return new AutomationPattern<IDropTargetPattern, Interop.UIAutomationClient.IUIAutomationDropTargetPattern>(
                DropTargetPattern.Pattern, this.BasicAutomationElement, (b, p) => new DropTargetPattern(b, p));
        }

        protected override IAutomationPattern<IExpandCollapsePattern> InitializeExpandCollapsePattern()
        {
            return new AutomationPattern<IExpandCollapsePattern, Interop.UIAutomationClient.IUIAutomationExpandCollapsePattern>(
                ExpandCollapsePattern.Pattern, this.BasicAutomationElement, (b, p) => new ExpandCollapsePattern(b, p));
        }

        protected override IAutomationPattern<IGridItemPattern> InitializeGridItemPattern()
        {
            return new AutomationPattern<IGridItemPattern, Interop.UIAutomationClient.IUIAutomationGridItemPattern>(
                GridItemPattern.Pattern, this.BasicAutomationElement, (b, p) => new GridItemPattern(b, p));
        }

        protected override IAutomationPattern<IGridPattern> InitializeGridPattern()
        {
            return new AutomationPattern<IGridPattern, Interop.UIAutomationClient.IUIAutomationGridPattern>(
                 GridPattern.Pattern, this.BasicAutomationElement, (b, p) => new GridPattern(b, p));
        }

        protected override IAutomationPattern<IInvokePattern> InitializeInvokePattern()
        {
            return new AutomationPattern<IInvokePattern, Interop.UIAutomationClient.IUIAutomationInvokePattern>(
                InvokePattern.Pattern, this.BasicAutomationElement, (b, p) => new InvokePattern(b, p));
        }

        protected override IAutomationPattern<IItemContainerPattern> InitializeItemContainerPattern()
        {
            return new AutomationPattern<IItemContainerPattern, Interop.UIAutomationClient.IUIAutomationItemContainerPattern>(
                ItemContainerPattern.Pattern, this.BasicAutomationElement, (b, p) => new ItemContainerPattern(b, p));
        }

        protected override IAutomationPattern<ILegacyIAccessiblePattern> InitializeLegacyIAccessiblePattern()
        {
            return new AutomationPattern<ILegacyIAccessiblePattern, Interop.UIAutomationClient.IUIAutomationLegacyIAccessiblePattern>(
                LegacyIAccessiblePattern.Pattern, this.BasicAutomationElement, (b, p) => new LegacyIAccessiblePattern(b, p));
        }

        protected override IAutomationPattern<IMultipleViewPattern> InitializeMultipleViewPattern()
        {
            return new AutomationPattern<IMultipleViewPattern, Interop.UIAutomationClient.IUIAutomationMultipleViewPattern>(
                MultipleViewPattern.Pattern, this.BasicAutomationElement, (b, p) => new MultipleViewPattern(b, p));
        }

        protected override IAutomationPattern<IObjectModelPattern> InitializeObjectModelPattern()
        {
            return new AutomationPattern<IObjectModelPattern, Interop.UIAutomationClient.IUIAutomationObjectModelPattern>(
                ObjectModelPattern.Pattern, this.BasicAutomationElement, (b, p) => new ObjectModelPattern(b, p));
        }

        protected override IAutomationPattern<IRangeValuePattern> InitializeRangeValuePattern()
        {
            return new AutomationPattern<IRangeValuePattern, Interop.UIAutomationClient.IUIAutomationRangeValuePattern>(
                RangeValuePattern.Pattern, this.BasicAutomationElement, (b, p) => new RangeValuePattern(b, p));
        }

        protected override IAutomationPattern<IScrollItemPattern> InitializeScrollItemPattern()
        {
            return new AutomationPattern<IScrollItemPattern, Interop.UIAutomationClient.IUIAutomationScrollItemPattern>(
                ScrollItemPattern.Pattern, this.BasicAutomationElement, (b, p) => new ScrollItemPattern(b, p));
        }

        protected override IAutomationPattern<IScrollPattern> InitializeScrollPattern()
        {
            return new AutomationPattern<IScrollPattern, Interop.UIAutomationClient.IUIAutomationScrollPattern>(
                ScrollPattern.Pattern, this.BasicAutomationElement, (b, p) => new ScrollPattern(b, p));
        }

        protected override IAutomationPattern<ISelectionItemPattern> InitializeSelectionItemPattern()
        {
            return new AutomationPattern<ISelectionItemPattern, Interop.UIAutomationClient.IUIAutomationSelectionItemPattern>(
                SelectionItemPattern.Pattern, this.BasicAutomationElement, (b, p) => new SelectionItemPattern(b, p));
        }

        protected override IAutomationPattern<ISelectionPattern> InitializeSelectionPattern()
        {
            return new AutomationPattern<ISelectionPattern, Interop.UIAutomationClient.IUIAutomationSelectionPattern>(
                SelectionPattern.Pattern, this.BasicAutomationElement, (b, p) => new SelectionPattern(b, p));
        }

        protected override IAutomationPattern<ISpreadsheetItemPattern> InitializeSpreadsheetItemPattern()
        {
            return new AutomationPattern<ISpreadsheetItemPattern, Interop.UIAutomationClient.IUIAutomationSpreadsheetItemPattern>(
                SpreadsheetItemPattern.Pattern, this.BasicAutomationElement, (b, p) => new SpreadsheetItemPattern(b, p));
        }

        protected override IAutomationPattern<ISpreadsheetPattern> InitializeSpreadsheetPattern()
        {
            return new AutomationPattern<ISpreadsheetPattern, Interop.UIAutomationClient.IUIAutomationSpreadsheetPattern>(
                SpreadsheetPattern.Pattern, this.BasicAutomationElement, (b, p) => new SpreadsheetPattern(b, p));
        }

        protected override IAutomationPattern<IStylesPattern> InitializeStylesPattern()
        {
            return new AutomationPattern<IStylesPattern, Interop.UIAutomationClient.IUIAutomationStylesPattern>(
                StylesPattern.Pattern, this.BasicAutomationElement, (b, p) => new StylesPattern(b, p));
        }

        protected override IAutomationPattern<ISynchronizedInputPattern> InitializeSynchronizedInputPattern()
        {
            return new AutomationPattern<ISynchronizedInputPattern, Interop.UIAutomationClient.IUIAutomationSynchronizedInputPattern>(
                SynchronizedInputPattern.Pattern, this.BasicAutomationElement, (b, p) => new SynchronizedInputPattern(b, p));
        }

        protected override IAutomationPattern<ITableItemPattern> InitializeTableItemPattern()
        {
            return new AutomationPattern<ITableItemPattern, Interop.UIAutomationClient.IUIAutomationTableItemPattern>(
                TableItemPattern.Pattern, this.BasicAutomationElement, (b, p) => new TableItemPattern(b, p));
        }

        protected override IAutomationPattern<ITablePattern> InitializeTablePattern()
        {
            return new AutomationPattern<ITablePattern, Interop.UIAutomationClient.IUIAutomationTablePattern>(
                TablePattern.Pattern, this.BasicAutomationElement, (b, p) => new TablePattern(b, p));
        }

        protected override IAutomationPattern<ITextChildPattern> InitializeTextChildPattern()
        {
            return new AutomationPattern<ITextChildPattern, Interop.UIAutomationClient.IUIAutomationTextChildPattern>(
                TextChildPattern.Pattern, this.BasicAutomationElement, (b, p) => new TextChildPattern(b, p));
        }

        protected override IAutomationPattern<ITextEditPattern> InitializeTextEditPattern()
        {
            return new AutomationPattern<ITextEditPattern, Interop.UIAutomationClient.IUIAutomationTextEditPattern>(
                TextEditPattern.Pattern, this.BasicAutomationElement, (b, p) => new TextEditPattern(b, p));
        }

        protected override IAutomationPattern<IText2Pattern> InitializeText2Pattern()
        {
            return new AutomationPattern<IText2Pattern, Interop.UIAutomationClient.IUIAutomationTextPattern2>(
                Text2Pattern.Pattern, this.BasicAutomationElement, (b, p) => new Text2Pattern(b, p));
        }

        protected override IAutomationPattern<ITextPattern> InitializeTextPattern()
        {
            return new AutomationPattern<ITextPattern, Interop.UIAutomationClient.IUIAutomationTextPattern>(
                TextPattern.Pattern, this.BasicAutomationElement, (b, p) => new TextPattern(b, p));
        }

        protected override IAutomationPattern<ITogglePattern> InitializeTogglePattern()
        {
            return new AutomationPattern<ITogglePattern, Interop.UIAutomationClient.IUIAutomationTogglePattern>(
                TogglePattern.Pattern, this.BasicAutomationElement, (b, p) => new TogglePattern(b, p));
        }

        protected override IAutomationPattern<ITransform2Pattern> InitializeTransform2Pattern()
        {
            return new AutomationPattern<ITransform2Pattern, Interop.UIAutomationClient.IUIAutomationTransformPattern2>(
                Transform2Pattern.Pattern, this.BasicAutomationElement, (b, p) => new Transform2Pattern(b, p));
        }

        protected override IAutomationPattern<ITransformPattern> InitializeTransformPattern()
        {
            return new AutomationPattern<ITransformPattern, Interop.UIAutomationClient.IUIAutomationTransformPattern>(
                TransformPattern.Pattern, this.BasicAutomationElement, (b, p) => new TransformPattern(b, p));
        }

        protected override IAutomationPattern<IValuePattern> InitializeValuePattern()
        {
            return new AutomationPattern<IValuePattern, Interop.UIAutomationClient.IUIAutomationValuePattern>(
                ValuePattern.Pattern, this.BasicAutomationElement, (b, p) => new ValuePattern(b, p));
        }

        protected override IAutomationPattern<IVirtualizedItemPattern> InitializeVirtualizedItemPattern()
        {
            return new AutomationPattern<IVirtualizedItemPattern, Interop.UIAutomationClient.IUIAutomationVirtualizedItemPattern>(
                 VirtualizedItemPattern.Pattern, this.BasicAutomationElement, (b, p) => new VirtualizedItemPattern(b, p));
        }

        protected override IAutomationPattern<IWindowPattern> InitializeWindowPattern()
        {
            return new AutomationPattern<IWindowPattern, Interop.UIAutomationClient.IUIAutomationWindowPattern>(
                WindowPattern.Pattern, this.BasicAutomationElement, (b, p) => new WindowPattern(b, p));
        }
    }
}
