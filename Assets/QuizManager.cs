using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject questionPanel;
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public TextMeshProUGUI resultText;

    [Header("Questions")]
    public Question[] questions;

    int currentQuestion;
    int score = 0;

    // 🔓 Called when pressing E near trashcan
    public void OpenQuestion()
    {
        questionPanel.SetActive(true);
        resultText.gameObject.SetActive(false);
        ShowQuestion();
    }

    void ShowQuestion()
    {
        currentQuestion = Random.Range(0, questions.Length);
        Question q = questions[currentQuestion];

        questionText.text = q.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;

            // Set answer text
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];

            // Reset color
            answerButtons[i].GetComponent<Image>().color = Color.white;

            // Remove old listeners
            answerButtons[i].onClick.RemoveAllListeners();

            // Add new listener
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    public void CheckAnswer(int index)
    {
        bool isCorrect = index == questions[currentQuestion].correctAnswer;

        if (isCorrect)
        {
            score += 10;
            resultText.text = "Correct!";
            answerButtons[index].GetComponent<Image>().color = Color.green;
        }
        else
        {
            resultText.text = "Wrong!";
            answerButtons[index].GetComponent<Image>().color = Color.red;

            // Highlight correct answer
            int correct = questions[currentQuestion].correctAnswer;
            answerButtons[correct].GetComponent<Image>().color = Color.green;
        }

        resultText.gameObject.SetActive(true);

        StartCoroutine(CloseAfterDelay());
    }

    IEnumerator CloseAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        questionPanel.SetActive(false);
    }
}