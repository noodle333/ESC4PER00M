using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator door;
    [SerializeField] private GameObject openText;
    [SerializeField] private AudioSource doorSound;

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
        if (inReach && Input.GetKeyDown(KeyCode.E) && door.GetBool("Close"))
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
        doorSound.Play();
        door.SetBool("Open", true);
        door.SetBool("Close", false);
    }

    private void DoorCloses()
    {
        doorSound.Play();
        door.SetBool("Open", false);
        door.SetBool("Close", true);
    }
}
