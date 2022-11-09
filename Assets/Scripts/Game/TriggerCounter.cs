using UnityEngine;

public class TriggerCounter : MonoBehaviour
{
    [SerializeField] private GameObject timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer.SetActive(true);
            //CLOSE DOOR
        }
    }
}
