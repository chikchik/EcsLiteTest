using EcsLiteTest.Logic;
using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLiteTest.View
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        public void Run(EcsSystems ecsSystems)
        {
            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var raycastHit))
                {
                    if (raycastHit.collider != null && raycastHit.collider.gameObject.tag == "Ground")
                    {
                        SetDestination(ecsSystems, raycastHit.point);
                    }
                }
            }
        }

        private void SetDestination(EcsSystems ecsSystems, Vector3 destination)
        {
            var playerFilter = ecsSystems.GetWorld()
                .Filter<PlayerComponent>().End();
            var playerMoveDestinationPool = ecsSystems.GetWorld().GetPool<PlayerMoveDestinationComponent>();

            foreach (var playerEntity in playerFilter)
            {
                if (playerMoveDestinationPool.Has(playerEntity))
                {
                    ref var playerMoveDestinationComponent = ref playerMoveDestinationPool.Get(playerEntity);
                    playerMoveDestinationComponent.value = destination;
                }
                else
                {
                    ref var playerMoveDestinationComponent = ref playerMoveDestinationPool.Add(playerEntity);
                    playerMoveDestinationComponent.value = destination;
                }
            }
        }
    }
}