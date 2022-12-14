using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private Animator door;
    [SerializeField] private GameObject keyToUnlock;
    [SerializeField] private GameObject openText;
    [SerializeField] private GameObject keyMissingText;
    //PLACE IN ORDER THEY WOULD BE SEEN THROUGHOUT THE GAME
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource doorSound;

    public bool inReach;
    public bool isOpen;

    private void Start()
    {
        inReach = false;
        openText.SetActive(false);
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
            keyMissingText.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown("e") && keyToUnlock.activeInHierarchy)
        {
            keyToUnlock.SetActive(false);
            DoorOpens();
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            doorSound.clip = audioClips[1];
            doorSound.Play();
            isOpen = true;
        }
        else if (inReach && Input.GetKeyDown("e") && !keyToUnlock.activeInHierarchy)
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
            doorSound.clip = audioClips[0];
            doorSound.Play();
        }

        if (isOpen)
        {
            //TURN OFF COLLISION AND SCRIPT         
            door.GetComponent<BoxCollider>().enabled = false;
            door.GetComponent<LockedDoor>().enabled = false;
        }
    }

    private void DoorOpens()
    {
        door.SetBool("Open", true);
        door.SetBool("Close", false);
    }
}
