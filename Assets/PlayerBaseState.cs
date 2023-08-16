using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(Movement pm);

    public abstract void UpdateState(Movement pm);

    public abstract void FixedUpdateState(Movement pm);

    public abstract void Input(Movement pm);

    public abstract void OnCollisionEnter(Movement pm);
}
public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(Movement pm)
    {
        pm.anim.Play("Idle");
    }

    public override void UpdateState(Movement pm)
    {
        pm.PlayerInput();
    }
    public override void FixedUpdateState(Movement pm)
    {
        pm.GroundMovement();
    }
    public override void Input(Movement pm)
    {

    }
    public override void OnCollisionEnter(Movement pm)
    {

    }
}
public class PlayerRunState : PlayerBaseState
{
    public override void EnterState(Movement pm)
    {
        pm.anim.Play("Run");
    }

    public override void UpdateState(Movement pm)
    {
        pm.PlayerInput();
    }
    public override void FixedUpdateState(Movement pm)
    {
        pm.GroundMovement();
    }
    public override void Input(Movement pm)
    {

    }
    public override void OnCollisionEnter(Movement pm)
    {

    }
}
public class PlayerRollState : PlayerBaseState
{
    public override void EnterState(Movement pm)
    {
        pm.anim.Play("Roll");
    }

    public override void UpdateState(Movement pm)
    {
        
    }
    public override void FixedUpdateState(Movement pm)
    {
        pm.RollMovement();
    }
    public override void Input(Movement pm)
    {

    }
    public override void OnCollisionEnter(Movement pm)
    {

    }
}
public class PlayerStunState : PlayerBaseState
{
    public override void EnterState(Movement pm)
    {
        pm.anim.Play("Stun");
    }

    public override void UpdateState(Movement pm)
    {

    }
    public override void FixedUpdateState(Movement pm)
    {
        
    }
    public override void Input(Movement pm)
    {

    }
    public override void OnCollisionEnter(Movement pm)
    {

    }
}