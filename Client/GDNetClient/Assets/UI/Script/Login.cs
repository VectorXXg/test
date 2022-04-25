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
        //�س��¼�
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoginGame();
        }
    }

    //ע��
    public void Register()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //��¼
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
