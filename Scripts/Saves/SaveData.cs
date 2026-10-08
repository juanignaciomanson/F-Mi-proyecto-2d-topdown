using System.Collections.Generic;
using UnityEngine;
//las saves no son monobehaviour, solo hace una clase
//esto significa que podemos empaquetar datos a forma de texto
[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
    //si tenes map o camera boundrys necesitas esto de abajo
    public string mapBoundary; //The boundary name for the map
    public List<InventorySaveData> inventorySaveData;
}
