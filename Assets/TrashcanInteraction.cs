using UnityEngine;

public class TrashcanInteraction : MonoBehaviour
{
    public GameObject pressEUI;
    public int questionIndex;

    private bool playerNear = false;
    private QuizManager quizManager;

    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();

        if (pressEUI != null)
            pressEUI.SetActive(false);
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            // 🔊 Play open sound
            if (AudioManager.instance != null)
                AudioManager.instance.PlayTrashcan();
            // 🎯 Open specific question
            quizManager.OpenSpecificQuestion(questionIndex, gameObject);

            if (pressEUI != null)
                pressEUI.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (pressEUI != null)
                pressEUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (pressEUI != null)
                pressEUI.SetActive(false);
        }
    }
}