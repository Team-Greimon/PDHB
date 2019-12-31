using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInstructionBtn : MonoBehaviour
{
    public GameObject _arrowContainer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        _arrowContainer.transform.position = new Vector2(transform.position.x-20,transform.position.y+50);
        _arrowContainer.SetActive(true);
        //_arrowContainer.GetComponent<UIArrowContainer>
    }
}
