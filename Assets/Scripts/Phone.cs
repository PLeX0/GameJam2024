using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Phone : MonoBehaviour
{
    public AudioClip[] audioClip = new AudioClip[4];
    public AudioSource audioSource;
    private bool isCalling = false;
    public GameObject text;
    public Camera mainCamera;
    public int callId = 0;
    private string objectName;
    public string call1str = "The first and second digits of the door code are 7 and 2";
    public string call2str = "The third and fourth digits of the door code are 2 and 4";
    public string call3str = "The fifth and sixth digits of the door code are 8 and 1";
    public TMP_Text callText;
    private bool isDisplaying = false;
    public float time = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDisplaying == false)
            callText.text = " ";

     
        if (isDisplaying)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                isDisplaying = false;
                time = 3.5f;
            }
        }

        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 3f))
        {
            objectName = raycastHit.collider.gameObject.name;
        }
        else
        {
            objectName = null;
            Debug.Log(objectName);
        }
        if (objectName == "Phone")
        {
            text.SetActive(true);
            text.transform.LookAt(mainCamera.transform);
            text.transform.Rotate(0, 180, 0);
            if (Input.GetKeyDown(KeyCode.E) && isCalling)
            {
                isCalling = false;
                Debug.Log("odebralem");
                audioSource.Stop();
                audioSource.clip = audioClip[callId];
                audioSource.loop = false;
                audioSource.Play();
                DisplayText(callId);
            }
        }
        else if (objectName != "Phone")
        {
            text.SetActive(false);
        }


    }

    public void Call(int id)
    {
        callId = id;
        isCalling = true;
        if(isCalling)
        {
            Debug.Log("dryn dryn");
            audioSource.clip = audioClip[0];
            audioSource.loop = true;
            audioSource.Play();
        }
        else if(isCalling==false)
        {
            DisplayText(id);
            audioSource.Stop();
            audioSource.clip = audioClip[id];
            audioSource.loop = false;
            
        }

    }

    public void DisplayText(int id)
    {
        Debug.Log("pisze");
        isDisplaying = true;
        if(id == 1)
        {
            callText.text = call1str;
        }
        else if(id==2)
        {
            callText.text = call2str;
        }
        else if (id == 3)
        {
            callText.text = call3str;
        }
    }
}
