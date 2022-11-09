using UnityEngine;
using TMPro;

public class ThreeKeyDoor : MonoBehaviour
{
    [SerializeField] private Animator door;
    [SerializeField] private GameObject keyOne;
    [SerializeField] private GameObject keyTwo;
    [SerializeField] private GameObject keyThree;
    [SerializeField] private GameObject openText;
    [SerializeField] private GameObject keyMissingText;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource doorSound;

    [SerializeField] private TMP_Text keyMissing;
    public bool inReach;
    public bool isOpen;
    private bool canOpen;

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
        if (keyOne.activeInHierarchy && keyTwo.activeInHierarchy && keyThree.activeInHierarchy)
        {
            canOpen = true;
        }
        if (inReach && Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            keyOne.SetActive(false);
            keyTwo.SetActive(false);
            keyThree.SetActive(false);
            DoorOpens();
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            doorSound.clip = audioClips[1];
            doorSound.Play();
            isOpen = true;
        }
        else if (inReach && Input.GetKeyDown(KeyCode.E) && !canOpen)
        {
            CheckKeyAmount();
            openText.SetActive(false);
            keyMissingText.SetActive(true);
            doorSound.clip = audioClips[0];
            doorSound.Play();
        }
    }

    private void DoorOpens()
    {
        door.SetBool("Open", true);
        door.SetBool("Close", false);
    }

    private void CheckKeyAmount()
    {
        int keys = 0;
        if (keyOne.activeInHierarchy)
        {
            keys++;
        }
        if (keyTwo.activeInHierarchy)
        {
            keys++;
        }
        if (keyThree.activeInHierarchy)
        {
            keys++;
        }

        //CHANGE TEXT
        keyMissing.text = keys + "/3 KEYS COLLECTED";
    }
}
