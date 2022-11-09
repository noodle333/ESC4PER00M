using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Update()
    {
        text.text = "FPS: " + (int)(1f / Time.unscaledDeltaTime);
    }
}
