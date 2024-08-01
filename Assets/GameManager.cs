using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private CameraManager m_cameraManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }
        else if (m_cameraManager == null)
        {
            return;
        }
        else if ((Input.GetKeyDown(KeyCode.Return)))
        {
            m_cameraManager.SetCamera("goal");
        }
        else if ((Input.GetKeyUp(KeyCode.Return)))
        {
            m_cameraManager.SetCamera("player");
        }
    }
}
