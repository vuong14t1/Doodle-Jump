using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static float height;
    public static float width;
    private void Awake() {
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }
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
        }
    }
}
