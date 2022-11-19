using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject keypadObj;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject inv;
    [SerializeField] private GameObject flashlight;

    [SerializeField] private GameObject animatorObj;
    [SerializeField] private Animator anim;

    [SerializeField] private TMP_Text textObj;
    [SerializeField] private string answer = "8888";

    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource correct;
    [SerializeField] private AudioSource wrong;

    public bool animate;
    private bool isFlashOn;

    //TURN OFF TEXT AFTER COMPLETE
    [SerializeField] private GameObject openText;

    public void Number(int number)
    {
        if (textObj.text == "Incorrect")
        {
            Clear();
        }
        if (!animate && textObj.textInfo.characterCount < 4)
        {
            textObj.text += number.ToString();
            button.Play();
        }
    }

    public void Execute()
    {
        if (!animate)
        {
            if (textObj.text == answer)
            {
                correct.Play();
                textObj.text = "Correct";
                animate = true;
                openText.SetActive(false);
            }
            else
            {
                wrong.Play();
                textObj.text = "Incorrect";
            }
        }
    }

    public void Clear()
    {
        if (!animate)
        {
            textObj.text = "";
            button.Play();
        }
    }

    public void Exit()
    {
        Clear();
        keypadObj.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        flashlight.SetActive(isFlashOn);
        player.GetComponent<FPSController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isFlashOn = false;
    }

    private void Update()
    {
        if (textObj.text == "Correct" && animate)
        {
            anim.SetBool("Open", true);
        }

        if (keypadObj.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            if (flashlight.activeInHierarchy)
            {
                isFlashOn = true;
                flashlight.SetActive(false);
            }
            player.GetComponent<FPSController>().playerAudio.Stop();
            player.GetComponent<FPSController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Exit();
        }
    }
}
