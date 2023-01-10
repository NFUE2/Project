using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Variable
    string[] Scenelist = { "Mainmenu", "World", "Ingame", "Loading" };
    string prev_scene;

    public GameObject ExitButton;
    public GameObject ChangeButton;
    public Image LoadingBar;

    public List<Vector3> NodeList;

    #endregion Variable

    private static GameManager instance = null;
    public static GameManager GetInstance { get { return instance; } } 

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    private void Update()
    {
        //esc누를때의 작동
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

    public bool NodeCheck(Vector3 Pos) {  return NodeList.Contains(Pos); }

    #region SceneControl

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name != Scenelist[3])
        {
            if (SceneManager.GetActiveScene().name == Scenelist[1] && GameObject.Find("CloseNode").activeSelf && NodeList.Count == 0)
                for (int i = 0; i < GameObject.Find("CloseNode").transform.childCount; i++)
                    NodeList.Add(GameObject.Find("CloseNode").transform.GetChild(i).position);

            if(GameObject.Find("SceneChangeButton") != null)
            {
                ChangeButton = GameObject.Find("SceneChangeButton");
                ChangeButton.GetComponent<Button>().onClick.AddListener(ChangeScene);

                if (SceneManager.GetActiveScene().name != Scenelist[0])
                    ChangeButton.SetActive(false);
            }
        }
        else
            StartCoroutine(LoadScene());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //씬을 변경하는 함수
    public void ChangeScene()
    {
        if(SceneManager.GetActiveScene().name == Scenelist[0])
            SceneManager.LoadScene(Scenelist[1]);

        else if(SceneManager.GetActiveScene().name == Scenelist[1])
        {
            prev_scene = Scenelist[1];
            SceneManager.LoadScene(Scenelist[3]);
        }

        else if (SceneManager.GetActiveScene().name == Scenelist[2])
        {
            prev_scene = Scenelist[2];
            SceneManager.LoadScene(Scenelist[3]);
        }
    }

    //로딩씬 작동
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.0f);
        string next_scene = prev_scene == Scenelist[1] ? Scenelist[2] : Scenelist[1];

        AsyncOperation asyn = SceneManager.LoadSceneAsync(next_scene);
        LoadingBar = GameObject.Find("Bar").GetComponent<Image>();
        asyn.allowSceneActivation = false;

        float Loadingtime = 0.0f;

        while (!asyn.isDone)
        {
            yield return null;

            if (asyn.progress < 0.9f)
                LoadingBar.fillAmount = asyn.progress;
            else
            {
                Loadingtime += Time.deltaTime;
                LoadingBar.fillAmount = Mathf.Lerp(LoadingBar.fillAmount, 1.0f, Loadingtime);
                if (LoadingBar.fillAmount >= 1.0f)
                {
                    asyn.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
    #endregion SceneControl

    //게임종료
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
