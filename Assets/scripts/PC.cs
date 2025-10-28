using System;
using UnityEngine;

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
        realpos += transform.forward * speed * Time.deltaTime;
        int x = (int)Math.Round(realpos.x);
        int y = (int)Math.Round(realpos.y);
        int z = (int)Math.Round(realpos.z);
        Vector3 roundedPos = new Vector3(x,y,z);
        transform.position = roundedPos;
    }
}
