using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject questionPanel;
    public TextMeshProUGUI questionText;
    public Button[] answerButtons;
    public Question[] questions;

    int currentQuestion;

    public void OpenQuestion()
    {
        questionPanel.SetActive(true);
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

            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = q.answers[i];

            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int index)
    {
        if (index == questions[currentQuestion].correctAnswer)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        questionPanel.SetActive(false);
    }
}