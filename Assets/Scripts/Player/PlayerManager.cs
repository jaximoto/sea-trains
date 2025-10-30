using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    Collider coll;

    public Camera cam;

    //first person camera movement

    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll = rb.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
