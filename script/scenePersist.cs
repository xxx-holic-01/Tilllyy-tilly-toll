using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenePersist : MonoBehaviour
{
    void Awake() 
    {
        
  int numOfScenePersist= FindObjectsOfType<scenePersist>().Length;
  if(numOfScenePersist  > 1)
  {
    Destroy(gameObject);
  }
  else
  {
    DontDestroyOnLoad(gameObject);
  }
        
  }

  public void ResetScenePersist()
  {
    Destroy(gameObject);
  }

}
