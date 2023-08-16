using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DamageType { Combat, Mining, Chopping, Misc}
public class Resource : MonoBehaviour
{
    [SerializeField]
    int hp;
    [SerializeField]
    DamageType weakness;

    [SerializeField]
    GameObject[] drop;

    public void ApplyDMG(int dmg, DamageType dmgType)
    {
        StartCoroutine(GetComponent<WhiteFlash>().FlashEffect());
        if(weakness == dmgType || weakness == DamageType.Misc)
        {
            hp -= dmg * 2;
        }
        else
        {
            hp -= dmg;
        }


        if(hp <= 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
}
