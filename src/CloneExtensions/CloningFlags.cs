using System;
namespace UnlockedData.CloneExtensions
{
    [Flags]
    public enum CloningFlags
    {
        None = 0x0,
        Fields = 0x1,
        Properties = 0x2,
        CollectionItems = 0x4,
        Shallow = 0x8,
    }
}
