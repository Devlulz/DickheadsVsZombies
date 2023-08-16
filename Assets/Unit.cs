using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int MaxHP;
    public int HP;

    public float speed;

    public int mana;
    public int mgk;

    public int str;

    public int dex;

    [SerializeField]
    GameObject[] drop;

    [SerializeField]
    GameObject particles;

    public void OnDMGTake(int dmg, Vector2 particleDir)
    {
        HP -= dmg;
        EZCameraShake.CameraShaker.Instance.ShakeOnce(3f, 5, .1f, 0.3f);
        StartCoroutine(GetComponent<WhiteFlash>().FlashEffect());
        if (particles)
        {
            //Debug.Log("bruh");
            Instantiate(particles, transform.position, Quaternion.Euler((Mathf.Atan2(particleDir.y, particleDir.x) * Mathf.Rad2Deg) , -90,0));
        }
        DeathCheck();
    }

    private void DeathCheck()
    {
        if(HP <= 0)
        {
            OnDeath();
        }
    }
    private void OnDeath()
    {
        if (!gameObject.CompareTag("Player"))
        {

        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player") && GetComponent<Movement>().currentState != GetComponent<Movement>().rollState)
        {
            GetComponent<Movement>().InitiateStun();
            Vector2 knockDir = (collision.transform.position - transform.position).normalized * 100;
            OnDMGTake(1, -knockDir);
            GetComponent<Rigidbody2D>().AddForce(-knockDir, ForceMode2D.Impulse);
        }
    }
}
