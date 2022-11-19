using System.Collections;
using UnityEngine;

public class SecretDoorLever : MonoBehaviour
{
    [SerializeField] private Animator door;
    [SerializeField] private Animator lever;
    [SerializeField] private AudioSource doorSound;
    [SerializeField] private GameObject openleverText;
    [SerializeField] private GameObject doorHasOpenedText;

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
            //CALL DOOR OPENS TEXT PROMPT
            StartCoroutine("DoorHasOpenedText", 3f);
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

    IEnumerator DoorHasOpenedText(float showForSeconds)
    {
        yield return new WaitForSeconds(1);
        doorHasOpenedText.SetActive(true);
        yield return new WaitForSeconds(showForSeconds);
        doorHasOpenedText.SetActive(false);
    }
}
