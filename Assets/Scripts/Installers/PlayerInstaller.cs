using Items.Abstract;
using Player;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private ArmControllerConfig _armConfig;
    [SerializeField] private Inventory _inventory;

    private PlayerInput _input;
    public override void InstallBindings()
    {
        _input = new PlayerInput();
        Container.Bind<PlayerInput>()
            .FromInstance(_input)
            .AsSingle()
            .NonLazy();
        Container.Bind<PlayerConfig>()
            .FromInstance(_config)
            .AsSingle()
            .NonLazy();
        Container.Bind<Inventory>()
            .FromInstance(_inventory)
            .AsSingle()
            .NonLazy();
        Container.Bind<ArmControllerConfig>().FromInstance(_armConfig).AsSingle().NonLazy();
    }
}