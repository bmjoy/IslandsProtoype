using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GraphicsPanel : MenuPanel
{
    [SerializeField] Toggle shadowsToggle;
    [SerializeField] Toggle grassToggle;

    public override void Initialize()
    {
        base.Initialize();

        shadowsToggle.onValueChanged.AddListener(OnShadowsUIChange);
        grassToggle.onValueChanged.AddListener(OnGrassUIChange);

        LoadSaved();
    }
    public override void FillFunctions()
    {
        base.FillFunctions();

        if (UIMenu.instance != null)
            GetButton("Back").onClick.AddListener(new UnityAction(() => UIMenu.instance.OpenMenuPanel("Settings")));
        else if (UIGame.instance != null)
            GetButton("Back").onClick.AddListener(new UnityAction(() => UIGame.instance.OpenMenuPanel("Settings0")));

        GetButton("Back").onClick.AddListener(new UnityAction(() => Save()));
    }
    public void LoadSaved()
    {
        var settings = DataManager.instance.GetSavedData().settings;

        shadowsToggle.isOn = settings.shadows;
        grassToggle.isOn = settings.grass;
    }
    public void Save()
    {
        var settings = DataManager.instance.GetSavedData().settings;

        settings.shadows = shadowsToggle.isOn;
        settings.grass = grassToggle.isOn;

        DataManager.instance.Modify(settings);
    }

    void OnShadowsUIChange(bool state)
    {
        var lights = FindObjectsOfType<Light>();

        if (state)
            foreach(var light in lights)
                light.shadows = LightShadows.Hard;
        else
            foreach (var light in lights)
                light.shadows = LightShadows.None;
    }
    void OnGrassUIChange(bool state)
    {
        var terrains = FindObjectsOfType<Terrain>();

        foreach (Terrain terrain in terrains)
            terrain.drawTreesAndFoliage = state;
    }
}
