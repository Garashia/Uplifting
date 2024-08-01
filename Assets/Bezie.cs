using System.Collections.Generic;
using UnityEngine;

public class Bezie
{
    private static List<List<int>> Lister = new List<List<int>>();
    // “ñ€ŒW”ƒe[ƒuƒ‹‚Ì¶¬
    private static void GenerateBinomialTable(int n)
    {
        int count = Lister.Count;
        if (n <= count - 1)
            return;

        for (int i = count; i <= n; ++i)
        {
            Debug.Log(i);
            int[] lister = new int[i + 1];
            lister[0] = 1;
            lister[i] = 1;
            for (int j = 1; j < i; ++j)
            {
                lister[j] = Lister[i - 1][j - 1] + Lister[i - 1][j];
            }
            Lister.Add(new List<int>(lister));
        }

    }

    public static Vector3 CalculateBezierPoint(float t, in List<Vector3> controlPoints)
    {
        int n = controlPoints.Count - 1;
        Vector3 point = new Vector3(0.0f, 0.0f, 0.0f);

        GenerateBinomialTable(n);
        var binomialTable = Lister;
        for (int i = 0; i <= n; ++i)
        {
            float binomialCoeff = (float)(binomialTable[n][i]);
            float blend = binomialCoeff * Mathf.Pow((float)(1 - t), n - i) * Mathf.Pow((float)t, i);
            point.x += blend * controlPoints[i].x;
            point.y += blend * controlPoints[i].y;
            point.z += blend * controlPoints[i].z;
        }

        return point;
    }

}
