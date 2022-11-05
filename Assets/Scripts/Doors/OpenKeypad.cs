using UnityEngine;

public class OpenKeypad : MonoBehaviour
{
    [SerializeField] private GameObject keypadObj;
    [SerializeField] private GameObject keypadText;

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
        if (inReach && Input.GetKeyDown("e") && keypadObj.GetComponent<Keypad>().animate == false)
        {
            keypadObj.SetActive(true);
        }
    }
}
