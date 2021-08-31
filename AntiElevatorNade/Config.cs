using Exiled.API.Interfaces;
using System.ComponentModel;

namespace AntiElevatorNade
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Should the thrower of the grenade take damage from the explosion")]
        public bool KillThrower { get; set; } = true;
    }
}
