using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string Name;
    //al ser virtual se puede extender por si queremos que un item funcione diferente
    public virtual void PickUp()
    {
        Sprite itemIcon = GetComponent<Image>().sprite;
        if(ItemPickupUIController.Instance != null)
        {
            ItemPickupUIController.Instance.ShowItemPickup(Name, itemIcon);
        }
    }
}
