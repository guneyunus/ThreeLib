﻿using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace IrisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class IrisBasicMaterial : IrisMaterial, IEquatable<IrisBasicMaterial>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IrisBasicMaterial()
        {
            Type = "MeshBasicMaterial";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        public IrisBasicMaterial(string name, int color) : this()
        {
            Name = name;
            Color = color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IrisBasicMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Type.Equals(other.Type) &&
                       Color.Equals(other.Color);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IrisBasicMaterialCollection : Collection<IrisBasicMaterial>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisBasicMaterial item)
        {
            var q = from a in this
                    where a.Equals(item)
                    select a.Uuid;

            var enumerable = q as Guid[] ?? q.ToArray();
            if (!enumerable.Any())
            {
                Add(item);
                return item.Uuid;
            }
            else
            {
                return enumerable.Single();
            }
        }
    }
}
