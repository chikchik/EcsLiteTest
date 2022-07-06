using EcsLiteTest.Logic;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsLiteTest.View
{
    public class WorldTimeSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<WorldTime> worldTime;

        public void Run(EcsSystems ecsSystems)
        {
            worldTime.Value.time += Time.time;
            worldTime.Value.deltaTime = Time.deltaTime;
        }
    }
}