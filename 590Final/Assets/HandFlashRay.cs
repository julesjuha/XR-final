using UnityEngine;

public class HandFlashRay : MonoBehaviour
{
    public GameObject handModel;
    public GameObject flashlightModel;
    public GameObject rayGunModel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetHandMode()
    {
        handModel.SetActive(true);
        flashlightModel.SetActive(false);
        rayGunModel.SetActive(false);
    }

    public void SetFlashlightMode()
    {
        handModel.SetActive(false);
        flashlightModel.SetActive(true);
        rayGunModel.SetActive(false);
    }

    public void SetRayGunMode()
    {
        handModel.SetActive(false);
        flashlightModel.SetActive(false);
        rayGunModel.SetActive(true);
    }
}