using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { //esto hace que el menu no este abierto apenas entras
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //aca elegimos que tecla hace que abra el menu
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {//aca dice hace lo que no estas haciendo ahora, basicamente un toggle
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
        //Si el menu esta abierto lo cierra y si esta cerrado lo abre
    }
}
