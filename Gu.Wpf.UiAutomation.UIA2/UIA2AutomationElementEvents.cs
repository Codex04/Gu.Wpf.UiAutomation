﻿using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.UIA2.Identifiers;

namespace Gu.Wpf.UiAutomation.UIA2
{
    public class UIA2AutomationElementEvents : IAutomationElementEvents
    {
        public EventId AsyncContentLoadedEvent => AutomationObjectIds.AsyncContentLoadedEvent;
        public EventId FocusChangedEvent => AutomationObjectIds.FocusChangedEvent;
        public EventId PropertyChangedEvent => AutomationObjectIds.PropertyChangedEvent;
        public EventId HostedFragmentRootsInvalidatedEvent => EventId.NotSupportedByFramework;
        public EventId LayoutInvalidatedEvent => AutomationObjectIds.LayoutInvalidatedEvent;
        public EventId LiveRegionChangedEvent => EventId.NotSupportedByFramework;
        public EventId MenuClosedEvent => AutomationObjectIds.MenuClosedEvent;
        public EventId MenuModeEndEvent => EventId.NotSupportedByFramework;
        public EventId MenuModeStartEvent => EventId.NotSupportedByFramework;
        public EventId MenuOpenedEvent => AutomationObjectIds.MenuOpenedEvent;
        public EventId StructureChangedEvent => AutomationObjectIds.StructureChangedEvent;
        public EventId SystemAlertEvent => EventId.NotSupportedByFramework;
        public EventId ToolTipClosedEvent => AutomationObjectIds.ToolTipClosedEvent;
        public EventId ToolTipOpenedEvent => AutomationObjectIds.ToolTipOpenedEvent;
    }
}
