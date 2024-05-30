using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionsWithItems : MonoBehaviour
{
    [SerializeField] private float range = 1f;
    [SerializeField] private int id = 0;
    public Camera mainCamera;
    private string itemName;
    public string description;
    private string objectName;
    public GameObject text;
    public GameObject inspectPoint;
    public GameObject item;
    public GameObject keyboardUI;
    public PlayerMovement playerMovement;
    public float rotationSpeed = 100.0f;
    public Vector3 startPos;
    public Quaternion startRot;

    private bool isBeingInspected = false;

    void Start()
    {
        itemName = this.gameObject.name;
    }

    void Update()
    {
        if (id == 0)
        {

            if (playerMovement.isInspecting && !isBeingInspected)
            {
                return;
            }

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, range))
            {
                objectName = raycastHit.collider.gameObject.name;
                Debug.Log(objectName);
            }
            else
            {
                objectName = null;
                Debug.Log(objectName);
            }

            if (objectName == itemName)
            {
                text.SetActive(true);
                text.transform.LookAt(mainCamera.transform);
                text.transform.Rotate(0, 180, 0);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    startPos = item.transform.position;
                    startRot = item.transform.rotation;
                    playerMovement.isInspecting = true;
                    isBeingInspected = true;
                    item.transform.rotation = inspectPoint.transform.rotation;
                }


            }
            else if (objectName != itemName && !playerMovement.isInspecting)
            {
                text.SetActive(false);
            }
            if (isBeingInspected)
            {
                text.SetActive(false);
                item.transform.position = inspectPoint.transform.position;

                transform.Rotate(Vector3.up, -mouseX * rotationSpeed * Time.deltaTime, Space.World);
                transform.Rotate(Vector3.right, mouseY * rotationSpeed * Time.deltaTime, Space.Self);

                if (Input.GetKeyUp(KeyCode.E))
                {
                    playerMovement.isInspecting = false;
                    isBeingInspected = false;
                    item.transform.position = startPos;
                    item.transform.rotation = startRot;
                    playerMovement.isCrouch = false;
                }
            }
        }
        else if(id==1)
        {
            if (playerMovement.isInspecting && !isBeingInspected)
            {
                return;
            }
         
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, range))
            {
                objectName = raycastHit.collider.gameObject.name;
                Debug.Log(objectName);
            }
            else
            {
                objectName = null;
                Debug.Log(objectName);
            }

            if (objectName == itemName)
            {
                text.SetActive(true);
                text.transform.LookAt(mainCamera.transform);
                text.transform.Rotate(0, 180, 0);

                if (Input.GetKeyUp(KeyCode.E))
                {
                    keyboardUI.SetActive(true);
                    playerMovement.isInspecting = true;
                    isBeingInspected = true;
                }


            }
            else if (objectName != itemName && !playerMovement.isInspecting)
            {
                text.SetActive(false);
            }
            if (isBeingInspected)
            {
                text.SetActive(false);

               
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    keyboardUI.SetActive(false);
                    playerMovement.isInspecting = false;
                    isBeingInspected = false;
                    playerMovement.isCrouch = false;
                }
            }
        }
    }

    public void OutFromKeyboard()
    {
        keyboardUI.SetActive(false);
        playerMovement.isInspecting = false;
        isBeingInspected = false;
        playerMovement.isCrouch = false;
    }
}
