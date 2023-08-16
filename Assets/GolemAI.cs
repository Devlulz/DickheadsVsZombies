using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GolemState {Attack, ChasePlayer, ChaseCrystal}
public class GolemAI : MonoBehaviour
{
    GolemState state;
    // Start is called before the first frame update
    void Start()
    {
        state = GolemState.ChaseCrystal;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GolemState.ChaseCrystal:

                break;
        }
    }
}
