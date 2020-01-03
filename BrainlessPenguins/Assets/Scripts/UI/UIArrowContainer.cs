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

        transform.GetChild(0).gameObject.GetComponent<UIArrowActionBtn>()._actionType = 0;
        transform.GetChild(0).gameObject.GetComponent<UIArrowActionBtn>()._param = -1;
        transform.GetChild(0).gameObject.GetComponent<UIArrowActionBtn>()._btnID = 0;

        transform.GetChild(1).gameObject.GetComponent<UIArrowActionBtn>()._actionType = 0;
        transform.GetChild(1).gameObject.GetComponent<UIArrowActionBtn>()._param = 1;
        transform.GetChild(1).gameObject.GetComponent<UIArrowActionBtn>()._btnID = 1;

        transform.GetChild(2).gameObject.GetComponent<UIArrowActionBtn>()._actionType = 2;
        transform.GetChild(2).gameObject.GetComponent<UIArrowActionBtn>()._param = 1;
        transform.GetChild(2).gameObject.GetComponent<UIArrowActionBtn>()._btnID = 2;

        transform.GetChild(3).gameObject.GetComponent<UIArrowActionBtn>()._actionType = 3;
        transform.GetChild(3).gameObject.GetComponent<UIArrowActionBtn>()._param = 1;
        transform.GetChild(3).gameObject.GetComponent<UIArrowActionBtn>()._btnID = 3;
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

    public void actionBtnOnClick(int number,int param,int btnID)
    {
        _instructionBtn.GetComponent<UIInstructionBtn>()._selfActionType = (Instruction.Action.ActionType)number;
        _instructionBtn.GetComponent<UIInstructionBtn>()._selfDirection.GetComponent<Image>().sprite = transform.GetChild(btnID).gameObject.GetComponent<Image>().sprite;
        _instructionBtn.GetComponent<UIInstructionBtn>()._actionParam = param;
        gameObject.SetActive(false);
    }
}
