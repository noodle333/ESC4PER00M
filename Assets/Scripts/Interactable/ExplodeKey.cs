using UnityEngine;

public class ExplodeKey : MonoBehaviour
{
    [SerializeField] private GameObject pickupText;
    [SerializeField] private GameObject killPlayer;

    public bool inReach;

    private void Start()
    {
        inReach = false;
        pickupText.SetActive(false);
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
            pickupText.SetActive(false);
            gameObject.SetActive(false);
            killPlayer.SetActive(true);
        }
    }
}
