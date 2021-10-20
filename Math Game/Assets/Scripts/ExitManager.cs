using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour
{
    // Start is called before the first frame update
   private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0) //Main Menu
                Application.Quit();
            else
                SceneManager.LoadScene(0);
        }
    }
}
