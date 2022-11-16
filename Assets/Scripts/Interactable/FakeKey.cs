using UnityEngine;

public class FakeKey : MonoBehaviour
{
    [SerializeField] private GameObject keyObj;
    [SerializeField] private Animator door;
    [SerializeField] private GameObject[] floorsToBreak;
    [SerializeField] private GameObject pickupText;
    [SerializeField] private AudioSource doorSound;
    [SerializeField] private AudioSource floorSound;
    [SerializeField] private GameObject keyMesh;

    public bool inReach;
    public float timeRemaining = 1;
    private bool destroyFloor = false;


    private void Start()
    {
        inReach = false;
        pickupText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickupText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickupText.SetActive(false);
        }
    }

    private void Update()
    {
        if (inReach && Input.GetKeyDown(KeyCode.E))
        {
            keyMesh.SetActive(false);
            pickupText.SetActive(false);

            //CLOSE DOOR
            if (door.GetBool("Open"))
            {
                door.SetBool("Close", true);
                door.SetBool("Open", false);
                doorSound.Play();
            }
            destroyFloor = true;
        }

        if (destroyFloor)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                foreach (GameObject floor in floorsToBreak)
                {
                    floor.SetActive(false);
                    floorSound.Play();
                }
                keyObj.SetActive(false);
            }
        }
    }



}
