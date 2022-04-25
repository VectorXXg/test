using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField accountInput;
    public InputField passwordInput;

    void Update()
    {
        //回车事件
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoginGame();
        }
    }

    //注册
    public void Register()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //登录
    public void LoginGame()
    {
        if (accountInput.text.Equals("Admin") && passwordInput.text.Equals("Admin"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else
        {

        }
    }
}
