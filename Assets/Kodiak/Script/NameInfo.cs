using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;

public class NameInfo : MonoBehaviour
{
    [SerializeField] GameObject[] nameSlides;
    [SerializeField] int currentSlide;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Transform openPosition;
    [SerializeField] Transform closedPosition;

    //Chsnge current slide Public
    private void MoveSlide(Transform slide, Transform targetPosition)
    {
        slide.position = Vector2.Lerp(slide.position, targetPosition.position, moveSpeed);
    }
    public void ChangeCurrentSlide(int newSlide)
    {
        if (currentSlide != -1)
        {
            MoveSlide(nameSlides[currentSlide].transform, closedPosition);
        }
        if (currentSlide != newSlide)
        {
            MoveSlide(nameSlides[newSlide].transform, openPosition);
            currentSlide = newSlide;
        }
        else
        {
            currentSlide = -1;
        }
    }
}
