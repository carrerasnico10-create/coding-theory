using System;
using UnityEngine;
using extend;
public class PC : MonoBehaviour
{
    public float speed;
    private float FT;
    public float coolDownsec = 1f;
    private Vector3 realpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //turn
        float PIX = Input.GetAxis("Horizontal");
        if (Time.time > FT) {
            switch (PIX)
            {
                case 1: transform.Rotate(new Vector3(0, 90, 0)); break;
                case -1: transform.Rotate(new Vector3(0, -90, 0)); break;
            }
            FT = Time.time+coolDownsec;
        }
        //move forward
        realpos += (transform.forward * speed * Time.deltaTime);
        Vector3 roundedPos = realpos.Vec3Round();
        transform.position = roundedPos;
    }
}
