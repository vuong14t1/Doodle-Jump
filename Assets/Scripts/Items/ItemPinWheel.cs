using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPinWheel : MonoBehaviour
{
     public static string KEY_ANIMATION_RUN = "Run";
    public float speed = 500f;
    public float timeLive = 3f;
    [SerializeField]
    private Rigidbody2D rbCharacter;

    public Animator animator;
    public float originGravity;
    private void Awake() {
        CharacterControl character = GameObject.FindObjectOfType<CharacterControl>();
        rbCharacter = character.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originGravity = rbCharacter.gravityScale;
        Debug.Log("gravity aa " + originGravity);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void excute() {
        animator.SetBool(KEY_ANIMATION_RUN, true);
        rbCharacter.velocity = new Vector2(rbCharacter.velocity.x, 8f);
        rbCharacter.gravityScale = 0;
        StartCoroutine(stopExcute());

    }

    IEnumerator stopExcute() {
        yield return new WaitForSeconds(timeLive);
        rbCharacter.velocity = new Vector2(rbCharacter.velocity.x, 0);
        gameObject.SetActive(false);
        rbCharacter.gravityScale = originGravity;
    }
    public void reset() {
        animator.SetBool(KEY_ANIMATION_RUN, false);
    }
}
