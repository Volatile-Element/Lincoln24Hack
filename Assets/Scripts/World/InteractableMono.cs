﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableMono : MonoBehaviour
{
    public abstract void Interact();
    public abstract string GetText();
    public abstract bool IsCurrentlyInteractable();
}