﻿namespace Gu.Wpf.UiAutomation.Patterns
{
    using Accessibility;
    using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
    using Gu.Wpf.UiAutomation.Identifiers;
    using Gu.Wpf.UiAutomation.Patterns.Infrastructure;
    using Gu.Wpf.UiAutomation.WindowsAPI;

    public interface ILegacyIAccessiblePattern : IPattern
    {
        ILegacyIAccessiblePatternProperties Properties { get; }

        AutomationProperty<int> ChildId { get; }
        AutomationProperty<string> DefaultAction { get; }
        AutomationProperty<string> Description { get; }
        AutomationProperty<string> Help { get; }
        AutomationProperty<string> KeyboardShortcut { get; }
        AutomationProperty<string> Name { get; }
        AutomationProperty<AccessibilityRole> Role { get; }
        AutomationProperty<AutomationElement[]> Selection { get; }
        AutomationProperty<AccessibilityState> State { get; }
        AutomationProperty<string> Value { get; }

        void DoDefaultAction();
        IAccessible GetIAccessible();
        void Select(int flagsSelect);
        void SetValue(string value);
    }

    public interface ILegacyIAccessiblePatternProperties
    {
        PropertyId ChildId { get; }
        PropertyId DefaultAction { get; }
        PropertyId Description { get; }
        PropertyId Help { get; }
        PropertyId KeyboardShortcut { get; }
        PropertyId Name { get; }
        PropertyId Role { get; }
        PropertyId Selection { get; }
        PropertyId State { get; }
        PropertyId Value { get; }
    }

    public abstract class LegacyIAccessiblePatternBase<TNativePattern> : PatternBase<TNativePattern>, ILegacyIAccessiblePattern
    {
        private AutomationProperty<int> _childId;
        private AutomationProperty<string> _defaultAction;
        private AutomationProperty<string> _description;
        private AutomationProperty<string> _help;
        private AutomationProperty<string> _keyboardShortcut;
        private AutomationProperty<string> _name;
        private AutomationProperty<AccessibilityRole> _role;
        private AutomationProperty<AutomationElement[]> _selection;
        private AutomationProperty<AccessibilityState> _state;
        private AutomationProperty<string> _value;

        protected LegacyIAccessiblePatternBase(BasicAutomationElementBase basicAutomationElement, TNativePattern nativePattern) : base(basicAutomationElement, nativePattern)
        {
        }

        public ILegacyIAccessiblePatternProperties Properties => Automation.PropertyLibrary.LegacyIAccessible;

        public AutomationProperty<int> ChildId => GetOrCreate(ref _childId, Properties.ChildId);
        public AutomationProperty<string> DefaultAction => GetOrCreate(ref _defaultAction, Properties.DefaultAction);
        public AutomationProperty<string> Description => GetOrCreate(ref _description, Properties.Description);
        public AutomationProperty<string> Help => GetOrCreate(ref _help, Properties.Help);
        public AutomationProperty<string> KeyboardShortcut => GetOrCreate(ref _keyboardShortcut, Properties.KeyboardShortcut);
        public AutomationProperty<string> Name => GetOrCreate(ref _name, Properties.Name);
        public AutomationProperty<AccessibilityRole> Role => GetOrCreate(ref _role, Properties.Role);
        public AutomationProperty<AutomationElement[]> Selection => GetOrCreate(ref _selection, Properties.Selection);
        public AutomationProperty<AccessibilityState> State => GetOrCreate(ref _state, Properties.State);
        public AutomationProperty<string> Value => GetOrCreate(ref _value, Properties.Value);

        public abstract void DoDefaultAction();
        public abstract IAccessible GetIAccessible();
        public abstract void Select(int flagsSelect);
        public abstract void SetValue(string value);
    }
}
