using UnityEngine;

public static class MathUtilities
{
    public static float Remap(float start, float end, float remapValueStart, float remapValueEnd, float currentValue){
        float tValue = Mathf.InverseLerp(start, end, currentValue);
        return Mathf.Lerp(remapValueStart, remapValueEnd, tValue);
    }

    public static Vector3 ClampX(this Vector3 v, float minX, float maxX){
        return new Vector3(Mathf.Clamp(v.x, minX, maxX), v.y, v.z);
    }
    public static Vector3 ClampY(this Vector3 v, float minY, float maxY){
        return new Vector3(v.x, Mathf.Clamp(v.x, minY, maxY), v.z);
    }
    public static Vector3 ClampZ(this Vector3 v, float minZ, float maxZ){
        return new Vector3(v.x, v.y, Mathf.Clamp(v.z, minZ, maxZ));
    }

    public static Vector3 GetRandomPositionInABox(float width, float length, float height){
        float x = Random.Range(-width / 2f, width / 2f);
        float y = Random.Range(-height / 2f, height / 2f);
        float z = Random.Range(-length / 2f, length / 2f);
        return new Vector3(x, y, z);
    }
}