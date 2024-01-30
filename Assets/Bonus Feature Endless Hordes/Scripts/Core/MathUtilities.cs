using UnityEngine;

public static class MathUtilities
{
    public static float Remap(float start, float end, float remapValueStart, float remapValueEnd, float currentValue){
        float tValue = Mathf.InverseLerp(start, end, currentValue);
        return Mathf.Lerp(remapValueStart, remapValueEnd, tValue);
    }
}