using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cup : MonoBehaviour
{
    public Sprite[] sprites;
    private int i;
    private int size;
     private float nextActionTime = 0.0f;
     public float period = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        i=0;
        size = sprites.Length;
        Debug.Log("Sise is : "+size);
    }

    // Update is called once per frame
    void Update()
    {   
        if (Time.time > nextActionTime ) {
            nextActionTime += period;
            i=(i+1)%size;
            this.GetComponent<SpriteRenderer>().sprite = sprites[i];
        }
    }
}
