using Meta.XR.MRUtilityKit.SceneDecorator;
using UnityEngine;

public class SoundTarget : MonoBehaviour
{
    public AudioSource beep;
    public Targets targets; 
    bool active = false; 

    public void SetActive(bool value)
    {
        active = value;

        if (beep != null)
        {
            if (active && !beep.isPlaying) beep.Play();
            if (!active && beep.isPlaying) beep.Stop();
        }
    }

    public void OnHit()
    {
        if (!active) return;
        SetActive(false);
        gameObject.SetActive(false);
        targets.OnTargetHit(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
