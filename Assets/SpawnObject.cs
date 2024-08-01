using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;
    [SerializeField]
    private int count;
    [SerializeField]
    private int minX, maxX;
    [SerializeField]
    private int minY, maxY;
    [SerializeField]
    private int minZ, maxZ;
    [SerializeField]
    private int m_bezieCountMax;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        var rand = new System.Random();
        float rangeX = maxX - minX;
        float rangeY = maxY - minY;
        float rangeZ = maxZ - minZ;

        for (int i = 0; i < count; ++i)
        {
            int count2 = rand.Next(3, m_bezieCountMax);
            List<Vector3> add = new List<Vector3>();
            for (int j = 0; j <= count2; ++j)
            {
                Vector3 vector = new Vector3();
                vector.x = ((float)rand.NextDouble() * rangeX) + minX;
                vector.y = ((float)rand.NextDouble() * rangeY) + minY;
                vector.z = ((float)rand.NextDouble() * rangeZ) + minZ;
                add.Add(vector);
            }
            GameObject gameObject = Instantiate(spawnObject, transform);
            gameObject.GetComponent<Moving>().controlPoints = add;
        }
        // Time.timeScale = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
