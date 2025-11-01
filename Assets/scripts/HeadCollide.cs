using UnityEngine;

public class HeadCollide : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("hit"))
        {
            BodyManager bm = GetComponent<BodyManager>();
            if (bm.pl.Count == 0)
            {
                Time.timeScale = 0f;
            }
            else
            {
                bm.Remove();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("body"))
        {
            Time.timeScale = 0f;
        }
        if (other.gameObject.CompareTag("food"))
        {
            Food food =other.GetComponent<Food>();
            BodyManager bm = gameObject.GetComponent<BodyManager>();
            if(food != null)
            {
                food.ChangePos();
                bm.Add();
            }
        }
    }
}
