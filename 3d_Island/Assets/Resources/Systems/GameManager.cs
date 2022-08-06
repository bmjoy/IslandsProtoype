using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] bool _lockFrameRate = false;
    [SerializeField] int _frameRatelock = 60;
    [SerializeField] bool _startFrozen = true;

    [Header("Game Design")]
    [SerializeField] bool _showFrameRate;
    [SerializeField] PlayerSystem _myPlayer;
    [SerializeField] GameObject _eggAsset;
    [SerializeField] GameObject _ballAsset;
    [SerializeField] NPC _npcAsset;

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

    Vector3 _camCustomizingViewPos;
    Quaternion _camCustomizingViewRot;

    void Start()
    {
        instance = this;

        if(_startFrozen)
            Time.timeScale = 0f;

        if (_lockFrameRate)
            Application.targetFrameRate = _frameRatelock;
        else
            Application.targetFrameRate = 0;

        if (_myPlayer == null)
            FindObjectOfType<PlayerSystem>();

        if (!_showFrameRate)
            UIController.instance.UpdateFrameRate("");

        _camCustomizingViewPos = Camera.main.transform.position;
        _camCustomizingViewRot = Camera.main.transform.rotation;

        LoadSettings();
    }
    void Update()
    {
        if (_showFrameRate)
            UIController.instance.UpdateFrameRate((1f / Time.deltaTime).ToString());
    }

    //Settings
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
            if (slider._saveName == growTime_saveString)
                _npcAsset.growTime = slider._mySlider.value;
            else if (slider._saveName == boredTime_saveString)
                _npcAsset.boredTime = slider._mySlider.value;
            else if (slider._saveName == sleepTime_saveString)
                _npcAsset.sleepTime = slider._mySlider.value;
            else if (slider._saveName == seekNpcProb_saveString)
                _npcAsset.seekNpcProb = slider._mySlider.value;
            else if (slider._saveName == seekPlayerProb_saveString)
                _npcAsset.seekPlayerProb = slider._mySlider.value;
            else if (slider._saveName == seekBallProb_saveString)
                _npcAsset.seekBallProb = slider._mySlider.value;
            else if (slider._saveName == seekTreeProb_saveString)
                _npcAsset.seekTreeProb = slider._mySlider.value;
            else if (slider._saveName == dropBallProb_saveString)
                _npcAsset.dropBallProb = slider._mySlider.value;
            else if (slider._saveName == throwBallOnNpcProb_saveString)
                _npcAsset.throwBallOnNpcProb = slider._mySlider.value;
            else if (slider._saveName == throwBallOnPlayerProb_saveString)
                _npcAsset.throwBallOnPlayerProb = slider._mySlider.value;
            else if (slider._saveName == punchNpcProb_saveString)
                _npcAsset.punchNpcProb = slider._mySlider.value;
            else if (slider._saveName == seekFruit_saveString)
                _npcAsset.seekFruitProb = slider._mySlider.value;
            else if (slider._saveName == seekAlter_saveString)
                _npcAsset.seekAlterProb = slider._mySlider.value;
            else if (slider._saveName == deathTime_saveString)
                _npcAsset.deathTime = slider._mySlider.value;
        }

        //then change the rest to its values (for optimization)
        foreach (NPC npc in npcList)
        {
            npc.growTime = _npcAsset.growTime;
            npc.boredTime = _npcAsset.boredTime;
            npc.sleepTime = _npcAsset.sleepTime;
            npc.seekPlayerProb = _npcAsset.seekPlayerProb;
            npc.seekNpcProb = _npcAsset.seekNpcProb;
            npc.seekBallProb = _npcAsset.seekBallProb;
            npc.seekTreeProb = _npcAsset.seekTreeProb;
            npc.dropBallProb = _npcAsset.dropBallProb;
            npc.throwBallOnNpcProb = _npcAsset.throwBallOnNpcProb;
            npc.throwBallOnPlayerProb = _npcAsset.throwBallOnPlayerProb;
            npc.punchNpcProb = _npcAsset.punchNpcProb;
            npc.seekFruitProb = _npcAsset.seekFruitProb;
            npc.seekAlterProb = _npcAsset.seekAlterProb;
            npc.deathTime = _npcAsset.deathTime;
        }

        SaveSettings();
    }
    public void LoadSettings()
    {
        foreach (SliderElement slider in UIController.instance.GetSliders())
            slider._mySlider.value = PlayerPrefs.GetFloat(slider._saveName);

        ApplySettings();
    }
    public void SaveSettings()
    {
        foreach (SliderElement slider in UIController.instance.GetSliders())
            PlayerPrefs.SetFloat(slider._saveName, slider._mySlider.value);
    }
    public void SwitchMode_Game()
    {
        Time.timeScale = 1f;
        _myPlayer.gameObject.SetActive(true);
    }
    public void SwitchMove_MainScreen()
    {
        _myPlayer.gameObject.SetActive(false);

        Camera.main.transform.position = _camCustomizingViewPos;
        Camera.main.transform.rotation = _camCustomizingViewRot;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
    


    //for design Buttons
    public void SpawnBall()
    {
        Instantiate(_ballAsset.gameObject, _myPlayer.transform.position + _myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public void SpawnEgg()
    {
        Instantiate(_eggAsset.gameObject, _myPlayer.transform.position + _myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }

}
