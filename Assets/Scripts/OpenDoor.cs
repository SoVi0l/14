using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator ElDoor1;
    public Animator ElDoor2;

    void Start()
    {
        ElDoor1.SetTrigger("Open");
        ElDoor2.SetTrigger("Open");
    }
}
