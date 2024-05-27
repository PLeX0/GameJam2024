using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InteractionsWithItems : MonoBehaviour
{
    [SerializeField] private float range = 1f;
    public Camera camera;
    private string itemName;
    public string description;
    private string objectName;
    public GameObject text;
    public GameObject inspectPoint;
    public GameObject item;
    public PlayerMovement playerMovement;
    public float rotationSpeed = 100.0f;
    public Vector3 startPos;
    public Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        itemName = GetComponent<GameObject>().name;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, range))
        {
            objectName = raycastHit.collider.gameObject.name;
            Debug.Log(objectName);
        }
        else if(!Physics.Raycast(ray, out raycastHit, range))
        {
            objectName = null;
            Debug.Log(objectName);
        }


        if (objectName==itemName)
        {
            text.SetActive(false);
        }
        else if(objectName!=itemName && playerMovement.isInspecting==false)
        {
            text.SetActive(true);
            text.transform.LookAt(camera.transform);
            text.transform.Rotate(0, 180, 0);
            if(Input.GetKeyDown(KeyCode.E))
            {
                startPos = item.transform.position;
                startRot = item.transform.rotation;
                playerMovement.isInspecting = true;
                item.transform.rotation = inspectPoint.transform.rotation;
            }
            
        }
        else if(playerMovement.isInspecting)
        {
           // Debug.Log("eeeeee");
            text.SetActive(false);
            item.transform.position = inspectPoint.transform.position;
            

            transform.Rotate(Vector3.up, -mouseX * rotationSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.right, mouseY * rotationSpeed * Time.deltaTime, Space.Self);

            if (Input.GetKeyUp(KeyCode.E))
            {
                playerMovement.isInspecting = false;
                item.transform.position = startPos;
                item.transform.rotation = startRot;
            }
        }
        
    }
}
