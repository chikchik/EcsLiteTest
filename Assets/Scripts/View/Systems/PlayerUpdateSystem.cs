using EcsLiteTest.Logic;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsLiteTest.View
{
    public class PlayerUpdateSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<ViewsCache> viewsCache;
        private readonly EcsCustomInject<WorldTime> worldTime;

        private Vector3 velocity;

        public void Run(EcsSystems ecsSystems)
        {
            var playerFilter = ecsSystems.GetWorld()
                .Filter<PlayerComponent>()
                .Inc<PositionComponent>().End();
            var positionPool = ecsSystems.GetWorld().GetPool<PositionComponent>();

            foreach (var playerEntity in playerFilter)
            {
                ref var positionComponent = ref positionPool.Get(playerEntity);
                var playerView = viewsCache.Value.Players[playerEntity];
                playerView.transform.position = Vector3.SmoothDamp(playerView.transform.position, positionComponent.value, ref velocity, 0.1f, playerView.moveSpeed, worldTime.Value.deltaTime);
            }
        }
    }
}