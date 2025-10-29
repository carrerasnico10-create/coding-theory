using System;
using UnityEngine;
using extend;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class PC : MonoBehaviour
{
    public float speed;
    private float FT;
    public float coolDownsec = 1f;
    private Vector3 realpos;
    private Vector3 lastRPos;
    public List<Vector3> tList
    { private set; get; }
    public int listMax = 0;
// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tList = new List<Vector3>();
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
            if(Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(new Vector3(90, 0, 0));
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(new Vector3(-90, 0, 0));
            }
        }
        //move forward
        realpos += (transform.forward * speed * Time.deltaTime);
        Vector3 roundedPos = realpos.Vec3Round();
        transform.position = roundedPos;
        if (listMax >0) {
            if (lastRPos != realpos.Vec3Round()) {
                tList.Add(realpos.Vec3Round());
                lastRPos = realpos.Vec3Round();
            }
            while (tList.Count > listMax)
            {
                tList.RemoveAt(0);
            }
        }
    }
}
