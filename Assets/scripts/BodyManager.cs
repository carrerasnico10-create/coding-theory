using extend;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class BodyManager : MonoBehaviour
{
    public PC pc;
    public GameObject body;
    public List<GameObject> pl = new List<GameObject>();
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
        //test
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
        //end test
        move();
    }
    //adds object and sets maxposlist
    public void Add()
    {
        pc.listMax += 1;
        pl.Add(Instantiate(body));
        pl[pl.Count-1].SetActive(false);//hide initial add
        resAdded = true;//let the move method know to make hidden object visible
    }
    //removes object and sets pc maxposlist
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
        /*
         *it cheacks if the two lists are in sync 
         * it is maped to the index of the game object list to the vector3 lis
         */
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
            // i have done it like this in case there is more then one hidden
        }
    }
}
