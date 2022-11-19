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

    private void FixedUpdate()
    {
        Vector3 origin = playerController.playerCamera.transform.position;
        Vector3 dir = playerController.playerCamera.transform.forward;

        RaycastHit hit;
        Ray forwardRay = new Ray(origin, dir);

        if (Physics.Raycast(forwardRay, out hit, Vector3.Distance(Camera.main.transform.position, flashPos.transform.position)))
        {
            if (hit.transform.tag == "Hidden" && playerFlashlight.on)
            {
                hitObj = hit.transform.gameObject;
                hitObj.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                if (hitObj != null)
                {
                    hitObj.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }

        Debug.DrawLine(transform.position, hit.point, Color.red);
    }
}
