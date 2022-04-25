using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsSet : MonoBehaviour
{
    public static int resolutionIndex = 3;
    public static int voiceIndex = 50;
    public static int bgmIndex = 25;
    public Dropdown resolution;
    public Slider voice;
    public Slider bgm;

    void Start()
    {
        resolution.value = resolutionIndex;
        voice.value = voiceIndex;
        bgm.value = bgmIndex;
    }

    //确认
    public void SetOptions()
    {
        UpdateResolution();
        UpdateVoice();
        UpdateBGM();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    //返回
    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    //修改分辨率
    public void UpdateResolution()
    {
        switch (resolution.value)
        {
            case 0:
                resolutionIndex = 0;
                Screen.SetResolution(480, 270, false);
                break;
            case 1:
                resolutionIndex = 1;
                Screen.SetResolution(720, 405, false);
                break;
            case 2:
                resolutionIndex = 2;
                Screen.SetResolution(1024, 576, false);
                break;
            case 3:
                resolutionIndex = 3;
                Screen.SetResolution(1280, 720, false);
                break;
            case 4:
                resolutionIndex = 4;
                Screen.SetResolution(1360, 768, false);
                break;
            case 5:
                resolutionIndex = 5;
                Screen.SetResolution(1366, 768, false);
                break;
            case 6:
                resolutionIndex = 6;
                Screen.SetResolution(1600, 900, false);
                break;
            case 7:
                resolutionIndex = 7;
                Screen.SetResolution(1920, 1080, false);
                break;
            case 8:
                resolutionIndex = 8;
                Screen.SetResolution(2560, 1440, false);
                break;
            default:
                break;
        }
    }

    //修改音量
    public void UpdateVoice()
    {
        voiceIndex = (int)voice.value;
    }

    //修改BGM
    public void UpdateBGM()
    {
        bgmIndex = (int)bgm.value;
    }
}
