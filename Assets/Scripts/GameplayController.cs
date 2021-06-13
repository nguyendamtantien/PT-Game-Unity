using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameplayController : MonoBehaviour
{
    public GameObject pausePannel;
    public Button ButtonResume;
    public void PlayerDie()
    {
        pausePannel.SetActive(true);
    }
    public void ResumeGame()
    {
        pausePannel.SetActive(false);
        Application.LoadLevel("GameScene");
    }
}
