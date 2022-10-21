using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] private bool on;
    [SerializeField] private bool off;

    //Audio Source turnOn, turnOff,

    private void Start()
    {
        off = true;
        flashlight.SetActive(false);
    }

    private void Update()
    {
        if (off && Input.GetKeyDown(KeyCode.F))
        {
            on = true;
            off = false;
            flashlight.SetActive(true);
        }
        else if (on && Input.GetKeyDown(KeyCode.F))
        {
            off = true;
            on = false;
            flashlight.SetActive(false);
        }
    }

}
