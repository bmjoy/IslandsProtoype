using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SessionData
{
    public string sessionName;
    public Mode_Data modeData = new Mode_Data();
    public string since;
    public GameData data = new GameData();

    public SessionData(string sessionName, modes modeName, string since)
    {
        this.sessionName = sessionName;
        this.since = since;
        this.data = new GameData() { player = new Player_Data(), npcs = new List<NPC_Data>()};
        this.modeData = new Mode_Data(modeName, 0f);
    }
}
