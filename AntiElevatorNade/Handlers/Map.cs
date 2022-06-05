using System.Linq;
using Exiled.API.Enums;
using Exiled.Events.EventArgs;

namespace AntiElevatorNade.Handlers
{
    public class Map
    {
        public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            // Checks if grenade harms players
            if (ev.GrenadeType != GrenadeType.FragGrenade) return;

            // Checks if all affected players and thrower are of same side
            if (!(ev.TargetsToAffect.Count != 0 && ev.TargetsToAffect.Count >= AntiElevatorNade.Instance.Config.MinimumPlayersGrenade && ev.TargetsToAffect.All(player => ev.Thrower.Role.Side == player.Role.Side))) return; 

            foreach (Lift lift in Lift.Instances)
            {
                // Iterates through each elevator room
                foreach (Lift.Elevator elevator in lift.elevators)
                {
                    // Checks if affected players are in the elevator
                    if (!((ev.TargetsToAffect.First().Position - elevator.target.position).sqrMagnitude < 13)) continue; 

                    ev.IsAllowed = false; // Disables damage dealt to players

                    // Checks config to see if thrower should be damaged by their grenade and is affected by explosion
                    if (AntiElevatorNade.Instance.Config.KillThrower && ev.TargetsToAffect.Contains(ev.Thrower))
                    {
                        ev.Thrower.ShowHint(AntiElevatorNade.Instance.Config.ThrowerHint, 5); // Gives hint to thrower
                        ev.Thrower.Hurt(ev.Thrower, 1000f, DamageType.Explosion); // Kills the thrower
                    }
                    return;
                }
            } 
        }
    }
}
