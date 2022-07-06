using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Vector3 = UnityEngine.Vector3;

namespace EcsLiteTest.Logic
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<WorldTime> worldTime;

        public void Run(EcsSystems ecsSystems)
        {
            var playerFilter = ecsSystems.GetWorld()
                .Filter<PlayerComponent>()
                .Inc<PositionComponent>().End();
            var playerPool = ecsSystems.GetWorld().GetPool<PlayerComponent>();
            var playerPositionPool = ecsSystems.GetWorld().GetPool<PositionComponent>();
            var playerMoveDestinationPool = ecsSystems.GetWorld().GetPool<PlayerMoveDestinationComponent>();

            foreach (var playerEntity in playerFilter)
            {
                if (playerMoveDestinationPool.Has(playerEntity))
                {
                    ref var playerComponent = ref playerPool.Get(playerEntity);
                    ref var playerPositionComponent = ref playerPositionPool.Get(playerEntity);

                    ref var playerMoveDestinationComponent = ref playerMoveDestinationPool.Get(playerEntity);
                    playerPositionComponent.value = Vector3.MoveTowards(playerPositionComponent.value, playerMoveDestinationComponent.value, playerComponent.moveSpeed * worldTime.Value.deltaTime);

                    if (playerPositionComponent.value == playerMoveDestinationComponent.value)
                    {
                        playerMoveDestinationPool.Del(playerEntity);
                    }
                }
            }
        }
    }
}