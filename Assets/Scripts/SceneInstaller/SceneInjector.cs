using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneInjector : MonoInstaller
{
    public override void InstallBindings()
    {
        
        Container.Bind<_ImergeService>().To<MergeService>().AsSingle();
        Container.Bind<IAddService>().To<AddService>().AsSingle();
    }
}