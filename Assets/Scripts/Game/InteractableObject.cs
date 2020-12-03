using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableObject
{
    int GetLevel();
    void SetLevel(int level);
    MeshRenderer GetMeshRenderer();
}
