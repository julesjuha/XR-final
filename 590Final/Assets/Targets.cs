using UnityEngine;

public class Targets : MonoBehaviour
{
    // public SoundTarget[] targetScripts; 
    public GameObject[] targets; 
    public BoxCelebration boxCelebration; 
    int curr = -1; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTargets()
    {
        curr = 0;
        ActivateCurrentTarget();
    }
    
    void ActivateCurrentTarget()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            bool isCurrent = i == curr;

            targets[i].SetActive(isCurrent);
        
            var st = targets[i].GetComponent<SoundTarget>();
            if (st != null) st.SetActive(isCurrent);
        }
    }

    public void OnTargetHit(GameObject target)
    {
        if (curr < 0 || curr >= targets.Length) return;
        if (targets[curr] != target) return;

        curr++;

        if (curr >= targets.Length)
        {
            if (boxCelebration != null)
                boxCelebration.TriggerCelebration();
        }
        else
        {
            ActivateCurrentTarget();
        }
    }
}
