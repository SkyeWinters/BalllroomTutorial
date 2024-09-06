using System.Collections.Generic;
using UnityEngine;

public class TextLineRenderer : MonoBehaviour
{
    [SerializeField] TextLineCharacter characterPrefab;
    [SerializeField] string message;
    [SerializeField] float minDistance;

    private List<TextLineCharacter> text;
    private Vector3 lastPosition;
    private int index;
    private int messageIndex;

    private void Awake()
    {
        text = new List<TextLineCharacter>();

        for (int i = 0; i < 30; i++)
        {
            text.Add(Instantiate(characterPrefab, transform.parent));
            text[i].Hide();
        }

        lastPosition = transform.position;
        index = 0;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, lastPosition) < minDistance) return;

        text[index].Display(message[messageIndex].ToString(), transform.position);
        index = (index + 1) % text.Count;
        messageIndex = (messageIndex + 1) % message.Length;
        lastPosition = transform.position;
    }
}
