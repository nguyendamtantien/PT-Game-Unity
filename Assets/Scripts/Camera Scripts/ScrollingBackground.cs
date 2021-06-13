using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
   public float bgSpeed;
    public Renderer bgRend;
    // private Transform player;
    // Start is called before the first frame update
    // private void Awake()
    // {
    //     player = GameObject.Find("Player").transform;
    // }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0);
    }
}
// public float speed = 1f;
//     public Material mat;
//     private Vector2 offset = Vector2.zero;
//     private Transform player;
//     private void Awake()
//     {
//         mat = GetComponent<Renderer>().material;
//         player = GameObject.Find("Player").transform;
//     }
//     void Start()
//     {
//         offset = mat.GetTextureOffset("_MainTex");
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         offset = new Vector2(player.position.x, 0);
//         //offset.x -= speed * Time.deltaTime;
//         mat.SetTextureOffset("_MainTex", offset);
//     }
// }


