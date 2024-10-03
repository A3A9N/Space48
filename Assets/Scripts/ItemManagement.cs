using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManagement : MonoBehaviour
{
    [SerializeField] private Image itemImageHolder;
    [SerializeField] private TMP_Text messageField;
    [SerializeField] private Movement movementScript;
    [SerializeField] private Shooting shootingScript;
    [SerializeField] private TMP_Text introductionField;

    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;

    void Start()
    {
        StartCoroutine(Introduction());
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item")) {
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
                StartCoroutine(ShowMessage(" + Move Speed"));
                movementScript.IncreaseMoveSpeed(5f);
            }
            else if (items[activeItemIndex] == Color.red)
            {
                StartCoroutine(ShowMessage(" + Fire Rate"));
                shootingScript.DecreaseCooldownTime(0.2f);
            }
            else if(items[activeItemIndex] == Color.green)
            {
                StartCoroutine(ShowMessage(" + Rotation Speed"));
                movementScript.IncreaseRotationSpeed(10f);
            }      
            items.RemoveAt(activeItemIndex);            
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if(items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }

    IEnumerator ShowMessage(string message) 
    {
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(3f);
        messageField.enabled = false;
    }
    IEnumerator Introduction()
    {
        introductionField.enabled = true;
        introductionField.text = "Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.";
        yield return new WaitForSeconds(5f);
        introductionField.enabled = false;
    }

    void Update()
    {
        CycleItems();
        UseItem();
    }
}
