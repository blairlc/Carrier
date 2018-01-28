using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Based on code from Unity's 2D Platformer tutorial.
// https://unity3d.com/learn/tutorials/topics/2d-game-creation/intro-and-session-goals?playlist=17093

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public float money = 0.0f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Inventory inventory;
    private Collider2D doorCollider;

    public Sprite letterSprite;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        inventory = GetComponent<Inventory>();
    }

    new void Update()
    {
        base.Update();

        if (Input.GetButtonDown("Fire1") && doorCollider != null)
        {
            // delivering letters
            Item letter = inventory.ContainsAddress(doorCollider.gameObject.tag);
            if (letter != null)
            {
                inventory.RemoveItem(letter);
            }
        }
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        // collecting money
        if (other.gameObject.CompareTag("Penny"))
        {
            other.gameObject.SetActive(false);
            GetComponent<Inventory>().AddMoney(.01f);
        }
        if (other.gameObject.CompareTag("Nickel"))
        {
            other.gameObject.SetActive(false);
            GetComponent<Inventory>().AddMoney(.05f);
        }
        if (other.gameObject.CompareTag("Dime"))
        {
            other.gameObject.SetActive(false);
            GetComponent<Inventory>().AddMoney(.1f);
        }
        if (other.gameObject.CompareTag("Quarter"))
        {
            other.gameObject.SetActive(false);
            GetComponent<Inventory>().AddMoney(.25f);
        }

        // store door to interact on keypress
        if (other.gameObject.tag.Contains("Door"))
        {
            doorCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // only store the door while the pigeon is in front of it
        if(collision.Equals(doorCollider))
        {
            doorCollider = null;
        }
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x < 0.01f) : (move.x > 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}