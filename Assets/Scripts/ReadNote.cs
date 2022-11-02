using UnityEngine;

public class ReadNote : MonoBehaviour
{
    [SerializeField] private GameObject noteObj;
    [SerializeField] private GameObject noteText;
    public bool inReach;

    private void Start()
    {
        inReach = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            noteText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            noteText.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown("e"))
        {
            // noteText.SetActive(false);
            noteObj.SetActive(true);
        }
    }
}
