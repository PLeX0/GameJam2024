using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0.02f, 0);
        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }
}
