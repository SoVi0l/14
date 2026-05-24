using UnityEngine;
using TMPro; 
public class RandomNote : MonoBehaviour
{
    [Header("Список возможных текстов для записки")]
    [TextArea(3, 5)]
    public string[] possibleTexts = new string[5];

    [Header("Ссылка на TextMeshPro на листке")]
    public TextMeshProUGUI textComponent;

    private string myFinalText;

    void Start()
    {
        if (possibleTexts.Length > 0)
        {
            int randomIndex = Random.Range(0, possibleTexts.Length);
            myFinalText = possibleTexts[randomIndex];
        }
        else
        {
            myFinalText = "Эта записка пуста...";
        }

        if (textComponent != null)
        {
            textComponent.text = myFinalText;
        }
        else
        {
            Debug.LogError("ВНИМАНИЕ: На записке не найдена ссылка на TextMeshProUGUI!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainCamera"))
        {
            ShowNote();
        }
    }

    void ShowNote()
    {
        Debug.Log($"[ИГРОК ЧИТАЕТ ЗАПИСКУ]: {myFinalText}");

    }
}