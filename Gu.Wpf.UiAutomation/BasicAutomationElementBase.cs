﻿namespace Gu.Wpf.UiAutomation
{
    using System;
    using Gu.Wpf.UiAutomation.AutomationElements.Infrastructure;
    using Gu.Wpf.UiAutomation.Conditions;
    using Gu.Wpf.UiAutomation.Definitions;
    using Gu.Wpf.UiAutomation.EventHandlers;
    using Gu.Wpf.UiAutomation.Exceptions;
    using Gu.Wpf.UiAutomation.Identifiers;
    using Gu.Wpf.UiAutomation.Shapes;

    public abstract class BasicAutomationElementBase
    {
        protected BasicAutomationElementBase(AutomationBase automation)
        {
            Automation = automation;
            Properties = new AutomationElementPropertyValues(this);
        }

        public abstract AutomationElementPatternValuesBase Patterns { get; }

        public AutomationElementPropertyValues Properties { get; }

        /// <summary>
        /// Underlying <see cref="AutomationBase" /> object where this element belongs to
        /// </summary>
        public AutomationBase Automation { get; }

        /// <summary>
        /// Gets the desired property value. Ends in an exception if the property is not supported or not cached.
        /// </summary>
        public object GetPropertyValue(PropertyId property)
        {
            return GetPropertyValue<object>(property);
        }

        public T GetPropertyValue<T>(PropertyId property)
        {
            if (Equals(property, PropertyId.NotSupportedByFramework))
            {
                throw new NotSupportedByFrameworkException();
            }
            var isCacheActive = CacheRequest.IsCachingActive;
            try
            {
                var value = InternalGetPropertyValue(property.Id, isCacheActive, false);
                if (value == Automation.NotSupportedValue)
                {
                    throw new PropertyNotSupportedException(property);
                }
                return property.Convert<T>(Automation, value);
            }
            catch (Exception ex)
            {
                if (isCacheActive)
                {
                    var cacheRequest = CacheRequest.Current;
                    if (!cacheRequest.Properties.Contains(property))
                    {
                        throw new PropertyNotCachedException(property, ex);
                    }
                }
                // Should actually never come here
                throw;
            }
        }

        /// <summary>
        /// Tries to get the property value.
        /// Returns false and sets a default value if the property is not supported.
        /// </summary>
        public bool TryGetPropertyValue(PropertyId property, out object value)
        {
            return TryGetPropertyValue<object>(property, out value);
        }

        public bool TryGetPropertyValue<T>(PropertyId property, out T value)
        {
            if (Equals(property, PropertyId.NotSupportedByFramework))
            {
                throw new NotSupportedByFrameworkException();
            }
            var isCacheActive = CacheRequest.IsCachingActive;
            try
            {
                var internalValue = InternalGetPropertyValue(property.Id, isCacheActive, false);
                if (internalValue == Automation.NotSupportedValue)
                {
                    value = default(T);
                    return false;
                }
                value = property.Convert<T>(Automation, internalValue);
                return true;
            }
            catch (Exception ex)
            {
                if (isCacheActive)
                {
                    var cacheRequest = CacheRequest.Current;
                    if (!cacheRequest.Properties.Contains(property))
                    {
                        throw new PropertyNotCachedException(property, ex);
                    }
                }
                // Should actually never come here
                throw;
            }
        }

        public T GetNativePattern<T>(PatternId pattern)
        {
            if (Equals(pattern, PatternId.NotSupportedByFramework))
            {
                throw new NotSupportedByFrameworkException();
            }
            var isCacheActive = CacheRequest.IsCachingActive;
            try
            {
                var nativePattern = InternalGetPattern(pattern.Id, isCacheActive);
                if (nativePattern == null)
                {
                    throw new InvalidOperationException("Native pattern is null");
                }
                return (T)nativePattern;
            }
            catch (Exception ex)
            {
                if (isCacheActive)
                {
                    var cacheRequest = CacheRequest.Current;
                    if (!cacheRequest.Patterns.Contains(pattern))
                    {
                        throw new PatternNotCachedException(pattern, ex);
                    }
                }
                throw new PatternNotSupportedException(pattern, ex);
            }
        }

        public bool TryGetNativePattern<T>(PatternId pattern, out T nativePattern)
        {
            try
            {
                nativePattern = GetNativePattern<T>(pattern);
                return true;
            }
            catch (PatternNotSupportedException)
            {
                nativePattern = default(T);
                return false;
            }
        }

        public Point GetClickablePoint()
        {
            Point point;
            if (!TryGetClickablePoint(out point))
            {
                throw new NoClickablePointException();
            }
            return point;
        }

        public abstract void SetFocus();

        /// <summary>
        /// Gets the desired property value
        /// </summary>
        /// <param name="propertyId">The id of the property to get</param>
        /// <param name="cached">Flag to indicate if the cached or current value should be fetched</param>
        /// <param name="useDefaultIfNotSupported">
        /// Flag to indicate, if the default value should be used if the property is not supported
        /// </param>
        /// <returns>The value / default value of the property or <see cref="AutomationBase.NotSupportedValue" /></returns>
        protected abstract object InternalGetPropertyValue(int propertyId, bool cached, bool useDefaultIfNotSupported);

        /// <summary>
        /// Gets the desired pattern
        /// </summary>
        /// <param name="patternId">The id of the pattern to get</param>
        /// <param name="cached">Flag to indicate if the cached or current pattern should be fetched</param>
        /// <returns>The pattern or null if it was not found / cached</returns>
        protected abstract object InternalGetPattern(int patternId, bool cached);

        public abstract AutomationElement[] FindAll(TreeScope treeScope, ConditionBase condition);
        public abstract AutomationElement FindFirst(TreeScope treeScope, ConditionBase condition);
        public abstract bool TryGetClickablePoint(out Point point);
        public abstract IAutomationEventHandler RegisterEvent(EventId @event, TreeScope treeScope, Action<AutomationElement, EventId> action);
        public abstract IAutomationPropertyChangedEventHandler RegisterPropertyChangedEvent(TreeScope treeScope, Action<AutomationElement, PropertyId, object> action, PropertyId[] properties);
        public abstract IAutomationStructureChangedEventHandler RegisterStructureChangedEvent(TreeScope treeScope, Action<AutomationElement, StructureChangeType, int[]> action);
        public abstract void RemoveAutomationEventHandler(EventId @event, IAutomationEventHandler eventHandler);
        public abstract void RemovePropertyChangedEventHandler(IAutomationPropertyChangedEventHandler eventHandler);
        public abstract void RemoveStructureChangedEventHandler(IAutomationStructureChangedEventHandler eventHandler);
        public abstract PatternId[] GetSupportedPatterns();
        public abstract PropertyId[] GetSupportedProperties();
        public abstract AutomationElement GetUpdatedCache();
        public abstract AutomationElement[] GetCachedChildren();
        public abstract AutomationElement GetCachedParent();
    }
}
