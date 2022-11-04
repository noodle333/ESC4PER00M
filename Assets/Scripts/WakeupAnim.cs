using UnityEngine;

public class WakeupAnim : MonoBehaviour
{
    [SerializeField] private RectTransform upperEye;
    [SerializeField] private RectTransform lowerEye;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wakeupCanvas;

    [Range(0.0f, 630.0f)]
    public float upperEyeHeight;

    [Range(0.0f, 630.0f)]
    public float lowerEyeHeight;

    public bool isAnimFinished = false;

    private void Start()
    {
        //SHOW VALUES ON SLIDER
        upperEyeHeight = upperEye.rect.height;
        lowerEyeHeight = lowerEye.rect.height;
        //DISABLE PLAYER ELEMENTS
        crosshair.SetActive(false);
        player.GetComponent<FPSController>().enabled = false;

        isAnimFinished = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //CHANGE VALUES OF SLIDER
        upperEye.sizeDelta = new Vector2(upperEye.rect.width, upperEyeHeight);
        lowerEye.sizeDelta = new Vector2(lowerEye.rect.width, lowerEyeHeight);

        if (isAnimFinished)
        {
            player.GetComponent<FPSController>().enabled = true;
            crosshair.SetActive(true);
            wakeupCanvas.SetActive(false);
        }
    }
    //UPDATE -> PLAY ANIMATION -> WHEN ANIMATION STOP -> RETURN CROSSHAIR + DISABLE OBJECT
}

