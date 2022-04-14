using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatfomGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _objects;//0-green , 1- blue, 2-brown, 3-white, 4-spring, 5-trampline

    [SerializeField]
    [Range(15, 50)]
    private float _addidionalDistance;

    private float _offset;

    private Vector3 _boundary;

    private Transform _playerPosition;

    private float _lastPositionY;

    private Vector3 _idlePosition;

    IEnumerator _routine;


    private void Start()
    {
        _playerPosition = PlayerController._singleton.transform;
        _boundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        _offset = 0.3f;
        _lastPositionY = transform.position.y;
        _idlePosition = gameObject.transform.position;
        AddListeners();
        StartSpawning();
    }

    private void AddListeners()
    {
        GameController._singleton._stopEvent.AddListener(StopSpawning);
        GameController._singleton._restartEvent.AddListener(Restart);
    }

    private void StartSpawning()
    {
        StartCoroutine(SpawnPlatform());
    }

    private void StopSpawning()
    {
        StopCoroutine("SpawnPlatform");
    }


    private void Restart()
    {
        transform.position = _idlePosition;
        StartSpawning();
    }


    IEnumerator SpawnPlatform()
    {
        while (true)
        {
            if (_playerPosition.position.y + _addidionalDistance > transform.position.y)
            {
                transform.position += new Vector3(0, Random.Range(1f, 3f), 0);//move spawner
                float _positionX = Random.Range(_boundary.x + _offset, -_boundary.x - _offset);
                Vector3 _platformPosition = new Vector3(_positionX, transform.position.y, transform.position.z);

                //spawn regular platform
                int _randomIndex = Random.Range(0, 40);
                GameObject _randomPlatform;
                if (_randomIndex >= 0 && _randomIndex <= 35)
                    _randomPlatform = _objects[0];//choose green platfom
                else
                    _randomPlatform = _objects[1];//choose blue platfom
                Transform _spawnedPlatform = Instantiate(_randomPlatform, _platformPosition, Quaternion.identity).gameObject.transform;
                PlatformManager._singleton.AddPlatform(_spawnedPlatform);

                if (transform.position.y - _lastPositionY >= 1.5f)
                {
                    //spawn white or brown platform


                    if (Random.Range(0, 7) == 0)
                    {
                        _positionX = Random.Range(_boundary.x + _offset, -_boundary.x - _offset);
                        Transform _spawnedCrackingPlatform;
                        Vector3 _crackingPlatformPosition =
                        new Vector3(
                            _positionX,
                            _lastPositionY + 0.35f,
                            _platformPosition.z
                        );
                        _spawnedCrackingPlatform = Instantiate(_objects[Random.Range(2, 4)], _crackingPlatformPosition, Quaternion.identity).gameObject.transform;
                        PlatformManager._singleton.AddPlatform(_spawnedCrackingPlatform);
                    }

                    // spawn bonus platform

                    if (Random.Range(0, 10) == 0)
                    {
                        Transform _spawnedBomusPlatform;
                        _positionX = Random.Range(_boundary.x + _offset, -_boundary.x - _offset);
                        _randomIndex = Random.Range(0, 30);
                        GameObject _bonusPlatform;
                        Vector3 _bonusPlatformPosition =
                        new Vector3(
                            _positionX,
                            _lastPositionY + 1,
                            _platformPosition.z
                        );
                        if (_randomIndex <= 19)
                            _bonusPlatform = _objects[4];//spring
                        else
                            _bonusPlatform = _objects[5];//trampline

                        _spawnedBomusPlatform = Instantiate(_bonusPlatform, _bonusPlatformPosition, Quaternion.identity).gameObject.transform;
                        PlatformManager._singleton.AddPlatform(_spawnedBomusPlatform);
                    }
                }
                _lastPositionY = transform.position.y;

            }
            yield return null;
        }
    }

    private void Update()
    {

    }

}
