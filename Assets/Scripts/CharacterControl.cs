using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public static string JUMP = "Jump";
    Rigidbody2D rb;
    private float forceJump = 350f;
    private float forceHorizontal = 500f;
    private Vector2 directionHorizontal = Vector2.zero;

    public Transform pointItemAhead;
    public Transform pointItemBehind;
    public Animator animator;
    [SerializeField]
    public GameObject itemRocket;
    public GameObject itemPinWheel;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal();
        updateReachBound();
        updateFace();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(LayerMask.LayerToName(other.gameObject.layer).Equals("Platform")) {
            jumpUp();
        }
    }

    public void jumpUp() {
        rb.AddForce(new Vector2(0, forceJump));
    }

    public void moveHorizontal () {
        if(directionHorizontal == Vector2.zero) {
            return;
        }
        rb.AddForce(new Vector2(directionHorizontal.x * forceHorizontal * Time.deltaTime, 0));
    }

    public void setDirectionHorizontal (Vector2 dir) {
        directionHorizontal = dir;
    }

    public void excuteRocket() {
        GameObject item = Instantiate(itemRocket, pointItemBehind.position, Quaternion.identity);
        item.transform.parent = pointItemBehind;
        item.GetComponent<ItemRocket>().excute();
    }

    public void excutePinWheel () {
        GameObject item = Instantiate(itemPinWheel, pointItemAhead.position, Quaternion.identity);
        item.transform.parent = pointItemAhead;
        item.GetComponent<ItemPinWheel>().excute();
    }


    public void updateReachBound() {
        if(Mathf.Abs(transform.position.x) >= CameraFollow.width / 2 + 0.1f){
            transform.position = new Vector2(-(transform.position.x), transform.position.y);
        }
    }

    public void updateFace() {
        if(directionHorizontal.x > 0) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        if(directionHorizontal.x < 0) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
