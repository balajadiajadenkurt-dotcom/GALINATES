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
    public int totalTrashcans = 10;
    private int completed = 0;

    [Header("Win UI")]
    public GameObject winPanel;

    private int currentQuestion;
    private int score = 0;
    private GameObject currentTrashcan;

    // 🔒 LOCK SYSTEM
    private bool answered = false;

    // 🎯 OPEN QUESTION
    public void OpenSpecificQuestion(int index, GameObject trashcan)
    {
        currentTrashcan = trashcan;

        questionPanel.SetActive(true);
        resultText.gameObject.SetActive(false);

        currentQuestion = index;

        // 🔓 RESET LOCK HERE
        answered = false;

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

            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];

            answerButtons[i].GetComponent<Image>().color = Color.white;

            answerButtons[i].onClick.RemoveAllListeners();

            answerButtons[i].onClick.AddListener(() => CheckAnswer(idx));
        }
    }

    // ✅ CHECK ANSWER
    public void CheckAnswer(int index)
    {
        // 🚫 PREVENT DOUBLE CLICK
        if (answered) return;
        answered = true;

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

        // 🗑️ REMOVE TRASHCAN
        if (currentTrashcan != null)
        {
            currentTrashcan.SetActive(false);
        }

        // 📊 PROGRESS
        completed++;
        CheckWin();

        StartCoroutine(CloseAfterDelay());
    }

    // ⏳ CLOSE PANEL
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