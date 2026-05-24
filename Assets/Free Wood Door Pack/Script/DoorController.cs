using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleDoor() // Этот метод можно вызвать прямо из инспектора
    {
        bool isOpen = animator.GetBool("isOpen");
        animator.SetBool("isOpen", !isOpen);
    }
}
