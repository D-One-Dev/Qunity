using UnityEngine;

public static class Explosion
{
    public static Vector3 Calculate(Vector3 objectPos, Vector3 explosionPos, float explosionForce)
    {
        Vector3 blastDir = objectPos - explosionPos;
        float distance = blastDir.magnitude;
        if(distance == 0) return Vector3.zero;
        else
        {
            float invDistance = 1.0f / distance;
            float impulseMag = explosionForce * invDistance;
            return impulseMag * blastDir;
        }
    }
}
