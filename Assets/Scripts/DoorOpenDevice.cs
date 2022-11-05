using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class DoorOpenDevice : MonoBehaviour
{
    //[SerializeField] private Vector3 dPos;
    public bool needKey;

    private bool _isOpen;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Operate()
    {
        if (!needKey)
        {
            _animator.SetBool("isOpened", _isOpen);
            _isOpen = !_isOpen;
        }

        //if (_open)
        //{
        //    Vector3 pos = transform.position - dPos;
        //    transform.position = pos;
        //}
        //else
        //{
        //    Vector3 pos = transform.position + dPos;
        //    transform.position = pos;
        //}
        //_open = !_open;
    }

    public void Activate()
    {
        if (!_isOpen)
        {
            //Vector3 pos = transform.position + dPos;
            //transform.position = pos;
            _isOpen = true;
            _animator.SetBool("isOpened", _isOpen);
        }
    }

    public void Deactivate()
    {
        if (_isOpen)
        {
            //Vector3 pos = transform.position - dPos;
            //transform.position = pos;
            _isOpen = false;
            _animator.SetBool("isOpened", _isOpen);
        }
    }
}
