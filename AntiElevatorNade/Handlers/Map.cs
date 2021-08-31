using System.Linq;
using Exiled.Events.EventArgs;

namespace AntiElevatorNade.Handlers
{
    class Map
    {
        public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            // Checks if grenade harms players
            if (ev.IsFrag) 
            {
                // Checks if all affected players and thrower are of same side
                if (ev.TargetsToAffect.Count > 1 && ev.TargetsToAffect.All(player => ev.Thrower.Side == player.Side))
                {
                    foreach (Lift lift in Exiled.API.Features.Map.Lifts)
                    {
                        // Iterates through each elevator room
                        foreach (Lift.Elevator elevator in lift.elevators)
                        {
                            // Checks if affected players are in the elevator
                            if ((ev.TargetsToAffect.First().Position - elevator.target.position).sqrMagnitude < 13)
                            {
                                ev.IsAllowed = false; // Disables damage dealt to players

                                // Checks config to see if thrower should be damaged by their grenade and is affected by explosion
                                if (AntiElevatorNade.Instance.Config.KillThrower == true && ev.TargetsToAffect.Contains(ev.Thrower))
                                {
                                    ev.Thrower.Hurt(1000, ev.Thrower, DamageTypes.Grenade); // Kills the thrower
                                }
                                return;
                            }
                        }
                    } 
                }
            }
        }
    }
}
