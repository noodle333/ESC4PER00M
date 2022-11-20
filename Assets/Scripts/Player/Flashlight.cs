using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] private AudioSource flashSound;
    public bool on;
    public bool off;

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
            flashSound.Play();
        }
        else if (on && Input.GetKeyDown(KeyCode.F))
        {
            off = true;
            on = false;
            flashlight.SetActive(false);
            flashSound.Play();
        }
    }

}
