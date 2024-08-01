using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private Jump m_jump;

    private Vector3 m_jumpppp;

    private bool m_jumping = false;
    private float maxFallSpeed = 20f;
    private float gravity = 15f;
    // Start is called before the first frame update
    void Start()
    {
        m_jumpppp = Vector3.zero;
        m_jumping = false;
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (m_jump.Flag && Input.GetKeyDown(KeyCode.Space))
        {
            m_jumping = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && m_jumping)
        {
            m_jumping = false;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float by = 15.0f;
        if (Input.GetKey(KeyCode.LeftShift) ||
            Input.GetKey(KeyCode.RightShift))
        {
            by *= 3.0f;
        }


        // “ü—Í‚ðx‚Æz‚É‘ã“ü
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 vector = new Vector3(x, 0.0f, z);
        vector = Vector3.Normalize(vector);
        vector *= by;
        if (m_jumping && m_jump.Flag)
        {
            m_jumpppp.y = 5.0f;
        }
        else if (!m_jumping && !m_jump.Flag)
        {
            if (0 <= m_jumpppp.y)
            {
                m_jumpppp.y = 0;
            }
        }
        Vector3 fall = Vector3.zero;
        fall.y = m_jumpppp.y - gravity * Time.deltaTime;
        fall.y = Mathf.Max(fall.y, -maxFallSpeed);
        //Rigidbody‚É—Í‚ð‰Á‚¦‚é
        rb.AddForce(vector);
        rb.AddForce(fall, ForceMode.Impulse);
        m_jumpppp.y *= 0.68f;

        Vector3 velocity = rb.velocity;
        velocity.x *= 0.94f;
        velocity.z *= 0.94f;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {

        }
    }
}
