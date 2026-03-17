using UnityEngine;

public class TrashcanInteraction : MonoBehaviour
{
    // Drag your "Press E" UI here
    public GameObject pressEUI;

    // Drag your question panel here
    public GameObject questionPanel;

    private bool playerNear = false;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (questionPanel != null)
            {
                questionPanel.SetActive(true);
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