using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemActions : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    GameObject hurtbox;

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        anim.Play("Attack");
    }

    public void AttackEvent()
    {
        StartCoroutine(ActivateHurtBox());
    }

    IEnumerator ActivateHurtBox()
    {
        yield return new WaitForSeconds(.05f);
    }
}
