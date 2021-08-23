using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface IInteractble {
    void Interact();
    void HoldInteract();
    void OnPlayerEnter();
    void OnPlayerExit();
}


public class Switch : MonoBehaviour, IInteractble
{
    public UnityEvent OnCallback;
    public UnityEvent OffCallback;

    public bool initialStatus;

    void Awake()
    {
        if (initialStatus)
        {
            Vector3 scale = transform.localScale;
            scale.y *= -1;
            transform.localScale = scale;
        }
    }

    public void Interact()
    {
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;

        if (scale.y > 0)
        {
            OffCallback.Invoke();
            GetComponent<AudioSource>().Play();
        }
        else
        {
            OnCallback.Invoke();
            GetComponent<AudioSource>().Play();
        }
    }

    public void HoldInteract() {}
    public void OnPlayerEnter() {}
    public void OnPlayerExit() { }
}
