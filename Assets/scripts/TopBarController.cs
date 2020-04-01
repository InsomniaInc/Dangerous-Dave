using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopBarController : MonoBehaviour
{
    private Sprite[] DIGITS = new Sprite[10];
    private Image[] Score = new Image[5], Level = new Image[2], Lives = new Image[3];  
    // Start is called before the first frame update
    void Start()
    {
        #region load digit sprites to DIGITS

        for (int i = 0; i < 10; i++)
        {
            DIGITS[i] = Resources.Load<Sprite>("sprites/" + i);
        }

        #endregion

        #region Initialize Score

        for (int i = 0; i < 5; i++)
        {
            var gameObject = GameObject.Find("Score_Digit_" + i);
            Score[i] = gameObject.GetComponent<Image>();
        }

        #endregion

        #region Initialize Level

        for (int i = 0; i < 2; i++)
        {
            Level[i] = GameObject.Find("Level_Digit_" + i).GetComponent<Image>();
        }

        #endregion

        #region Initialize Lives

        for (int i = 0; i < 3; i++)
        {
            var gameObject = GameObject.Find("Daves_Life_" + i);
            Lives[i] = gameObject.GetComponent<Image>();
        }

        #endregion
    }

    public void setScore(int score)
    {
        int count = 0;
        do
        {
            int digit = score % 10;
            Score[count].sprite = DIGITS[digit];
            count++;
            score = score / 10;
        } while (score > 0 && count < 5);
    }

    public void setLevel(int level)
    {
        int count = 0;
        do
        {
            int digit = level % 10;
            Level[count].sprite = DIGITS[digit];
            count++;
            level = level / 10;
        } while (level > 0 && count < 2);
    }

    public void setRemainingLives(int lives)
    {
        for (int i = 0; i < lives; i++)
        {
            Lives[i].color = new Color(Lives[i].color.r, Lives[i].color.g, Lives[i].color.b, 1);
        }
        for (int i = lives; i < 3; i++)
        {
            Lives[i].color = new Color(Lives[i].color.r, Lives[i].color.g, Lives[i].color.b, 0);
        }
    }
}
