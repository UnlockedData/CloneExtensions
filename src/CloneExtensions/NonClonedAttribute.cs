using System;
namespace UnlockedData.CloneExtensions
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NonClonedAttribute : Attribute
    {
    }
}
