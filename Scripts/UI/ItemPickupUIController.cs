using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;




public class ItemPickupUIController : MonoBehaviour
{
    //una instance hace que cualquier script pueda acceder a este script sin hacer una referencia
    //asi un item prefab puede entrar. Este script llama a todos
    public GameObject popupPrefab;
    public int maxPopups = 5;
    public float popupDuration = 3f;

    private readonly Queue<GameObject> activePopups = new();


    public static ItemPickupUIController Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple ItemPickupUIManager instances detected! Destroying the extra one.");
            Destroy(gameObject);
        }
    }

    //aca usa el sprite y nombre del item que agarras
    public void ShowItemPickup(string itemName, Sprite itemIcon)
    {
        GameObject newPopup = Instantiate(popupPrefab, transform);
        //toma datos de children del item prefab
        newPopup.GetComponentInChildren<TMP_Text>().text = itemName;
        //tiene que llamarse como el nombre en ""
        Image itemImage = newPopup.transform.Find("ItemIcon")?.GetComponent<Image>();
        if (itemImage)
        {
            itemImage.sprite = itemIcon;
        }

        activePopups.Enqueue(newPopup);
        if(activePopups.Count > maxPopups)
        {
            // esto agarra el ultimo
            Destroy(activePopups.Dequeue());
        }
        //fade out and destroy
        StartCoroutine(FadeOutAndDestroy(newPopup));
    }
    private IEnumerator FadeOutAndDestroy(GameObject popup)
    {
        yield return new WaitForSeconds(popupDuration);
        if (popup == null) yield break;

        CanvasGroup canvasGroup = popup.GetComponent<CanvasGroup>();
        for(float timePassed = 0f; timePassed < 1f; timePassed += Time.deltaTime)
        {
            if (popup == null) yield break;
            //alpha hace fade out en este caso por segundo
            canvasGroup.alpha = 1f - timePassed;
            yield return null;
        }

        Destroy(popup);
    }
}
