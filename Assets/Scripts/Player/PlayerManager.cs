using UnityEngine;
using Unity.Cinemachine;
public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    Collider coll;

    public CinemachineCamera cam;
    //first person camera movement

    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        coll = rb.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        SyncCam();
    }

    void SyncCam()
    {
        Debug.Log($"transform.rotation.y = {transform.rotation.y}, cam.transform.rotation.y = {cam.transform.rotation.y}");
        transform.rotation = Quaternion.AngleAxis(cam.transform.eulerAngles.y, Vector3.up);
    }
}
