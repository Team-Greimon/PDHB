using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        
        foreach(GameObject child in transform)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0) == true &&
                !(Input.mousePosition.x > gameObject.transform.position.x - _width &&
                Input.mousePosition.x < gameObject.transform.position.x + _width &&
                Input.mousePosition.y > gameObject.transform.position.y - _height &&
                Input.mousePosition.y < gameObject.transform.position.y + _height))
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void onClick()
    {

    }
}
