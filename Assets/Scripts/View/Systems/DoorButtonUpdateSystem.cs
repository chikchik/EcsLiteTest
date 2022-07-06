using EcsLiteTest.Logic;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsLiteTest.View
{
    public class DoorButtonUpdateSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<ViewsCache> viewsCache;

        public void Run(EcsSystems ecsSystems)
        {
            var doorButtonFilter = ecsSystems.GetWorld()
                .Filter<DoorButtonComponent>().End();
            var doorButtonPool = ecsSystems.GetWorld().GetPool<DoorButtonComponent>();

            foreach (var doorButtonEntity in doorButtonFilter)
            {
                ref var doorButtonComponent = ref doorButtonPool.Get(doorButtonEntity);
                var doorButtonView = viewsCache.Value.DoorButtons[doorButtonEntity];
                doorButtonView.Pressed = doorButtonComponent.pressed;
            }
        }
    }
}