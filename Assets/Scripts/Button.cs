using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPack;
using UnityEngine.Events;

public class Button : MonoBehaviour, IInteractble
{
    public Sprite pressedSprite;
    private Sprite unpressedSprite;

    public Timer stayOnTimer;

    private SpriteRenderer spriteRenderer;

    public UnityEvent onEvent;
    public UnityEvent offEvent;

    // public bool continus;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        unpressedSprite = spriteRenderer.sprite;
        stayOnTimer.Running = false;
    }

    void Update()
    {
        // if (continus)
        // {
        //     if (!Input.GetKey(KeyCode.E))
        //     {
        //         spriteRenderer.sprite = unpressedSprite;
        //         offEvent.Invoke();
        //     }
        //     return;
        // }
        if (stayOnTimer.Running && stayOnTimer.UpdateEnd)
        {
            stayOnTimer.Running = false;
            spriteRenderer.sprite = unpressedSprite;
            offEvent.Invoke();
        }
    }

    public void Interact()
    {
        spriteRenderer.sprite = pressedSprite;

        if (!stayOnTimer.Running) onEvent.Invoke();
        stayOnTimer.Reset();
        GetComponent<AudioSource>().Play();
    }

    public void HoldInteract() {
        stayOnTimer.Reset();
    }
    public void OnPlayerEnter() { }
    public void OnPlayerExit() { }
}
