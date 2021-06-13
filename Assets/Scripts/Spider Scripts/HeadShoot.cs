using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShoot : MonoBehaviour
{
    [SerializeField]
    public GameObject bullet;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
        //  StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("Player");
            if(go != null)
            {
                player = go.transform;
            }
        }
        if (player != null && Vector3.Distance(transform.position,player.position)<5)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1,3));
        Instantiate(bullet,transform.position, transform.rotation);
        //  StartCoroutine(Attack());
        
    }
}
