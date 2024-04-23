using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody sphereRB;
    public Rigidbody carRB;
    [SerializeField] BoxCollider carBC;

    [Header("visuals")]
    [SerializeField] GameObject hitEffectPrefab;
    [SerializeField] GameObject brakeBox;


    [Header("speed and turning")]
    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;
    public LayerMask groundLayer;
    
    [HideInInspector] public float carSpeed;
    private float moveInput;
    private float turnInput;
    private bool isCarGrounded;


    [Header("drag + physics")]
    public float modifiedDrag;
    public float alignToGroundTime;
    private float normalDrag;
    private bool isBraking;


    void Start()
    {
        // Detach Sphere from car
        sphereRB.transform.parent = null;
        carRB.transform.parent = null;
        
        normalDrag = sphereRB.drag;
    }

    void Update()
    {
        // Get Input
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        // Calculate Turning Rotation
        float newRot = turnInput * turnSpeed * Time.deltaTime * moveInput;

        if (isCarGrounded)
            transform.Rotate(0, newRot, 0, Space.World);

        // Set Cars Position to Our Sphere
        transform.position = sphereRB.transform.position;

        // Raycast to the ground and get normal to align car with it.
        RaycastHit hit;
        isCarGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundLayer);

        // Rotate Car to align with ground
        Quaternion toRotateTo = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotateTo, alignToGroundTime * Time.deltaTime);

        // Calculate Movement Direction
        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        // Calculate Drag
        sphereRB.drag = isCarGrounded ? normalDrag : modifiedDrag;

        carSpeed = Mathf.Abs(moveInput/4f);
    }

    //add force if car is grounded
    private void FixedUpdate()
    {
        //move if on ground
        if (isCarGrounded)
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration); // Add Movement
        else
            sphereRB.AddForce(transform.up * -200f); // Add Gravity

        carRB.MoveRotation(transform.rotation); // Move Car to match sphere

        //when braking, disable brake box asset
        if (moveInput > 0 || moveInput < 0)
        {
            brakeBox.SetActive(false);
        }
        else
        {
            brakeBox.SetActive(true);
        }
    }
}