using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickableTags { NPC, Egg, Ball, Fruit}

[System.Serializable]
public class HandSystem
{
    [Header("Pickable Parameters")]
    [SerializeField] GameObject _myHand;
    [SerializeField] float _throwForce = 20f;
    [SerializeField] float _plantDistance = 1f;
    [SerializeField] float _pickSpeedThrushold = 2f;
    [SerializeField] float _petTime = 1f;

    public DetectorSystem _detector;
    public bool _gotSomething;
    public bool _canPick;
    public bool _canDrop;
    public bool _canThrow;
    public bool _canPlant;
    public bool _canPet;

    //Private Data
    public Pickable _objectInHand = new();
    float _nearObjectDistance;
    IHandController _myController;


    //Outside Interface
    public void Initialize(DetectorSystem detector, IHandController _controller)
    {
        _detector = detector;
        _nearObjectDistance = _detector._nearObjectDistance;
        _myController = _controller;
    }
    public void Update()
    { 
        if(_objectInHand == null)
        {
            _canPick = _detector.GetPickables().Count > 0;
            _canThrow = false;
            _gotSomething = false;
            _canPlant = false;
        }
        else
        {

            _canPick = false;
            _canDrop = true;
            _canThrow = true;
            _gotSomething = true;
        }

        _canPet = (_detector._npcDetectionStatus == DetectionStatus.VeryNear) && (_objectInHand == null);
    }


    public void PickObject()
    {
        if ((_detector.GetPickables().Count > 0) ) 
        {
            if ((_detector.GetPickables()[0].GetSpeed() <= _pickSpeedThrushold))
            {
                _objectInHand = _detector.GetPickables()[0];
                _objectInHand.Pick(this);

                _canPick = false;
                _canDrop = true;
                _canThrow = true;
                _gotSomething = true;

                if (_objectInHand?.GetType() == typeof(Egg))
                {
                    _canPlant = true;
                }
                else
                {
                    _canPlant = false;
                }
            }
        }
    }
    public void PetObject()
    {
        Transform _petObject = _detector.GetPickables()[0].transform;

        ConditionChecker condition = new ConditionChecker(true);
        _myController.StartCoroutine_Custom(UpdatePetCondition(condition));

        UIController.uIController.RepeatMessage("Petting", _petObject, _petTime, 5f, condition);

        if ((_detector.GetPickables().Count > 0))
        {
            if ((_detector.GetPickables()[0].GetSpeed() <= _pickSpeedThrushold))
            {
                _objectInHand = _detector.GetPickables()[0];
                _myController.GetBody().isKinematic = true;
                ((NPC)_objectInHand).StartPetting();

                _canPick = false;
                _canDrop = true;
                _canThrow = true;
                _gotSomething = true;

                _myController.StartCoroutine_Custom(PetObjectRoutine(condition));
            }
        }
    }
    public void DropObject()
    {
        _canDrop = false;
        _canThrow = false;

        if(_objectInHand != null)
            _objectInHand.Drop();

        _objectInHand = null;
    }
    public void ThrowObject(Vector3 target)
    {
        if(_objectInHand != null)
        {
            //Because Drop function removes the reference
            var _tempReference = _objectInHand;

            DropObject();

            Vector3 _direction = (target - _tempReference.transform.position).normalized;

            _tempReference.GetComponent<Rigidbody>().AddForce(_direction * _throwForce, ForceMode.Impulse);
        }
    }
    public void PlantObject()
    {
        Egg egg = (Egg)(_objectInHand);

        DropObject();

        Vector3 _direction = (Vector3.down + _myController.GetBody().transform.forward).normalized;
        RaycastHit ray;
        Physics.Raycast(_myHand.transform.position, _direction, out ray, 50, GroundDetector.GetGroundLayer());
        egg.Plant(ray.point);
    }
    public Pickable ObjectInHand()
    {
        return _objectInHand;
    }
    public Transform GetHand()
    {
        return _myHand.transform;
    }

   
    //Internal Algorithms
    IEnumerator PetObjectRoutine(ConditionChecker condition)
    {
        while (condition.isTrue)
        {
            Debug.Log("Petting");

            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }

        ((NPC)_objectInHand).EndPetting();
        _myController.GetBody().isKinematic = false;
        DropObject();
    }
    IEnumerator UpdatePetCondition(ConditionChecker condition)
    {
        bool isConditionTrue = true;
        float _time = 0;

        while (isConditionTrue)
        {
            condition.Update(true);

            isConditionTrue = (_time <= _petTime);

            _time += Time.fixedDeltaTime;
            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }

        condition.Update(false);
    }
}


public interface IHandController
{
    public Rigidbody GetBody();
    public void StartCoroutine_Custom(IEnumerator routine);
}