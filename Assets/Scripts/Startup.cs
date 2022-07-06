using EcsLiteTest.Logic;
using EcsLiteTest.View;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace EcsLiteTest
{
    public class Startup : MonoBehaviour
    {
        private EcsWorld ecsWorld;
        private EcsSystems initSystems;
        private EcsSystems updateSystems;

        private void Start()
        {
            ecsWorld = new EcsWorld();

            var viewsCache = new ViewsCache();
            var worldTime = new WorldTime();

            initSystems = new EcsSystems(ecsWorld)
                .Add(new DoorInitSystem())
                .Add(new PlayerInitSystem())
                .Inject(viewsCache);
            initSystems.Init();

            updateSystems = new EcsSystems(ecsWorld)
                .Add(new WorldTimeSystem())
                .Add(new PlayerInputSystem())
                .Add(new PlayerUpdateSystem())
                .Add(new DoorUpdateSystem())
                .Add(new DoorButtonUpdateSystem())
                .Add(new PlayerMoveSystem())
                .Add(new DoorButtonSystem())
                .Add(new DoorSystem())
                .Inject(worldTime)
                .Inject(viewsCache);
            updateSystems.Init();
        }

        private void Update()
        {
            updateSystems.Run();
        }

        private void OnDestroy()
        {
            initSystems.Destroy();
            updateSystems.Destroy();
            ecsWorld.Destroy();
        }
    }
}