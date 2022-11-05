using UnityEngine;

public class SecretDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnim;
    [SerializeField] private GameObject lever;
    [SerializeField] private AudioSource doorSound;

    public bool isOpen;

    private void Start()
    {
        doorAnim.SetBool("Close", true);
    }

    private void Update()
    {

    }
}
