using CrmSdkLibrary_Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CrmSdkLibrary_Core.Services
{
    public class XrmMapper : IXrmMapper
    {
        private readonly ILogger<XrmMapper> logger;

        public XrmMapper(ILogger<XrmMapper> logger)
        {
            this.logger = logger;
        }

        #region Static Attributes

        /// <summary>
        /// Try Mapping Only Proerties With XrmAttribute.
        /// Default = false
        /// </summary>
        public static bool MappingOnlyPrpertiesHasXrmAttribute = false;

        /// <summary>
        /// Write Warnning Log When Mapping Error. (Almost Type Cast Problem)
        /// Default = false
        /// </summary>
        public static bool WriteWarningLogMappingPropertiesSkippedOnError = false;

        #endregion Static Attributes

        /// <summary>
        /// Not Suppoert Aliased Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Map<T>(Entity entity) where T : new()
        {
            T item = new T();
            foreach (var property in GetProperties(item, MappingOnlyPrpertiesHasXrmAttribute))
            {
                // Make Safe When Convert ChangeType
                var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                // if null => set property name
                string xrmAttributeName = property.GetCustomAttribute<XrmAttribute>()?.AttributeName ?? property.Name;
                // if null => find attribute's type, if null => set property type
                //Type xrmAttributeType = property.GetCustomAttribute<XrmAttribute>()?.AttributeType ?? (entity.Contains(xrmAttributeName) ? entity.Attributes.First(x => x.Key == xrmAttributeName).Value.GetType() : property.PropertyType);
                Type xrmAttributeType = property.GetCustomAttribute<XrmAttribute>()?.AttributeType ?? property.PropertyType;
                var method = entity.GetType().GetMethod("GetAttributeValue").MakeGenericMethod(new Type[] { xrmAttributeType });
                bool isFormattedValue = property.GetCustomAttributes().Any(x => x.GetType() == typeof(XrmFormattedValue));
                object rtn;
                try
                {
                    if (!isFormattedValue)
                    {
                        rtn = xrmAttributeName.Equals($"{typeof(T).Name}id", StringComparison.CurrentCultureIgnoreCase) ? entity.Id : method.Invoke(entity, new object[] { xrmAttributeName });
                    }
                    else
                    {
                        rtn = entity.FormattedValues[xrmAttributeName];
                    }
                }
                catch //(Exception)
                {
                    //Console.WriteLine($@" 오류 : {ex.Message + "/" + ex.ToString()} , 구성 요소 이름 : {xrmAttributeName} , 타입 : {xrmAttributeType.Name}");
                    WriteWarningLog<T>(entity, xrmAttributeName, xrmAttributeType);
                    continue;
                }

                if (rtn is EntityReference)
                {
                    if (propertyType != typeof(EntityReference))
                    {
                        rtn = (rtn as EntityReference).Id;
                    }
                }
                else if (rtn is OptionSetValue)
                {
                    if (propertyType != typeof(OptionSetValue))
                    {
                        rtn = (rtn as OptionSetValue).Value;
                    }
                }
                else if (rtn is Money)
                {
                    if (propertyType != typeof(Money))
                    {
                        rtn = (rtn as Money).Value;
                    }
                }

                try
                {
                    object safeValue = rtn == null ? null : Convert.ChangeType(rtn, propertyType);
                    property.SetValue(item, safeValue);
                }
                catch//(Exception ex)
                {
                    //Console.WriteLine($@" 오류 : {ex.Message + "/" +ex.ToString()} , 구성 요소 이름 : {xrmAttributeName} , 타입 : {xrmAttributeType.Name}");

                    WriteWarningLog<T>(entity, xrmAttributeName, propertyType);
                    // Skip Error
                    continue;
                }
            }
            return item;
        }

        /// <summary>
        /// Only UnMap Properties with XrmAttribute
        /// this method dont support you use wrong. e.g.) use Guid type property to EntityReference even you do not set xrmAttributeType.
        /// Not Support Aliased Value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityLogicalName"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public Entity UnMap<T>(string entityLogicalName, T item)
        {
            if (string.IsNullOrWhiteSpace(entityLogicalName))
            {
                throw new ArgumentNullException(nameof(entityLogicalName));
            }

            var entity = new Entity(entityLogicalName.ToLower());
            foreach (var property in GetProperties(item))
            {
                var propertyType = property.PropertyType;
                string xrmAttributeName = property.GetCustomAttribute<XrmAttribute>()?.AttributeName ?? property.Name;
                // if null => set property type
                Type xrmAttributeType = property.GetCustomAttribute<XrmAttribute>()?.AttributeType ?? propertyType;
                bool isFormattedValue = property.GetCustomAttributes().Any(x => x.GetType() == typeof(XrmFormattedValue));

                if (isFormattedValue)
                {
                    if (property.GetValue(item) != null)
                    {
                        entity.FormattedValues.Add(xrmAttributeName, property.GetValue(item).ToString());
                    }
                    //skip formattedvalue
                    continue;
                };

                if (xrmAttributeType == typeof(EntityReference))
                {
                    string entityReferenceLogicalName = property.GetCustomAttribute<XrmAttribute>()?.EntityReferenceLogicalName;
                    if (string.IsNullOrWhiteSpace(entityReferenceLogicalName))
                    {
                        WriteWarningLog<T>(entity, xrmAttributeName, xrmAttributeType);
                        // Skip Error
                        continue;
                    }

                    Guid entityReferenceId;
                    if (propertyType == typeof(Guid))
                    {
                        entityReferenceId = (Guid)property.GetValue(item);
                    }
                    else
                    {
                        if (property.GetValue(item) == null || !Guid.TryParse(property.GetValue(item).ToString(), out entityReferenceId))
                        {
                            WriteWarningLog<T>(entity, xrmAttributeName, xrmAttributeType);
                            // Skip Error
                            continue;
                        }
                    }
                    entity.Attributes[xrmAttributeName] = new EntityReference(entityReferenceLogicalName.ToLower(), entityReferenceId);
                }
                else if (xrmAttributeType == typeof(OptionSetValue))
                {
                    int optionSetValue;
                    if (propertyType == typeof(int))
                    {
                        optionSetValue = (int)property.GetValue(item);
                    }
                    else
                    {
                        if (property.GetValue(item) == null || !int.TryParse(property.GetValue(item).ToString(), out optionSetValue))
                        {
                            WriteWarningLog<T>(entity, xrmAttributeName, xrmAttributeType);
                            // Skip Error
                            continue;
                        }
                    }
                    entity.Attributes[xrmAttributeName] = new OptionSetValue(optionSetValue);
                }
                else if (xrmAttributeType == typeof(Money))
                {
                    decimal money;
                    if (propertyType == typeof(decimal))
                    {
                        money = (decimal)property.GetValue(item);
                    }
                    else
                    {
                        if (property.GetValue(item) == null || !decimal.TryParse(property.GetValue(item).ToString(), out money))
                        {
                            WriteWarningLog<T>(entity, xrmAttributeName, xrmAttributeType);
                            // Skip Error
                            continue;
                        }
                    }
                    entity.Attributes[xrmAttributeName] = new Money(money);
                }
                else
                {
                    // Warning : Can make Exception on create record request (not here)
                    if (xrmAttributeName.Equals($"{entityLogicalName}id", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Guid value;

                        var isParsed = Guid.TryParse(property.GetValue(item).ToString(), out value);
                        entity.Id = isParsed ? value : Guid.Empty;
                    }
                    else
                    {
                        entity.Attributes[xrmAttributeName] = property.GetValue(item);
                    }
                }
                //entity.Attributes[xrmAttributeName] = item.
            }
            return entity;
        }

        /// <summary>
        /// For Static Readonly as Dictionary
        /// Key             Value
        /// -----------------------------------
        /// Variable        Value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetFieldValues(object obj)
        {
            return obj.GetType()
                      .GetProperties()
                      .Where(f => f.PropertyType == typeof(string))
                      .ToDictionary(f => f.Name,
                                    f => f.GetValue(obj));
        }

        private IEnumerable<PropertyInfo> GetProperties(object obj, bool onlyPrpertyHasXrmAttributes = false)
            => onlyPrpertyHasXrmAttributes ?
                obj.GetType().GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(XrmAttribute)) && !x.CustomAttributes.Any(y => y.AttributeType == typeof(XrmMapIgnore)))
                : obj.GetType().GetProperties().Where(x => !x.CustomAttributes.Any(y => y.AttributeType == typeof(XrmMapIgnore)));

        private void WriteWarningLog(string message)
        {
            if (WriteWarningLogMappingPropertiesSkippedOnError)
            {
                logger.LogWarning(message);
            }
        }

        private void WriteWarningLog<T>(Entity entity, string xrmAttributeName, Type targetAttributeType)
        {
            if (WriteWarningLogMappingPropertiesSkippedOnError)
            {
                try
                {
                    var attrTypeName = xrmAttributeName.Equals($"{typeof(T).Name}id", StringComparison.CurrentCultureIgnoreCase) ? entity.Id.GetType().Name
                            : entity.Contains(xrmAttributeName) ? entity.Attributes.First(x => x.Key == xrmAttributeName).Value.GetType().Name : "[Not Exist Attribute]";
                    logger.LogWarning($"[{typeof(T).Name} XrmMapper.Map] Warnning : '{xrmAttributeName}' skipped mapping. (Cannot '{attrTypeName}' Type AttributeValue as '{targetAttributeType.Name}')");
                }
                catch { }
            }
        }
    }
}