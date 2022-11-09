using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject player;

    [SerializeField] private AudioSource deathSound;
    [SerializeField] private GameObject wakeUpText;
    [SerializeField] private float timeRemaining = 5f;

    private void Start()
    {
        wakeUpText.SetActive(false);
        deathScreen.SetActive(true);
        cursor.SetActive(false);
        player.GetComponent<FPSController>().enabled = false;
        deathSound.Play();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            wakeUpText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}
