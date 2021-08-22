using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPack;


public class MovingPlatform : MonoBehaviour
{
    public Vector3 destination;
    private Vector3 original;

    public enum SwitchMode {
        OnAndOff,
        Position,
    }

    public SwitchMode mode;
    private bool headToDestination = true;

    public Timer moveTimer;
    public Timer resetTimer;

    private List<Rigidbody2D> rigidbody2Ds = new List<Rigidbody2D>();

    private void Awake()
    {
        original = transform.position;
        resetTimer.Running = false;
        if (mode == SwitchMode.Position)
        {
            moveTimer.Reset(1, true);
        }
    }

    void Update()
    {
        if (mode == SwitchMode.OnAndOff)
        {
            if (resetTimer.Running)
            {
                if (resetTimer.UpdateEnd)
                {
                    resetTimer.Running = false;
                }
                return;
            }

            if (moveTimer.UpdateEnd)
            {
                transform.position = headToDestination? destination: original;
                moveTimer.Reset();

                headToDestination = !headToDestination;
                resetTimer.Reset();
                return;

            }
            else
            {
                CalculatePosition();
            }
        }
        else
        {
            if (moveTimer.Running)
            {
                if (moveTimer.UpdateEnd)
                {
                    transform.position = headToDestination ? destination : original;
                    moveTimer.Running = false;
                    return;
                }
                else
                {
                    CalculatePosition();
                }
            }
        }
    }

    private void CalculatePosition()
    {
        Vector3 newPosition;
        if (headToDestination)
            newPosition = Vector3.Lerp(original, destination, moveTimer.Progress);
        else
            newPosition = Vector3.Lerp(destination, original, moveTimer.Progress);

        Vector3 delta = newPosition - transform.position;
        for (int i = 0; i < rigidbody2Ds.Count; i++)
        {
            rigidbody2Ds[i].transform.position += delta;
        }
        transform.position = newPosition;
    }

    public void SwitchOn()
    {
        if (mode == SwitchMode.OnAndOff)
        {
            enabled = true;
        }
        else
        {
            headToDestination = true;

            moveTimer.Reset(1 - moveTimer.Progress, true);
            moveTimer.Running = true;
        }
    }

    public void SwitchOff()
    {
        if (mode == SwitchMode.OnAndOff)
        {
            enabled = false;
        }
        else
        {
            headToDestination = false;
            moveTimer.Reset(1 - moveTimer.Progress, true);
            moveTimer.Running = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.DrawSphere(destination, 0.1f);
        Gizmos.DrawLine(destination, transform.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2Ds.Add(collision.rigidbody);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        rigidbody2Ds.Remove(collision.rigidbody);
    }
}
