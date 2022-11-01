using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private CharacterController player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("TP");
            player.enabled = false;
            player.transform.position = target.position;
            player.enabled = true;
        }
    }
}
