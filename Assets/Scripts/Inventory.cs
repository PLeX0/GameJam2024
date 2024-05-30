using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] slot = new Image[7];
    public Sprite[] icon = new Sprite[8];
    public bool[] isEmpty = new bool[7];
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(slot[0].sprite.name);
        }
    }

    public void AddItem(int id)
    {
        Debug.Log("podniesiono " + id);
        for(int i = 0; i<isEmpty.Length;i++)
        {
            Debug.Log("petla");
            if(isEmpty[i]==true)
            {
                slot[i].sprite = icon[id];
                isEmpty[i] = false;
                break;
            }
        }
    }

    public void RemoveItem(int id)
    {

    }

    public void UseItem(int id)
    {

    }
    
}
