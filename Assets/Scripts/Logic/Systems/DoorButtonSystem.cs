using Leopotam.EcsLite;
using Vector3 = UnityEngine.Vector3;

namespace EcsLiteTest.Logic
{
    public class DoorButtonSystem : IEcsRunSystem
    {
        public void Run(EcsSystems ecsSystems)
        {
            var doorButtonFilter = ecsSystems.GetWorld()
                .Filter<DoorButtonComponent>()
                .Inc<PositionComponent>().End();
            var doorButtonPool = ecsSystems.GetWorld().GetPool<DoorButtonComponent>();
            var doorButtonPositionPool = ecsSystems.GetWorld().GetPool<PositionComponent>();

            var playerFilter = ecsSystems.GetWorld()
                .Filter<PlayerComponent>()
                .Inc<PositionComponent>().End();
            var playerPositionPool = ecsSystems.GetWorld().GetPool<PositionComponent>();

            foreach (var doorButtonEntity in doorButtonFilter)
            {
                ref var doorButtonComponent = ref doorButtonPool.Get(doorButtonEntity);
                ref var doorButtonPositionComponent = ref doorButtonPositionPool.Get(doorButtonEntity);

                int pressCount = 0;
                foreach (var playerEntity in playerFilter)
                {
                    ref var playerPositionComponent = ref playerPositionPool.Get(playerEntity);

                    if (Vector3.Distance(doorButtonPositionComponent.value, playerPositionComponent.value) < doorButtonComponent.radius)
                    {
                        pressCount++;
                    }
                }

                doorButtonComponent.pressed = pressCount > 0;
            }
        }
    }
}