using UnityEngine;
using TMPro;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text countdown;
    [SerializeField] private ThreeKeyDoor door;
    [SerializeField] private float timeUntilDeath;
    [SerializeField] private GameObject killPlayer;
    [SerializeField] private AudioSource countdownSound;

    private void Start()
    {
        countdown.text = timeUntilDeath + "";
        countdownSound.Play();
    }

    private void Update()
    {
        if (!door.isOpen)
        {
            Countdown();
            Death();
        }
        countdown.text = (int)timeUntilDeath + "";
    }

    private void Countdown()
    {
        timeUntilDeath -= Time.deltaTime;
    }

    private void Death()
    {
        if (timeUntilDeath <= 0)
        {
            killPlayer.SetActive(true);
        }
    }
}
