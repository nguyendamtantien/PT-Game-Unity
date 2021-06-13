using UnityEngine;
using System.Collections;

public class SpiderBullet : MonoBehaviour {
public GameObject effect;
public float speed = 10f;
void Update(){
	Vector3 pos = transform.position;
	Vector3 velocity = new Vector3(0,speed*Time.deltaTime,0);
	pos += transform.rotation*velocity;
	transform.position = pos;
}// ham nay them cua thay
	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			// GameObject.Find("Gameplay Controller").GetComponent<GameplayController>().PlayerDied();
			Destroy(target.gameObject);
			Destroy(gameObject);
			GameObject effectSpawn = (GameObject)Instantiate(effect, target.transform.position, target.transform.rotation);
			Destroy(effectSpawn,1f);
		}

		if (target.gameObject.tag == "Grounds") {
			Destroy(gameObject);
		}//vien dan tu huy khi cham vao dat
	}

}
