using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvest : Pickable, IStorableObject, ISavable
{
    public void LoadData(SaveStructure saveData)
    {
        Harvest_Data harvest_data = (Harvest_Data)saveData;

        transform.position = harvest_data.position.GetVector();
    }
    public Harvest_Data GetData()
    {
        Harvest_Data harvestData = new Harvest_Data();

        harvestData.position = new nVector3(transform.position);

        return harvestData;
    }
}
