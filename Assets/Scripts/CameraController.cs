using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _player, _playerCamera, _focusPoint;
    [SerializeField]
    private float _playerHeight=2f;
    #region VariablesZoom
    [SerializeField]
    private float _zoom=-7, _zoomSpeed = 4, _zoomMin = -7, _zoomMax = 0;
    [SerializeField]
    private float _camRotX, _camRotY;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region Asignacion de objeto
        if(_player==null)
        {
            Debug.LogWarning("Se debe asignar el jugador desde el inspector");
        }
        if(_playerCamera==null)
        {
            Debug.LogWarning("Se debe asignar la camara desde el inspector");
        }
        if(_player==null)
        {
            Debug.LogWarning("Se debe asignar el punto de foco desde el inspector");
        }
        #endregion

        #region Parentezco
        // _focusPoint.transform.SetParent(_player);
        _playerCamera.transform.SetParent(_focusPoint);
        #endregion

        #region Inicializa Zoom
        if(_zoom > _zoomMax)
        {
            _zoom = -7;
        }
        _playerCamera.transform.localPosition = new Vector3(0,0,_zoom);
        _focusPoint.transform.localPosition = new Vector3(0,_playerHeight,0);
        _playerCamera.LookAt(_focusPoint);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region focusPointCopyPositionPlayer
        _focusPoint.transform.localPosition = new Vector3(_player.transform.localPosition.x, _player.transform.localPosition.y+_playerHeight, _player.transform.localPosition.z);
        #endregion


        #region Zoom
        _zoom += Input.GetAxis("Mouse ScrollWheel") * _zoomSpeed;
        _zoom = Mathf.Clamp(_zoom,_zoomMin,_zoomMax);
        _playerCamera.transform.localPosition = new Vector3(0,0, _zoom);
        #endregion

        #region rotacion camara
        if(Input.GetMouseButton(1))
        {
            _camRotX += Input.GetAxis("Mouse X");
            _camRotY += Input.GetAxis("Mouse Y");
            _focusPoint.transform.localRotation = Quaternion.Euler(-_camRotY, _camRotX, 0);
        }
        #endregion
    }
}
