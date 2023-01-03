using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Variable
    string[] Scenelist = { "Mainmenu", "World", "Ingame", "Loading" };
    string prev_scene;
    public GameObject ExitButton;
    public GameObject ChangeButton;
    #endregion Variable

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == Scenelist[0] && Input.GetKeyDown(KeyCode.Escape) && !ExitButton.activeSelf)
        {
            ChangeButton.SetActive(false);
            ExitButton.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == Scenelist[0] && Input.GetKeyDown(KeyCode.Escape) && ExitButton.activeSelf)
        {
            ChangeButton.SetActive(true);
            ExitButton.SetActive(false);
        }
    }

    public void ChangeScene()
    {
        if(SceneManager.GetActiveScene().name == Scenelist[0])
            SceneManager.LoadScene(Scenelist[1]);

        else if(SceneManager.GetActiveScene().name == Scenelist[1])
        {
            SceneManager.LoadScene(Scenelist[3]);
            prev_scene = Scenelist[1];
        }

        else if (SceneManager.GetActiveScene().name == Scenelist[2])
        {
            SceneManager.LoadScene(Scenelist[3]);
            prev_scene = Scenelist[2];
        }

        else if(SceneManager.GetActiveScene().name == Scenelist[3] && prev_scene == Scenelist[1])
            SceneManager.LoadScene(Scenelist[2]);

        else if(SceneManager.GetActiveScene().name == Scenelist[3] && prev_scene == Scenelist[2])
            SceneManager.LoadScene(Scenelist[1]);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
