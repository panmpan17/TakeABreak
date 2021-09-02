using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MPack;
using MPack.Aseprite;


public abstract class AbstractInteractableCaller : MonoBehaviour
{
    protected bool interacting;
    private List<IInteractble> interactbles = new List<IInteractble>();

    protected void CallInteractble()
    {
        for (int i = 0; i < interactbles.Count; i++)
        {
            interactbles[i].Interact();
        }
    }

    protected void CallHoldInteract()
    {
        for (int i = 0; i < interactbles.Count; i++)
        {
            interactbles[i].HoldInteract();
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Switch"))
        {
            IInteractble interact = collider.GetComponent<IInteractble>();
            interact.OnPlayerEnter();
            interactbles.Add(interact);
            collider.GetComponent<SpriteRenderer>().material.SetFloat("OutlineWidth", 0.04f);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Switch"))
        {
            IInteractble interact = collider.GetComponent<IInteractble>();
            interact.OnPlayerExit();
            interactbles.Remove(interact);
            collider.GetComponent<SpriteRenderer>().material.SetFloat("OutlineWidth", 0f);
        }
    }
}


public class PlayerControl : AbstractInteractableCaller
{
    public static PlayerControl ins;

    public Vector3 sitPositionOffsetToChair;
    private Transform m_collidingChair;
    private Transform m_ghostingChair;
    private bool m_inChair;

    public float walkAccelerate;
    public float maxWalkSpeed;
    public float jumpForce;
    public Timer keepJumpForcetimer;

    private GhostControl m_ghost;

    private Rigidbody2D m_rigidbody2D;
    private SmartBoxCollider m_smartCollider;
    private AseAnimator m_animator;

    private PlayerInput m_input;
    private float m_xAxis;
    public Timer jumpPressTimer;

    private bool m_interactPressed = false;
    private bool m_interactPressing = false;


    void Awake()
    {
        ins = this;

        m_smartCollider = GetComponent<SmartBoxCollider>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_ghost = FindObjectOfType<GhostControl>();
        m_animator = GetComponent<AseAnimator>();

        keepJumpForcetimer.Running = false;

        m_input = new PlayerInput();

        m_input.OnGround.Horizontal.started += HorizontalChanged;
        m_input.OnGround.Horizontal.performed += HorizontalChanged;
        m_input.OnGround.Horizontal.canceled += HorizontalChanged;

        m_input.OnGround.Jump.started += JumpButtonPressed;
        m_input.OnGround.Jump.canceled += JumpButtonReleased;
        jumpPressTimer.Running = false;

        m_input.OnGround.Interact.started += InteractButtonPressed;
        m_input.OnGround.Interact.canceled += InteractButtonReleased;
    }

    #region Input
    void OnEnable() {
        m_input.Enable();
    }
    void OnDisable() {
        m_input.Disable();
    }

    void HorizontalChanged(InputAction.CallbackContext callback) { m_xAxis = callback.ReadValue<float>(); }

    void JumpButtonPressed(InputAction.CallbackContext callback) { jumpPressTimer.Reset(); }
    void JumpButtonReleased(InputAction.CallbackContext callback) { jumpPressTimer.Running = false; }

    void InteractButtonPressed(InputAction.CallbackContext callback) { m_interactPressed = true; }
    void InteractButtonReleased(InputAction.CallbackContext callback) { m_interactPressing = false; }
    #endregion

    void Start()
    {
        m_ghost.gameObject.SetActive(false);
    }

    void Update()
    {
        if (m_ghostingChair)
        {
            transform.position = m_ghostingChair.position + sitPositionOffsetToChair;
            m_animator.Play(4);
            return;
        }

        if (m_interactPressed)
        {
            m_interactPressed = false;
            m_interactPressing = true;

            if (m_collidingChair)
            {
                m_ghostingChair = m_collidingChair;

                transform.position = m_ghostingChair.position + sitPositionOffsetToChair;
                m_rigidbody2D.simulated = false;
                m_inChair = true;

                m_input.Disable();

                m_ghost.transform.position = transform.position;
                m_ghost.gameObject.SetActive(true);
            }
            else
            {
                CallInteractble();
                interacting = true;
            }
        }
        else if (interacting && m_interactPressing)
        {
            CallHoldInteract();
        }

        HandleMovement();

        if (m_rigidbody2D.velocity.y >= 0.1f)
        {
            m_animator.Play(2);
        }
        else if(m_rigidbody2D.velocity.y <= -0.1f)
        {
            m_animator.Play(3);
        }
        else if (Mathf.Abs(m_rigidbody2D.velocity.x) >= 0.1f)
        {
            m_animator.Play(1);
        }
        else
        {
            m_animator.Play(0);
        }
    }

    private void HandleMovement()
    {
        Vector2 delta = m_rigidbody2D.velocity;

        // Handle horizontal movement
        delta.x = Mathf.Clamp(delta.x + (m_xAxis * walkAccelerate * Time.deltaTime), -maxWalkSpeed, maxWalkSpeed);

        if (m_smartCollider.LeftTouched && delta.x < 0) delta.x = 0;
        else if (m_smartCollider.RightTouched && delta.x > 0) delta.x = 0;

        if (delta.x > 0 && transform.localScale.x < 0) transform.localScale = new Vector3(1, 1, 1);
        else if (delta.x < 0 && transform.localScale.x > 0) transform.localScale = new Vector3(-1, 1, 1);

        // Handle jump movement
        if (jumpPressTimer.Running)
        {
            if (m_smartCollider.DownTouched)
            {
                delta.y = jumpForce;
                keepJumpForcetimer.Reset();
            }
            else if (jumpPressTimer.UpdateEnd)
            {
                jumpPressTimer.Running = false;
            }
        }
        if (keepJumpForcetimer.Running)
        {
            if (!jumpPressTimer.Running)
            {
                keepJumpForcetimer.Running = false;
                return;
            }
            if (keepJumpForcetimer.UpdateEnd)
            {
                keepJumpForcetimer.Running = false;
            }
            delta.y = jumpForce;
        }

        m_rigidbody2D.velocity = delta;
    }

    public void WakeUp()
    {
        m_ghostingChair = null;
        m_rigidbody2D.simulated = true;
        m_input.Enable();
    }

    public void ForceWakeUp()
    {
        m_ghost.ForceWakeUp();
        m_ghostingChair = null;
        m_rigidbody2D.simulated = true;
        m_input.Enable();
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);

        if (collider.CompareTag("Chair"))
        {
            m_collidingChair = collider.transform;
            collider.GetComponent<SpriteRenderer>().material.SetFloat("OutlineWidth", 0.04f);
        }
        if (collider.CompareTag("GetOutDoor"))
        {
            LevelsSceneManager.ins.NextLevel();
        }
    }

    protected override void OnTriggerExit2D(Collider2D collider)
    {
        base.OnTriggerExit2D(collider);

        if (collider.CompareTag("Chair"))
        {
            m_collidingChair = null;
            collider.GetComponent<SpriteRenderer>().material.SetFloat("OutlineWidth", 0f);
        }


        interacting = false;
    }

    // protected void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject)
    //     ForceWakeUp();
    // }
}
