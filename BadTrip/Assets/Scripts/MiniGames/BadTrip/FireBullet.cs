using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;

    [SerializeField] private AudioCue audioCue;

    public bool gameStart = false;


    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                audioCue.PlayAudio(0);
                Instantiate(Bullet, FirePos.transform.position, Quaternion.identity);
            }
        }
    }

    public void SetGameStart(bool b)
    {
        gameStart = b;
    }
}
