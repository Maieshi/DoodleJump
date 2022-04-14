using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private string _lavelName;

    public void Load()
    {
        SceneManager.LoadScene(_lavelName);
    }
}
