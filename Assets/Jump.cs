using UnityEngine;

public class Jump : MonoBehaviour
{
    private int index = 0;
    // private bool m_flag;
    public bool Flag
    {
        // set { m_flag = value; }
        get { return index > 0; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // m_flag = false;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = transform.parent.position + Vector3.down * 0.5f;
        gameObject.transform.rotation = new Quaternion();

    }
    private void OnTriggerEnter(Collider collision)
    {
        ++index;
        // m_flag = true;
        Debug.Log(true);
        if (collision.CompareTag("Floor"))
        {
            transform.parent.parent = collision.transform;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        --index;
        if (collision.CompareTag("Floor"))
        {
            transform.parent.parent = null;

        }

    }
}
