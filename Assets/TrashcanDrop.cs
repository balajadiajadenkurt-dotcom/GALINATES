using UnityEngine;
using UnityEngine.EventSystems;

public class TrashcanDrop : MonoBehaviour, IDropHandler
{
    public int answerIndex;
    public QuizManager quizManager;

    public void OnDrop(PointerEventData eventData)
    {
        quizManager.SendMessage("CheckAnswer", answerIndex);
    }
}