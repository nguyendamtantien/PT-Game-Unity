using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
   void Start () {
if (DoorScript.Instance != null)
DoorScript.Instance.CollectablesCount++;
}

private void OnTriggerEnter2D(Collider2D collision)
{
if(collision.gameObject.tag =="Player")
{
Destroy(gameObject);
if (DoorScript.Instance != null)
DoorScript.Instance.DecrementCollectables();

}
}
// Update is called once per frame cái cửa k triger vẫn đc à, cái code viết đụng tag player là đc k cần triger ok cảm ơn ông
void Update () {

}
}
