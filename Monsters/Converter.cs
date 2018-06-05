using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonTool.Monsters
{
    public abstract class Converter<T> : JsonConverter
    {
        /// <summary>
        /// Checks if the given object type can be converted by this method
        /// </summary>
        /// <param name="objectType">An object type</param>
        /// <returns>true if the given object can be converted</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        
        /// <summary>
        /// Returns false because the Converter can't write
        /// </summary>
        public override bool CanWrite => false;
        
        /// <summary>
        /// Processes a json file
        /// </summary>
        /// <param name="reader">The reader used to read the json file</param>
        /// <param name="objectType">The type of object the json file converts into</param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns>The created object</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            T createdObject = Create(objectType, jObject);
            return createdObject;
        }

        /// <summary>
        /// Creates an object of a given type, if the type can be converted
        /// </summary>
        /// <param name="objectType">The type of object that is created</param>
        /// <param name="jObject">A json object</param>
        /// <returns>The created object</returns>
        protected abstract T Create(Type objectType, JObject jObject);

        /// <summary>
        /// Checks if a field exists in a json object
        /// </summary>
        /// <param name="fieldName">The field that might exist</param>
        /// <param name="jObject">The json object in which it might exist</param>
        /// <returns>true if the field exists in the json object</returns>
        protected bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// remarks: DO NOT USE, CANNOT WRITE
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
