using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamSpider : MonoBehaviour
{
  [SerializeField]
    private GameObject SpiderShooter;
    
	// Use this for initialization
	void Start () {
        StartCoroutine(CreateSpider());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator CreateSpider()
    {
        yield return new WaitForSeconds(3);

        Vector2 temp = transform.position;
        // temp.y += Random.Range(-1, 1);
         
        Instantiate(SpiderShooter, temp, this.transform.rotation);

        StartCoroutine(CreateSpider());
    }
}
