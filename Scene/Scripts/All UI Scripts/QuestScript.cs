using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestScript : MonoBehaviour
{
   public void StartQuest()
    {
        SceneManager.LoadScene(1); //Числа изменяюся соотвественно выбранному квесту
        
    }
}
