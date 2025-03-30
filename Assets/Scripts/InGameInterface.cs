using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameInterface : MonoBehaviour, IObserver<PlayerCatchEvent>
{
    private int _animalsLeft;
    private int _animalsCaught;

    private Dictionary<string, Animal> _removedAnimals;
        
    public void OnCompleted() => throw new NotImplementedException();

    public void OnError(Exception error) => throw new NotImplementedException();

    public void OnNext(PlayerCatchEvent value)
    {
        if (value.IsCaught)
        {
            _animalsCaught++;
        }
        _animalsLeft--;
    }
}