using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPack;


public class GhostControl : AbstractInteractableCaller
{
    public Vector2 moveSpeed;
    public Vector2 maxMoveSpeed;

    private PlayerControl playerControl;

    private Transform chair;

    private new Rigidbody2D rigidbody2D;
    private SmartBoxCollider smartCollider;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        smartCollider = GetComponent<SmartBoxCollider>();
        playerControl = FindObjectOfType<PlayerControl>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (chair)
            {
                rigidbody2D.velocity = Vector2.zero;
                gameObject.SetActive(false);

                playerControl.WakeUp();
            }
            else
            {
                CallInteractble();
            }
        }
        else if (Input.GetKey(KeyCode.E))
        {
            CallHoldInteract();
        }

        Vector2 delta = rigidbody2D.velocity;

        if (Input.GetKey(KeyCode.A)) delta.x -= moveSpeed.x * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) delta.x += moveSpeed.x * Time.deltaTime;

        if (delta.x > maxMoveSpeed.x) delta.x = maxMoveSpeed.x;
        if (delta.x < -maxMoveSpeed.x) delta.x = -maxMoveSpeed.x;

        if (delta.x > 0 && transform.localScale.x < 0) transform.localScale = new Vector3(1, 1, 1);
        if (delta.x < 0 && transform.localScale.x > 0) transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.W)) delta.y += moveSpeed.y * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) delta.y -= moveSpeed.y * Time.deltaTime;

        if (delta.y > maxMoveSpeed.y) delta.y = maxMoveSpeed.y;
        if (delta.y < -maxMoveSpeed.y) delta.y = -maxMoveSpeed.y;

        if (smartCollider.LeftTouched && delta.x < 0) delta.x = 0;
        if (smartCollider.RightTouched && delta.x > 0) delta.x = 0;
        if (smartCollider.UpTouched && delta.y > 0) delta.y = 0;
        if (smartCollider.DownTouched && delta.y < 0) delta.y = 0;

        rigidbody2D.velocity = delta;
    }

    public void ForceWakeUp()
    {
        rigidbody2D.velocity = Vector2.zero;
        gameObject.SetActive(false);
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
