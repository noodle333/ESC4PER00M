using UnityEngine;

public class SecretDoorLever : MonoBehaviour
{
    [SerializeField] private Animator door;
    [SerializeField] private Animator lever;
    [SerializeField] private AudioSource doorSound;
    [SerializeField] private GameObject openleverText;

    public bool inReach;
    public bool isOpen;
    public bool isAnimFinished;

    private void Start()
    {
        inReach = false;
        openleverText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openleverText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openleverText.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            openleverText.SetActive(false);
            lever.SetBool("Open", true);
        }

        if (isAnimFinished)
        {
            DoorOpens();
            doorSound.Play();
            isOpen = true;
        }

        if (isOpen)
        {
            lever.GetComponent<BoxCollider>().enabled = false;
            lever.GetComponent<SecretDoorLever>().enabled = false;
        }
    }

    private void DoorOpens()
    {
        door.SetBool("Open", true);
        door.SetBool("Close", false);
    }
}
