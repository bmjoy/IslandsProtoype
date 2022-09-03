using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.EventSystems;

public class UIMenu : MonoBehaviour, IPanelsManagerUser
{
    [SerializeField] PanelsManager panelsManager;
    [SerializeField] BackgroundAnimation backgroundAnimation;
    [SerializeField] PostProcessingFunctions postProcessingFunctions;

    [Header("References")]
    [SerializeField] GameObject savePrefab;
    [SerializeField] GameObject savesObject;
    [SerializeField] Button newButton;
    [SerializeField] Button loadButton;
    [SerializeField] Button deleteButton;
    [SerializeField] TMP_InputField saveNameInput;
    [SerializeField] Button createSave;
    [SerializeField] TextMeshProUGUI inputHint;
    [SerializeField] Slider difficultySlider;
    [SerializeField] TextMeshProUGUI difficultyText;

    List<GameObject> savesUi = new List<GameObject>();
    GameObject selected;
    int MaxNumOfSaves = 5;

    void Start()
    {
        backgroundAnimation.Initialize();
        panelsManager.Initialize();
        postProcessingFunctions.Initialize();
        postProcessingFunctions.SetBlur(true);
        saveNameInput.onValueChanged.AddListener(SaveNameVaildator);
        difficultySlider.onValueChanged.AddListener(OnDifficultySliderValueChange);

        UpdateSavesUI();
    }
    void OnDrawGizmos()
    {
        panelsManager.OnDrawGizmos();
    }
    void Update()
    {
        CheckNewSelection();
    }


    public void NewSave()
    {
        var _time = System.DateTime.Now;

        SessionData sessionData = new SessionData(saveNameInput.text, DataManager.instance.GetCurrentMode(), _time.ToString(), GetDifficulty());

        DataManager.instance.Add(sessionData);
        
        saveNameInput.text = "";
        UpdateSavesUI();
    }
    public void LoadSave()
    {
        var _save = selected.GetComponent<SaveInfo>();
        
        DataManager.instance.SetCurrentSession(_save.saveName.text);

        OpenGame();
    }
    public void DeleteSave()
    {
        if(selected != null && selected.GetComponent<SaveInfo>())
        {
            var _save = selected.GetComponent<SaveInfo>();

            DataManager.instance.Remove(_save.saveName.text);

            UpdateSavesUI();
        }
    }


    //UI commands
    public void OpenMenuPanel(string _menuName)
    {
        panelsManager.OpenMenuPanel(_menuName, true);
    }
    public void ToggleMenuPanel(string _menuInfo)
    {
        panelsManager.ToggleMenuPanel(_menuInfo, false);
    }
    public void OpenMenuPanelNonExclusive(string _menuInfo)
    {
        panelsManager.OpenMenuPanel(_menuInfo, false);
    }
    public void CloseMenuPanelNonExclusive(string _menuInfo)
    {
        panelsManager.CloseMenuPanel(_menuInfo);
    }
    public void SetLastScene(string sceneName)
    {
        DataManager.instance.SetLastScenen(sceneName);
    }
    public void SetCurrentMode(string modeName)
    {
        DataManager.instance.SetCurrentMode(modeName);
    }


    //Game mangement
    public void Quit()
    {
        Application.Quit();
    }
    public void OpenGame()
    {
        SceneControl.instance.LoadScene(1);
    }


    //internal
    public void UpdateSavesUI()
    {
        ClearOldUI();

        List<SessionData> saves = DataManager.instance.GetSavedData();

        //Recreate them and add
        foreach (var _save in saves)
        {
            if (_save.modeData.modeName == DataManager.instance.GetCurrentMode())
            {
                var _saveInfo = Instantiate(savePrefab, savesObject.transform).GetComponent<SaveInfo>();
                _saveInfo.saveName.text = _save.sessionName;
                _saveInfo.date.text = _save.since;
                savesUi.Add(_saveInfo.gameObject);
            }
        }

        UpdateSavesButton();
    }
    void OnDifficultySliderValueChange(float _value)
    {
        if (_value >= 0f && _value <= 0.33f)
        {
            difficultySlider.value = 0f;
            difficultyText.text = "Easy";
        }
        else if (_value > 0.33f && _value <= 0.66f)
        {
            difficultySlider.value = 0.5f;
            difficultyText.text = "Medium";
        }
        else if(_value > 0.66f && _value <= 1f)
        {
            difficultySlider.value = 1f;
            difficultyText.text = "Hard";
        }
    }
    AiSet GetDifficulty()
    {
        if (difficultySlider.value >= 0f && difficultySlider.value <= 0.33f)
        {
            return AiSet.Easy;
        }
        else if (difficultySlider.value > 0.33f && difficultySlider.value <= 0.66f)
        {
            return AiSet.Medium;
        }
        else if (difficultySlider.value > 0.66f && difficultySlider.value <= 1f)
        {
            return AiSet.Hard;
        }

        return AiSet.Default;
    }
    void ClearOldUI()
    {
        foreach (GameObject saveUi in savesUi)
        {
            Destroy(saveUi);
        }
        savesUi.Clear();
    }
    void UpdateSavesButton()
    {
        if (savesUi.Count >= MaxNumOfSaves)
        {
            newButton.interactable = false;
        }
        else
        {
            newButton.interactable = true;
        }


        if(selected != null && selected.GetComponent<SaveInfo>())
        {
            loadButton.interactable = true;
            deleteButton.interactable = true;
        }
        else
        {
           loadButton.interactable = false;
           deleteButton.interactable = false;
        }

    }
    void CheckNewSelection()
    {
        var _new = EventSystem.current.currentSelectedGameObject;

        if (_new != selected)
        {
            if (_new != null)
            {
                if (_new.GetComponent<SaveInfo>())
                    selected = EventSystem.current.currentSelectedGameObject;
            }
            else
            {
                selected = null;
            }

            UpdateSavesButton();
        }

    }
    void SaveNameVaildator(string _saveName)
    {
        string _saveNameVaildator = "";

        if(_saveName.Length >= 15)
        {
            _saveNameVaildator = "Save name is too long";
        }
        else if(DataManager.instance.Contains(_saveName))
        {
            _saveNameVaildator = "Save name already exists";
        }
        else if(_saveName.Replace(" ", "").Length == 0)
        {
            _saveNameVaildator = "Enter a name";
        }


        if(_saveNameVaildator == "")
        {
            createSave.interactable = true;
            inputHint.text = "";
        }
        else
        {
            createSave.interactable = false;
            inputHint.text = _saveNameVaildator;
        }
    }
}




