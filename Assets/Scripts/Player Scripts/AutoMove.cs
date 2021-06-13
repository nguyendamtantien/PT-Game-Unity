using System.Collections; 
using System.Collections.Generic;
using UnityEngine; 
public class AutoMove : MonoBehaviour 
{ 
    public float delta = 8.5f; 
    public float speed = 1.0f; 
    private Vector2 startPos; 
    void Start() 
    { 
        startPos = transform.position; 
        } 
    void Update() 
    { 
        Vector2 v = startPos; 
        v.x += delta * Mathf.Sin(Time.time * speed); 
        transform.position = v; 
    }
    }
