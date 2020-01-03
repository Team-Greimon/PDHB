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
        var penguinCount = System.Enum.GetValues(typeof(Penguin.PenguinType)).Length;

        penguinBtnClick += setInstruction;
        penguinBtnClick += penguinBtnOnClick;

        _penguinBtnArray = new GameObject[penguinCount];
        _isClickedPenguinBtnArray = new bool[penguinCount];
        _instructionArray = new List<List<GameObject>>();
        _arrowContainer.SetActive(false);

        _currentSelectedPenguin = 0;

        var penguinTypeValues = System.Enum.GetValues(typeof(Penguin.PenguinType));
        foreach (int i in penguinTypeValues)
        {
            _isClickedPenguinBtnArray[i] = false;
            GameObject tempBtn = Instantiate(_penguinBtn);
            tempBtn.transform.SetParent(_penguinContainer.transform);
            tempBtn.GetComponent<UIPenguinBtn>()._myNumber = i;
            _penguinBtnArray[i] = tempBtn;

            _instructionArray.Add(new List<GameObject>());

            var tileTypeValues = System.Enum.GetValues(typeof(Tile.TileType));
            foreach (int tileTypeVal in tileTypeValues)
            {
                if ((Tile.TileType)tileTypeVal == Tile.TileType.invalid) continue;

                var access = AddInstructionBtn(i, tileTypeVal);
                access._selfCondition.GetComponent<Image>().sprite = _tileSprite;
                access._selfConditionType = Instruction.Condition.ConditionType.tileCollision;
            }
            foreach (int penguinTypeVal in penguinTypeValues)
            {
                var access = AddInstructionBtn(i, penguinTypeVal);
                access._selfCondition.GetComponent<Image>().sprite = _penguinGrey;
                access._selfConditionType = Instruction.Condition.ConditionType.penguinCollision;
            }
        }
        setInstruction(0);
        flipClickImage(0);
    }

    UIInstructionBtn AddInstructionBtn(int penguinType, int conditionParam)
    {
        var gameObj = Instantiate(_instruction);
        _instructionArray[penguinType].Add(gameObj);
        gameObj.transform.SetParent(_instructionContainer.transform);
        gameObj.SetActive(false);

        UIInstructionBtn access = gameObj.GetComponent<UIInstructionBtn>();

        access._selfPenguinType = (Penguin.PenguinType)penguinType;
        access._arrowContainer = _arrowContainer;
        access._selfActionType = Instruction.Action.ActionType.nullAction;
        access._conditionParam = conditionParam;

        return access;
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
