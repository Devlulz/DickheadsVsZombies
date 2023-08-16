using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CowState {Idle, Walking, Stunned}
public class CowAI : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    Rigidbody2D rb;

    CowState state;

    float stunTimer = 0.1f;

    [SerializeField]
    float speed = 10;

    bool reachedSpot;

    float chillTimer;

    float failSafeSeconds = 10f;
    float failSafeTimer;

    Vector2 nextSpot;

    Unit unit;

    int lastHP;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        unit = GetComponent<Unit>();
        CreateRandomSpot();
        lastHP = unit.HP;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case CowState.Idle:
                if(rb.velocity.magnitude <= 0.1f)
                {
                    anim.Play("Idle");
                }
                if (reachedSpot)
                {
                    if (chillTimer > 0)
                    {
                        chillTimer -= Time.deltaTime;
                    }
                    else
                    {
                        CreateRandomSpot();
                    }
                }
                break;
            case CowState.Walking:
                anim.Play("Run");
                failSafeTimer -= Time.deltaTime;
                if (lastHP > unit.HP)
                {
                    lastHP = unit.HP;
                    ReachedSpot();
                }
                if (failSafeTimer < 0)
                {
                    ReachedSpot();
                }
                if (rb.velocity.x > 0)
                {
                    anim.transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (rb.velocity.x < 0)
                {
                    anim.transform.localScale = new Vector3(1, 1, 1);
                }
                if (DistanceToSpot() > 0.05f && !reachedSpot)
                {
                    GroundMovement();
                    if (DistanceToSpot() < 0.1f)
                    {
                        ReachedSpot();
                    }
                }
                break;
            case CowState.Stunned:
                anim.Play("Stun");
                break;
        }
    }

    float DistanceToSpot()
    {
        Vector2 compareVector;
        compareVector.x = transform.position.x - nextSpot.x;
        compareVector.y = transform.position.y - nextSpot.y;
        //Debug.Log(compareVector.magnitude);
        return compareVector.magnitude;
    }

    private void GroundMovement()
    {
        //Debug.Log("moo ving");
        Vector2 moveDir;
        moveDir = (Vector2)transform.position - nextSpot;
        rb.AddForce(-moveDir.normalized * Time.deltaTime * 1500);
    }

    private void ReachedSpot()
    {
        //Debug.Log("reached");
        reachedSpot = true;
        chillTimer = Random.Range(0f, 5f);
        state = CowState.Idle;
    }

    private void CreateRandomSpot()
    {
        Vector2 offset = new Vector2(Random.Range(-2f,2f), Random.Range(-2f, 2f));
        nextSpot = new Vector2(transform.position.x + offset.x, transform.position.y + offset.y);
        //Debug.Log(nextSpot);
        failSafeTimer = failSafeSeconds;
        reachedSpot = false;
        state = CowState.Walking;
    }

    public IEnumerator InitiateStun()
    {
        state = CowState.Stunned;
        yield return new WaitForSeconds(.1f);
        state = CowState.Idle;
    }
}
