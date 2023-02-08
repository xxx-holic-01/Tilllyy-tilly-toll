using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gamesession : MonoBehaviour
{
    [SerializeField] int PlayerLives = 3;
    [SerializeField] int score =0;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI ScoreText;

    void Awake() 
    {
        
  int numOfGameSESS= FindObjectsOfType<gamesession>().Length;
  if(numOfGameSESS  > 1)
  {
    Destroy(gameObject);
  }
  else
  {
    DontDestroyOnLoad(gameObject);
  }
        
  }

void Start()
 {
   livesText.text = PlayerLives.ToString();
   ScoreText.text = score.ToString();

}

 public void ProcessPlayerDeath()
 {
    if(PlayerLives>1)
    {
        TakeaLife();
    }

    else
    {
        ResetGameSession();
       
    }
 }
   
void TakeaLife()
{
    PlayerLives --;
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
   livesText.text = PlayerLives.ToString();

}
 public void Score( int pointsToAdd)
{
  score +=  pointsToAdd;
  ScoreText.text = score.ToString();

}

   void ResetGameSession()
   {
    FindObjectOfType<scenePersist>().ResetScenePersist();
    SceneManager.LoadScene(0);
    Destroy(gameObject);
   }
    
}
