using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    private int _score = 0;

    [SerializeField]
    private Text _text;

    private void Start()
    {
        GameController._singleton._restartEvent.AddListener(ClearScore);
    }

    private void ClearScore()
    {
        _score = 0;
    }

    void Update()
    {
        if ((int)(PlayerController._singleton.transform.position.y * 100) > _score)
            _score = (int)(PlayerController._singleton.transform.position.y * 100);
        _text.text = _score.ToString();
    }
}
