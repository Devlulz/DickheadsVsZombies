using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Weapon, Consumable, Buildable, Tool, None}
public class Equipment : MonoBehaviour
{
    [SerializeField]
    Movement move;
    [SerializeField]
    GameObject itemAnchor;

    [SerializeField]
    Transform slashAnchor;

    public GameObject itemEquipped;
    public ItemType type;

    Vector2 aimDirection;
    Vector2 offset;

    public float angleOffset;

    float leftAngle = -45;
    float rightAngle = 45;

    [SerializeField]
    float distance;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        aimDirection = (new Vector2(Screen.width / 2, Screen.height / 2) - mousePos ).normalized;
        //Debug.Log(aimDirection);
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);

        switch (type)
        {
            case ItemType.Weapon:
                itemAnchor.transform.rotation = Quaternion.Euler(0, 0, angle + angleOffset);
                slashAnchor.transform.rotation = Quaternion.Euler(0, 0, angle);

                move.facingLeft = aimDirection.x < 0;

                if (move.facingLeft)
                {
                    //Debug.Log("BRUH");
                    itemAnchor.transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    //Debug.Log("WTF");
                    itemAnchor.transform.localScale = new Vector3(1, 1, 1);
                }
                break;
            case ItemType.Buildable:

                break;
        }
    }
}
