using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    public Rigidbody2D r2;
    public float timedeplay = 2;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.CompareTag("Player")){
            StartCoroutine(fall());
        }
    }
    IEnumerator fall(){
        yield return new WaitForSeconds(timedeplay);
        r2.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
