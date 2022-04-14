using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController _singleton;

    [HideInInspector]
    public UnityEvent _stopEvent = new UnityEvent();

    [HideInInspector]
    public UnityEvent _restartEvent = new UnityEvent();

    [SerializeField]
    private Button _replayButton;

    [SerializeField]
    private Transform _idlePlayerPosition;

    private bool _gameStopped;

    private void Awake()
    {
        if (_singleton == null)
            _singleton = this;
        else if (_singleton == this)
        {
            Destroy(gameObject);
            return;
        }

    }

    private void Start()
    {
        _gameStopped = false;
    }

    private void StopGame()
    {
        _gameStopped = true;
        _stopEvent.Invoke();
        PlayerController._singleton.gameObject.SetActive(false);
        _replayButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        _gameStopped = false;
        _restartEvent.Invoke();
        PlayerController._singleton.transform.position = _idlePlayerPosition.position;
        PlayerController._singleton.gameObject.SetActive(true);
        _replayButton.gameObject.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        Vector3 _cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        if (PlayerController._singleton.transform.position.y < _cameraPosition.y - 2 && !_gameStopped)
            StopGame();
    }
}
