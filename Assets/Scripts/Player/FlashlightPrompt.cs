using System.Collections;
using UnityEngine;

public class FlashlightPrompt : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] private GameObject flashlightText;
    [SerializeField] private FlashlightPrompt script;

    private void Start()
    {
        StartCoroutine("ShowFlashPrompt", 5);
    }

    private void Update()
    {
        if (flashlight.activeInHierarchy)
        {
            flashlightText.SetActive(false);
            script.enabled = false;
        }
    }

    IEnumerator ShowFlashPrompt(float showForSeconds)
    {
        yield return new WaitForSeconds(showForSeconds);
        if (!flashlight.activeInHierarchy)
        {
            flashlightText.SetActive(true);
        }
        yield return new WaitForSeconds(5);
        flashlightText.SetActive(false);
        script.enabled = false;
    }
}
