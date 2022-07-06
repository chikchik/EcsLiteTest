using EcsLiteTest.Logic;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsLiteTest.View
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<ViewsCache> viewsCache;

        public void Init(EcsSystems ecsSystems)
        {
            var ecsWorld = ecsSystems.GetWorld();

            var playerViews = Object.FindObjectsOfType<PlayerView>();
            foreach (var playerView in playerViews)
            {
                var playerEntity = ecsWorld.NewEntity();
                var playerPool = ecsWorld.GetPool<PlayerComponent>();
                var playerPositionPool = ecsWorld.GetPool<PositionComponent>();

                ref var playerComponent = ref playerPool.Add(playerEntity);
                playerComponent.moveSpeed = playerView.moveSpeed;

                ref var playerPosition = ref playerPositionPool.Add(playerEntity);
                playerPosition.value = playerView.transform.position;

                viewsCache.Value.Players.Add(playerEntity, playerView);
            }
        }
    }
}