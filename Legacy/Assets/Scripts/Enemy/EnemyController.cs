using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    enum states {IDLE, WALKING, ATTACKING };
    private states state;

    public float speed = 5f;
    public Transform target;
    private float visionRange = 14f;

    public Vector2 attackingDirection = new Vector2(1, 0);
    public GameObject attackObject;
    public GameObject bomb;

    public float closeEnough = .25f;
    public float range = 7f;
    public float bossRange = 16f;

    //Time the attack collider will be active
    public float attackTime = .25f;
    private float attackTimeCurrent;

    //Time between attacks
    public float rechargeTime = .4f;
    private float rechargeTimeCurrent;

    // Time it takes for next bomb to be ready
    public float bombDelay = 3f;
    private float bombRechargeRate = 0f;

    // Cast Time
    public float castTime = .2f;
    private float castTimeCurrent;

    // Distance attack collider will spawn from enemy
    public float attackOffset = 1f;
    private Vector2 colliderX;
    public float colliderY;

    //Colors
    public Color idleColor;
    public Color castingColor;

    private string tag;
    // Use this for initialization
    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        state = states.IDLE;
        tag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        if (tag == "Boss")
        {
            BossActions();
            UpdateCooldowns();
        }
        else
        {
            Actions();
            UpdateCooldowns();
        }
        if(state == states.IDLE)
        {
            GetComponent<SpriteRenderer>().color = idleColor;
        }
        else if(state == states.ATTACKING)
        {
            GetComponent<SpriteRenderer>().color = castingColor;
        }
    }

    void BossActions()
    {
        float offset = 1.95f;
        float distanceToTarget = CalculateDistance(target, this.transform);

        if ((distanceToTarget - offset <= closeEnough) || (state == states.ATTACKING))
        {
            Attack();
        }
        else if (distanceToTarget > closeEnough && distanceToTarget <= bossRange && state != states.ATTACKING)
        {
            SeekTarget();
            if (LineOfSight() && bombRechargeRate <= 0)
            {
                ThrowBomb();
            }
        }
        else if (state != states.ATTACKING && distanceToTarget <= visionRange)
        {
            LookAtPlayer();
        }
    }

    void Actions()
    {
        float offset = 1.95f;
        float distanceToTarget = CalculateDistance(target, this.transform);

        if ((distanceToTarget - offset <= closeEnough) || (state == states.ATTACKING))
        {
            Attack();
        }
        else if (LineOfSight() && state != states.ATTACKING)
        {
            SeekTarget();
            if (bombRechargeRate <= 0)
            {
                ThrowBomb();
            }
        }
        else if (state != states.ATTACKING && distanceToTarget <= visionRange)
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
        attackingDirection = new Vector2(target.position.x - this.transform.position.x, target.position.y - this.transform.position.y).normalized;
        if (rechargeTimeCurrent <= 0 || state == states.ATTACKING)
        {
            if(state != states.ATTACKING)
            {
                state = states.ATTACKING;
                castTimeCurrent = castTime;
            }

            if(castTimeCurrent <= 0)
            {
                attackObject.SetActive(true);
                attackTimeCurrent = attackTime;
                rechargeTimeCurrent = rechargeTime;
                state = states.IDLE;
            }
            castTimeCurrent -= Time.deltaTime;
        } 
    }

    void ThrowBomb()
    { 
        bombRechargeRate = bombDelay;

        GameObject spareBomb = Instantiate(bomb, gameObject.transform.position, transform.rotation) as GameObject;

        // Get rigidbody and apply a force to bomb
        Rigidbody2D rigidbody = spareBomb.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(transform.up * 10, ForceMode2D.Impulse);
    }

    bool LineOfSight()
    {
        Vector2 start = transform.position + transform.up * 2.4f;
        Vector2 direction = transform.TransformDirection(Vector2.up) * range;
        RaycastHit2D hit;
        Debug.DrawRay(start, transform.up * bossRange, Color.yellow, .1f, true);

        if (tag == "Boss")
        {
            hit = Physics2D.Raycast(start, transform.up, bossRange);
        }
        else
        {
            hit = Physics2D.Raycast(start, transform.up, range);
        }
    
        if (hit)
        {
            //Debug.DrawRay(start + offset, transform.up * bossRange, Color.yellow, .1f, true);
      
            if (hit.collider.tag == "Player" && hit != null)
            {
                return true;
            }
        }

        return false;
    }

    void UpdateCooldowns()
    {
        rechargeTimeCurrent -= Time.deltaTime;
        bombRechargeRate -= Time.deltaTime;

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
    }
}
