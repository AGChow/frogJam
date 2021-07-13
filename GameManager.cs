using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float Score;

    CinemachineImpulseSource impulse;
    public float shakeIntensity = 10;

    public TMP_Text ScoreText;

    public static GameManager GMInstance;
    public CinemachineVirtualCamera cm1;
    public CinemachineVirtualCamera cm2;
    public CinemachineVirtualCamera cm3;

    public TMP_Text middleText;


    private void Awake()
    {
        if (GMInstance == null)
        {
            GMInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetCameras();

        impulse = transform.GetComponent<CinemachineImpulseSource>();

        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.SetText("Score: " + Score.ToString());
        
    }

    public void ShakeScreen()
    {
        impulse.GenerateImpulse(shakeIntensity);
    }


    public void Cam1Activate()
    {
        cm1.Priority = 11;
        cm2.Priority = 10;
        cm3.Priority = 10;
    }
    public void Cam2Activate()
    {
        cm1.Priority = 10;
        cm2.Priority = 11;
        cm3.Priority = 10;
    }

    public void Cam3Activate()
    {
        cm1.Priority = 10;
        cm2.Priority = 10;
        cm3.Priority = 11;
    }

    public void ResetCameras()
    {
        cm1 = GameObject.FindGameObjectWithTag("CM1").GetComponent<CinemachineVirtualCamera>();
        cm2 = GameObject.FindGameObjectWithTag("CM2").GetComponent<CinemachineVirtualCamera>();
        cm3 = GameObject.FindGameObjectWithTag("CM3").GetComponent<CinemachineVirtualCamera>();
    }

    public void WinScreen()
    {
        middleText = GameObject.FindGameObjectWithTag("ExtraText").GetComponent<TMP_Text>();

        middleText.SetText("YOU WON?");
    }

}
