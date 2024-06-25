using UnityEngine;

public class BangActive : MonoBehaviour
{
    public GameObject spaceMark;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            spaceMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            spaceMark.SetActive(false);
        }
    }

    public void DisappearMark()
    {
        spaceMark.SetActive(false);
    }


}
