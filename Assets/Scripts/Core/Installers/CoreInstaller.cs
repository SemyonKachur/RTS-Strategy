﻿namespace Core.Installers
{
    using Core.Time;
    using Zenject;

    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
        }
    }
}