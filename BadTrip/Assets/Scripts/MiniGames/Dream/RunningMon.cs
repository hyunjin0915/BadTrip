using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMon : MonoBehaviour
{
    protected Vector2 currentPosition;

    private Rigidbody2D rb;

    [SerializeField]
    private float velocity;
    protected float velocity_Apply;
    private float addVelocity;

    //dash 값 설정 범위
    [SerializeField]
    private float LRange;
    [SerializeField]
    private float RRange;

    [SerializeField]
    private float dashTime; //몇초간격으로

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        velocity_Apply = velocity;
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(RandomDash());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        currentPosition.x += Time.deltaTime * velocity_Apply;
        transform.position = currentPosition;
    }

    private void SetRandomDash()
    {
        addVelocity = Random.Range(LRange, RRange);
        velocity_Apply += addVelocity;
    }

    IEnumerator RandomDash()
    {
        while(true)
        {
            SetRandomDash();
            yield return new WaitForSeconds(dashTime);
            velocity_Apply = velocity;
            yield return new WaitForSeconds(dashTime);
        }
    }
}
