using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Security.Cryptography;
using UnityEngine.Events;
using UnityEngine.InputSystem.Controls;

public enum PickMode { Pick, Drop, Shake};

public class UIGame : MonoBehaviour, IPanelsManagerUser
{
    public static UIGame instance;

    [SerializeField] List<PanelsManager> PanelsManagers;

    [Header("References")]
    [SerializeField] GameObject threeDCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject declarationsArea;
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject messagesArea;
    [SerializeField] GameObject highlightMessage;
    [SerializeField] GameObject ThreeDHighlightPrefab;
    [SerializeField] GameObject progressBarPrefab;
    [SerializeField] GameObject npcUiElementPrefab;
    [SerializeField] GameObject inventoryElementPrefab;
    [SerializeField] GameObject popUpMessageAsset;
    [SerializeField] GameObject touchControls;

    [Header("Ui parameters")]

    [SerializeField] float buttonOnAlpha = 1f;
    [SerializeField] float buttonOffAlpha = 0.3f;


    [Header("Ai Sliders")]
    [SerializeField] List<AIParameterSlider> sliders = new List<AIParameterSlider>();

    [Header("UI Objects")]
    [SerializeField] NPCStatsUI npcStatsUI;
    [SerializeField] GameObject npcStatsEdit;
    [SerializeField] TextMeshProUGUI npcStatsName;
    [SerializeField] Image pickDropButtonImage;
    [SerializeField] Image throwButtonImage;
    [SerializeField] Image plantButtonImage;
    [SerializeField] Image jumpButtonImage;
    [SerializeField] Image dashButtonImage;
    [SerializeField] Image petButtonImage;
    [SerializeField] Text pickDropButtonImage_Text;
    [SerializeField] Text customizeDebugger;
    [SerializeField] GameObject designMenus;
    [SerializeField] Button nextButton;
    [SerializeField] Button previousButton;
    [SerializeField] public TextMeshProUGUI countDownText;
    [SerializeField] GameObject savingText;
    [SerializeField] GameObject delcareUIAsset;



    //Helpers
    void Awake()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
            touchControls.SetActive(false);


        instance = this;

        foreach (AIParameterSlider slider in sliders)
            slider.Initialize();

        foreach(PanelsManager panelManager in PanelsManagers)
            panelManager.Initialize();

    }
    void OnDrawGizmos()
    {
        foreach (PanelsManager panelManager in PanelsManagers)
            panelManager.OnDrawGizmos();

        //update sliders list to have a member for each name
        if(sliders.Count != Enum.GetValues(typeof(AIParametersNames)).Length)
        {
            foreach (var parameter in Enum.GetValues(typeof(AIParametersNames)))
            {
                bool exists = false;

                foreach(AIParameterSlider slider in sliders)
                {
                    if(slider.saveName == parameter.ToString())
                    {
                        exists = true;
                    }
                }

                if(exists == false)
                {
                    sliders.Add(new AIParameterSlider() { saveName = parameter.ToString() , value = 0});
                }
            }

        }
    }



    //UI control
    public void PickDropButton_Enable(bool _state)
    {
        ChangeAlpha(pickDropButtonImage, _state);
    }
    public void ThrowButton_Enable(bool _state)
    {
        ChangeAlpha(throwButtonImage, _state);
    }
    public void PlantButton_Enable(bool _state)
    {
        ChangeAlpha(plantButtonImage, _state);
    }
    public void JumpButton_Enable(bool _state)
    {
        ChangeAlpha(jumpButtonImage, _state);
    }
    public void DashButton_Enable(bool _state)
    {
        ChangeAlpha(dashButtonImage, _state);

    }
    public void PetButton_Enable(bool _state)
    {
        ChangeAlpha(petButtonImage, _state);
    }
    public void PickDropButton_SwitchMode(PickMode _mode)
    {
        pickDropButtonImage_Text.text = _mode.ToString();
    }
    public void UpdateAISliders(List<AIParameter> aIParameters)
    {
        foreach(AIParameter parameter in aIParameters)
        {
            foreach(AIParameterSlider slider in sliders)
            {
                if(parameter.saveName == slider.saveName)
                {
                    slider.ChangeSlider(parameter.value);
                }
            }
        }
    }
    public List<AIParameter> GetSlidersData()
    {
        List<AIParameter> parameters = new List<AIParameter>();

        foreach (AIParameterSlider slider in sliders)
            parameters.Add(new AIParameter() { saveName = slider.saveName, value = slider.value });

        return parameters;
    }
    public void ChangeCustomizingIndicator(string text, Color color)
    {
        customizeDebugger.text = text;
        customizeDebugger.color = color;
    }
    public NPCStatsUI GetNPCStatsUI()
    {
        return npcStatsUI;
    }
    public void EditNPCStats(bool state)
    {
        npcStatsEdit.SetActive(state);
    }
    public string GetUiName()
    {
        return npcStatsName.text;
    }



    ///////// In Game UI ///////////////
    
    //NonReferenced Messages (Once done, you can't access them)
    public void ShowPopUpMessage(string header, string message, string button, UnityAction onPress)
    {
        UIPopUp popUpMessage = Instantiate(popUpMessageAsset, gameCanvas.transform).GetComponent<UIPopUp>();

        popUpMessage.header.text = header;
        popUpMessage.message.text = message;
        popUpMessage.button.GetComponentInChildren<TextMeshProUGUI>().text = button;
        popUpMessage.button.onClick.AddListener(onPress);
    }
    public void ShowFloatingMessage(string message, float time, Vector3 startSize, float speed)
    {
        StartCoroutine(this.message(message, time, startSize, speed));
    }
    public void ShowRepeatingMessage(string message, Transform parent, float messageTime, float repeats, ConditionChecker condition)
    {
        StartCoroutine(RepeatMessage_Coroutine(message, parent, messageTime, repeats, condition));
    }
    public void ShowDeclare(string message)
    {
        DeclarationElement element = Instantiate(delcareUIAsset, declarationsArea.transform).GetComponent<DeclarationElement>();
        element.message.text = message;
    }

    //Referenced Messages
    
    //Sliders
    Dictionary<GameObject, Slider> slidersContainer = new();
    public void ShowSlider(GameObject user, Vector2 limits, Transform parent)
    {
        Slider _progressBar = Instantiate(progressBarPrefab, parent.position, Quaternion.identity, threeDCanvas.transform).GetComponent<Slider>();
        _progressBar.minValue = limits.x;
        _progressBar.maxValue = limits.y;

        slidersContainer.Add(user, _progressBar);

        StartCoroutine(TranslateUiElement(_progressBar.gameObject, parent));
    }
    public void UpdateProgressBar(GameObject user, float value)
    {
        slidersContainer[user].value = value;
    }
    public void UpdateProgressBarLimits(GameObject user, Vector3 limits)
    {
        slidersContainer[user].minValue = limits.x;
        slidersContainer[user].maxValue = limits.y;
    }
    public void DestroyProgressBar(GameObject user)
    {
        Slider _temp = slidersContainer[user];
        slidersContainer.Remove(user);
        Destroy(_temp.gameObject);
    }


    //NPC inGame Ui
    Dictionary<GameObject, UIElement_NPC> npcUiContainer = new();
    public void CreateNPCUi(GameObject user, Transform parent)
    {
        UIElement_NPC _npcUi = Instantiate(npcUiElementPrefab, parent.position, Quaternion.identity, threeDCanvas.transform).GetComponent<UIElement_NPC>();

        npcUiContainer.Add(user, _npcUi);

        StartCoroutine(TranslateUiElement(_npcUi.gameObject, parent));
    }
    public void UpateNpcUiElement(GameObject user, string text)
    {
        npcUiContainer[user].levelText.text = text;
    }
    public void DestroyNpcUiElement(GameObject user)
    {
        if (npcUiContainer.ContainsKey(user))
        {
            UIElement_NPC _temp = npcUiContainer[user];
            npcUiContainer.Remove(user);
            Destroy(_temp.gameObject);
        }
    }


    //Inventory Ui
    Dictionary<string, UiElement_Inventory> InventoryItemsContainer = new();
    public void CreateInventoryUI(string itemTag, UnityAction onClick)
    {
        var _inventoryItem = Instantiate(inventoryElementPrefab, inGamePanel.transform).GetComponent<UiElement_Inventory>();

        _inventoryItem.elementButton.onClick.AddListener(onClick);
        _inventoryItem.elementName.text = itemTag;
        _inventoryItem.elementNo.text = 1.ToString();

        InventoryItemsContainer.Add(itemTag, _inventoryItem);
    }
    public void UpdateInventoryUI(string itemTag, int nubmer)
    {
        InventoryItemsContainer[itemTag].elementNo.text = nubmer.ToString();
    }
    public void DestroyInventoryUI(string itemTag)
    {
        UiElement_Inventory _temp = InventoryItemsContainer[itemTag];
        InventoryItemsContainer.Remove(itemTag);
        Destroy(_temp.gameObject);
    }
    
    ///////////////////////////////


    //Control UI flow
    public void OpenMenuPanel(string menuPanelName_PlusManagerNum)
    {
        PanelsManager.OpenMenuPanel(menuPanelName_PlusManagerNum, PanelsManagers, true);
    }
    public void SetPanelDefault(string menuPanelName_PlusManagerNum)
    {
        PanelsManager.SetDefault(menuPanelName_PlusManagerNum, PanelsManagers);
    }
    public void OpenMenuPanelNonExclusive(string menuPanelName_PlusManagerNum)
    {
        PanelsManager.OpenMenuPanel(menuPanelName_PlusManagerNum, PanelsManagers, false);
    }
    public void CloseMenuPanelNonExclusive(string menuPanelName_PlusManagerNum)
    {
        PanelsManager.CloseMenuPanel(menuPanelName_PlusManagerNum, PanelsManagers);
    }
    public void CloseAllPanels()
    {
        foreach(PanelsManager panel in PanelsManagers)
        {
            panel.CloseAll();
        }
    }
    public void ToggleMenuPanel(string menuInfo)
    {
        PanelsManager.TogglePanel(menuInfo, PanelsManagers, false);
    }
    public void ShowIncrementPage(int incrementTimesManagerNum)
    {
        int _managerNumber = Mathf.Abs(incrementTimesManagerNum);
        
        int _increment = incrementTimesManagerNum / Mathf.Abs(incrementTimesManagerNum);

        string _targetPanel = PanelsManagers[_managerNumber].GetPanelRelativeToActive(_increment);

        var _directions = PanelsManagers[_managerNumber].GetPossibleDirection(PanelsManagers[_managerNumber].GetActivePage() + _increment);

        UpdateNextPrevious(_directions);

        PanelsManagers[_managerNumber].OpenMenuPanel(_targetPanel, true);
    }
    public IEnumerator SavingUI()
    {
        savingText.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        savingText.SetActive(false);
    }



    //Interal Algorithms
    bool DoesInventoryItemExists(string itemTag)
    {
        return (InventoryItemsContainer.ContainsKey(itemTag));
    }
    IEnumerator message(string message, float time, Vector3 startScale, float speed)
    {
        var messageObj = Instantiate(highlightMessage, messagesArea.transform);
        
        messageObj.transform.localScale = startScale;

        var Text = messageObj.GetComponent<TextMeshProUGUI>();

        Text.text =  message;

        float _animationCurrentTime = time;

        while(_animationCurrentTime >= 0)
        {

            Text.color = new Color(Text.color.r, Text.color.g, Text.color.b, _animationCurrentTime / time);

            _animationCurrentTime -= Time.fixedDeltaTime;

            messageObj.transform.localScale += speed * (new Vector3(Time.fixedDeltaTime, Time.fixedDeltaTime, Time.fixedDeltaTime));

            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }
    }
    void UpdateNextPrevious(ListPossibleDirections directions)
    {
        previousButton.interactable = directions.Previous;
        nextButton.interactable = directions.Next;
    }
    IEnumerator TranslateUiElement(GameObject _object, Transform parent)
    {
        while((parent != null ) && (_object != null))
        {
            _object.transform.position = parent.transform.position + Vector3.up;

            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator RepeatMessage_Coroutine(string message, Transform parent, float messageTime, float repeats, ConditionChecker condition)
    {
        float _time = 0f;

        while (condition.isTrue && _time<=messageTime && parent != null)
        {
            _time += messageTime / repeats;
            SpawnMessage(message, (parent.position + (1.5f*Vector3.up)));
            yield return new WaitForSecondsRealtime(messageTime / repeats);
        }
    }
    void SpawnMessage(string text, Vector3 position)
    {
        var _gameObject = Instantiate(ThreeDHighlightPrefab, position, Quaternion.identity, threeDCanvas.transform);
        _gameObject.GetComponentInChildren<Text>().text = text;
    }
    void ChangeAlpha(Image myImage, bool state)
    {
        myImage.color =  new Color(myImage.color.r, myImage.color.g, myImage.color.b, state ? buttonOnAlpha : buttonOffAlpha);
    }
}


 