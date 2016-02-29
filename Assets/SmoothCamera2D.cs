using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {
    private Transform player;
    public float rightBound;
    public float leftBound;
    public float topBound;
    public float bottomBound;
    // Use this for initialization
    void Start () {
        //set rightBounds
        //leftBound
        //topBound
        //bottomBound
        player = GameObject.Find("OwlSprite").transform;
     }
    void Update() {
        Vector3 playerpos= player.position;
        playerpos.z = transform.position.z;
        transform.position = playerpos;
    }
    // Update is called once per frame
}