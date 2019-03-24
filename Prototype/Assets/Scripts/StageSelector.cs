using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour {

    [SerializeField]
    GameObject[] zodiacSigns;
    int zodiacIndex;

    [SerializeField]
    GameObject canvas;

    [SerializeField]
    GameObject cursor;

    GameObject cursorClone;

    // Use this for initialization
    void Start()
    {
        cursorClone = (GameObject)Instantiate(cursor, transform);
    }
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            zodiacIndex--;
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            zodiacIndex++;
        }

        if(zodiacIndex < 0)
        {
            zodiacIndex = 11;
        }

        else if (zodiacIndex > 11)
        {
            zodiacIndex = 0;
        }

        if(zodiacIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if(zodiacIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if (zodiacIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if (zodiacIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if (zodiacIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if (zodiacIndex == 5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if (zodiacIndex == 6)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if (zodiacIndex == 7)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if (zodiacIndex == 8)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if (zodiacIndex == 9)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }

        else if (zodiacIndex == 10)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }
        cursorClone.transform.SetParent(zodiacSigns[zodiacIndex].transform, false);

    }
}
