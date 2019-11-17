using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHorizontal : MonoBehaviour
{
    private float speed = 50f;
    private Vector2 direction = Vector2.right;

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        checkReachBound();
        moveHorizontal();
    }

    public void moveHorizontal() {
        rb.velocity = direction * speed * Time.deltaTime;
    }

    public void reset() {
        direction = Random.Range(0, 1) == 1 ? Vector2.right: Vector2.left;
    }

    public void checkReachBound() {
        if(transform.position.x + spriteRenderer.bounds.size.x / 2 >= CameraFollow.width / 2) {
            direction = Vector2.left;
        }

        if(transform.position.x - spriteRenderer.bounds.size.x / 2 <= - CameraFollow.width / 2) {
            direction = Vector2.right;
        }
    }
}
