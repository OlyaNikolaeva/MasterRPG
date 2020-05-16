using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
   
        public bool pause = false;
        public GameObject PauseUI;

      public void Update()

     {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Resume();
            }
            else
            {
                PauseUp();
            }
        }


     }
     public void PauseUp() // Пауза

     {
        PauseUI.SetActive(true);

        Time.timeScale = 0f;
        pause = true;
     }
      public void Resume()  // Продолжить
      {
              PauseUI.SetActive(false);

              Time.timeScale = 1f;
              pause = false;
      }
       public void BackToMenu() // Вернутся в меню
        {
              Time.timeScale = 1f;
              SceneManager.LoadScene(2); // В билде на чьем компе мы будем собирать игру сцена с другим номером
        }
       public void BackToStart() // Вернутся к началу квеста
       {
            
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
       }
        public void BackToGildia() // Вернуться в гильдию
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

     

}
