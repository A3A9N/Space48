using System.Collections;
using TMPro;
using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text messageField;

    public void ShowMessage(string message, float duration)
    {
        StartCoroutine(DisplayMessage(message, duration));
    }

    private IEnumerator DisplayMessage(string message, float duration)
    {
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(duration);
        messageField.enabled = false;
    }
}
