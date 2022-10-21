using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator door;
    [SerializeField] private GameObject openText;

    public bool inReach;

    private void Start()
    {
        inReach = false;
        door.SetBool("Close", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown("e") && door.GetBool("Close"))
        {
            DoorOpens();
        }
        else if (inReach && Input.GetKeyDown("e"))
        {
            DoorCloses();
        }
    }

    private void DoorOpens()
    {
        Debug.Log("It opens");
        door.SetBool("Open", true);
        door.SetBool("Close", false);
    }

    private void DoorCloses()
    {
        Debug.Log("It closes");
        door.SetBool("Open", false);
        door.SetBool("Close", true);
    }
}
