using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IAgent
{
    int Health { get; set; }
    UnityEvent OnGetHit { get; set; }
    UnityEvent OnDie { get; set; }
}