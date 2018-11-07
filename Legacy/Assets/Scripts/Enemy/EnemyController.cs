using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    float timeCount = 0.0f;
    Rigidbody2D rb;

    public Vector2 attackingDirection = new Vector2(1, 0);
    public GameObject attackObject;

    public float closeEnough = .25f;
    public float range = 7f;

    //Time the attack collider will be active
    public float attackTime = .25f;
    private float attackTimeCurrent;

    //Time between attacks
    public float rechargeTime = .4f;
    private float rechargeTimeCurrent;




    public float attackOffset = .7f;

    void Awake()
    {
        gameObject.tag = "Enemy";
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = 1.95f;
        float distanceToTarget = CalculateDistance(target, this.transform);

        if (distanceToTarget - offset <= closeEnough)
        {
            Attack();   //------------------------TODO----------------------------------
            UpdateCooldowns();
        }
        else if (distanceToTarget <= range)
        {
            SeekTarget();
        }
        else 
        {
            LookAtPlayer();
        }
    }

    float CalculateDistance(Transform a, Transform b)
    {
        return Mathf.Pow((Mathf.Pow(a.position.x - b.position.x, 2) + Mathf.Pow(a.position.y - b.position.y, 2)), .5f);
    }

    void Attack()
    {
        Debug.Log("Attack called!");
        attackingDirection = new Vector2(target.position.x - this.transform.position.x, target.position.y - this.transform.position.y).normalized;
        if (rechargeTimeCurrent <= 0)
        {
            attackObject.transform.position = transform.up * attackOffset;
            attackObject.SetActive(true);
            attackTimeCurrent = attackTime;
            rechargeTimeCurrent = rechargeTime;
        }
        
    }

    void UpdateCooldowns()
    {
        rechargeTimeCurrent -= Time.deltaTime;
        if (attackTimeCurrent > 0)
        {
            attackTimeCurrent -= Time.deltaTime;
        }
        else
        {
            attackObject.SetActive(false);
        }
    }
    void SeekTarget()
    {
        LookAtPlayer();
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    void LookAtPlayer()
    {
        Vector3 vectorTarget = target.position - transform.position;
        float angle = (Mathf.Atan2(vectorTarget.y, vectorTarget.x) * Mathf.Rad2Deg) - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 3);
        
        //Vector2 lookDir = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);

        //transform.up = target.position - transform.position;
    }
}
