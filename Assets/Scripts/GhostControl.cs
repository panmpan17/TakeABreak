using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPack;
using UnityEngine.InputSystem;


public class GhostControl : AbstractInteractableCaller
{
    public float moveSpeed;
    public float maxMoveSpeed;

    private PlayerControl playerControl;

    private Transform chair;

    private new Rigidbody2D rigidbody2D;
    private SmartBoxCollider smartCollider;

    private PlayerInput m_input;
    private Vector2 m_movement;

    private bool m_interactPressed = false;
    private bool m_interactPressing = false;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        smartCollider = GetComponent<SmartBoxCollider>();
        playerControl = FindObjectOfType<PlayerControl>();

        m_input = new PlayerInput();

        m_input.InTheAir.Delta.started += DeltaChanged;
        m_input.InTheAir.Delta.performed += DeltaChanged;
        m_input.InTheAir.Delta.canceled += DeltaChanged;

        m_input.InTheAir.Interact.started += InteractButtonPressed;
        m_input.InTheAir.Interact.canceled += InteractButtonReleased;
    }

    #region Input
    void OnEnable() { m_input.Enable(); }
    void OnDisable() { m_input.Disable(); }

    void DeltaChanged(InputAction.CallbackContext callback) { m_movement = callback.ReadValue<Vector2>(); }

    void InteractButtonPressed(InputAction.CallbackContext callback) { m_interactPressed = true; }
    void InteractButtonReleased(InputAction.CallbackContext callback) { m_interactPressing = false; }
    #endregion

    void Update()
    {
        if (m_interactPressed)
        {
            m_interactPressed = false;
            m_interactPressing = true;

            if (chair)
            {
                rigidbody2D.velocity = Vector2.zero;
                gameObject.SetActive(false);

                playerControl.WakeUp();
                m_input.Disable();
            }
            else
            {
                CallInteractble();
            }
        }
        else if (m_interactPressing)
        {
            CallHoldInteract();
        }

        Vector2 delta = rigidbody2D.velocity;

        delta += m_movement * moveSpeed * Time.deltaTime;

        delta.x = Mathf.Clamp(delta.x, -maxMoveSpeed, maxMoveSpeed);
        delta.y = Mathf.Clamp(delta.y, -maxMoveSpeed, maxMoveSpeed);

        if (smartCollider.LeftTouched && delta.x < 0) delta.x = 0;
        else if (smartCollider.RightTouched && delta.x > 0) delta.x = 0;
        if (smartCollider.UpTouched && delta.y > 0) delta.y = 0;
        else if (smartCollider.DownTouched && delta.y < 0) delta.y = 0;

        if (delta.x > 0 && transform.localScale.x < 0) transform.localScale = new Vector3(1, 1, 1);
        else if (delta.x < 0 && transform.localScale.x > 0) transform.localScale = new Vector3(-1, 1, 1);

        rigidbody2D.velocity = delta;
    }

    public void ForceWakeUp()
    {
        rigidbody2D.velocity = Vector2.zero;
        gameObject.SetActive(false);
        m_input.Disable();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);

        if (collider.CompareTag("Chair"))
        {
            chair = collider.transform;
            collider.GetComponent<SpriteRenderer>().material.SetFloat("OutlineWidth", 0.04f);
        }
    }

    protected override void OnTriggerExit2D(Collider2D collider)
    {
        base.OnTriggerExit2D(collider);

        if (collider.CompareTag("Chair"))
        {
            chair = null;
            collider.GetComponent<SpriteRenderer>().material.SetFloat("OutlineWidth", 0f);
        }
    }
}
