using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetectedEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public enum MyParent
    {
        Character,
        Construction,
    }
    public MyParent myParent;
    public CircleCollider2D RangeCollider;
    public Construction refParentConstruction;
    public Character refParentCharacter;
    public float range;
    [SerializeField]
    private Character targetCharacter;
    void Start()
    {
        RangeCollider.radius = range;
    }
    public enum TeamCharacter
    {
        Team1,
        Team2,
    }
    private void OnTriggerStay2D(Collider2D collider2D)
    {
        Character _targetCharacter = collider2D.GetComponent<Character>();
        if (targetCharacter != null)
        {
            if (!targetCharacter.gameObject.activeSelf)
            {
                targetCharacter = null;
            }
        }
        if (_targetCharacter != null)
        {
            switch (myParent)
            {
                case MyParent.Construction:
                    if (refParentConstruction != null)
                    {
                        if (_targetCharacter.team.ToString() != refParentConstruction.team.ToString() && targetCharacter == null)
                        {
                            targetCharacter = _targetCharacter;
                        }
                    }
                    else
                    {
                        Debug.Log("refParentConstruction es nulo");
                    }
                    break;
                case MyParent.Character:
                    if (refParentCharacter != null)
                    {
                        if (_targetCharacter.team.ToString() != refParentCharacter.team.ToString() && targetCharacter == null)
                        {
                            targetCharacter = _targetCharacter;
                        }
                    }
                    else
                    {
                        Debug.Log("refParentCharacter es nulo");
                    }
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        Character _targetCharacter = collider2D.GetComponent<Character>();
        if(targetCharacter == _targetCharacter)
        {
            targetCharacter = null;
        }
    }
    public Character GetTargetCharacter()
    {
        return targetCharacter;
    }
}
