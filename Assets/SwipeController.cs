using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializedField] Vector3 pageStep;
    [SerializedField] RectTransform levelPagesRect;

    [SerializedField] float tweenTime;
    [SerializedField] LeanTweenType tweenType;


    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
     }


    public void Next()
    {
         if(currentPage<maxPage)  
         {
         currentPage++;
         targetPos += pageStep;
         MovePage;
         }
    }

    public void Previous()
    {
       if(currentPage > 1)
       {
        currentPage--;
        targetPos-=pageStep;
        MovePage;
       }
    }


    void MovePage()
    {
       levelPagesRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);

    }
}
