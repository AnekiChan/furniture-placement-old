using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float _speed = 3f;
    private Transform currentPorition;

    enum State
    {
        Idle,
        SmallAction,
        Walk,
        Sleep
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPorition = gameObject.transform;
        Vector3 newPosition = new Vector3(currentPorition.position.x + Random.Range(1, 4), currentPorition.position.y + Random.Range(1, 4), transform.position.z);
        Debug.Log(newPosition);
        _animator.SetFloat("Speed", _speed);
        if (transform.position.x != newPosition.x && transform.position.y != newPosition.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, newPosition, _speed);

        }
        _animator.SetFloat("Speed", 0);
    }

    IEnumerator IdleCorutine()
    {
        yield return new WaitForSeconds(Random.Range(3, 10));
    }

    /*
    IEnumerator WalkCorutine()
    {
        Transform currentPorition = gameObject.transform;
        Vector3 newPosition = new Vector3(currentPorition.position.x + Random.Range(1, 4), currentPorition.position.y + Random.Range(1, 4), transform.position.z);
        Debug.Log(newPosition);
        _animator.SetFloat("Speed", _speed);
        while (transform.position.x != newPosition.x && transform.position.y != newPosition.y)
        {
            transform.position = Vector2.MoveTowards(transform.position, newPosition, _speed);
            
        }
        _animator.SetFloat("Speed", 0);
        yield return null;
    }
    */
}
