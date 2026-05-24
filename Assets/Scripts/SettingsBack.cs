using UnityEngine;
using UnityEngine.UI;

public class SettingsBack : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject SettingsPanel;
    public Button ButtonBack;

    void Update()
    {
        ButtonBack.onClick.AddListener(OnBackClick);
    }

    public void OnBackClick()
    {
        MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }
}
