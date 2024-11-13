using Fungus;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject Cocktail;
    public GameObject HolyWater;
    private GameObject Bullet;
    public Transform FirePos;

    [SerializeField] private AudioCue audioCue;
    [SerializeField] private PlayerDataSO playerDataSO;

    public bool gameStart = false;

    void Start()
    {
        if(playerDataSO.getDC)
        {
            Bullet = HolyWater;
        }
        else
        {
            Bullet = Cocktail;
        }
    }
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
