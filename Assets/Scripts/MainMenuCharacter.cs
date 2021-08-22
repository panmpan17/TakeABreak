using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPack;
using MPack.Aseprite;


public class MainMenuCharacter : MonoBehaviour
{
    public Vector3LerpTimer vector3Lerp;
    private AseAnimator animator;

    public Timer awakeAnimTimer;

    void Awake()
    {
        animator = GetComponent<AseAnimator>();
        vector3Lerp.Timer.Running = false;
        awakeAnimTimer.Running = false;
    }

    void Update()
    {
        if (awakeAnimTimer.Running)
        {
            if (awakeAnimTimer.UpdateEnd)
            {
                animator.Play(1);
                vector3Lerp.Timer.Running = true;
                awakeAnimTimer.Running = false;
            }
        }

        if (vector3Lerp.Timer.Running)
        {
            if (vector3Lerp.Timer.UpdateEnd)
            {
                LevelsSceneManager.ins.StartGame();
                enabled = false;
            }

            transform.position = vector3Lerp.Value;
        }
    }

    public void TurnOn()
    {
        awakeAnimTimer.Running = true;
        animator.Play(2);
        // vector3Lerp.Timer.Running = true;
    }
}
