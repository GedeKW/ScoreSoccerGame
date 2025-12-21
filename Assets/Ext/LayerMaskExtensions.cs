using UnityEngine;

public static class LayerMaskExtensions
{
    //Check if Layermask is present
    public static bool Contains(this LayerMask mask, int layer)
    {
        return (mask & (1 << layer)) != 0;
    }
}
