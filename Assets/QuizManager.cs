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

    [Header("Progress")]
    public int totalTrashcans = 9;
    private int completed = 0;

    [Header("Win UI")]
    public GameObject winPanel;

    private int currentQuestion;
    private int score = 0;
    private GameObject currentTrashcan;

    // 🎯 OPEN SPECIFIC QUESTION (called by trashcan)
    public void OpenSpecificQuestion(int index, GameObject trashcan)
    {
        currentTrashcan = trashcan;

        questionPanel.SetActive(true);
        resultText.gameObject.SetActive(false);

        currentQuestion = index;
        ShowQuestion();
    }

    // 📜 SHOW QUESTION
    void ShowQuestion()
    {
        Question q = questions[currentQuestion];

        questionText.text = q.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int idx = i;

            // Set answer text
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];

            // Reset color
            answerButtons[i].GetComponent<Image>().color = Color.white;

            // Reset listeners
            answerButtons[i].onClick.RemoveAllListeners();

            // Add click
            answerButtons[i].onClick.AddListener(() => CheckAnswer(idx));
        }
    }

    // ✅ CHECK ANSWER
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

            int correct = questions[currentQuestion].correctAnswer;
            answerButtons[correct].GetComponent<Image>().color = Color.green;
        }

        resultText.gameObject.SetActive(true);

        // 🗑️ REMOVE USED TRASHCAN
        if (currentTrashcan != null)
        {
            currentTrashcan.SetActive(false);
        }

        // 📊 TRACK PROGRESS
        completed++;
        CheckWin();

        StartCoroutine(CloseAfterDelay());
    }

    // ⏳ CLOSE PANEL AFTER DELAY
    IEnumerator CloseAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        questionPanel.SetActive(false);
    }

    // 🎉 WIN CHECK
    void CheckWin()
    {
        if (completed >= totalTrashcans)
        {
            winPanel.SetActive(true);
        }
    }
}