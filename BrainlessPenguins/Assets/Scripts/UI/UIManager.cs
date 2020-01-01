using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject _arrowContainer;

    public Sprite _penguinGrey;
    public Sprite _penguinPink;
    public GameObject _penguinBtn;
    public GameObject _instruction;
    public int _penguinCount = 4;
    public GameObject _penguinContainer;
    public GameObject _instructionContainer;
    public Sprite _penguinBtnClicked;
    public Sprite _penguinBtnUnClicked;
    GameObject[] _penguinBtnArray;
    List<List<GameObject>> _instructionArray;
    bool[] _isClickedPenguinBtnArray;
    int _currentSelectedPenguin = 0;

    public int _instructionNumber = 8;

    public delegate void PenguinBtnClickEvent(int number);
    public static event PenguinBtnClickEvent penguinBtnClick;

    // Start is called before the first frame update
    void Start()
    {
        penguinBtnClick += setInstruction;
        penguinBtnClick += penguinBtnOnClick;

        _penguinBtnArray = new GameObject[_penguinCount];
        _isClickedPenguinBtnArray = new bool[_penguinCount];
        _instructionArray = new List<List<GameObject>>();

        _currentSelectedPenguin = 0;
        for(int i = 0; i < _penguinCount; i++)
        {
            _isClickedPenguinBtnArray[i] = false;
            GameObject tempBtn = Instantiate(_penguinBtn);
            tempBtn.transform.SetParent(_penguinContainer.transform);
            tempBtn.GetComponent<UIPenguinBtn>()._myNumber = i;
            _penguinBtnArray[i] = tempBtn;

            _instructionArray.Add(new List<GameObject>());
            for(int j = 0; j < _instructionNumber; j++)
            {
                _instructionArray[i].Add(Instantiate(_instruction));
                _instructionArray[i][j].transform.SetParent(_instructionContainer.transform);
                _instructionArray[i][j].SetActive(false);
                _instructionArray[i][j].GetComponent<UIInstructionBtn>()._index = new KeyValuePair<int, int>(i, j);
            }
        }
        setInstruction(0);
        flipClickImage(0);
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
        flipClickImage(_currentSelectedPenguin);
        flipClickImage(number);
        _currentSelectedPenguin = number;
    }
    public void setInstruction(int number)
    {
        foreach(GameObject instruction in _instructionArray[_currentSelectedPenguin])
        {
            instruction.SetActive(false);
        }
        foreach(GameObject instruction in _instructionArray[number])
        {
            instruction.SetActive(true);
        }

    }
}
