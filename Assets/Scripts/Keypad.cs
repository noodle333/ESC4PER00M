using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject keypadObj;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject inv;

    [SerializeField] private GameObject animatorObj;
    [SerializeField] private Animator anim;

    [SerializeField] private TMP_Text textObj;
    [SerializeField] private string answer = "8888";

    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource correct;
    [SerializeField] private AudioSource wrong;

    public bool animate;

    private void Start()
    {
        // keypadObj.SetActive(false);
    }

    public void Number(int number)
    {
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
        keypadObj.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FPSController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (textObj.text == "Correct" && animate)
        {
            anim.SetBool("Open", true);
            Debug.Log("Open");
        }

        if (keypadObj.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            player.GetComponent<FPSController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
