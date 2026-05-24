using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button ButtonStart;
    public Button ButtonSettings;
    public Button ButtonExit;
    public Animator ElDoor1;
    public Animator ElDoor2;
    public GameObject MenuPanel;
    public GameObject SettingsPanel;

    void Update()
    {
        ButtonStart.onClick.AddListener(OnStartClick);
    }

    public void OnStartClick()
    {
        if (ElDoor1 != null && ElDoor2 != null)
        {
            ElDoor1.SetTrigger("Open");
            ElDoor2.SetTrigger("Open");
            MenuPanel.SetActive(false);
        }
    }

    public void OnSettingsClick()
    {
        SettingsPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //в готовой сборке игры оставить только Application.Quit();
#else
        Application.Quit(); 
#endif
    }

    
}