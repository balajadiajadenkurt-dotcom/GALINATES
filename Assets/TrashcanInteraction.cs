using UnityEngine;

public class TrashcanInteraction : MonoBehaviour
{
    public GameObject pressEUI;
    public int questionIndex;

    public QuizManager quizManager;

    private bool playerNear = false;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (quizManager != null)
            {
                quizManager.OpenSpecificQuestion(questionIndex, gameObject);

                if (pressEUI != null) pressEUI.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            if (pressEUI != null) pressEUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            if (pressEUI != null) pressEUI.SetActive(false);
        }
    }
}