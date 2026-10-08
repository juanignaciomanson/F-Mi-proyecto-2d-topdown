using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    //queda privado para no poder modificarlo
    private ItemDictionary itemDictionary;
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public int slotCount;
    public GameObject[] itemPrefabs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemDictionary = FindFirstObjectByType<ItemDictionary>();
        //for (int i = 0; i < slotCount; i++)
        //{
        //    Slot slot = Instantiate(slotPrefab, inventoryPanel.transform).GetComponent<Slot>();
        //    if (i < itemPrefabs.Length)
        //    {
        //        GameObject item = Instantiate(itemPrefabs[i], slot.transform);
        //        //esto hace que el item se ponga en medio del inventory slot
        //        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        //        slot.currentItem = item;
        //    }
        //}
    }

    public bool AddItem(GameObject itemPrefab)
    {
        //Look for an empty slot (not necessary in roguelike?)
        foreach(Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot != null && slot.currentItem == null)
            {
                GameObject newItem = Instantiate(itemPrefab, slot.transform);
                newItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                slot.currentItem = newItem;
                return true;
            }
        }

        Debug.Log("Inventory is full!");
        return false;

    }
    public List<InventorySaveData> GetInventoryItems()
    {
        List<InventorySaveData> invData = new List<InventorySaveData>();
        foreach (Transform slotTransform in inventoryPanel.transform)
        {
            Slot slot = slotTransform.GetComponent<Slot>();
            if (slot.currentItem != null)
            {
                Item item = slot.currentItem.GetComponent<Item>();
                //GetSiblingIndex si GameObjects comparten un parent en la hierarchy, es donde se sientan en la sibling hierarchy
                //o sea cual va primero segundo y asi segun la lista de slots
                invData.Add(new InventorySaveData { itemID = item.ID, slotIndex = slotTransform.GetSiblingIndex() });
            }
           
        }
        return invData;
    } 
        public void SetInventoryItems(List<InventorySaveData> inventorySaveData)
        {
        //clear inventory panel to avoid duplicates

        foreach(Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
        //create new slots
        for(int i = 0; i < slotCount; i++)
        {
            Instantiate(slotPrefab, inventoryPanel.transform);
        }
       //populate slots with saved items 
       foreach(InventorySaveData data in inventorySaveData)
        {
            if(data.slotIndex < slotCount)
            {
                Slot slot = inventoryPanel.transform.GetChild(data.slotIndex).GetComponent<Slot>();
                GameObject itemPrefab = itemDictionary.GetItemPrefab(data.itemID);
                if(itemPrefab != null)
                {
                    GameObject item = Instantiate(itemPrefab, slot.transform);
                    item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    slot.currentItem = item;
                }
            }    
        }
        }
    }

