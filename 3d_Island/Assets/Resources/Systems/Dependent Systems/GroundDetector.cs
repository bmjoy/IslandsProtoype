using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroundDetector
{
    [SerializeField] LayerMask detectableLayers;
    [SerializeField] string groundTag = "Ground";
    [SerializeField] string waterTag = "Water";
    [SerializeField] float onGroundThreshold = 1.3f;

    public static LayerMask detectablelayers;
    
    public void Initialize()
    {
        detectablelayers = detectableLayers;
    }
    public static LayerMask GetGroundLayer()
    {
        return detectablelayers;
    }
    public bool IsOnGroud(Rigidbody body)
    {
        return DetectGround(body, groundTag);
    }
    public bool IsOnWater(Rigidbody body)
    {
        return DetectGround(body, waterTag);
    }
    public void SetThreshold(float thrus)
    {
        onGroundThreshold = thrus;
    }
    public float DistanceFromGround(Rigidbody body)
    {
        RaycastHit ray;

        Physics.Raycast(body.transform.position + Vector3.up, Vector2.down, out ray, 50f, detectableLayers);

        if (ray.collider.tag == groundTag)
        {
            return (body.transform.position - ray.point).magnitude;
        }
        else
        {
            return -1f;
        }
    }
    bool DetectGround(Rigidbody body, string tag)
    {
        if (body.isKinematic == false)
        {
            RaycastHit ray = RayCaster(body);

            if ((ray.point.magnitude > 0) && (ray.collider.tag == tag))
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }
    public RaycastHit RayCaster(Rigidbody body)
    {
        RaycastHit ray;
        Physics.Raycast(body.transform.position + Vector3.up, Vector2.down, out ray, onGroundThreshold, detectableLayers);
        return ray;
    }


}
