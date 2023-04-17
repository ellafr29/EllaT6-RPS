using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField]bool isPlayer1DoneSelecting;
    [SerializeField]bool isPlayer2DoneSelecting;
    [SerializeField]bool isAttackDone;
    [SerializeField]bool isDamagingDone;
    [SerializeField]bool isReturningDone;
    [SerializeField]bool isPlayerEliminated;
//   [SerializeField] Player player1;
//   [SerializeField] PLayer player2;
enum State{
    Preparation,
    Player1Select,
    Player2Select,
    Attacking,
    Damaging,
    Returning,
    BattleOver
}
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Preparation:
                //Player prepare
                //set player1 play first
                state = State.Player1Select;
                break;

            case State.Player1Select:
                if (isPlayer1DoneSelecting)
                {
                //     set player2 play next
                state = State.Player2Select;
                } 
                break;

            case State.Player2Select:
                if (isPlayer2DoneSelecting)
                {
                //     set player1 player2 attack
                state = State.Attacking;
                } 
                break;

            case State.Attacking:
                if (isAttackDone)
                {
                    // calculate who take damages
                    // start damage animation
                    state = State.Damaging;
                 }
                break;

            case State.Damaging:
                if(isDamagingDone)
                {
                    state = State.Returning;
                }
                break;

            case State.Returning:
                if(isReturningDone)
                {
                    if(isPlayerEliminated)
                        state = State.BattleOver;
                    else
                        state = State.Preparation;
                    

                }
                break;
            case State.BattleOver:
                break;
            
        }
    }
}
