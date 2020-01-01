using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrowContainer : MonoBehaviour
{
    GameObject _instructionBtn;
    float _width;
    float _height;
    // Start is called before the first frame update
    void Start()
    {
        _width = gameObject.GetComponent<RectTransform>().rect.width;
        _height = gameObject.GetComponent<RectTransform>().rect.height;

        _width /= 2;
        _height /= 2;

        Debug.Log(_width);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true&&
            !(Input.mousePosition.x > gameObject.transform.position.x-_width&&
            Input.mousePosition.x<gameObject.transform.position.x+_width&&
            Input.mousePosition.y>gameObject.transform.position.y-_height&&
            Input.mousePosition.y<gameObject.transform.position.y+_height))
        {
            gameObject.SetActive(false);
        }
    }

    public void onClick()
    {
        Debug.Log(1);
    }
}
