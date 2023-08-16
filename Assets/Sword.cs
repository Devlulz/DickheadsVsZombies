using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    GameObject slash;

    public Equipment equip;

    bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        isLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnUse();
        }
    }

    public void OnUse()
    {
        StartCoroutine(Slash());
    }
    IEnumerator Slash()
    {
        slash.SetActive(true);
        if (isLeft)
        {
            SetRight();
        }
        else
        {
            SetLeft();
        }
        yield return new WaitForSeconds(.1f);
        slash.SetActive(false);
    }
    public void SetLeft()
    {
        isLeft = true;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        equip.angleOffset = -90;
    }
    public void SetRight()
    {
        isLeft = false;
        transform.localRotation = Quaternion.Euler(0, 0, 180);
        equip.angleOffset = 45;
    }
}
