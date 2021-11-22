using UnityEngine.UI;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    GameObject canvas;
    Sprite cursor;

    [SerializeField]
    Sprite newCursor;
    [SerializeField]
    Vector3 scalaIcone;

    private void Start()
    {
        canvas = GameObject.Find("Canvas");

        cursor = canvas.transform.Find("CursorMouse").GetComponent<Image>().sprite;
        canvas.transform.Find("CursorMouse").GetComponent<Image>().sprite = cursor;
    }

    public void ChangeImage()
    {
        canvas.transform.Find("CursorMouse").GetComponent<Image>().sprite = newCursor;
        canvas.transform.Find("CursorMouse").GetComponent<RectTransform>().localScale = scalaIcone;
    }
    public void OriginalImage()
    {
        canvas.transform.Find("CursorMouse").GetComponent<Image>().sprite = cursor;
        canvas.transform.Find("CursorMouse").GetComponent<RectTransform>().localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }
}
