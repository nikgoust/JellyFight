using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

internal static class OpenCVInterop
{
    [DllImport("OpenCvUnity")]
    internal static extern int Init(ref int outCameraWidth, ref int outCameraHeight);

    [DllImport("OpenCvUnity")]
    internal static extern int Close();

    [DllImport("OpenCvUnity")]
    internal static extern int SetScale(int downscale);

    [DllImport("OpenCvUnity")]
    internal static extern unsafe void Detect(CvCircle* outFaces, int maxOutFacesCount, ref int outDetectedFacesCount);
}


[StructLayout(LayoutKind.Sequential, Size = 12)]
public struct CvCircle
{
    public int X, Y, Radius;
}