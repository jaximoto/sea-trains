using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public InputActionReference move;
    public InputActionReference jump;
    bool takingInputs = true;

    bool grounded;
    bool jumpLoaded, jumpPressed;
    public float playerGroundAcceleration, playerAirAcceleration;
    public float playerGroundMaxVelocity, playerAirMaxVelocity;

    Vector2 moveDir;

    Rigidbody rb;
    Collider coll;

    LayerMask layerMask;

    public bool jumpHeld, jumpHeldMax;
    public float jumpStrength;

    public struct InputBuffer
    {
         
    };
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        Debug.Log($"{rb} is rb & {coll} is coll");

        layerMask = LayerMask.GetMask("Default");
    }
    void GatherInputs()
    {
        if (takingInputs)
        {
            moveDir = move.action.ReadValue<Vector2>();
            //if(moveDir != Vector2.zero) Debug.Log("movedir = " + moveDir);
            if (jumpLoaded && jump.action.IsPressed())
            {
                jumpPressed = true;
            }
        }
    }

    void CheckGround()
    {
        Debug.DrawRay(rb.transform.position, Vector3.down * rb.transform.localScale.x, Color.blue);
        if (Physics.Raycast(rb.transform.position, Vector3.down, rb.transform.localScale.x * 1.25f, layerMask))
        {
            Debug.Log("grounded");
            grounded = true;
        }
        else grounded = false;
    }

    void UpdateMovement()
    {
        
        CheckGround();
        //stupid
        if (grounded && jumpPressed)
        {
            Debug.Log("we jump");
            jumpStrength = 200;
            jumpLoaded = false;
            jumpPressed = false;
        }
        else 
        {
            jumpStrength = 0;
            jumpLoaded = true;
        }

            //add some smoothing sometime
        float Acceleration = grounded ? playerGroundAcceleration :  playerAirAcceleration;
        Vector3 movement = new Vector3(moveDir.x * Acceleration * Time.deltaTime, jumpStrength * Time.deltaTime, moveDir.y * Acceleration * Time.deltaTime);
        rb.linearVelocity += movement;
        //if(rb.linearVelocity != Vector3.zero) Debug.Log($"player linear velocity is = {rb.linearVelocity}") ;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GatherInputs();
        UpdateMovement();
    }
}
