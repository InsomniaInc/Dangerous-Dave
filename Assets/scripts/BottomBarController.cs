using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBarController : MonoBehaviour
{
    public SpriteRenderer GoThroughTheDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGoThroughTheDoorMessage()
    {
        GoThroughTheDoor.color = new Color(GoThroughTheDoor.color.r, GoThroughTheDoor.color.g, GoThroughTheDoor.color.b,255);
    }
}
