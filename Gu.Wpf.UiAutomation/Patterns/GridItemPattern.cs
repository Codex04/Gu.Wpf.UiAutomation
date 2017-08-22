﻿namespace Gu.Wpf.UiAutomation.Patterns
{
    using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
    using Gu.Wpf.UiAutomation.Identifiers;
    using Gu.Wpf.UiAutomation.Patterns.Infrastructure;

    public interface IGridItemPattern : IPattern
    {
        IGridItemPatternProperties Properties { get; }

        AutomationProperty<int> Column { get; }
        AutomationProperty<int> ColumnSpan { get; }
        AutomationProperty<AutomationElement> ContainingGrid { get; }
        AutomationProperty<int> Row { get; }
        AutomationProperty<int> RowSpan { get; }
    }

    public interface IGridItemPatternProperties
    {
        PropertyId Column { get; }
        PropertyId ColumnSpan { get; }
        PropertyId ContainingGrid { get; }
        PropertyId Row { get; }
        PropertyId RowSpan { get; }
    }

    public abstract class GridItemPatternBase<TNativePattern> : PatternBase<TNativePattern>, IGridItemPattern
    {
        private AutomationProperty<int> _column;
        private AutomationProperty<int> _columnSpan;
        private AutomationProperty<AutomationElement> _containingGrid;
        private AutomationProperty<int> _row;
        private AutomationProperty<int> _rowSpan;

        protected GridItemPatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public IGridItemPatternProperties Properties => Automation.PropertyLibrary.GridItem;

        public AutomationProperty<int> Column => GetOrCreate(ref _column, Properties.Column);
        public AutomationProperty<int> ColumnSpan => GetOrCreate(ref _columnSpan, Properties.ColumnSpan);
        public AutomationProperty<AutomationElement> ContainingGrid => GetOrCreate(ref _containingGrid, Properties.ContainingGrid);
        public AutomationProperty<int> Row => GetOrCreate(ref _row, Properties.Row);
        public AutomationProperty<int> RowSpan => GetOrCreate(ref _rowSpan, Properties.RowSpan);
    }
}
