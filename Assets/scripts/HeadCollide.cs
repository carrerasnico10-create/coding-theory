using UnityEngine;

public class HeadCollide : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("hit"))
        {
            Time.timeScale = 0f;
        }
    }
}
