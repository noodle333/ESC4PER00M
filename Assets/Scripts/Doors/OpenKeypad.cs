using UnityEngine;

public class OpenKeypad : MonoBehaviour
{
    [SerializeField] private GameObject keypadObj;
    [SerializeField] private GameObject keypadText;

    public bool inReach;

    private GameObject player;

    private void Start()
    {
        inReach = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            if (keypadObj.GetComponent<Keypad>().animate == false)
            {
                keypadText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            keypadText.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown("e") && keypadObj.GetComponent<Keypad>().animate == false && player.GetComponent<CharacterController>().isGrounded)
        {
            keypadObj.SetActive(true);
        }
    }
}
