using UnityEngine;

public class HoldObject : MonoBehaviour
{
    public bool picked;
    [SerializeField] private float pickedSpeed;

    private Vector3 pickVelocity;
    public GameObject pickedObject;

    [SerializeField] private Transform pickPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
