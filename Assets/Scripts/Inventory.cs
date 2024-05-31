using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] slot = new Image[7];
    public int[] itemIdInSlot = new int[7];
    public Sprite[] icon = new Sprite[8];
    public bool[] isEmpty = new bool[7];

    public Transform inspectPoint;
    public GameObject keyboardPasswordItem;
    public ItemList itemList;
    public PlayerMovement PlayerMovement;
    private float mouseX, mouseY;
    public GameObject flashLight;
    
    // Start is called before the first frame update
    void Start()
    {
        AddItem(1);
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(itemIdInSlot[0]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(itemIdInSlot[1]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(itemIdInSlot[2]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItem(itemIdInSlot[3]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UseItem(itemIdInSlot[4]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            UseItem(itemIdInSlot[5]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            UseItem(itemIdInSlot[6]);
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
                itemIdInSlot[i] = id;
                isEmpty[i] = false;
                break;
            }
        }
    }

    public void RemoveItem(int id)
    {

    }
    //id=0 passwordToKeyboard
    public void UseItem(int id)
    {
        if (id == 0)
        {

        }
        else if (id == 1)
        {
            if (flashLight.active == true)
            {
                flashLight.SetActive(false);
            }
            else if(flashLight.active==false)
            {
                flashLight.SetActive(true);
            }
        }
    }


  
}
