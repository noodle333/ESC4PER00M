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

    public void Number(int number)
    {
        textObj.text += number.ToString();
        button.Play();
    }
}
