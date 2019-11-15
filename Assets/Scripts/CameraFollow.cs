using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followCharacter();
    }

    public void followCharacter() {
        if(character.position.y >= transform.position.y) {
            transform.position =  new Vector3(transform.position.x, character.position.y, transform.position.z);
            Debug.Log("vao day");
            // transform.Translate(Vector2.up, (character.position.y - transform.position));
        }
    }
}
