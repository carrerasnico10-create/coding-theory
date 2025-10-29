using Unity.VisualScripting;
using UnityEngine;

namespace extend
{
    public static class Vec
    {
        public static Vector3 Vec3Round(this Vector3 v3)
        {
            float x = Mathf.Round(v3.x);
            float y = Mathf.Round(v3.y);
            float z = Mathf.Round(v3.z);
            return new Vector3(x,y,z);
        }
    }
}