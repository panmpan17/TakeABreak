using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPack;


public class Door : MonoBehaviour
{
    public bool initialStatus;

    public Vector3 openPositionDelta;
    private Vector3 closePosition;
    private Vector3 openPosition;

    public Timer animateTimer;
    private bool isOpening;

    void Awake()
    {
        if (initialStatus)
        {
            openPosition = transform.position;
            closePosition = openPosition - openPositionDelta;
            isOpening = true;
        }
        else
        {
            closePosition = transform.position;
            openPosition = closePosition + openPositionDelta;
        }

        animateTimer.Running = false;
    }

    void Update()
    {
        if (animateTimer.Running)
        {
            if (animateTimer.UpdateEnd)
            {
                animateTimer.Running = false;
            }

            if (isOpening) transform.position = Vector3.Lerp(closePosition, openPosition, animateTimer.Progress);
            else transform.position = Vector3.Lerp(openPosition, closePosition, animateTimer.Progress);
        }
    }

    public void Open()
    {
        if (isOpening) return;

        isOpening = true;
        animateTimer.Reset();
        GetComponent<AudioSource>().Play();
    }
    public void Close()
    {
        if (!isOpening) return;

        isOpening = false;
        animateTimer.Reset();
        GetComponent<AudioSource>().Play();
    }
}
