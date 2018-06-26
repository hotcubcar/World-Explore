using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform player;
    public float baseHeight;
    public float currentHeight = 0;
    public float speed;
    public AnimationCurve wave;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(player.transform.position.x, baseHeight + wave.Evaluate(currentHeight), player.transform.position.z);
        currentHeight += Time.deltaTime / speed;
	}
}
