using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LogicGate : MonoBehaviour
{
    public bool[] logics;

    public UnityEvent onEvent;
    public UnityEvent offEvent;

    public void TurnOnLogic(int number)
    {
        logics[number] = true;

        for (int i = 0; i < logics.Length; i++)
        {
            if (!logics[i]) return;
        }

        onEvent.Invoke();
    }

    public void TurnOffLogic(int number)
    {
        logics[number] = false;

        for (int i = 0; i < logics.Length; i++)
        {
            if (!logics[i] && i != number) return;
        }
        offEvent.Invoke();
    }
}
