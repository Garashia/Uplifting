using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [System.Serializable]
    struct CameraMan
    {
        [SerializeField]
        private CinemachineVirtualCamera _cam;
        public CinemachineVirtualCamera cam
        {
            get { return _cam; }
            set { _cam = value; }
        }
        [SerializeField]
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }

    [SerializeField]
    private List<CameraMan> _camera;

    public void SetCamera(string cameraName)
    {

        foreach (CameraMan _cameras in _camera)
        {
            _cameras.cam.Priority = 0;
            if (_cameras.Name == cameraName)
            {
                _cameras.cam.Priority = 1;
            }
        }
    }
}
