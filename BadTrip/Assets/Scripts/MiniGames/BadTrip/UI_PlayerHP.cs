using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHP : MonoBehaviour
{
    public PlayerHPSO Player_healthManager;
    public GameObject prfHPBar;
    public GameObject canvas;
    public Image PlayerHPBar;

    RectTransform hpBar;

    public float height = 3f;

    private void OnEnable()
    {
        PlayerHPSO.OnPlayerDamaged +=ChangeHPBar;
    }
    private void OnDisable()
    {
        PlayerHPSO.OnPlayerDamaged -=ChangeHPBar;
    }
    // Start is called before the first frame update
    void Start()
    {
        hpBar = Instantiate(prfHPBar, canvas.transform).GetComponent<RectTransform>();
        PlayerHPBar = hpBar.GetChild(0).GetComponent<Image>();
        Player_healthManager.PlayerHPInit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 _hpBarPos = 
            Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y+height,0));
        hpBar.position = _hpBarPos;
    }
    private void ChangeHPBar()
    {
        PlayerHPBar.fillAmount = Player_healthManager.PlayerHealth/Player_healthManager.PlayerMaxHealth;
    }
}
