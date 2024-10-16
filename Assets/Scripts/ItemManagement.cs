using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManagement : MonoBehaviour
{
    [SerializeField] private Image itemImageHolder;
    [SerializeField] private MessageSystem messageSystem;
    [SerializeField] private Movement movementScript;
    [SerializeField] private Shooting shootingScript;

    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }

    void PickUpItem(GameObject item)
    {
        Color color = item.GetComponent<Renderer>().material.color;
        Destroy(item);
        items.Add(color);
        activeItemIndex = items.Count - 1;
        itemImageHolder.color = items[activeItemIndex];
        itemImageHolder.enabled = true;
    }

    void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                if (activeItemIndex < items.Count - 1)
                {
                    activeItemIndex++;
                }
                else
                {
                    activeItemIndex = 0;
                }
                itemImageHolder.color = items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }

    void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {
            if (items[activeItemIndex] == Color.blue)
            {
                messageSystem.ShowMessage("+ Move Speed", 3f); 
                movementScript.IncreaseMoveSpeed(5f);
            }
            else if (items[activeItemIndex] == Color.red)
            {
                messageSystem.ShowMessage("+ Fire Rate", 3f); 
                shootingScript.DecreaseCooldownTime(0.2f);
            }
            else if (items[activeItemIndex] == Color.green)
            {
                messageSystem.ShowMessage("+ Rotation Speed", 3f); 
                movementScript.IncreaseRotationSpeed(10f);
            }
            items.RemoveAt(activeItemIndex);
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if (items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }

    void Update()
    {
        CycleItems();
        UseItem();
    }
}
