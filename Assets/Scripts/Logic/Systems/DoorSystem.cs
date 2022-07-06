using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsLiteTest.Logic
{
    public class DoorSystem : IEcsRunSystem
    {
        private readonly EcsCustomInject<WorldTime> worldTime;

        public void Run(EcsSystems ecsSystems)
        {
            var doorButtonFilter = ecsSystems.GetWorld().Filter<DoorButtonComponent>().End();
            var doorButtonPool = ecsSystems.GetWorld().GetPool<DoorButtonComponent>();
            var doorPool = ecsSystems.GetWorld().GetPool<DoorComponent>();

            foreach (var doorButtonEntity in doorButtonFilter)
            {
                ref var doorButtonComponent = ref doorButtonPool.Get(doorButtonEntity);
                ref var doorComponent = ref doorPool.Get(doorButtonComponent.doorId);

                if (doorButtonComponent.pressed && doorComponent.openProgress < 1f)
                {
                    doorComponent.openProgress += doorComponent.openSpeed * worldTime.Value.deltaTime;

                    if (doorComponent.openProgress > 1f)
                        doorComponent.openProgress = 1f;
                }
            }
        }
    }
}