using UnityEngine;

public class InteractNpc : MonoBehaviour
{
    [SerializeField] private GameObject npcText;
    [SerializeField] private GameObject npcCanvas;
    public bool inReach;

    private void Start()
    {
        inReach = false;
        npcText.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            npcText.SetActive(true);
            inReach = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            npcText.SetActive(false);
            inReach = false;
        }
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            npcText.SetActive(false);
            npcCanvas.SetActive(true);
        }
    }
}

