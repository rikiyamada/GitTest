using System.Collections.Concurrent;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Python : MonoBehaviour
{
    private Process pythonProcess;
    public ConcurrentQueue<string> messages = new ConcurrentQueue<string>();
    

    void Start()
    {
        StartPythonProcess();
    }

    void StartPythonProcess()
    {
        pythonProcess = new Process();
        pythonProcess.StartInfo.FileName = "python3";
        pythonProcess.StartInfo.Arguments = "/Users/yamadariki/unity/GitTest/Assets/Scripts/unity_test.py";
        pythonProcess.StartInfo.UseShellExecute = false;
        pythonProcess.StartInfo.RedirectStandardInput = true;
        pythonProcess.StartInfo.RedirectStandardOutput = true;
        pythonProcess.StartInfo.CreateNoWindow = true;
        pythonProcess.OutputDataReceived += (sender, args) => messages.Enqueue(args.Data);
        pythonProcess.Start();
        pythonProcess.BeginOutputReadLine();
    }

    public void SendCommandToPython(string command)
    {
        if (pythonProcess != null)
        {
            pythonProcess.StandardInput.WriteLine(command);
            pythonProcess.StandardInput.Flush();
        }
    }

    void OnApplicationQuit()
    {
        if (pythonProcess != null)
        {
            pythonProcess.Close();
        }
    }
}