using TMPro;
using UnityEngine;

public class TextLineCharacter : MonoBehaviour
{
    [SerializeField] TMP_Text characterDisplay;

    private Vector3 position;
    private Quaternion rotation;

    public void Display(string character, Vector3 position)
    {
        gameObject.SetActive(true);
        characterDisplay.text = character;
        transform.position = position;
        this.position = position;
        rotation = transform.rotation;
        characterDisplay.color = GenerateRandomLightColor();
    }

    private void Update()
    {
        transform.position = position;
        var temp = Camera.main.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(temp);
        characterDisplay.transform.localPosition = Vector3.zero;
        characterDisplay.transform.localEulerAngles = new Vector3(0, 180, 0);
    }

    private Color GenerateRandomLightColor()
    {
        // Generate random RGB values in the light color range
        float r = Random.Range(0.7f, 1f); // Higher range for lightness
        float g = Random.Range(0.7f, 1f);
        float b = Random.Range(0.7f, 1f);

        return new Color(r, g, b);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}