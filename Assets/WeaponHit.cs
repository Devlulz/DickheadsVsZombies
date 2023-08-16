using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
    Vector2 direction;
    [SerializeField]
    DamageType dmgType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Enemy":
                //Debug.Log("Hit");
                direction = collision.transform.position - transform.parent.parent.position;
                KnockBack(collision.attachedRigidbody);
                collision.GetComponent<Unit>().OnDMGTake(1, direction);
                break;
            case "Mob":
                direction = collision.transform.position - transform.parent.parent.position;
                KnockBack(collision.attachedRigidbody);
                collision.GetComponent<Unit>().OnDMGTake(1, direction);
                break;
            case "Resource":
                collision.gameObject.GetComponent<Resource>().ApplyDMG(1, dmgType);
                break;
        }
    }

    private void KnockBack(Rigidbody2D rb)
    {
        Vector2 dir = rb.transform.position - transform.parent.parent.position;
        rb.AddForce(dir.normalized * 70, ForceMode2D.Impulse);
    }
}
