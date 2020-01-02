using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArrowContainer : MonoBehaviour
{
    public GameObject _instructionBtn;
    float _width;
    float _height;
    
    // Start is called before the first frame update
    void Start()
    {
        UIManager.GetInst().actionBtnClick += actionBtnOnClick;
        _width = gameObject.GetComponent<RectTransform>().rect.width;
        _height = gameObject.GetComponent<RectTransform>().rect.height;

        _width /= 2;
        _height /= 2;
        int i = 0;
        foreach(Transform child in transform)
        {
            child.gameObject.GetComponent<UIArrowActionBtn>()._actionType = i;
            i++;
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

    public void actionBtnOnClick(int number)
    {
        _instructionBtn.GetComponent<UIInstructionBtn>()._selfActionType = (Instruction.Action.ActionType)number;
        _instructionBtn.GetComponent<UIInstructionBtn>()._selfDirection.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
        gameObject.SetActive(false);
    }
}
