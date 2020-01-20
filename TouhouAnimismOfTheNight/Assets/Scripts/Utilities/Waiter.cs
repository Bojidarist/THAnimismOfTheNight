using System;
using System.Collections;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    public void InvokeAfterSeconds(Action action, float seconds)
    {
        object[] parms = new object[] { action, seconds };
        StartCoroutine(nameof(WaitCoroutine), parms);
    }

    private IEnumerator WaitCoroutine(object[] parms)
    {
        Action action = parms[0] as Action;
        float seconds = (float)parms[1];
        yield return new WaitForSeconds(seconds);
        action.Invoke();
    }
}
