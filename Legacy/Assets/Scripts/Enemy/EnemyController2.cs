using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    float timeCount = 0.0f;
    Rigidbody2D rb;

    public Vector2 attackingDirection = new Vector2(1, 0);
    public GameObject projectile;
    public Transform firePosition;

    public float closeEnough = .25f;
    public float range = 7f;

    //Time the attack collider will be active
    public float attackTime = .25f;
    private float attackTimeCurrent;

    //Time between attacks
    public float rechargeTime;
    private float rechargeTimeCurrent;

    public float attackOffset = 1f;

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

        rechargeTime = Random.Range(0.6f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = CalculateDistance(target, this.transform);
     
        if (distanceToTarget <= closeEnough)
        {
            RunAway();
        }
        else if (distanceToTarget <= range)
        {
            LookAtPlayer();
            Attack();
            UpdateCooldowns();
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
        if (rechargeTimeCurrent <= 0)
        {
            GameObject bullet = Instantiate(projectile, firePosition.position, firePosition.rotation) as GameObject;
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
    }

    void RunAway()
    {

    }

    void LookAtPlayer()
    {
        Vector3 vectorTarget = target.position - transform.position;
        float angle = (Mathf.Atan2(vectorTarget.y, vectorTarget.x) * Mathf.Rad2Deg) - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 20);
    }
}
