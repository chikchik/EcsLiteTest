using EcsLiteTest.Logic;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsLiteTest.View
{
    public class DoorUpdateSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<ViewsCache> viewsCache;

        public void Run(EcsSystems ecsSystems)
        {
            var doorFilter = ecsSystems.GetWorld()
                .Filter<DoorComponent>().End();
            var doorPool = ecsSystems.GetWorld().GetPool<DoorComponent>();

            foreach (var doorEntity in doorFilter)
            {
                ref var doorComponent = ref doorPool.Get(doorEntity);
                var doorView = viewsCache.Value.Doors[doorEntity];
                doorView.OpenProgress = doorComponent.openProgress;
            }
        }
    }
}