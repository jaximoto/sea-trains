using UnityEngine;

public class TrainEngine : MonoBehaviour
{
    //Get splines. Attach a spline. Follow Spline.
    //Brake, Go
    public GameObject BrakeLever, GearLever;

    float boilerPressure, boilerLevel, fuelLevel;
    

    enum gear
    {
        brake,
        forward,
        backward
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PullBrake()
    {

    }

    void SetGear()
    {

    }
    
    
    //player function, define behavior on interactables and an interact key on actionmap
    void Interact()
    {

    }
}
