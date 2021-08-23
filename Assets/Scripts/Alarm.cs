using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPack;

public class Alarm : MonoBehaviour, IInteractble
{
    private Transform pointer;

    public FloatLerpTimer pointerRotateTimer;

    public Timer ringTimer;

    public float vibrateSize;
    public Timer vibrateTimer;

    public float radius;

    public GameObject rangeIndicate;

    void Awake()
    {
        pointer = transform.GetChild(0);
        ringTimer.Running = false;
        pointerRotateTimer.Timer.Running = false;
        rangeIndicate.SetActive(false);
    }

    void Update()
    {
        if (ringTimer.Running)
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-vibrateSize, vibrateSize));

            if (ringTimer.UpdateEnd)
            {
                ringTimer.Running = false;
                transform.rotation = Quaternion.identity;
            }
            return;
        }

        if (pointerRotateTimer.Timer.Running)
        {
            if (pointerRotateTimer.Timer.UpdateEnd)
            {
                pointerRotateTimer.Timer.Reset();
                pointerRotateTimer.Timer.Running = false;
                pointer.rotation = Quaternion.identity;

                ringTimer.Reset();

                GetComponent<AudioSource>().Play();

                float sqrMagnitude = (PlayerControl.ins.transform.position - transform.position).sqrMagnitude;
                if (sqrMagnitude < radius * radius)
                    PlayerControl.ins.ForceWakeUp();
            }
            else
                pointer.rotation = Quaternion.Euler(0, 0, pointerRotateTimer.Value);
        }
    }

    public void Interact()
    {
        pointerRotateTimer.Timer.Running = true;
    }
    public void HoldInteract() {}

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void OnPlayerEnter()
    {
        rangeIndicate.SetActive(true);
    }


    public void OnPlayerExit()
    {
        rangeIndicate.SetActive(false);
    }
}
