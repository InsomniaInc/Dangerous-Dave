using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Jump
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.position = new Vector2(this.transform.position.x + moveSpeed * Time.deltaTime,this.transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.position = new Vector2(this.transform.position.x - moveSpeed * Time.deltaTime, this.transform.position.y);
        }
    }
}
