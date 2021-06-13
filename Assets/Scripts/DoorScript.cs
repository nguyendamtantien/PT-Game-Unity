
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour {


public static DoorScript Instance;
public GameObject exit;
private Animator anim;
private BoxCollider2D box;
private int Score = 0;
public Text txtScore;

[HideInInspector]
public int CollectablesCount;
// Use this for initialization
void Awake () {
if (Instance == null)
Instance = this;
anim = GetComponent<Animator>();
box = GetComponent<BoxCollider2D>();
}

IEnumerator DoorOpen()
{
box.isTrigger = true;
anim.Play("Door_Open");
yield return new WaitForSeconds(0.1f);
//ong thu mo len tui xem  mo gi cái open dó là gọi animation tên đó hả mà đặt tên ở đâu =))

}

public void DecrementCollectables()
{
CollectablesCount--;
Score++;
txtScore.text = "Score: " + Score;
if(CollectablesCount==0)
{
StartCoroutine(DoorOpen());
}
}

private void OnTriggerEnter2D(Collider2D collision)
{
if(collision.gameObject.tag =="Player")
{
Destroy(collision.gameObject);
Destroy(Instantiate(exit, collision.transform.position, Quaternion.identity),1f );
}
}
// Update is called once per frame
void Update () {

}
}