using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Game");
    }
    

}
