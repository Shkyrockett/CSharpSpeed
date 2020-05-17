using System;

namespace CSharpSpeed
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Property)]
    public class VisualizerProviderAttribute
        : Attribute
    { }
}