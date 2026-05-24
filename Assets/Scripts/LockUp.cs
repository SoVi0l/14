using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LockUp : MonoBehaviour
{
    public Animator Closet;

    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        if (interactable == null)
            interactable = gameObject.AddComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(_ => Lock_Up());
    }

    void Lock_Up()
    {
        if (Closet != null)
        {
            Closet.SetTrigger("LockUp");
        }
    }
}
