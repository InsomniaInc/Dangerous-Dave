using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    public int score=100;
    public TopBarController topBarController;
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("dave"))
        {
            Debug.Log("Enteres" + this.gameObject.name);
            //scoreboard.updateScore(score);
            topBarController.addToScore(100);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
