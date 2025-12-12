using UnityEngine;
using System.Collections;
using NUnit.Framework.Constraints;

public class InvisibleButton : MonoBehaviour
{
    private bool pressed = false;
    private Renderer rend;
    public Renderer childRend;
    public ParticleSystem ps;
    public AudioSource beep;
    public AudioSource confettiSFX;
    public GameObject hint;
    public GameObject threeButtons;

    public AudioSource leftSFX;
    public AudioSource centerSFX;
    public AudioSource rightSFX;
    public float timeBetweenSounds = 1f;  // how long to wait between each sound
    public float loopDelay = 3f;           // delay before restarting the whole sequence
    private Coroutine sound; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
        childRend = transform.GetChild(0).GetComponent<Renderer>();
        childRend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pressed) return;

        if (other.CompareTag("Hand"))
        {
            OnFirstPress();
        }
    }

    void OnFirstPress()
    {
        pressed = true;
        hint.SetActive(false);
        rend.enabled = true;
        childRend.enabled = true;
        beep.loop = false;
        threeButtons.SetActive(true);
        ps.Play();
        confettiSFX.Play();

        sound = StartCoroutine(PlayDirectionalSequence());
    }

    private IEnumerator PlayDirectionalSequence()
    {
        while (true)
        {
            // Wait before looping again
            yield return new WaitForSeconds(loopDelay);

            // Left
            leftSFX.Play();
            yield return new WaitForSeconds(timeBetweenSounds);

            // Right
            rightSFX.Play();
            yield return new WaitForSeconds(timeBetweenSounds);

            // Center
            centerSFX.Play();
        }
    }

    public void StopDirectionalSequence()
    {
        if (sound != null)
        {
            StopCoroutine(sound);
            sound = null;
        }

        if (beep != null)      beep.Stop();
        if (leftSFX != null)   leftSFX.Stop();
        if (centerSFX != null) centerSFX.Stop();
        if (rightSFX != null)  rightSFX.Stop();
    }
}
