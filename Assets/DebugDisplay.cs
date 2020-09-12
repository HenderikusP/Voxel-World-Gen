using UnityEngine;
using TMPro;
using System;
using System.Linq;
//using Steamworks;

public class DebugDisplay : MonoBehaviour {

    private KeyCode toggleKey = KeyCode.F1;
    private bool debugEnabled = false;

    private float refreshPeriod = 0.05f;
    private float timer;
    private int i = 0;
    private int[] fpsStamps = new int[10];

    private TextMeshProUGUI debugText;
    private string[] debugLines = new string[9];

    private string gameVersion;
    private string unityVersion;
    private string unityUser;
    private string gpu;
    private string cpu;
    private string ram;

    private int fps = 0;
    private int avgFps = 0;

    private void Start()
    {
        gameVersion = Application.version;
        unityVersion = Application.unityVersion;

        //if (SteamManager.Initialized) unityUser = SteamFriends.GetPersonaName();
        //else unityUser = "Steam User Not Found.";

        gpu = SystemInfo.graphicsDeviceName;
        cpu = SystemInfo.processorType;
        ram = ((float)SystemInfo.systemMemorySize / 1024).ToString("F2");

        debugText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey)) debugEnabled = !debugEnabled; //Toggles debug window.

        if (Time.unscaledTime > timer && debugEnabled)
        {
            fps = (int)(1f / Time.unscaledDeltaTime);
            fpsStamps[i] = fps;
            timer = Time.unscaledTime + refreshPeriod;
            if (i >= 9) CalculateAvg();
            else i++;

            debugText.text = ConnectStrings();
        }
        else if (!debugEnabled)
            debugText.text = string.Format("Debug [{0}]", toggleKey);
    }

    private string ConnectStrings() {
        debugLines[0] = string.Format("Debug [{0}]", toggleKey);

        //Version Info.
        debugLines[1] = string.Format("\n  Game Version : {0}", gameVersion);
        debugLines[2] = string.Format(" Unity Version : {0}", unityVersion);

        //System Info.
        debugLines[3] = string.Format("\n           GPU : {0}", gpu);
        debugLines[4] = string.Format("           CPU : {0}", cpu);
        debugLines[5] = string.Format("           RAM : {0}GB", ram);

        //FPS and Average FPS.
        
        if (fps < 60) debugLines[7] = string.Format("\n   Current FPS : <color=red>{0}</color>", fps);
        else if (fps < 120) debugLines[7] = string.Format("\n   Current FPS : {0}", fps);
        else debugLines[7] = string.Format("\n   Current FPS : <color=green>{0}</color>", fps);

        if (avgFps < 60) debugLines[8] = string.Format("   Average FPS : <color=red>{0}</color>", avgFps);
        else if (avgFps < 120) debugLines[8] = string.Format("   Average FPS : {0}", avgFps);
        else debugLines[8] = string.Format("   Average FPS : <color=green>{0}</color>", avgFps);

        return string.Join("\n", debugLines);
    }

    private void CalculateAvg() {
        i = 0;
        avgFps = fpsStamps.Sum() / 10;
    }
}
