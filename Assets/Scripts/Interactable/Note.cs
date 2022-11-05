using UnityEngine;

public class Note : MonoBehaviour
{
    //INCASE OF UI AND SHOW INVENTORY DISABLE HUD AND INV
    [SerializeField] private GameObject noteObj;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject inv;
    [SerializeField] private GameObject flashlight;

    private void Exit()
    {
        noteObj.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        flashlight.SetActive(true);
        player.GetComponent<FPSController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Flip()
    {
        noteObj.transform.localScale = new Vector3(noteObj.transform.localScale.x, -noteObj.transform.localScale.y, noteObj.transform.localScale.z);
    }

    private void Update()
    {
        if (noteObj.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            flashlight.SetActive(false);
            player.GetComponent<FPSController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Exit();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Flip();
        }
    }
}
