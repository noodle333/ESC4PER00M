using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource voiceSound;
    [SerializeField] private GameObject image;

    private int index;

    private void Start()
    {
        player.GetComponent<FPSController>().enabled = false;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            if (c + "" != " ")
            {
                voiceSound.Play();
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            //WHEN TEXT IS OVER
            player.GetComponent<FPSController>().enabled = true;
            gameObject.SetActive(false);
            image.SetActive(false);
        }
    }
}
