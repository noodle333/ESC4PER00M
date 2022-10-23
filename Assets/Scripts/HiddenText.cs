using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenText : MonoBehaviour
{
    private Flashlight playerFlashlight;
    private FPSController playerController;
    private GameObject hitObj;

    [SerializeField] private Transform flashPos;

    private void Start()
    {
        playerFlashlight = GetComponent<Flashlight>();
        playerController = GetComponent<FPSController>();
    }

    private void Update()
    {
        Vector3 origin = playerController.playerCamera.transform.position;
        Vector3 dir = playerController.playerCamera.transform.forward;

        RaycastHit hit;
        Ray forwardRay = new Ray(origin, dir);

        if (Physics.Raycast(forwardRay, out hit, Vector3.Distance(Camera.main.transform.position, flashPos.transform.position)))
        {
            // Debug.Log("HIT");
            if (hit.transform.tag == "Hidden" && playerFlashlight.on)
            {
                // Debug.Log("SHOW TEXT");
                hitObj = hit.transform.gameObject;
                hitObj.GetComponent<MeshRenderer>().enabled = true;
            }
            else if (playerFlashlight.off)
            {
                if (hitObj != null)
                {
                    hitObj.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        else
        {
            // Debug.Log("HIDE TEXT");
            if (hitObj != null)
            {
                hitObj.GetComponent<MeshRenderer>().enabled = false;
            }
        }

    }
}
