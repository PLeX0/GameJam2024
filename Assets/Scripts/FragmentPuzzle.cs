using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentPuzzle : MonoBehaviour
{
    public GameObject fragment;
    public GameObject paintingWithFragment;
    public GameObject painting;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PaintingFragment"))
        {
            painting.SetActive(false);
            paintingWithFragment.SetActive(true);
            fragment.SetActive(false);
            playerMovement.isInspecting = false;
            playerMovement.isMoveingItem = false;
        }
    }
}
