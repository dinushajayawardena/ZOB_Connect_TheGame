using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void Load_Scene(int scene_Index)
    {
        SceneManager.LoadScene(scene_Index);
    }

}
