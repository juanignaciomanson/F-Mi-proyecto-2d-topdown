using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ItemDictionary : MonoBehaviour
{
    //manualmente poblada, contiene todos nuestros items prefabs
    public List<Item> itemPrefabs;
    //Un diccionario es una lista de lo que queramos sobre el segundo campo (GameObjecto), con la Key del primer campo (int)
    private Dictionary<int, GameObject> itemDictionary;

    // Awake es antes que Start
    private void Awake()
    {
        itemDictionary = new Dictionary<int, GameObject>();
        //para autoincrementar el numero de Id
        for(int i = 0; i <itemPrefabs.Count; i++)
        {
            if (itemPrefabs[i] != null)
            {
                itemPrefabs[i].ID = i + 1;
            }
        }
        foreach(Item item in itemPrefabs)
        {
            itemDictionary[item.ID] = item.gameObject;
        }
    }

    public GameObject GetItemPrefab(int itemID)
    {
        //esto evita que si el numero de item no existe el juego crashee
        itemDictionary.TryGetValue(itemID, out GameObject prefab);
        if(prefab == null)
        {
            //usamos el $ y los {} para que aparezca el Id en medio de un mensaje de texto
            Debug.LogWarning($"Item with ID {itemID} is not found in dictionary");
        }
        return prefab;
    }
}
