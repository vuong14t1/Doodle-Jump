using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [SerializeField]
    private Transform circle;
    [SerializeField]
    private Transform outerCircle;
    public float speed = 5f;
    private bool isTouched = false;
    Vector3 posStart;
    Vector3 posEnd;
    Vector2 posCamStart;

    CharacterControl character;

    // Start is called before the first frame update
    void Start()
    {
    
        VisibleUIJoystick(false);
        character =  GameObject.FindObjectOfType<CharacterControl>();
        // myPlane.SetDirection(new Vector2(0, 0));
        posStart = posEnd = new Vector2(0, 0);    
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    
    }

    public void Movement () {
        if(Input.GetMouseButtonDown(0)) {
            VisibleUIJoystick(true);
            isTouched = true;
            
            posStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            // Debug.Log("x " + posStart.x + "| y " + posStart.y + "|z " + posStart.z);
            Vector3 posWP = Camera.main.ScreenToWorldPoint(posStart);
            circle.localPosition = transform.InverseTransformPoint(new Vector3(posWP.x, posWP.y, 0));
            outerCircle.localPosition = transform.InverseTransformPoint(new Vector3(posWP.x, posWP.y, 0));
            // Debug.Log("wolde_x " + posWP.x + "| y " + posWP.y + "|z" + posWP.z);
            // Debug.Log("local_x " + outerCircle.localPosition.x + "| y " + outerCircle.localPosition.y + "|z" + outerCircle.localPosition.z);
        }
        if(Input.GetMouseButtonUp(0)) {
            isTouched = false;
            VisibleUIJoystick(false);
        
        }
        if(isTouched) {
            posEnd = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
    }

    private void FixedUpdate() {
        MovementJoystick();
    }

    public void MovementJoystick () {
        
        if(isTouched == false) {
            character.setDirectionHorizontal(new Vector2(0, 0));
            return;
        }
        Vector2 offset = Camera.main.ScreenToWorldPoint(posEnd) -  Camera.main.ScreenToWorldPoint(posStart);
        Vector2 direction = Vector2.ClampMagnitude(offset, 0.4f);
        character.setDirectionHorizontal(offset.normalized);
        Vector3 posWP = Camera.main.ScreenToWorldPoint(posStart);
        circle.localPosition = transform.InverseTransformPoint(new Vector3(posWP.x + direction.x, posWP.y + direction.y, 0));
    }

    public void VisibleUIJoystick (bool a) {
        circle.GetComponent<SpriteRenderer>().enabled = a;
        outerCircle.GetComponent<SpriteRenderer>().enabled = a;
    }

    public void movingJoystickByCamera (Vector2 pos) {
        
    }
}
