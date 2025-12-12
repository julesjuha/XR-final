using UnityEngine;

public class PuzzleRayGun : MonoBehaviour
{
    public OVRInput.RawButton shootingButton = OVRInput.RawButton.RIndexTrigger;
    public Transform shootingPoint;
    public float maxLineDistance = 10f;
    public float lineShowTime = 0.2f;
    public LineRenderer linePrefab;
    public GameObject rayImpactPrefab;
    public AudioSource source;
    public AudioClip shootingAudioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingButton))
            Shoot();
    }

    void Shoot()
    {
        source.PlayOneShot(shootingAudioClip);

        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDistance);

        Vector3 endPoint = Vector3.zero; 
        if (hasHit)
        {
            endPoint = hit.point; 

            Quaternion rayImpactRotation = Quaternion.LookRotation(-hit.normal);
            GameObject rayImpact = Instantiate(rayImpactPrefab, hit.point, rayImpactRotation);
            Destroy(rayImpact, 1);

            if (hit.collider.CompareTag("Target"))
            {
                var target = hit.collider.GetComponent<SoundTarget>();
                if (target == null) target = hit.collider.GetComponentInParent<SoundTarget>();
                if (target != null) target.OnHit();
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

        Destroy(line.gameObject, lineShowTime); 
    }
}
