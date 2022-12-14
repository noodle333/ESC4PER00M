using UnityEngine;

public class PickupKey : MonoBehaviour
{
    [SerializeField] private GameObject keyObj;
    [SerializeField] private GameObject invObj;
    [SerializeField] private GameObject pickupText;
    [SerializeField] private AudioSource pickupAudio;

    public bool inReach;

    private void Start()
    {
        inReach = false;
        pickupText.SetActive(false);
        invObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickupText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickupText.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            pickupAudio.Play();
            keyObj.SetActive(false);
            invObj.SetActive(true);
            pickupText.SetActive(false);
        }
    }
}
