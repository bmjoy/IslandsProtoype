using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void OnNamingDone();

public class GameManager : MonoBehaviour
{
    [SerializeField] PostProcessingFunctions posProcessingFunctions;

    [Header("Game Design")]
    [SerializeField] PlayerSystem myPlayer;
    [SerializeField] GameObject eggAsset;
    [SerializeField] GameObject ballAsset;
    [SerializeField] GameObject fruitAsset;
    [SerializeField] GameObject harvestAsset;
    [SerializeField] GameObject fertilityBoostAsset;
    [SerializeField] GameObject extroversionBoostAsset;
    [SerializeField] GameObject aggressivenessBoostAsset;
    [SerializeField] GameObject powerBoostAsset;
    [SerializeField] GameObject healthBoostAsset;
    [SerializeField] GameObject woodpackAsset;
    [SerializeField] GameObject stonepackAsset;
    [SerializeField] GameObject seedAsset;
    [SerializeField] GameObject treeAsset;
    [SerializeField] GameObject nameingHouseAsset;
    [SerializeField] GameObject craftingBenchAsset;
    [SerializeField] GameObject clothCreatorAsset;
    [SerializeField] GameObject axeAsset;
    [SerializeField] GameObject swordAsset;
    [SerializeField] GameObject rockAsset;
    [SerializeField] GameObject hatAsset;
    [SerializeField] GameObject regularZombieAsset;
    [SerializeField] GameObject deadchild;
    [SerializeField] NPC npcAsset;


    public static GameManager instance;
    public event OnNamingDone OnNamingDone;
    Vector3 camCustomizingViewPos;
    Quaternion camCustomizingViewRot;
    AbstractMode modeHandler;


    //Private functions
    void Awake()
    {
        instance = this;

        camCustomizingViewPos = Camera.main.transform.position;
        camCustomizingViewRot = Camera.main.transform.rotation;

        if (myPlayer == null)
            FindObjectOfType<PlayerSystem>();

        posProcessingFunctions.Initialize();


        SetBlur(false);

        modeHandler = ModeFactory.CreateModeHandler(DataManager.instance.GetCurrentSession());

        LoadAndApply();

        StartCoroutine(autoSave());
    }
    void Update()
    {
        if (modeHandler != null)
            modeHandler.Update();
    }
    IEnumerator autoSave()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(60f);
            Save();
        }
    }
    void LoadAndApply()
    {
        SessionData sessionData = DataManager.instance.GetCurrentSession();

        foreach(NPC_Data npc_data in  sessionData.data.npcs)
            npc_data.SpawnWithData(npcAsset.gameObject, true);

        foreach (Ball_Data ball_data in sessionData.data.balls)
            ball_data.SpawnWithData(ballAsset, true);

        foreach (Egg_Data egg_data in sessionData.data.eggs)
            egg_data.SpawnWithData(eggAsset, true);

        foreach (Fruit_Data fruit_data in sessionData.data.fruits)
            fruit_data.SpawnWithData(fruitAsset, true);

        foreach (Harvest_Data harvest_Data in sessionData.data.harvests)
            harvest_Data.SpawnWithData(harvestAsset, true);

        foreach (Seed_Data seed_data in sessionData.data.seeds)
            seed_data.SpawnWithData(seedAsset, true);

        foreach (FertilityBoost_Data boost in sessionData.data.fertilityBoosts)
            boost.SpawnWithData(fertilityBoostAsset, true);

        foreach(ExtroversionBoost_Data boost in sessionData.data.extroversionBoosts)
            boost.SpawnWithData(extroversionBoostAsset, true);

        foreach (AggressivenessBoost_Data boost in sessionData.data.aggressivenessBoosts)
            boost.SpawnWithData(aggressivenessBoostAsset, true);

        foreach (PowerBoost_Data boost in sessionData.data.powerboosts)
            boost.SpawnWithData(powerBoostAsset, true);

        foreach (FitnessBoost_Data boost in sessionData.data.healthboosts)
            boost.SpawnWithData(healthBoostAsset, true);
       
        foreach (WoodPack_Data woodPack in sessionData.data.woodpacks)
            woodPack.SpawnWithData(woodpackAsset, true);

        foreach (StonePack_Data stonePack in sessionData.data.stonepacks)
            stonePack.SpawnWithData(stonepackAsset, true);

        foreach (NamingHouse_Data namingHouse_data in sessionData.data.namingHouses)
            namingHouse_data.SpawnWithData(nameingHouseAsset, true);

        foreach (Axe_Data axe_data in sessionData.data.axes)
            axe_data.SpawnWithData(axeAsset, true);

        foreach (CraftingBench_Data craftingBench_Data in sessionData.data.craftingBenches)
            craftingBench_Data.SpawnWithData(craftingBenchAsset, true);

        foreach (ClothCreator_Data clothCreator in sessionData.data.clothCreators)
            clothCreator.SpawnWithData(clothCreatorAsset, true);

        foreach (Hat_Data hat in sessionData.data.hats)
            hat.SpawnWithData(hatAsset, true);

        foreach (Sword_Data sword in sessionData.data.swords)
            sword.SpawnWithData(swordAsset, true);

        foreach (Zombie_Data zombie in sessionData.data.zombies)
            zombie.SpawnWithData(regularZombieAsset, true);

        foreach (Tree_Data tree_data in sessionData.data.trees)
            tree_data.SpawnWithData(treeAsset, true);
        foreach (Rock_Data rock_data in sessionData.data.rocks)
            rock_data.SpawnWithData(rockAsset, true);

        sessionData.data.player.SpawnWithData(myPlayer.gameObject, false);

        DayNightControl.instance.factor = sessionData.DayNightFactor;
    }
    public void Save()
    {
        SessionData sessionData = DataManager.instance.GetCurrentSession();

        sessionData.data.npcs = NPC_Data.GameToDate(FindObjectsOfType<NPC>());
        sessionData.data.balls = Ball_Data.GameToDate(FindObjectsOfType<Ball>());
        sessionData.data.eggs = Egg_Data.GameToDate(FindObjectsOfType<Egg>());
        sessionData.data.fruits = Fruit_Data.GameToDate(FindObjectsOfType<Fruit>());
        sessionData.data.harvests = Harvest_Data.GameToDate(FindObjectsOfType<Harvest>());
        sessionData.data.seeds = Seed_Data.GameToDate(FindObjectsOfType<Seed>());
        sessionData.data.trees = Tree_Data.GameToDate(FindObjectsOfType<TreeSystem>());
        sessionData.data.rocks = Rock_Data.GameToDate(FindObjectsOfType<Rock>());
        sessionData.data.fertilityBoosts = FertilityBoost_Data.GameToDate(FindObjectsOfType<FertilityBoost>());
        sessionData.data.extroversionBoosts = ExtroversionBoost_Data.GameToDate(FindObjectsOfType<ExtroversionBoost>());
        sessionData.data.aggressivenessBoosts = AggressivenessBoost_Data.GameToDate(FindObjectsOfType<AggressivenessBoost>());
        sessionData.data.powerboosts = PowerBoost_Data.GameToDate(FindObjectsOfType<PowerBoost>());
        sessionData.data.healthboosts = FitnessBoost_Data.GameToDate(FindObjectsOfType<FitnessBoost>());
        sessionData.data.stonepacks = StonePack_Data.GameToDate(FindObjectsOfType<StonePack>());
        sessionData.data.woodpacks = WoodPack_Data.GameToDate(FindObjectsOfType<WoodPack>());
        sessionData.data.namingHouses = NamingHouse_Data.GameToDate(FindObjectsOfType<NamingHouse>());
        sessionData.data.craftingBenches = CraftingBench_Data.GameToDate(FindObjectsOfType<CraftingBench>());
        sessionData.data.clothCreators = ClothCreator_Data.GameToDate(FindObjectsOfType<ClothCreator>());
        sessionData.data.axes = Axe_Data.GameToDate(FindObjectsOfType<Axe>());
        sessionData.data.swords = Sword_Data.GameToDate(FindObjectsOfType<Sword>());
        sessionData.data.hats = Hat_Data.GameToDate(FindObjectsOfType<Hat>());
        sessionData.data.player = Player_Data.GameToData(myPlayer);
        sessionData.data.zombies = Zombie_Data.GameToDate(FindObjectsOfType<RegularZombie>());
        sessionData.modeData = modeHandler.GetModeData();
        sessionData.DayNightFactor = DayNightControl.instance.factor;

        DataManager.instance.Modify(sessionData);
        StartCoroutine(UIGame.instance.SavingUI());
    }


    //Settings
    public void SetPlaying(bool state)
    {
        SetBlur(!state);

        myPlayer.LockPlayer(state);
    }
    public void SetCamera(bool state)
    {
        if(state == false)
        {
            Camera.main.transform.position = camCustomizingViewPos;
            Camera.main.transform.rotation = camCustomizingViewRot;
        }
    }
    public void SetBlur(bool state)
    {
        posProcessingFunctions.SetBlur(state);
    }
    public void OpenMainMenu()
    {
        Save();
        SceneControl.instance.LoadScene(0);
    }
    public void ExitWithoutSaving()
    {
        SceneControl.instance.LoadScene(0);
    }
    public void OpenInventory(bool state)
    {
        UIGame.instance.DisplayInventory(state, myPlayer.inventorySystem);
    }


    //For design Buttons
    public void SpawnBall()
    {
        Instantiate(ballAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public void SpawnEgg()
    {
        Instantiate(eggAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public void SpawnRandomItem()
    {
        var points = MapSystem.instance.GetExplorationPoints();

        int randomPoint = UnityEngine.Random.Range(0,points.Count);
        int randomItem = UnityEngine.Random.Range(0, 7);

        GameObject item = null;

        if (randomItem == 0)
            item = fertilityBoostAsset;
        else if (randomItem == 1)
            item = aggressivenessBoostAsset;
        else if (randomItem == 2)
            item = healthBoostAsset;
        else if (randomItem == 3)
            item = powerBoostAsset;
        else if (randomItem == 4)
            item = extroversionBoostAsset;
        else if (randomItem == 5)
            item = stonepackAsset;
        else if (randomItem == 6)
            item = woodpackAsset;

        Instantiate(item, points[randomPoint].position,Quaternion.identity);
    }
    public GameObject SpawnBoost(string boostType)
    {
        return Instantiate(GetBoost(boostType).gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public GameObject SpawnBoost(string boostType, Vector3 position)
    {
        return Instantiate(GetBoost(boostType).gameObject, position, Quaternion.identity);
    }
    public GameObject SpawnDeadBody_ReturnDeadBody(Vector3 position)
    {
        return Instantiate(deadchild, position, Quaternion.identity);
    }
    public Egg SpawnEgg_ReturnEgg(Vector3 position)
    {
        return Instantiate(eggAsset.gameObject, position, Quaternion.identity).GetComponent<Egg>();
    }
    public GameObject SpawnSeed()
    {
        return Instantiate(seedAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public GameObject SpawnFruit()
    {
        return Instantiate(fruitAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public GameObject SpawnTree(Vector3 position)
    {
        return Instantiate(treeAsset.gameObject, position, Quaternion.identity);
    }
    public GameObject SpawnRock(Vector3 position)
    {
        return Instantiate(rockAsset.gameObject, position, Quaternion.identity);
    }
    public GameObject SpawnStonePack()
    {
        return SpawnStonePack(myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5);
    }
    public GameObject SpawnStonePack(Vector3 position)
    {
        return Instantiate(stonepackAsset.gameObject, position, Quaternion.identity);
    }
    public GameObject SpawnWoodPack()
    {
        return SpawnWoodPack(myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5);
    }
    public GameObject SpawnWoodPack(Vector3 position)
    {
        return Instantiate(woodpackAsset.gameObject, position, Quaternion.identity);
    }
    public GameObject SpawnHarvest()
    {
        return Instantiate(harvestAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public GameObject SpawnAxe()
    {
        return Instantiate(axeAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public GameObject SpawnHat()
    {
        return Instantiate(hatAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public GameObject SpawnSword()
    {
        return Instantiate(swordAsset.gameObject, myPlayer.transform.position + myPlayer.transform.forward * 2f + Vector3.up * 5, Quaternion.identity);
    }
    public GameObject SpawnNamingHouse(Vector3 position)
    {
        return Instantiate(nameingHouseAsset.gameObject, position, Quaternion.identity);

    }
    public GameObject SpawnCraftingBench(Vector3 position)
    {
        return Instantiate(craftingBenchAsset.gameObject, position, Quaternion.identity);

    }
    public GameObject SpawnClothCreator(Vector3 position)
    {
        return Instantiate(clothCreatorAsset.gameObject, position, Quaternion.identity);

    }
    public GameObject SpawnRegularZombie(Vector3 position)
    {
        return Instantiate(regularZombieAsset.gameObject, position, Quaternion.identity);
    }
    public void OnNamingFinsihed()
    {
        OnNamingDone.Invoke();
    }
    GameObject GetBoost(string boostType)
    {
        GameObject boost = powerBoostAsset;

        if (boostType == "AggressivenessBoost")
        {
            boost = aggressivenessBoostAsset;
        }
        else if (boostType == "ExtroversionBoost")
        {
            boost = extroversionBoostAsset;
        }
        else if (boostType == "FertilityBoost")
        {
            boost = fertilityBoostAsset;
        }
        else if (boostType == "HealthBoost")
        {
            boost = healthBoostAsset;
        }
        else if (boostType == "PowerBoost")
        {
            boost = powerBoostAsset;
        }

        return boost;
    }
}
