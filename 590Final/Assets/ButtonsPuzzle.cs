using UnityEngine;

public class ButtonsPuzzle : MonoBehaviour
{
    public int[] correct = {0, 2, 1}; 
    int progress = 0; 
    public DirectionButton[] buttons;
    public BoxCelebration boxCelebration; 
    public GameObject hint; 
    public InvisibleButton invisibleButton; 
    public HandFlashRay handController;
    public FlashButton flashButton; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(int directionIndex) {
        if (directionIndex == correct[progress]) {
            progress++;
            buttons[directionIndex].TurnGreen(); 
            if (progress >= correct.Length) {
                PuzzleSolved();
            }
            buttons[directionIndex].pressed = false; 
        } else {
            buttons[directionIndex].pressed = false; 
            ResetProgress();
        }
    }

    void ResetProgress()
    {
        progress = 0;
        foreach (var b in buttons) {
            if (b != null) b.ResetColor();
        }
    }

    void PuzzleSolved() {
        hint.SetActive(false); 
        invisibleButton.StopDirectionalSequence(); 
        handController.SetFlashlightMode();
        flashButton.StartBeeping(); 
        //boxCelebration.TriggerCelebration();
    }
}
