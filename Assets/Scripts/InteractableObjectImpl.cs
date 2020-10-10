using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectImpl : MonoBehaviour, InteractableObject
{

    [SerializeField] int level;
    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public MeshRenderer GetMeshRenderer()
    {
        return gameObject.GetComponent<MeshRenderer>();
    }
}
