using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Input Direction
    Vector2 moveDir;

    // Movement Fields
    [SerializeField]
    private float speed = 10;

    public float rollTime = .3f;

    public float stunTimer = 0.5f;

    public Animator anim;

    private Rigidbody2D rb;

    public bool facingLeft;

    public PlayerBaseState currentState;

    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerRunState runState = new PlayerRunState();
    public PlayerRollState rollState = new PlayerRollState();
    public PlayerStunState stunState = new PlayerStunState();

    private Vector2 lockedDir;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        SwitchState(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if (facingLeft)
        {
            anim.transform.localScale = new Vector3(-1, 1, 1);
            facingLeft = false;
        }
        else
        {
            anim.transform.localScale = new Vector3(1, 1, 1);
            facingLeft = true;
        }
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);

    }
    public void SwitchState(PlayerBaseState state)
    {
        //Debug.Log("State Switched");
        currentState = state;
        state.EnterState(this);
    }

    public void PlayerInput()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.Space) && currentState == runState)
        {
            SwitchState(rollState);
            lockedDir = moveDir;
            StartCoroutine(Roll());
        }
    }

    public void GroundMovement()
    {
        if(moveDir != Vector2.zero)
        {
            SwitchState(runState);
            rb.velocity = ((moveDir.normalized * (speed * 10)));
        }
        else
        {
            SwitchState(idleState);
            rb.velocity = Vector2.zero;
        }
    }

    private IEnumerator Roll()
    {
        anim.Play("Roll");
        yield return new WaitForSeconds(rollTime);
        SwitchState(idleState);
    }

    public void InitiateStun()
    {
        SwitchState(stunState);
        StartCoroutine(StunTimer());
    }

    private IEnumerator StunTimer()
    {
        yield return new WaitForSeconds(stunTimer);
        SwitchState(idleState);
    }

    public void RollMovement()
    {
        rb.velocity = ((lockedDir.normalized * (speed * 10) * 2));
    }
}
