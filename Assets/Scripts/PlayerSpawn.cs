using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    public Vector3 outsidePosition = new Vector3(0f,0.013f,0f);
    public Vector3 outsideRotation = new Vector3(0, 180, 0);
    public Vector3 insidePosition = new Vector3(0.5f, 0.013f, -0.5f);
    public Vector3 insideRotation = new Vector3(0, 180, 0);
    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        //if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex==0)
        if(currentScene == "MainMenu")
        {
            transform.position = outsidePosition;
            transform.eulerAngles = outsideRotation;
        }
        else
        {
            transform.position = insidePosition;
            transform.eulerAngles = insideRotation;
        }
    }
}
