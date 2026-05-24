using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;


public class HomeDoorOpen : MonoBehaviour
{
    public Animator Door;

    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        if (interactable == null)
            interactable = gameObject.AddComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(_ => OpenDoor());
    }
    void OpenDoor()
    {
        if (Door != null)
        {
            Door.SetTrigger("Open");
            StartCoroutine(CloseDoor());
        }
    }
    IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(2f);
        Door.SetTrigger("Close");
    }
}
