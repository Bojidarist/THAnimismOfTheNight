using System;
using System.Collections;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    public void InvokeForSeconds(Action action, float seconds)
    {
        object[] parms = new object[] { action, seconds };
        StartCoroutine("Wait", parms);
    }

    private IEnumerator Wait(object[] parms)
    {
        Action action = parms[0] as Action;
        float seconds = (float)parms[1];
        yield return new WaitForSeconds(seconds);
        action.Invoke();
    }
}
