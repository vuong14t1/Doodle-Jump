using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBroken : MonoBehaviour
{
    private static string KEY_ANIMATION_RUN = "Run";
    private float timeOut = 1f;
    private Rigidbody2D rigidbody;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool(KEY_ANIMATION_RUN, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void broken() {
        Debug.Log("vao day broken");
        animator.SetBool(KEY_ANIMATION_RUN, true);
        StartCoroutine(finishBroken());
    }

    IEnumerator finishBroken() {
        yield return new WaitForSeconds(0.05f);
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(timeOut);
        gameObject.SetActive(false);
    }

    public void reset () {
        GetComponent<BoxCollider2D>().enabled = true;
        gameObject.SetActive(true);
        animator.SetBool(KEY_ANIMATION_RUN, false);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(LayerMask.LayerToName(other.gameObject.layer).Equals("Character")) {
            broken();
        }
    }
}
