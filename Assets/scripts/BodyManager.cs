using extend;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BodyManager : MonoBehaviour
{
    public PC pc;
    public GameObject body;
    private List<GameObject> pl = new List<GameObject>();
    private float wait;
    public float cooldown = 1f;
    private bool resAdded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (Time.time > wait)
            {
                Add();
                wait = Time.time + cooldown;
            }
        }
        if(Input.GetKey(KeyCode.X))
        {
            if (Time.time > wait)
            {
                Remove();
                wait = Time.time + cooldown;
            }
        }
        move();
    }
    public void Add()
    {
        pc.listMax += 1;
        pl.Add(Instantiate(body));
        pl[pl.Count-1].SetActive(false);
        resAdded = true;
    }
    public void Remove()
    {
        if(pl.Count >0)
        {
            pc.listMax -= 1;
            Destroy(pl[0]);
            pl.RemoveAt(0);
        }
    }
    public void move()
    {
        if (pc.tList.Count == pl.Count) {
            for (int i = 0; i < pl.Count; i++)
            {
                pl[i].transform.position = pc.tList[i].Vec3Round();
            }
        }
        if (resAdded)
        {
            for (int i = 0; i < pl.Count; i++)
            {
                pl[i].SetActive(true);
            }
            resAdded = false;
        }
    }
}
