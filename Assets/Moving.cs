using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> m_controlPoints;
    public List<Vector3> controlPoints
    {
        set { m_controlPoints = value; }
        get { return m_controlPoints; }
    }
    private float m_timer;
    private Transform m_transform;
    private int direct;
    private float time;


    // Start is called before the first frame update
    void Start()
    {
        m_transform = transform;
        m_timer = 0.0f;
        direct = 1;
        time = (1.0f / 60.0f) * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_timer >= 1.0f)
        {
            direct = -1;
        }
        else if (m_timer <= 0.0f)
        {
            direct = 1;
        }
        m_timer += time * (float)direct;
        // Vector3 vector3 = transform.localPosition;
        m_transform.localPosition = Bezie.CalculateBezierPoint(Mathf.Clamp(m_timer, 0.0f, 1.0f), m_controlPoints);



        // Debug.DrawLine(vector3, m_transform.position, Color.red, 3.0f);
    }

}
