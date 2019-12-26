using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject _penguinBtn;
    public GameObject _instruction;
    public int _penguinCount = 4;
    public GameObject _penguinContainer;
    public GameObject _instructionContainer;
    public Sprite _penguinBtnClicked;
    public Sprite _penguinBtnUnClicked;
    GameObject[] _penguinBtnArray;
    bool[] _isClickedPenguinBtnArray;
    int currentSelectedPenguin = 0;

    public int _instructionNumber = 4;

    public delegate void PenguinBtnClickEvent(int number);
    public static event PenguinBtnClickEvent penguinBtnClick;

    // Start is called before the first frame update
    void Start()
    {
        penguinBtnClick += penguinBtnOnClick;
        penguinBtnClick += setInstruction;

        _penguinBtnArray = new GameObject[_penguinCount];
        _isClickedPenguinBtnArray = new bool[_penguinCount];
        currentSelectedPenguin = 0;
        for(int i = 0; i < _penguinCount; i++)
        {

            _isClickedPenguinBtnArray[i] = false;
            GameObject tempBtn = Instantiate(_penguinBtn);
            tempBtn.transform.SetParent(_penguinContainer.transform);
            tempBtn.GetComponent<UIPenguinBtn>()._myNumber = i;
            _penguinBtnArray[i] = tempBtn;
        }

        flipClickImage(0);
        setInstruction(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void flipClickImage(int number)
    {
        _isClickedPenguinBtnArray[number] = !_isClickedPenguinBtnArray[number];
        if (_isClickedPenguinBtnArray[number] == true)
            _penguinBtnArray[number].GetComponent<Image>().sprite = _penguinBtnClicked;
        else
            _penguinBtnArray[number].GetComponent<Image>().sprite = _penguinBtnUnClicked;
    }
    
    public static void btnEventTrigger(int number)
    {
        penguinBtnClick(number);
    }

    public void penguinBtnOnClick(int number)
    {
        flipClickImage(currentSelectedPenguin);
        flipClickImage(number);
        currentSelectedPenguin = number;
    }
    public void setInstruction(int number)
    {
        foreach(Transform instruction in _instructionContainer.transform)
        {
            Destroy(instruction.gameObject);
        }
        for (int j = 0; j < _instructionNumber; j++)
        {
            GameObject tempInstruction = Instantiate(_instruction);
            tempInstruction.transform.SetParent(_instructionContainer.transform);
        }
    }
}
