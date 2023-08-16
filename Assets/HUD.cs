using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public int currentItem;
    [SerializeField]
    RectTransform slotSelected;

    [SerializeField]
    GameObject inventoryUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentItem++;
            SwitchSlots();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentItem--;
            SwitchSlots();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenInventory();
        }
    }

    void OpenInventory()
    {
        if (!inventoryUI.activeInHierarchy)
        {
            inventoryUI.SetActive(true);
        }
        else
        {
            inventoryUI.SetActive(false);
        }
    }
    void SwitchSlots()
    {
        if(currentItem >= 8)
        {
            currentItem = 0;
        }
        if (currentItem <= -1)
        {
            currentItem = 7;
        }
        float newX = -56 + (currentItem * 16);

        slotSelected.localPosition = new Vector3(newX, -64, 0);
    }
}
