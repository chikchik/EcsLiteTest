using EcsLiteTest.Logic;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsLiteTest.View
{
    public class DoorInitSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<ViewsCache> viewsCache;

        public void Init(EcsSystems ecsSystems)
        {
            var ecsWorld = ecsSystems.GetWorld();

            var doorViews = Object.FindObjectsOfType<DoorView>();
            foreach (var doorView in doorViews)
            {
                var doorEntity = ecsWorld.NewEntity();
                var doorPool = ecsWorld.GetPool<DoorComponent>();
                ref var doorComponent = ref doorPool.Add(doorEntity);
                doorComponent.openSpeed = doorView.openSpeed;

                var doorButtonEntity = ecsWorld.NewEntity();
                var doorButtonPool = ecsWorld.GetPool<DoorButtonComponent>();
                var positionPool = ecsWorld.GetPool<PositionComponent>();

                ref var doorButtonPositionComponent = ref positionPool.Add(doorButtonEntity);
                doorButtonPositionComponent.value = doorView.button.transform.position;

                ref var doorButtonComponent = ref doorButtonPool.Add(doorButtonEntity);
                doorButtonComponent.doorId = doorEntity;
                doorButtonComponent.radius = doorView.button.GetComponentInChildren<Renderer>().bounds.size.x * 0.5f;

                viewsCache.Value.Doors.Add(doorEntity, doorView);
                viewsCache.Value.DoorButtons.Add(doorButtonEntity, doorView.button);
            }
        }
    }
}