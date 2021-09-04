using Exiled.API.Interfaces;
using System.ComponentModel;

namespace AntiElevatorNade
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("The minimum players to trigger the anti elevator grenade")]
        public int MinimumPlayersGrenade { get; set; } = 2;

        [Description("Should the thrower of the grenade take damage if they are within the explosion")]
        public bool KillThrower { get; set; } = true;

        [Description("The message said to the thrower when they die, leave blank to disable")]
        public string ThrowerHint { get; set; } = "Don't kill your teammates!";
    }
}
