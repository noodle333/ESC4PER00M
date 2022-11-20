using UnityEngine;

public class ReadNote : MonoBehaviour
{
    [SerializeField] private GameObject noteObj;
    [SerializeField] private GameObject noteText;
    [SerializeField] private AudioSource noteAudio;
    public bool inReach;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inReach = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            noteText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            noteText.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown("e") && player.GetComponent<CharacterController>().isGrounded)
        {
            noteAudio.Play();
            noteObj.SetActive(true);
        }
    }
}
