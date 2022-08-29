using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GroundTag { Ground, Farm}

public abstract class Plantable : Pickable
{
    [SerializeField] public float plantTime = 10;
    [SerializeField] public float plantDistance = 1f;
    [SerializeField] List<GroundTag> allowedToPlantOn = new();
    
    protected float plantedSince = 0f;
    protected bool planted = false;


    public override void Pick(HandSystem _picker)
    {
        base.Pick(_picker);

        if (planted)
            CancelPlant();
    }
    public void Plant(Vector3 _plantLocation)
    {
        isPicked = false;
        planted = true;
        myBody.isKinematic = true;
        myBody.transform.rotation = Quaternion.identity;
        transform.position = _plantLocation;

        StartCoroutine(Planting());
    }
    protected virtual void CancelPlant()
    {
        plantedSince = 0;
        planted = false;

        UIController.instance.DestroyProgressBar(this.gameObject);
        StopCoroutine(Planting());
    }
    protected IEnumerator Planting()
    {
        UIController.instance.CreateProgressBar(this.gameObject, new Vector2(0f, plantTime), this.transform);

        while ((plantedSince < plantTime) && !isPicked)
        {
            plantedSince += Time.fixedDeltaTime;
            UIController.instance.UpdateProgressBar(this.gameObject, plantedSince);

            PlantingUpdate();

            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }

        if (!isPicked && (plantedSince >= plantTime))
        {
            UIController.instance.DestroyProgressBar(this.gameObject);
            OnPlantDone();
        }
    }
    protected IEnumerator DestroyMe(float _delay)
    {
        yield return new WaitForSecondsRealtime(_delay);
        Destroy(this.gameObject);
    }


    public bool IsOnPlatingGround(Vector3 _position)
    {
        RaycastHit _hit;

        Physics.Raycast(_position, Vector3.down, out _hit);

        if (_hit.collider)
            foreach (GroundTag _tag in allowedToPlantOn)
                if (_hit.collider.tag == _tag.ToString())
                    return true;

        return false;
    }
    protected abstract void OnPlantDone(); 
    protected abstract void PlantingUpdate(); //update while planting
}
