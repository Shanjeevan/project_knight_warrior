using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    public Image CursorImage;
    public GameObject CursorObject;
    public Sprite CursorBasic;
    public Sprite CursorHand;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CursorObject.transform.position = Input.mousePosition;
        if (Input.GetMouseButton(1))
        {
            CursorImage.sprite = CursorHand;
        }

        if (Input.GetMouseButtonUp(1))
        {
            CursorImage.sprite = CursorBasic;
        }
    }
}
