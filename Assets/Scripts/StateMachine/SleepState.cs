using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SleepState : State
{
    private Creature _creature;
    private float _timer;
    private GameObject _closestSeat;
    private float _speed;

    public SleepState(Creature creature)
    {
        _creature = creature;
    }
    public override void Enter()
    {
        base.Enter();
        //Debug.Log("sleep enter");

        _speed = _creature.speed;

        _closestSeat = FindSittingFurniture();

        if (_closestSeat != null)
        {
            if (Vector2.Distance(_creature.transform.position, _closestSeat.transform.position) > 0.01f)
                _creature.Animator.SetFloat("Speed", _speed);

            else
            {
                _closestSeat.GetComponent<Furniture>().furnitureScriptbleObject.iSOccupied = true;
                _creature.Animator.SetBool("IsSleeping", true);
            }

            _timer = Random.Range(10, 20);
        }
        else
        {
            _creature.IsStateEnd = true;
        }
    }

    public override void Exit()
    {
        base.Exit();
        //Debug.Log("sleep exit");
        _creature.Animator.SetBool("IsSleeping", false);
    }

    public override void Update()
    {
        if (_closestSeat != null)
        {
            if (Vector2.Distance(_creature.transform.position, _closestSeat.transform.position) > 0.01f)
            {
                MoveToSeat();
            }
            else
            {
                TimeLeft();
            }
        }
    }

    private GameObject FindSittingFurniture()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_creature.transform.position, 10f);

        foreach (var collider in colliders)
        {
            Furniture obj = collider.gameObject.GetComponent<Furniture>();
            if (obj != null && obj.furnitureScriptbleObject.isSitting)
            {
                if (obj.furnitureScriptbleObject.iSOccupied)
                {
                    continue;
                }
                return collider.gameObject;
            }
        }

        return null;
    }

    private void MoveToSeat()
    {
        _creature.transform.position = Vector2.MoveTowards(_creature.transform.position, _closestSeat.transform.position, _speed * Time.deltaTime);
        if (Vector2.Distance(_creature.transform.position, _closestSeat.transform.position) <= 0.01f)
        {
            _creature.Animator.SetFloat("Speed", 0);
            _creature.Animator.SetBool("IsSleeping", true);
            _closestSeat.GetComponent<Furniture>().furnitureScriptbleObject.iSOccupied = true;
        }
    }

    private void TimeLeft()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _closestSeat.GetComponent<Furniture>().furnitureScriptbleObject.iSOccupied = false;
            _creature.IsStateEnd = true;
        }
    }
}
