using UnityEngine;

public class Note : MonoBehaviour
{
    //INCASE OF UI AND SHOW INVENTORY DISABLE HUD AND INV
    [SerializeField] private GameObject noteObj;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject inv;

    public void Exit()
    {
        noteObj.SetActive(false);
        inv.SetActive(true);
        hud.SetActive(true);
        player.GetComponent<FPSController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (noteObj.activeInHierarchy)
        {
            hud.SetActive(false);
            inv.SetActive(false);
            player.GetComponent<FPSController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
