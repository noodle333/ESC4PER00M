using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;


    [HideInInspector]
    public bool canMove = true;

    //HOLDING IEMS
    [Header("Holding Items")]
    public bool picked;
    [SerializeField] private float pickedSpeed;

    private Vector3 pickVelocity;
    public GameObject pickedObject;

    [SerializeField] private Transform pickPos;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //HOLD ITEMS
        Vector3 origin = playerCamera.transform.position;
        Vector3 dir = playerCamera.transform.forward;

        RaycastHit hit;
        Ray forwardRay = new Ray(origin, dir);

        if (Physics.Raycast(forwardRay, out hit, Vector3.Distance(Camera.main.transform.position, pickPos.transform.position)))
        {
            if (hit.transform.tag == "Pickable")
            {
                pickedObject = hit.transform.gameObject;
                picked = true;
            }
            else
            {
                pickedObject = null;
                picked = false;
            }
        }

        if (Input.GetMouseButton(0) && picked && pickedObject != null)
        {
            Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;

            Vector3 toPos = pickPos.transform.position - pickedObject.transform.position;

            rb.velocity = toPos;
            rb.velocity *= pickedSpeed;

            if (Input.GetKey(KeyCode.R))
            {
                pickedObject.transform.rotation = Quaternion.identity;
            }
            else
            {
                pickedObject = null;
            }
        }

        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
