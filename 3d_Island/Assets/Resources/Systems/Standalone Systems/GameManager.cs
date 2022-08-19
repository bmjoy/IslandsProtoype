using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;


public enum CustomizingState { Detecting, Moving }

public class GameManager : MonoBehaviour, IInputUser
{
    [SerializeField] bool lockFrameRate = false;
    [SerializeField] int frameRatelock = 60;

    [Header("References")]
    [SerializeField] Volume volume;

    [Header("Game Design")]
    [SerializeField] bool showFrameRate;
    [SerializeField] PlayerSystem myPlayer;
    [SerializeField] GameObject eggAsset;
    [SerializeField] GameObject ballAsset;
    [SerializeField] NPC npcAsset;

    [Header("Save Keys")]
    public static string growTime_saveString = "growTime";
    public static string boredTime_saveString = "boredTime";
    public static string sleepTime_saveString = "sleepTime";
    public static string seekPlayerProb_saveString = "seekPlayer";
    public static string seekNpcProb_saveString = "seekNpc";
    public static string seekTreeProb_saveString = "seekTree";
    public static string seekBallProb_saveString = "seekBall";
    public static string dropBallProb_saveString = "dropBall";
    public static string throwBallOnPlayerProb_saveString = "throwBallPlayer";
    public static string throwBallOnNpcProb_saveString = "throwBallNPC";
    public static string punchNpcProb_saveString = "punchNPC";
    public static string seekFruit_saveString = "seekFruit";
    public static string seekAlter_saveString = "seekAlter";
    public static string deathTime_saveString = "deathTime";


    public static GameManager instance;
    
    CustomizingState customizingState = CustomizingState.Detecting;
    bool customizing = false;
    CustomizableObject lastdetected;
    Vector3 camCustomizingViewPos;
    Quaternion camCustomizingViewRot;
    DepthOfField depthOfField;
    

    void Start()
    {
        instance = this;

        InputSystem.SubscribeUser(this);

        if (lockFrameRate)
            Application.targetFrameRate = frameRatelock;
        else
            Application.targetFrameRate = 0;

        if (myPlayer == null)
            FindObjectOfType<PlayerSystem>();

        if (!showFrameRate)
            UIController.instance.UpdateFrameRate("");

        camCustomizingViewPos = Camera.main.transform.position;
        camCustomizingViewRot = Camera.main.transform.rotation;
        
        LoadSettings();

        StartCoroutine(UpdateFrameRate());

        VolumeProfile profile = volume.sharedProfile;
        depthOfField = (DepthOfField)(profile.components[2]);
        depthOfField.focusDistance.value = 0f;
    }
    IEnumerator UpdateFrameRate()
    {
        while(true)
        {
            if (showFrameRate)
                UIController.instance.UpdateFrameRate(((int)(1f / Time.deltaTime)).ToString());
            else
                UIController.instance.UpdateFrameRate("");

            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime * 10f);
        }
    }
    RaycastHit CastFromMouse()
    {
        RaycastHit _hit;

        Vector2 _mouse2D = InputSystem.GetMousePosition();
        Vector3 _mousePosition = new(_mouse2D.x, _mouse2D.y, 2f);

        Ray _ray = Camera.main.ScreenPointToRay(_mousePosition, Camera.MonoOrStereoscopicEye.Mono);

        Physics.Raycast(_ray, out _hit);

        return _hit;
    }



    //Settings
    public void SetCustomizing(bool state)
    {
        customizing = state;

        if(state)
            depthOfField.focusDistance.value = 10f;
        else
            depthOfField.focusDistance.value = 0f;

    }
    public void SetPlaying(bool state)
    {

        if (state)
        {
            myPlayer.gameObject.SetActive(true);

            depthOfField.focusDistance.value = 10f;
        }
        else
        {
            myPlayer.gameObject.SetActive(false);

            Camera.main.transform.position = camCustomizingViewPos;
            Camera.main.transform.rotation = camCustomizingViewRot;

            depthOfField.focusDistance.value = 0f;
        }
    }

    public void ApplySettings()
    {
        var _npcs = FindObjectsOfType<NPC>();
        List<NPC> npcList = new List<NPC>();
      
        foreach (NPC npc in _npcs)
        {
            npcList.Add(npc);
        }

        //Change NPC asset first
        foreach (SliderElement slider in UIController.instance.GetSliders())
        {
            if (slider.saveName == growTime_saveString)
                npcAsset.growTime = slider.mySlider.value;
            else if (slider.saveName == boredTime_saveString)
                npcAsset.boredTime = slider.mySlider.value;
            else if (slider.saveName == sleepTime_saveString)
                npcAsset.sleepTime = slider.mySlider.value;
            else if (slider.saveName == seekNpcProb_saveString)
                npcAsset.seekNpcProb = slider.mySlider.value;
            else if (slider.saveName == seekPlayerProb_saveString)
                npcAsset.seekPlayerProb = slider.mySlider.value;
            else if (slider.saveName == seekBallProb_saveString)
                npcAsset.seekBallProb = slider.mySlider.value;
            else if (slider.saveName == seekTreeProb_saveString)
                npcAsset.seekTreeProb = slider.mySlider.value;
            else if (slider.saveName == dropBallProb_saveString)
                npcAsset.dropBallProb = slider.mySlider.value;
            else if (slider.saveName == throwBallOnNpcProb_saveString)
                npcAsset.throwBallOnNpcProb = slider.mySlider.value;
            else if (slider.saveName == throwBallOnPlayerProb_saveString)
                npcAsset.throwBallOnPlayerProb = slider.mySlider.value;
            else if (slider.saveName == punchNpcProb_saveString)
                npcAsset.punchNpcProb = slider.mySlider.value;
            else if (slider.saveName == seekFruit_saveString)
                npcAsset.seekFruitProb = slider.mySlider.value;
            else if (slider.saveName == seekAlter_saveString)
                npcAsset.seekAlterProb = slider.mySlider.value;
            else if (slider.saveName == deathTime_saveString)
                npcAsset.deathTime = slider.mySlider.value;
        }

        //then change the rest to its values (for optimization)
        foreach (NPC npc in npcList)
        {
            npc.growTime = npcAsset.growTime;
            npc.boredTime = npcAsset.boredTime;
            npc.sleepTime = npcAsset.sleepTime;
            npc.seekPlayerProb = npcAsset.seekPlayerProb;
            npc.seekNpcProb = npcAsset.seekNpcProb;
            npc.seekBallProb = npcAsset.seekBallProb;
            npc.seekTreeProb = npcAsset.seekTreeProb;
            npc.dropBallProb = npcAsset.dropBallProb;
            npc.throwBallOnNpcProb = npcAsset.throwBallOnNpcProb;
            npc.throwBallOnPlayerProb = npcAsset.throwBallOnPlayerProb;
            npc.punchNpcProb = npcAsset.punchNpcProb;
            npc.seekFruitProb = npcAsset.seekFruitProb;
            npc.seekAlterProb = npcAsset.seekAlterProb;
            npc.deathTime = npcAsset.deathTime;
        }

        SaveSettings();
    }
    public void LoadSettings()
    {
        foreach (SliderElement slider in UIController.instance.GetSliders())
            slider.mySlider.value = PlayerPrefs.GetFloat(slider.saveName);

        ApplySettings();
    }
    public void SaveSettings()
    {
        foreach (SliderElement slider in UIController.instance.GetSliders())
            PlayerPrefs.SetFloat(slider.saveName, slider.mySlider.value);
    }
    
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }



    //for design Buttons
    public void SpawnBall()
    {
        Instantiate(ballAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public void SpawnEgg()
    {
        Instantiate(eggAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }



    //Input Interface
    public void PressInput()
    {
        if (customizing)
        {
            if ((customizingState == CustomizingState.Detecting))
            {
                RaycastHit _hit = CastFromMouse();

                if (_hit.collider.GetComponentInParent<CustomizableObject>())
                {
                    lastdetected = _hit.collider.GetComponentInParent<CustomizableObject>();

                    customizingState = CustomizingState.Moving;

                    UIController.instance.CustomizeLog("Selected object: " + lastdetected.name, Color.yellow);
                }
                else
                {
                    UIController.instance.CustomizeLog("No Object Detected", Color.white);
                }
            }
            else if (customizingState == CustomizingState.Moving)
            {
                RaycastHit _hit = CastFromMouse();

                if (_hit.collider.gameObject.CompareTag("Ground"))
                {
                    lastdetected.transform.position = _hit.point;
                    customizingState = CustomizingState.Detecting;

                    UIController.instance.CustomizeLog("", Color.white);
                }
                else
                {
                    customizingState = CustomizingState.Detecting;
                    PressInput();
                }
            }
        }
    }
    public void PetInput() { }
    public void DashInput() { }
    public void PlantInput() { }
    public void ThrowInput() { }
    public void JumpInput() { }
    public void PickInput() { }
    public void MoveInput(Vector2 _movementInput) { }
    public void RotateInput(Vector2 _deltaRotate) { }
}
