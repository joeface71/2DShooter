using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShakeFeedback : Feedback
{
    [SerializeField] private GameObject objectToShake;
    [SerializeField] private float duration = 0.2f, strength = 1f, randomness = 90f;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private bool snapping = false, fadeout = true;
    
    public override void CompletePreviousFeedback()
    {
        objectToShake.transform.DOComplete();
    }

    public override void CreateFeedback()
    {
        objectToShake.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeout);
    }
}
