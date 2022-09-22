using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


[System.Serializable]
public class AIParameter 
{
    [SerializeField] public string saveName;
    [SerializeField] public float value;

    public static float GetValue(List<AIParameter> parameters, AIParametersNames parameterName)
    {
        foreach(AIParameter parameter in parameters)
        {
            if (parameter.saveName == parameterName.ToString())
            {
                return parameter.value;
            }
        }

        return 0f;
    }
    public static float GetParameterDefaultValue(string parameterName, AiSet set)
    {
        int i = 0;

        foreach (var parameter in Enum.GetValues(typeof(AIParametersNames)))
        {
            if (parameterName == parameter.ToString())
            {
                if (set == AiSet.Default)
                    return DefaultValues[i];
                else if (set == AiSet.Easy)
                    return EasyValues[i];
                else if (set == AiSet.Medium)
                    return Medium[i];
                else if (set == AiSet.Hard)
                    return Hard[i];
            }

            i++;
        }

        return 0f;
    }

    //Settings Sets
    static List<float> DefaultValues = new List<float>()
    {
        0.5f, 0.5f,0.5f,
        0.5f,0.5f,0.5f,0.5f,0.5f,
        0.5f,0.5f,20f,100f,400f,10
    };

    static List<float> EasyValues = new List<float>()
    {
        0f, 0f,1f,
        0f,0f,1f,1f,0.8f,
        0f,0f,5f,20f,10000f,2f
    };

    static List<float> Medium = new List<float>()
    {
        0f, 0f,0.5f,
        0f,0f,0.5f,0.5f,0.5f,
        0f,0f,50f,10f,250f,50f
    };

    static List<float> Hard = new List<float>()
    {
        0f, 0f,0f,
        0f,0f,0f,0f,0f,
        0f,0f,50f,10f,120f,100f
    };
}
public enum AIParametersNames
{
    ThrowBallOnPlayerProb, ThrowBallOnNpcProb, SeekPlayerProb,
    SeekNpcProb, SeekBallProb, SeekTreeProb, SeekFruitProb, SeekAlterProb,
    PunchNpcProb, DropBallProb, SleepTime, BoredTime, DeathTime, GrowTime
}
public enum AiSet
{
    Default, Easy, Medium, Hard
}