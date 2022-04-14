using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private List<Transform> _platforms = new List<Transform>();

    public static PlatformManager _singleton;

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
        GameController._singleton._restartEvent.AddListener(ClearPlatforms);
    }



    public void AddPlatform(Transform _platformPosition)
    {
        if (_platformPosition != null)
        {
            _platforms.Add(_platformPosition);
        }
    }

    private void ClearPlatforms()
    {
        foreach (var platform in _platforms)
        {
            if (platform != null)
                Destroy(platform.gameObject);
        }
        _platforms.RemoveAll(item => item == null);
    }




}
