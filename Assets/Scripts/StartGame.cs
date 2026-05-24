using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button ButtonUp;
    //public Button ButtonOpen;
    public Button ButtonDown;
    public Animator ElDoor1;
    public Animator ElDoor2;
    public GameObject StartPanel;
    public string NextSceneName;
    public string MainMenu;

    void Start()
    {
        if (ButtonUp != null)
        {
            ButtonUp.onClick.AddListener(OnUpClick);
        }
        if (ButtonDown != null)
        {
            ButtonDown.onClick.AddListener(OnDownClick);
        }
       // if (ButtonOpen != null)
        //{
            //ButtonOpen.onClick.AddListener(OnDownClick);
        //}
    }

    public void OnUpClick()
    {
        if (ElDoor1 != null && ElDoor2 != null)
        {
            ElDoor1.SetTrigger("Close");
            ElDoor2.SetTrigger("Close");
            StartCoroutine(ChangeScene());
        }
    }

    public void OnDownClick()
    {
        if (ElDoor1 != null && ElDoor2 != null)
        {
            ElDoor1.SetTrigger("Close");
            ElDoor2.SetTrigger("Close");
            StartCoroutine(MainMenuScene());
        }
    }

    public void OnOpenClick()
    {
        if (ElDoor1 != null && ElDoor2 != null && HasParameter(ElDoor1,"Close") && HasParameter(ElDoor2, "Close"))
        {
            ElDoor1.SetTrigger("Open");
            ElDoor2.SetTrigger("Open");
            StartCoroutine(CloseDoors());
        }
    }

    IEnumerator CloseDoors()
    {
        yield return new WaitForSeconds(5f);
        ElDoor1.SetTrigger("Close");
        ElDoor2.SetTrigger("Close");
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(NextSceneName);
        StartPanel.SetActive(false);
    }

    IEnumerator MainMenuScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadSceneAsync(MainMenu);
        StartPanel.SetActive(false);
    }
    private bool HasParameter(Animator animator, string paramName)
    {
        if (animator == null) return false;
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName) return true;
        }
        return false;
    }
}
