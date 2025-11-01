using extend;
using UnityEngine;

public class Food : MonoBehaviour
{
    public void ChangePos()
    {
        float x = Random.Range(-24f, 24f);
        float y = Random.Range(-24f, 24f);
        float z = Random.Range(-24f, 24f);
        transform.position = new Vector3(x, y, z).Vec3Round();
    }
}
