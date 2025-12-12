using UnityEngine;

public class BoxCelebration : MonoBehaviour
{
    public Renderer[] boxRend;
    public Color winColor = Color.green;
    public bool useEmission = true; 
    public float emission = 5f; 
    public ParticleSystem[] confetti;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerCelebration()
    {
        LightGreen();
        PlayConfetti();
    }

    void LightGreen()
    {
        foreach (Renderer rend in boxRend) {
            Material mat = rend.material;
            if (mat.HasProperty("_Color")) {
                mat.SetColor("_Color", winColor);
            }

            if (mat.HasProperty("_EmissionColor")) {
                Color emissionColor = winColor * emission;
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", emissionColor);
            }
        }
    }

    void PlayConfetti() {
        foreach (ParticleSystem ps in confetti) {
            if (ps != null) ps.Play();
        }
    }
}
