using UnityEngine;

public static class Utils
{
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) 
            angle += 360F;
        if (angle > 360F) 
            angle -= 360F;

        return Mathf.Clamp(angle, min, max);
    }
}