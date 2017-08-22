﻿using System;
using System.Linq;
using Gu.Wpf.UiAutomation;
using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
using Gu.Wpf.UiAutomation.Conditions;
using Gu.Wpf.UiAutomation.Definitions;
using Gu.Wpf.UiAutomation.EventHandlers;
using Gu.Wpf.UiAutomation.Identifiers;
using Gu.Wpf.UiAutomation.Shapes;
using Gu.Wpf.UiAutomation.UIA2.Converters;
using Gu.Wpf.UiAutomation.UIA2.EventHandlers;
using Gu.Wpf.UiAutomation.UIA2.Extensions;
using UIA = System.Windows.Automation;

namespace Gu.Wpf.UiAutomation.UIA2
{
    public class UIA2BasicAutomationElement : BasicAutomationElementBase
    {
        public UIA2BasicAutomationElement(UIA2Automation automation, UIA.AutomationElement nativeElement) : base(automation)
        {
            Automation = automation;
            NativeElement = nativeElement;
            Patterns = new UIA2AutomationElementPatternValues(this);
        }
        
        public override AutomationElementPatternValuesBase Patterns { get; }

        /// <summary>
        /// Concrete implementation of the automation object
        /// </summary>
        public new UIA2Automation Automation { get; }

        /// <summary>
        /// Native object for the ui element
        /// </summary>
        public UIA.AutomationElement NativeElement { get; }

        public override void SetFocus()
        {
            NativeElement.SetFocus();
        }

        protected override object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported)
        {
            var property = UIA.AutomationProperty.LookupById(propertyId);
            var ignoreDefaultValue = !useDefaultIfNotSupported;
            var returnValue = cached ?
                NativeElement.GetCachedPropertyValue(property, ignoreDefaultValue) :
                NativeElement.GetCurrentPropertyValue(property, ignoreDefaultValue);
            return returnValue;
        }

        protected override object InternalGetPattern(int patternId, bool cached)
        {
            var pattern = UIA.AutomationPattern.LookupById(patternId);
            var returnedValue = cached
                ? NativeElement.GetCachedPattern(pattern)
                : NativeElement.GetCurrentPattern(pattern);
            return returnedValue;
        }

        public override AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition)
        {
            var cacheRequest = CacheRequest.IsCachingActive ? CacheRequest.Current.ToNative() : null;
            cacheRequest?.Push();
            var nativeFoundElements = NativeElement.FindAll((UIA.TreeScope)treeScope, ConditionConverter.ToNative(condition));
            cacheRequest?.Pop();
            return AutomationElementConverter.NativeArrayToManaged(Automation, nativeFoundElements);
        }

        public override AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition)
        {
            var cacheRequest = CacheRequest.IsCachingActive ? CacheRequest.Current.ToNative() : null;
            cacheRequest?.Push();
            var nativeFoundElement = NativeElement.FindFirst((UIA.TreeScope)treeScope, ConditionConverter.ToNative(condition));
            cacheRequest?.Pop();
            return AutomationElementConverter.NativeToManaged(Automation, nativeFoundElement);
        }

        public override bool TryGetClickablePoint(out Point point)
        {
            System.Windows.Point outPoint;
            var success = NativeElement.TryGetClickablePoint(out outPoint);
            if (success)
            {
                point = new Point(outPoint.X, outPoint.Y);
            }
            else
            {
                success = Properties.ClickablePoint.TryGetValue(out point);
            } 
            return success;
        }

        public override IAutomationEventHandler RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action)
        {
            var eventHandler = new UIA2BasicEventHandler(Automation, action);
            UIA.Automation.AddAutomationEventHandler(UIA.AutomationEvent.LookupById(@event.Id), NativeElement, (UIA.TreeScope)treeScope, eventHandler.EventHandler);
            return eventHandler;
        }

        public override IAutomationPropertyChangedEventHandler RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, PropertyId[] properties)
        {
            var eventHandler = new UIA2PropertyChangedEventHandler(Automation, action);
            UIA.Automation.AddAutomationPropertyChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, eventHandler.EventHandler);
            return eventHandler;
        }

        public override IAutomationStructureChangedEventHandler RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action)
        {
            var eventHandler = new UIA2StructureChangedEventHandler(Automation, action);
            UIA.Automation.AddStructureChangedEventHandler(NativeElement, (UIA.TreeScope)treeScope, eventHandler.EventHandler);
            return eventHandler;
        }

        public override void RemoveAutomationEventHandler(EventId @event, IAutomationEventHandler eventHandler)
        {
            UIA.Automation.RemoveAutomationEventHandler(UIA.AutomationEvent.LookupById(@event.Id), NativeElement, ((UIA2BasicEventHandler)eventHandler).EventHandler);
        }

        public override void RemovePropertyChangedEventHandler(IAutomationPropertyChangedEventHandler eventHandler)
        {
            UIA.Automation.RemoveAutomationPropertyChangedEventHandler(NativeElement, ((UIA2PropertyChangedEventHandler)eventHandler).EventHandler);
        }

        public override void RemoveStructureChangedEventHandler(IAutomationStructureChangedEventHandler eventHandler)
        {
            UIA.Automation.RemoveStructureChangedEventHandler(NativeElement, ((UIA2StructureChangedEventHandler)eventHandler).EventHandler);
        }

        public override PatternId[] GetSupportedPatterns()
        {
            var raw = NativeElement.GetSupportedPatterns();
            return raw.Select(r => PatternId.Find(Automation.AutomationType, r.Id)).ToArray();
        }

        public override PropertyId[] GetSupportedProperties()
        {
            var raw = NativeElement.GetSupportedProperties();
            return raw.Select(r => PropertyId.Find(Automation.AutomationType, r.Id)).ToArray();
        }

        public override AutomationElement GetUpdatedCache()
        {
            if (CacheRequest.Current != null)
            {
                var updatedElement = NativeElement.GetUpdatedCache(CacheRequest.Current.ToNative());
                return AutomationElementConverter.NativeToManaged(Automation, updatedElement);
            }
            return null;
        }

        public override AutomationElement[] GetCachedChildren()
        {
            var cachedChildren = NativeElement.CachedChildren;
            return AutomationElementConverter.NativeArrayToManaged(Automation, cachedChildren);
        }

        public override AutomationElement GetCachedParent()
        {
            var cachedParent = NativeElement.CachedParent;
            return AutomationElementConverter.NativeToManaged(Automation, cachedParent);
        }

        public override int GetHashCode()
        {
            return NativeElement.GetHashCode();
        }
    }
}
