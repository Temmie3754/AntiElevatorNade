using Exiled.API.Features;
using Map = Exiled.Events.Handlers.Map;
using System;

namespace AntiElevatorNade
{
    public class AntiElevatorNade : Plugin<Config>
    {
        private static AntiElevatorNade Singleton;

        static AntiElevatorNade()
        {
        }

        public static AntiElevatorNade Instance => Singleton;
        public override string Author => "TemmieGamerGuy";
        public override string Name => "AntiElevatorNade";
        public override Version Version => new Version(1, 0, 3);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        private Handlers.Map map;

        public void RegisterEvents()
        {
            map = new Handlers.Map();
            Map.ExplodingGrenade += map.OnExplodingGrenade;
        }

        public void UnregisterEvents()
        {
            Map.ExplodingGrenade -= map.OnExplodingGrenade;
            map = null;
        }

        public override void OnEnabled()
        {
            Singleton = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }
    }
}
