using UnityEngine;

public class FlashButton : MonoBehaviour
{
    public AudioSource beepLoop;
    public HandFlashRay handController; 
    public Targets targets; 
    bool solved = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beepLoop.loop = true; 
        beepLoop.Stop(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartBeeping()
    {
        if (!beepLoop.isPlaying) beepLoop.Play();
    }

    public void OnHit()
    {
        if (solved) return; 
        solved = true;
        beepLoop.Stop();
        handController.SetRayGunMode(); 
        targets.StartTargets();
    }
}
