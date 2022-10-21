using UnityEngine;

public class OpenBox : MonoBehaviour
{
    [SerializeField] private Animator boxAnimator;
    [SerializeField] private GameObject keyToUnlock;
    [SerializeField] private GameObject openText;
    [SerializeField] private GameObject keyMissingText;

    public bool inReach;
    public bool isOpen;

    private void Start()
    {
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
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
        if (inReach && Input.GetKeyDown(KeyCode.E) && keyToUnlock.activeInHierarchy)
        {
            keyToUnlock.SetActive(false);
            boxAnimator.SetBool("Open", true);
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            isOpen = true;
        }
        else if (inReach && Input.GetKeyDown(KeyCode.E) && !keyToUnlock.activeInHierarchy)
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
        }

        if (isOpen)
        {
            boxAnimator.GetComponent<BoxCollider>().enabled = false;
            boxAnimator.GetComponent<OpenBox>().enabled = false;

        }
    }
}
