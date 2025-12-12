using UnityEngine;

public class DirectionButton : MonoBehaviour
{
    public int directionIndex;

    public bool pressed = false; 
    public ButtonsPuzzle puzzle;
    private Color defaultColor = Color.red;
    public Renderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultColor = rend.material.GetColor("_EmissionColor"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other) {
        if (pressed) return;

        if (other.CompareTag("Hand"))
        {
            pressed = true; 
            puzzle.OnButtonPressed(directionIndex);
        }
    }

    public void ResetColor() {
        if (rend.material.HasProperty("_EmissionColor")) 
        {
            Color emissionColor = defaultColor;
            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", emissionColor);
        }
        rend.material.SetColor("_Color", defaultColor);
    }

    public void TurnGreen() {
        if (rend.material.HasProperty("_EmissionColor")) 
        {
            Color emissionColor = Color.green * 3;
            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", emissionColor);
        }
        rend.material.SetColor("_Color", Color.green);
    }

}
