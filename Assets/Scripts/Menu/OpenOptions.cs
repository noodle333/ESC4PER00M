using UnityEngine;

public class OpenOptions : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;

    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }
}
