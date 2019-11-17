using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSprings : MonoBehaviour
{
    private static string KEY_ANIMATION_RUN = "Run";
    private float forceJump = 600f;
    [SerializeField]
    public GameObject character;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(KEY_ANIMATION_RUN, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(LayerMask.LayerToName(other.gameObject.layer).Equals("Character")) {
            animator.SetBool(KEY_ANIMATION_RUN, true);
            character.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, forceJump));
        }   
    }
 
    public void reset () {
        animator.SetBool(KEY_ANIMATION_RUN, false);
    }
}
