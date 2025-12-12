using UnityEngine;

public class FlashlightRay : MonoBehaviour
{
    // public OVRInput.RawAxis1D flashlightAxis = OVRInput.RawAxis1D.RHandTrigger;
    public float onThreshold = 0.1f;
    public Transform shootingPoint;
    public float maxLineDistance = 8f;
    public float lineShowTimer = 0.05f;

    public LineRenderer linePrefab;
    public OVRInput.RawButton lightButton = OVRInput.RawButton.RHandTrigger; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // line.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(lightButton)) 
        {
            CastLight();
        }
    }
    
    void CastLight()
    {
        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward); 
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDistance);
        Vector3 endPoint;

        if (hasHit)
        {
            endPoint = hit.point;

            if (hit.collider.CompareTag("FlashButton"))
            {
                var flashButton = hit.collider.GetComponent<FlashButton>();
                if (flashButton == null) flashButton = hit.collider.GetComponentInParent<FlashButton>();
                flashButton.OnHit();
            }
        }
        else
        {
            endPoint = shootingPoint.position + shootingPoint.forward * maxLineDistance; 
        }
        LineRenderer line = Instantiate(linePrefab); 
        line.positionCount = 2;
        line.SetPosition(0, shootingPoint.position); 

        line.SetPosition(1, endPoint);

        Destroy(line.gameObject, lineShowTimer); 
    }
}
