using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDeathTrigger : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject player;

    [SerializeField] private AudioSource deathAudio;
    [SerializeField] private GameObject wakeUpText;
    [SerializeField] private float timeRemaining = 3;

    private void Start()
    {
        wakeUpText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            deathScreen.SetActive(true);
            cursor.SetActive(false);
            player.GetComponent<FPSController>().enabled = false;
            deathAudio.Play();
        }
    }

    private void Update()
    {
        if (deathScreen.activeInHierarchy)
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
}
