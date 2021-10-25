using System;
using System.Runtime.InteropServices;
using UnityEngine;

// Created by Luan Leme
public class ControladorMinimizar : MonoBehaviour
{
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    public void Minimizar()
    {
        ShowWindow(GetActiveWindow(), 2);
    }

}
