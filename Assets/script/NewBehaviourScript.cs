using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEfect;

    
    private void Start()
    {
       startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void Update()
    {
        float temp = (cam.transform.position.x *(1 - parallaxEfect));

        float dist = (cam.transform.position.x * parallaxEfect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }

    

}