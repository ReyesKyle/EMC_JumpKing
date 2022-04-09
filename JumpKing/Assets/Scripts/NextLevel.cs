using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    
    int sceneNum;
    int playerCheck = 0;


    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (playerCheck >= 1)
        {  
            if (sceneNum == 2)
            {
                Debug.Log("Game Finished!");
            }
            else
            {
                Debug.Log("Loaded Next Level");
                SceneManager.LoadScene(sceneNum + 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCheck++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerCheck--;
        }
    }
}
