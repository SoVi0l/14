using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class OpenMenuPanel : MonoBehaviour
{
    public GameObject MenuPanel;
    
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        if (interactable == null)
            interactable = gameObject.AddComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(_ => OpenWindow());
    }

    void OpenWindow()
    {
        if (MenuPanel!=null)
        {
            MenuPanel.SetActive(true);
        }
    }
}
