using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NameInfo : MonoBehaviour
{
    [SerializeField] GameObject info;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveDistance = 100f;
    [SerializeField] Vector2 openPosition;
    [SerializeField] Vector2 originalPosition;
    [SerializeField] Vector2 nextPosition;
    void Awake()
    {
        originalPosition = (Vector2)info.transform.position;
        openPosition = new Vector2(info.transform.position.x - 350f, info.transform.position.y);
        nextPosition = originalPosition;
    }
    public void moveInfo()
    {
        if (nextPosition == originalPosition)
        {
            nextPosition = openPosition;
        } else if (nextPosition == openPosition)
        {
            nextPosition = originalPosition;
        }
    }
    void Update()
    {
        info.transform.position = Vector2.Lerp(info.transform.position, nextPosition, moveSpeed * Time.deltaTime);
    }
}
