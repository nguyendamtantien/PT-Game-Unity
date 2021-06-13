using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    private Transform player;

	public float mixX, maxX;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			Vector3 temp = transform.position;
			temp.x = player.position.x;

			if(temp.x < mixX){
				temp.x = mixX;
			}

			if(temp.x > maxX){
				temp.x = maxX;
			}
			transform.position = temp;
		}
	}
}
