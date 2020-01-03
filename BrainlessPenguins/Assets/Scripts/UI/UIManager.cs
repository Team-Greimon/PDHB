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
    public GameObject _penguinContainer;
    public GameObject _instructionContainer;
    public Sprite _penguinBtnClicked;
    public Sprite _penguinBtnUnClicked;
    GameObject[] _penguinBtnArray;
    public List<List<GameObject>> _instructionArray;
    bool[] _isClickedPenguinBtnArray;
    int _currentSelectedPenguin = 0;

    public int _penguinCount;
    public int _tileNumber;
    public int _instructionNumber;

    public Sprite _tileSprite;

    public delegate void PenguinBtnClickEvent(int number);
    public event PenguinBtnClickEvent penguinBtnClick;

    public delegate void ActionBtnClickEvent(int number,int param,int btnID);
    public event ActionBtnClickEvent actionBtnClick;

    public delegate void PlayBtnClickEvent();
    public event PlayBtnClickEvent playBtnClick;

    // Start is called before the first frame update
    void Start()
    {
        _instructionNumber = _penguinCount + _tileNumber;

        penguinBtnClick += setInstruction;
        penguinBtnClick += penguinBtnOnClick;

        _penguinBtnArray = new GameObject[_penguinCount];
        _isClickedPenguinBtnArray = new bool[_penguinCount];
        _instructionArray = new List<List<GameObject>>();
        _arrowContainer.SetActive(false);

        _currentSelectedPenguin = 0;
        for(int i = 0; i < _penguinCount; i++)
        {
            _isClickedPenguinBtnArray[i] = false;
            GameObject tempBtn = Instantiate(_penguinBtn);
            tempBtn.transform.SetParent(_penguinContainer.transform);
            tempBtn.GetComponent<UIPenguinBtn>()._myNumber = i;
            _penguinBtnArray[i] = tempBtn;

            _instructionArray.Add(new List<GameObject>());
            for(int j = 0; j < _tileNumber; j++)
            {
                _instructionArray[i].Add(Instantiate(_instruction));
                _instructionArray[i][j].transform.SetParent(_instructionContainer.transform);
                _instructionArray[i][j].SetActive(false);

                UIInstructionBtn _access = _instructionArray[i][j].GetComponent<UIInstructionBtn>();

                _access._index = new KeyValuePair<int, int>(i, j);
                _access._selfPenguinType = (Penguin.PenguinType)i;
                _access._arrowContainer = _arrowContainer;
                _access._selfActionType = Instruction.Action.ActionType.nullAction;
                _access._selfCondition.GetComponent<Image>().sprite = _tileSprite;
                _access._selfConditionType = Instruction.Condition.ConditionType.tileCollision;
                _access._conditionParam = j + 1;
            }
            for(int j = _tileNumber; j < _tileNumber+_penguinCount; j++)
            {
                _instructionArray[i].Add(Instantiate(_instruction));
                _instructionArray[i][j].transform.SetParent(_instructionContainer.transform);
                _instructionArray[i][j].SetActive(false);

                UIInstructionBtn _access = _instructionArray[i][j].GetComponent<UIInstructionBtn>();

                _access._index = new KeyValuePair<int, int>(i, j);
                _access._selfPenguinType = (Penguin.PenguinType)i;
                _access._arrowContainer = _arrowContainer;
                _access._selfActionType = Instruction.Action.ActionType.nullAction;
                _access._selfCondition.GetComponent<Image>().sprite = _penguinGrey;
                _access._selfConditionType = Instruction.Condition.ConditionType.penguinCollision;
                _access._conditionParam = j + 1-_tileNumber;
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
    
    public void btnEventTrigger(int number)
    {
        penguinBtnClick(number);
    }
    public void actionBtnEventTrigger(int number,int param,int btnID)
    {
        actionBtnClick(number,param,btnID);
    }
    public void playBtnEventTrigger()
    {
        playBtnClick();
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
