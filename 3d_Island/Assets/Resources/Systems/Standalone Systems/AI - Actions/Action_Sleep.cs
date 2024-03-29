using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class Action_Sleep : AbstractAction
{
    public Action_Sleep(GameObject subject, NPC myAgent) : base(subject, myAgent)
    {
        actionName = "Sleeping";
        priority = 1;
    }
    public override void Execute()
    {
        base.Execute();
        ServicesProvider.instance.StartCoroutine(Sleep());
    }
    IEnumerator Sleep()
    {
        float time = 0;
        float sleepTime = myAgent.character.GetSleepTime();

        ConditionChecker condition = new ConditionChecker(!myAgent.isPicked);

        UIGame.instance.ShowRepeatingMessage("Sleeping", myAgent.transform, sleepTime, 15, condition);

        //sleep
        myAgent.GetBody().isKinematic = true;
        myAgent.navMeshAgent.enabled = false;

        while (condition.isTrue)
        {
            if (base.ShouldBreak())
                break;

            time += Time.fixedDeltaTime;
            condition.Update((time <= sleepTime) && !myAgent.isPicked && !isDone);

            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }

        //Wake up
        if (!myAgent.isPicked)
        {
            myAgent.navMeshAgent.enabled = true;
            myAgent.GetBody().isKinematic = false;
        }

        isDone = true;
        condition.Update(false);


    }
}
