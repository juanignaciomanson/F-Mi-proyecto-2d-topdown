using UnityEngine;
using UnityEngine.UI;
public class TabController : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] Pages; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {///activa la primera pagina siempre
        ActivateTab(0);
    }

    public void ActivateTab(int tabNo)
    {//elige las paginas que tienen que ser grises (tabs) y transparentes (menues)
        for(int i= 0; i < Pages.Length; i++)
        {
            Pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        Pages[tabNo].SetActive(true);
        tabImages[tabNo].color = Color.white;
    }
}
