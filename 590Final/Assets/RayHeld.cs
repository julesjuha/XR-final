using UnityEngine;

public class RayHeld : MonoBehaviour
{
    public HandFlashRay handController;
    public float grabThreshold = 0.5f;
    bool pickedUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (pickedUp) return;

        PickUp();
    }

    void PickUp()
    {
        pickedUp = true;
        handController.SetRayGunMode();
        gameObject.SetActive(false); 
    }
}
