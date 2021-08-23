using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private Transform collidingChair;
    private Transform ghostingChair;
    private bool inChair;

    public float walkAccelerate;
    public float maxWalkSpeed;
    public float jumpForce;
    public Timer keepJumpForcetimer;

    private GhostControl ghost;

    private new Rigidbody2D rigidbody2D;
    private SmartBoxCollider smartCollider;
    private AseAnimator animator;


    private float originalGravityScale;

    void Awake()
    {
        ins = this;

        smartCollider = GetComponent<SmartBoxCollider>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        ghost = FindObjectOfType<GhostControl>();
        animator = GetComponent<AseAnimator>();

        originalGravityScale = rigidbody2D.gravityScale;
        keepJumpForcetimer.Running = false;
    }

    void Start()
    {
        ghost.gameObject.SetActive(false);
    }

    void Update()
    {
        if (ghostingChair)
        {
            transform.position = ghostingChair.position + sitPositionOffsetToChair;
            animator.Play(4);
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collidingChair)
            {
                ghostingChair = collidingChair;

                transform.position = ghostingChair.position + sitPositionOffsetToChair;
                rigidbody2D.simulated = false;
                // rigidbody2D.gravityScale = originalGravityScale;
                inChair = true;

                ghost.transform.position = transform.position;
                ghost.gameObject.SetActive(true);
            }
            else
            {
                CallInteractble();
                interacting = true;
            }
        }
        else if (interacting && Input.GetKey(KeyCode.E))
        {
            CallHoldInteract();
        }

        HandleMovement();

        if (rigidbody2D.velocity.y >= 0.3f)
        {
            animator.Play(2);
        }
        else if(rigidbody2D.velocity.y <= -0.3f)
        {
            animator.Play(3);
        }
        else if (Mathf.Abs(rigidbody2D.velocity.x) >= 0.1f)
        {
            animator.Play(1);
        }
        else
        {
            animator.Play(0);
        }
    }

    private void HandleMovement()
    {
        Vector2 delta = rigidbody2D.velocity;

        if (Input.GetKey(KeyCode.A)) delta.x -= walkAccelerate * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) delta.x += walkAccelerate * Time.deltaTime;
        if (delta.x > maxWalkSpeed) delta.x = maxWalkSpeed;
        else if (delta.x < -maxWalkSpeed) delta.x = -maxWalkSpeed;

        if (delta.x > 0 && transform.localScale.x < 0) transform.localScale = new Vector3(1, 1, 1);
        if (delta.x < 0 && transform.localScale.x > 0) transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space) && smartCollider.DownTouched)
        {
            delta.y = jumpForce;
            keepJumpForcetimer.Reset();
        }
        if (keepJumpForcetimer.Running)
        {
            if (!Input.GetKey(KeyCode.Space))
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

        if (smartCollider.LeftTouched && delta.x < 0) delta.x = 0;
        if (smartCollider.RightTouched && delta.x > 0) delta.x = 0;

        rigidbody2D.velocity = delta;
    }

    public void WakeUp()
    {
        ghostingChair = null;
        rigidbody2D.simulated = true;
        // rigidbody2D.gravityScale = 0;
    }

    public void ForceWakeUp()
    {
        ghost.ForceWakeUp();
        ghostingChair = null;
        rigidbody2D.simulated = true;
        // rigidbody2D.gravityScale = 0;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);

        if (collider.CompareTag("Chair"))
        {
            collidingChair = collider.transform;
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
            collidingChair = null;
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
