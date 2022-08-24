using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class DataManager : MonoBehaviour 
{
    //Internal
    static string path;
    List<SessionData> dataCache;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            path = Application.persistentDataPath + "savedDate.json";
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void SaveData(List<SessionData> sessionsData)
    {
        dataCache = sessionsData;

        string data = JsonConvert.SerializeObject(sessionsData);

        File.WriteAllText(path, data);
    }


    public static DataManager instance;
    public List<SessionData> GetSavedData()
    {
        if(dataCache == null)
        {
            string save = File.ReadAllText(path);
            List<SessionData> data = JsonConvert.DeserializeObject<List<SessionData>>(save);

            dataCache = data;
        }

        return dataCache;
    }
    public void Add(SessionData sessionData)
    {
        List<SessionData> list = GetSavedData();
        list.Add(sessionData);

        SaveData(list);
    }
    public void Modify(SessionData newData)
    {
        List<SessionData> list = GetSavedData();
        SessionData oldData = list.Find(x => x.sessionName == newData.sessionName);
        int i = list.IndexOf(oldData);
        list[i] = newData;

        SaveData(list);
    }
    public void Remove(string sessionName)
    {
        List<SessionData> list = GetSavedData();
        SessionData oldData = list.Find(x => x.sessionName == sessionName);
        list.Remove(oldData);

        SaveData(list);
    }
    public bool Contains(string SessionName)
    {
        List<SessionData> list = GetSavedData();

        if (list.Count >= 0)
            if (list.Find(x => x.sessionName == SessionName) != null)
                return true;
            else
                return false;
        else
            return false;
    }
}
